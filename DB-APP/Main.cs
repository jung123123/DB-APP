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
using System.Data.SqlClient;

namespace DB_APP
{
    public partial class Main : Form
    {


        private MySqlConnection connection;

        private string db = "server=127.0.0.1;port=3306;database=food;uid=root;password=root1234!;charset=utf8mb4;";

        public Main()
        {
           
            InitializeComponent();
            guestSelect();      //guest 테이블 select

          
        }


        private void guestSelect()      //guest 테이블 select
        {
            using (connection = new MySqlConnection(db))
            {
                connection.Open();

                string query = "SELECT * FROM guest;";

                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataReader reader = command.ExecuteReader();

                listBox1.Items.Clear();
                while (reader.Read())
                {
                    string value1 = reader.GetString(0);  // 첫 번째 열 데이터
                    string value2 = reader.GetString(1);  // 두 번째 열 데이터

                    string output = value1 + "번 , " + value2;  // 출력

                    listBox1.Items.Add(output);
                }

                reader.Close();
            }
        }

        private void btnNumer_Click(object sender, EventArgs e)
        {

            Guest guestForm = new Guest();  // GuestForm 인스턴스 생성
            guestForm.StartPosition = FormStartPosition.Manual;  // 폼의 위치를 수동으로 설정
            guestForm.Location = Location;  // 현재 Main 폼의 위치를 GuestForm의 위치로 설정
            guestForm.Show();  // GuestForm을 보여줍니다.
            Hide();  // 현재 Main 폼을 숨깁니다.

        }

        private void 관리자GToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Admin admingForm = new Admin();
            admingForm.StartPosition = FormStartPosition.Manual;  // 폼의 위치를 수동으로 설정
            admingForm.Location = Location;
            admingForm.Show();
           
        }

        private void 종료XToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Main form = Application.OpenForms.OfType<Main>().FirstOrDefault();
            form?.Close();
            Close();
            Application.Exit();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            this.Text = "키오스크";
        }
    }
}
