using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace DB_APP
{
    public partial class Menu : Form
    {

        private string db = "server=127.0.0.1;port=3306;database=food;uid=root;password=root1234!;charset=utf8mb4;";
        private MySqlConnection connection;

        private string selectedFeature;     //feature 화면 에서 받아온 데이터     featureName
        private string guestNumber;         //feature 화면 에서 받아온 데이터     guestNumber


        public Menu(string feature, string guestNumber)
        {
            InitializeComponent();
            selectedFeature = GetFeatureNumber(feature);    //featureName 으로 featurenumber 찾기
            this.guestNumber = guestNumber;
            MenuSelect();       //Menu 테이블 select
        }

        private void Menu_FormClosing(object sender, FormClosingEventArgs e)
        {
            Main form = Application.OpenForms.OfType<Main>().FirstOrDefault();
            form?.Close();

            Application.Exit();
        }

        private string GetFeatureNumber(string feature) //featureName 으로 featurenumber 찾기
        {
            using (connection = new MySqlConnection(db))
            {
                connection.Open();

                string query = "SELECT feature_number FROM feature WHERE feature_name = @feature;";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@feature", feature);

                string featureNumber = command.ExecuteScalar()?.ToString();
                return featureNumber;
            }
        }

        private void MenuSelect()       //Menu 테이블 select
        {
            using (connection = new MySqlConnection(db))
            {
                connection.Open();

                string query = "SELECT * FROM menu WHERE feature_number = @feature;";
                

                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@feature", selectedFeature);

                MySqlDataReader reader = command.ExecuteReader();

                listBox1.Items.Clear();
                while (reader.Read())
                {

                    string menuPrice = reader.GetString("menu_price");  // "menu_price" 열의 데이터 가져오기
                    string menuName = reader.GetString("menu_name");// "menu_name" 열의 데이터 가져오기


                    string output = "메뉴 이름:" + menuName + ", 가격:" + menuPrice ;  //  출력

                    listBox1.Items.Add(output);
                }

                reader.Close();
            }
        }

        private void btnFeature_Click(object sender, EventArgs e)       //뒤로가기 버튼 클릭시 orderr 테이블 데이터 삭제 후 Feature 화면으로 이동
        {
            using (connection = new MySqlConnection(db))
            {
                connection.Open();

                string query = "DELETE FROM orderr;";
                MySqlCommand command = new MySqlCommand(query, connection);

                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    //MessageBox.Show("orderr 테이블의 데이터가 성공적으로 삭제되었습니다.");
                }
                else
                {
                    MessageBox.Show("데이터 삭제에 실패했습니다.");
                }
            }
                
            Feature featureForm = new Feature(guestNumber);     //Feature 화면으로 guestNumber 데이터 전달
            featureForm.StartPosition = FormStartPosition.Manual;  // 폼의 위치를 수동으로 설정
            featureForm.Location = Location;
            featureForm.Show();
            Hide();



        }

        private void btnPut_Click(object sender, EventArgs e)       //담기 버튼 클릭시 orderr 테이블에 INSERT 후 Orderr 화면으로 이동
        {
            if (listBox1.SelectedIndex != -1)
            {
                string selectedMenu = listBox1.SelectedItem.ToString();
                string menuNumber = GetMenuNumber(selectedMenu);

                if (menuNumber != null)
                {
                    using (connection = new MySqlConnection(db))
                    {
                        connection.Open();

                        string query = "INSERT INTO orderr (guest_number, menu_number, order_quantity) VALUES (@guestNumber, @menuNumber, 1);";

                        MySqlCommand command = new MySqlCommand(query, connection);
                        command.Parameters.AddWithValue("@guestNumber", guestNumber);
                        command.Parameters.AddWithValue("@menuNumber", menuNumber);

                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            //MessageBox.Show("데이터가 성공적으로 삽입되었습니다.");
                            Orderr orderrForm = new Orderr(selectedFeature, guestNumber, menuNumber);       // Orderr 화면으로Featurenumber, guestNumber,menuNumber 전달
                            orderrForm.StartPosition = FormStartPosition.Manual;  // 폼의 위치를 수동으로 설정
                            orderrForm.Location = Location;
                            orderrForm.Show();
                            Hide();


                        }
                        else
                        {
                            MessageBox.Show("데이터 삽입에 실패했습니다.");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("메뉴 번호를 가져오는데 실패했습니다.");
                }
            }
            else
            {
                MessageBox.Show("메뉴를 선택해주세요.");
            }
        }

        private string GetMenuNumber(string selectedMenu)   //menu_name, menu_price,feature_number 이용해 menu 테이블의 menu_number 구하기
        {
            using (connection = new MySqlConnection(db))
            {
                connection.Open();

                string query = "SELECT menu_number FROM menu WHERE menu_name = @menuName AND menu_price = @menuPrice AND feature_number = @featureNumber;";
                MySqlCommand command = new MySqlCommand(query, connection);

                // "메뉴 이름:"과 ", 가격:" 부분을 제거한 후 매개변수에 전달
                
                string[] menuParts = selectedMenu.Split(new string[] { ", 가격:" }, StringSplitOptions.None);
                string menuName = menuParts[0].Replace("메뉴 이름:", "").Trim();
                string menuPrice = menuParts[1].Trim();

                command.Parameters.AddWithValue("@menuName", menuName); // 선택한 메뉴의 이름만 추출하여 매개변수에 전달
                command.Parameters.AddWithValue("@menuPrice", menuPrice); // 선택한 메뉴의 가격만 추출하여 매개변수에 전달
                command.Parameters.AddWithValue("@featureNumber", selectedFeature); // @selectedFeature 매개변수 추가

                

                object result = command.ExecuteScalar();
                Console.WriteLine("menuNumber >>>>>>>>>>>>>>>>>" + result);
                if (result != null)
                {
                    string menuNumber = result.ToString();
                    return menuNumber;
                }
                else
                {
                    return null;

                }
            }
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            this.Text = "키오스크";
        }
    }
}
