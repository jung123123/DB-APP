using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace DB_APP
{
    public partial class Feature : Form
    {

        private string db = "server=127.0.0.1;port=3306;database=food;uid=root;password=root1234!;charset=utf8mb4;";
        private MySqlConnection connection;
        private string guestNumber;

        public Feature(string number)
        {
            InitializeComponent();
            guestNumber = number;   //guest 화면에서 받아온 데이터(guestNumber)
            FeatureSelect();    //Feature 테이블 Select
        }

        private void FeatureSelect()
        {
            using (connection = new MySqlConnection(db))
            {
                connection.Open();

                string query = "SELECT * FROM feature;";
               

                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataReader reader = command.ExecuteReader();

                listBox1.Items.Clear();
                while (reader.Read())
                {
                    //string value1 = reader.GetString(0);  // 첫 번째 열 데이터
                    string value2 = reader.GetString("feature_name");  // 두 번째 열 데이터

                    //string output = value1 + "번 , " + value2;  // 두 개의 데이터를 결합하여 출력

                    //listBox1.Items.Add(output);
                    listBox1.Items.Add(value2);
                }

                reader.Close();
            }
        }


        private void Feature_FormClosing(object sender, FormClosingEventArgs e)
        {
            Main form = Application.OpenForms.OfType<Main>().FirstOrDefault();
            form?.Close();

            Application.Exit();
        }

        private void btnMove_Click(object sender, EventArgs e)  //이동 버튼 클릭 시 
        {
            string selectedValue = listBox1.SelectedItem?.ToString();       //리스트박스에서 선택

            if (string.IsNullOrEmpty(selectedValue))            
            {
                MessageBox.Show("코너를 선택해주세요.");
                return;
            }

            // Feature 폼에서 선택한 값(selectedValue)과 guestNumber를 Menu 폼으로 전달
            Menu menuForm = new Menu(selectedValue, guestNumber);      // Menu 화면으로  selectedValue(featurname), guestNumber값을 전달
            menuForm.StartPosition = FormStartPosition.Manual;  // 폼의 위치를 수동으로 설정
            menuForm.Location = Location;
            menuForm.Show();
            Hide();
        }

        private void btnGuest_Click(object sender, EventArgs e) //뒤로가기 버튼 
        {
            Guest guestForm = new Guest();          // Guest화면으로 이동
            guestForm.StartPosition = FormStartPosition.Manual;  // 폼의 위치를 수동으로 설정
            guestForm.Location = Location;
            guestForm.Show();                       //Guest화면 띄우기 
            Hide();
        }

        private void Feature_Load(object sender, EventArgs e)
        {
            this.Text = "키오스크";
        }
    }
}
