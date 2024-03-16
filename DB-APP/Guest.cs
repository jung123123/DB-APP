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
    public partial class Guest : Form
    {

        private string db = "server=127.0.0.1;port=3306;database=food;uid=root;password=root1234!;charset=utf8mb4;";
        private MySqlConnection connection;

        public Guest()
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
                    string value1 = reader.GetString("guest_number");  // 첫 번째 열 데이터
                    string value2 = reader.GetString("guest_name");  // 두 번째 열 데이터

                    string output = value1 + "번 , " + value2;  // 출력

                    listBox1.Items.Add(output);
                }

                reader.Close();
            }
        }

        private void Guest_Load(object sender, EventArgs e)
        {
            this.Text = "키오스크";
        }

        private void guestNumber_Click(object sender, EventArgs e)      //txtbox에 내용(guestName) 추가 후 버튼 클릭 시(guestNumber_Click 실행 시)  guest 테이블 INSERT
        {
            string guestName = txtName.Text;

            if (string.IsNullOrWhiteSpace(guestName))
            {
                return;
            }

            using (connection = new MySqlConnection(db))
            {
                connection.Open();

                string query = "INSERT INTO guest (guest_name) VALUES (@guestName);";
                

                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@guestName", guestName);

                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    //MessageBox.Show("데이터가 성공적으로 삽입되었습니다.");
                    guestSelect(); //guest 테이블 select
                }
                else
                {
                    MessageBox.Show("데이터 삽입에 실패했습니다.");
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)    //ListBox에서 선택 후 버튼 클릭시(btnDelete_Click 실행 후) guest 테이블 delete
        {
            // ListBox에서 선택된 아이템 확인
            if (listBox1.SelectedIndex != -1)
            {
                string selectedValue = listBox1.SelectedItem.ToString();

                // 선택된 아이템에서 번호 추출
                string[] parts = selectedValue.Split('번');
                if (parts.Length > 0)
                {
                    string number = parts[0].Trim();

                    // Delete 쿼리 실행
                    using (connection = new MySqlConnection(db))
                    {
                        connection.Open();

                        string query = "DELETE FROM guest WHERE guest_number = @guestNumber;";
                        

                        MySqlCommand command = new MySqlCommand(query, connection);
                        command.Parameters.AddWithValue("@guestNumber", number);

                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            //MessageBox.Show("데이터가 성공적으로 삭제되었습니다.");
                            guestSelect();  // 삭제 후 데이터를 다시 로드하여 리스트 업데이트
                        }
                        else
                        {
                            MessageBox.Show("데이터 삭제에 실패했습니다.");
                        }
                    }
                }
            }
        }

        private void btnMain_Click(object sender, EventArgs e)  //화면 이동 Main으로
        {
            Main mainForm = new Main(); 
            mainForm.StartPosition = FormStartPosition.Manual;  // 폼의 위치를 수동으로 설정
            mainForm.Location = Location;  
            mainForm.Show();
            Hide();  
        }

        private void Guest_FormClosing(object sender, FormClosingEventArgs e)
        {
            Main form = Application.OpenForms.OfType<Main>().FirstOrDefault();      
            form?.Close();

            Application.Exit();
        }

        private void btnMove_Click(object sender, EventArgs e)
        {
            // ListBox에서 선택된 아이템 확인
            if (listBox1.SelectedIndex != -1)
            {
                string selectedValue = listBox1.SelectedItem.ToString();

                // 선택된 아이템에서 번호 추출
                string[] parts = selectedValue.Split('번');
                if (parts.Length > 0)
                {
                    string number = parts[0].Trim();

                    // 이동할 폼 생성 및 설정
                    Feature featureForm = new Feature(number); //  Feature 화면에 guset_number 전달
                    featureForm.StartPosition = FormStartPosition.Manual;  // 폼의 위치를 수동으로 설정
                    featureForm.Location = Location;
                    featureForm.Show();
                    Hide();
                }
            }
        }
    }
}
