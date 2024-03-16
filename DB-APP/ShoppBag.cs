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
    public partial class ShoppBag : Form
    {
        private string db = "server=127.0.0.1;port=3306;database=food;uid=root;password=root1234!;charset=utf8mb4;";
        private MySqlConnection connection;

        private string featureNumber;
        private string guestNumber;
        private string menuNumber;

        private List<int> sums = new List<int>();  // sum 값을 저장할 리스트


        public ShoppBag(string feature, string guestNumber, string menuNumber)
        {
            InitializeComponent();

            this.featureNumber = feature;   // 받아온 featureNumber 값
            this.guestNumber = guestNumber; // 받아온 guestNumber 값
            this.menuNumber = menuNumber;   // 받아온 menuNumber 값
            ShoppBagSelect();   //ShoppBag 테이블 Select

        }

        private void ShoppBagSelect()   //ShoppBag 테이블 Select
        {
            using (connection = new MySqlConnection(db))
            {
                connection.Open();

                string query = "SELECT shoppbag.menu_number, menu.menu_name, menu.menu_price, shoppbag.order_number , orderr.order_quantity, sum " +
                       "FROM shoppbag " +
                       "JOIN menu ON shoppbag.menu_number = menu.menu_number " +
                       "JOIN orderr ON shoppbag.order_number = orderr.order_number " +
                       "WHERE shoppbag.guest_number = @guestNumber;";


                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@guestNumber", guestNumber);

                MySqlDataReader reader = command.ExecuteReader();

                listBox1.Items.Clear();
                while (reader.Read())
                {

                    string menuPriceStr = reader.GetString("menu_price");  // "menu_price" 열의 데이터 가져오기
                    string menuName = reader.GetString("menu_name");// "menu_name" 열의 데이터 가져오기
                    string orderQuantityStr = reader.GetString("order_quantity");   // "order_quantity" 열의 데이터 가져오기
                    int menuPrice = Int32.Parse(menuPriceStr);      //가격
                    int orderQuantity = Int32.Parse(orderQuantityStr);  // 수량

                    int sum = menuPrice * orderQuantity;        // 가격 * 수량
                    sums.Add(sum);  // sum 값을 리스트에 추가

                    string output = "메뉴 이름:" + menuName + ", 가격:" + menuPrice + ", 수량:" + orderQuantity + "총 합 가격:" + sum;  // 출력

                    listBox1.Items.Add(output);
                }
                    
                reader.Close();
            }
        }


        private void ShoppBag_FormClosing(object sender, FormClosingEventArgs e)
        {
            Main form = Application.OpenForms.OfType<Main>().FirstOrDefault();
            form?.Close();

            Application.Exit();
        }

        private void btnOrder_Click(object sender, EventArgs e) //뒤로가기 버튼 클릭 시  shoppbag 테이블 delete
        {
            shoppbagdelete();   // shoppbag 테이블 delete


            Orderr orderrForm = new Orderr(featureNumber, guestNumber, menuNumber); // orderr 화면에 다시 featureNumber guestNumber menuNumber 데이터 전달
            orderrForm.StartPosition = FormStartPosition.Manual;  // 폼의 위치를 수동으로 설정
            orderrForm.Location = Location;
            orderrForm.Show();
            Hide();
        }

        private void shoppbagdelete()       // shoppbag 테이블 delete
        {
            using (connection = new MySqlConnection(db))
            {
                connection.Open();

                string query = "DELETE FROM shoppbag;";
                MySqlCommand command = new MySqlCommand(query, connection);

                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                   // MessageBox.Show("shoppbag 테이블의 데이터가 성공적으로 삭제되었습니다.");
                }
                else
                {
                    MessageBox.Show("데이터 삭제에 실패했습니다.");
                }
            }
        }

        private void orderrdelete()// orderr 테이블 delete
        {
            using (connection = new MySqlConnection(db))
            {
                connection.Open();

                string query = "DELETE FROM orderr;";
                MySqlCommand command = new MySqlCommand(query, connection);

                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                   // MessageBox.Show("orderr 테이블의 데이터가 성공적으로 삭제되었습니다.");
                }
                else
                {
                    MessageBox.Show("데이터 삭제에 실패했습니다.");
                }
            }
        }

        private void guestdelete()// guest 테이블 delete // guest_number 만
        {
            using (connection = new MySqlConnection(db))
            {
                connection.Open();

                string query = "DELETE FROM guest where guest_number = @guestNumber;";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@guestNumber", guestNumber);

                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    //MessageBox.Show("guest 테이블의 데이터가 성공적으로 삭제되었습니다.");
                }
                else
                {
                    MessageBox.Show("데이터 삭제에 실패했습니다.");
                }
            }
        }




        private void btnMain_Click(object sender, EventArgs e)  // 결제하기 버튼 클릭 시 
        {

            int totalSum = sums.Sum();  // sums 리스트의 모든 값을 합산

            MessageBox.Show("전체 총 합 가격: " + totalSum + "\n" + "구매 해주셔서 감사 합니다.");       //총 결제 액 띄우기

            shoppbagdelete();// shoppbag 테이블 delete
            orderrdelete();// orderr 테이블 delete
            guestdelete();// guest 테이블 delete // guest_number 만

            Main MainForm = new Main();// 메인 화면 
            MainForm.StartPosition = FormStartPosition.Manual;  // 폼의 위치를 수동으로 설정
            MainForm.Location = Location;
            Hide();
            MainForm.Show();// 메인 화면 띄우기 
            
        }

        private void ShoppBag_Load(object sender, EventArgs e)
        {
            this.Text = "키오스크";
        }
    }
}
