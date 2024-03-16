using Google.Protobuf.WellKnownTypes;
using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace DB_APP
{
    public partial class Admin : Form
    {

        private MySqlConnection connection;

        private string db = "server=127.0.0.1;port=3306;database=food;uid=root;password=root1234!;charset=utf8mb4;";


        public Admin()
        {
            InitializeComponent();
            selectfeature();    //feature 테이블 select
            selectmenu();       //menu 테이블 select
        }

        private void selectfeature()        //feature 테이블 select
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
                    string value1 = reader.GetString("feature_number");  // feature_number
                    string value2 = reader.GetString("feature_name");  // feature_name

                    string output = value1 + "번 : " + value2;  //출력

                    listBox1.Items.Add(output);
                }

                reader.Close();
            }
        }


        private void selectmenu()       //menu 테이블 select
        {
            using (connection = new MySqlConnection(db))
            {
                connection.Open();

                string query = "SELECT * FROM menu;";

                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataReader reader = command.ExecuteReader();

                listBox2.Items.Clear();
                while (reader.Read())
                {
                    string value1 = reader.GetString("menu_number");  //menu_number 
                    string value2 = reader.GetString("menu_name");  //menu_name
                    string value3 = reader.GetString("menu_price");  //menu_price
                    string value4 = reader.GetString("feature_number");  //feature_number

                    string output = value1 + " 번  메뉴 :" + value2 + ", 가격 :" + value3 + ", 코너 번호 :" + value4;  //출력

                    listBox2.Items.Add(output);
                }

                reader.Close();
            }
        }




        private void Admin_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }


        private void truncatefeatrue()      // TRUNCATE TABLE feature;
        {
            using (connection = new MySqlConnection(db))
            {
                connection.Open();

                // 외래 키 제약 조건 해제
                string dropForeignKeyQuery = "ALTER TABLE menu DROP FOREIGN KEY FK3nes0805wo6nypebsgo8q4tgr;";
                MySqlCommand dropForeignKeyCommand = new MySqlCommand(dropForeignKeyQuery, connection);
                dropForeignKeyCommand.ExecuteNonQuery();

                // feature 테이블 비우기
                string truncateFeatureQuery = "TRUNCATE TABLE feature;";
                MySqlCommand truncateFeatureCommand = new MySqlCommand(truncateFeatureQuery, connection);
                truncateFeatureCommand.ExecuteNonQuery();

                // 외래 키 제약 조건 재설정
                string addForeignKeyQuery = "ALTER TABLE menu ADD CONSTRAINT FK3nes0805wo6nypebsgo8q4tgr " +
                                             "FOREIGN KEY (feature_number) REFERENCES feature(feature_number);";
                MySqlCommand addForeignKeyCommand = new MySqlCommand(addForeignKeyQuery, connection);
                addForeignKeyCommand.ExecuteNonQuery();

                //MessageBox.Show("외래 키 제약 조건이 성공적으로 해제되었다가 재설정되었습니다.");
            }
        }

        private void truncatemenu() //TRUNCATE TABLE menu
        {
            using (connection = new MySqlConnection(db))
            {
                connection.Open();

                // 외래 키 제약 조건 해제
                string dropForeignKeyQuery = "ALTER TABLE `orderr` DROP FOREIGN KEY FK2mcna2cuomtjnar6t8j9i6bad;";
                MySqlCommand dropForeignKeyCommand = new MySqlCommand(dropForeignKeyQuery, connection);
                dropForeignKeyCommand.ExecuteNonQuery();

                string dropForeignKeyQuery2 = "ALTER TABLE `shoppbag` DROP FOREIGN KEY FK8b91n0461j82cjian3hu8eath;";
                MySqlCommand dropForeignKeyCommand2 = new MySqlCommand(dropForeignKeyQuery2, connection);
                dropForeignKeyCommand2.ExecuteNonQuery();

                // menu 테이블 비우기, shoppbag 테이블 비우기
                string truncateMenuQuery = "TRUNCATE TABLE menu;";
                MySqlCommand truncateMenuCommand = new MySqlCommand(truncateMenuQuery, connection);
                truncateMenuCommand.ExecuteNonQuery();

                string truncateShoppbagQuery = "TRUNCATE TABLE shoppbag;";
                MySqlCommand truncateShoppbagCommand = new MySqlCommand(truncateShoppbagQuery, connection);
                truncateShoppbagCommand.ExecuteNonQuery();

                // 외래 키 제약 조건 재설정
                string addForeignKeyQuery = "ALTER TABLE `orderr` ADD CONSTRAINT FK2mcna2cuomtjnar6t8j9i6bad " +
                    "FOREIGN KEY (menu_number) REFERENCES menu(menu_number);";
                MySqlCommand addForeignKeyCommand = new MySqlCommand(addForeignKeyQuery, connection);
                addForeignKeyCommand.ExecuteNonQuery();

                string addForeignKeyQuery2 = "ALTER TABLE `shoppbag` ADD CONSTRAINT FK8b91n0461j82cjian3hu8eath " +
                    "FOREIGN KEY (menu_number) REFERENCES menu(menu_number);";
                MySqlCommand addForeignKeyCommand2 = new MySqlCommand(addForeignKeyQuery2, connection);
                addForeignKeyCommand2.ExecuteNonQuery();

               // MessageBox.Show("외래 키 제약 조건이 성공적으로 해제되었다가 재설정되었습니다.");
            }
        }


        private void deleteorderr()     //TRUNCATE TABLE menu 을 위해 외래키가 있는 orderr 데이터 전부 삭제
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
                    //MessageBox.Show("데이터 삭제에 실패했습니다.");
                }
            }

        }


        private void btnReset_Click(object sender, EventArgs e)     //기본 값 추가
        {
            deleteorderr(); //DELETE FROM orderr
            truncatemenu();  //TRUNCATE TABLE menu
            truncatefeatrue();   //TRUNCATE TABLE featrue



            List<string> listfeatrue = new List<string>();      // featrue 기본 값 담는 리스트
            List<string> listmenu = new List<string>();          // menu 기본 값 담는 리스트


            listfeatrue.Add("한식");
            listfeatrue.Add("중식");
            listfeatrue.Add("분식");

            listmenu.Add("비빔밥 4000 1");
            listmenu.Add("불고기 6000 1");
            listmenu.Add("김치찌개 4500 1");
            listmenu.Add("자장면 4000 2");
            listmenu.Add("짬뽕 4500 2");
            listmenu.Add("탕수육 7000 2");
            listmenu.Add("떡볶이 3000 3");
            listmenu.Add("순대 3500 3");
            listmenu.Add("튀김 2500 3");






            // feature 삽입       
            if (listfeatrue.Count > 0)
            {
                StringBuilder featrueValues = new StringBuilder();
                for (int i = 0; i < listfeatrue.Count; i++)
                {
                    featrueValues.Append("('" + listfeatrue[i] + "')");
                    if (i < listfeatrue.Count - 1)
                        featrueValues.Append(",");
                }

                using (connection = new MySqlConnection(db))
                {
                    connection.Open();

                    string query = "INSERT INTO feature (feature_name) VALUES " + featrueValues + ";";
                    MySqlCommand command = new MySqlCommand(query, connection);

                    try
                    {
                        command.ExecuteNonQuery();
                       // MessageBox.Show("데이터가 성공적으로 삽입되었습니다.");
                        selectfeature();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("데이터 삽입에 실패했습니다: " + ex.Message);
                    }
                }
            }


            // menu 삽입
            if (listmenu.Count > 0)
            {
                StringBuilder menuValues = new StringBuilder();
                for (int i = 0; i < listmenu.Count; i++)
                {
                    string[] menuInfo = listmenu[i].Split(' '); // 공백을 기준으로 문자열을 분리
                    if (menuInfo.Length >= 3)
                    {
                        string menuName = menuInfo[0];
                        string menuPrice = menuInfo[1];
                        string featureNumber = menuInfo[2];

                        menuValues.Append("('" + menuName + "', '" + menuPrice + "', '" + featureNumber + "')");
                        if (i < listmenu.Count - 1)
                            menuValues.Append(",");
                    }
                }

                using (connection = new MySqlConnection(db))
                {
                    connection.Open();

                    string query = "INSERT INTO menu (menu_name, menu_price, feature_number) VALUES " + menuValues + ";";
                    MySqlCommand command = new MySqlCommand(query, connection);

                    try
                    {
                        command.ExecuteNonQuery();
                       // MessageBox.Show("데이터가 성공적으로 삽입되었습니다.");
                        selectmenu();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("데이터 삽입에 실패했습니다: " + ex.Message);
                    }
                }
            }



        }

        private void btnFpost_Click(object sender, EventArgs e)
        {
            insertfeature();
        }

        private void insertfeature()    //txtFname 에 적힌 값을 feature 테이블 에 추가
        {

            string featureName = txtFname.Text.Trim(); // featureName (공백 제외)

            if (string.IsNullOrWhiteSpace(featureName))
            {
                MessageBox.Show("코너 이름을 입력해주세요.");
                return;
            }

            using (connection = new MySqlConnection(db))
            {
                connection.Open();

                // INSERT 문장을 작성합니다.
                string query = "INSERT INTO feature (feature_name) VALUES (@featureName);";

                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@featureName", featureName);

                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    //MessageBox.Show("데이터가 성공적으로 삽입되었습니다.");
                    selectfeature(); // 삽입 후 특징 목록을 다시 조회하여 업데이트합니다.
                }
                else
                {
                    MessageBox.Show("데이터 삽입에 실패했습니다.");
                }
            }
        }


        private void insertmenu()   //txtMname, txtMprice, txtMfnumber 적힌 값을 menu 테이블에 추가
        {

            string menuName = txtMname.Text.Trim(); // menuName (공백 제외)
            string menuPrice = txtMprice.Text.Trim(); // menuPrice (공백 제외)
            string featureNumber = txtMfnumber.Text.Trim(); // featureNumber (공백 제외)

            if (string.IsNullOrWhiteSpace(menuName))
            {
                MessageBox.Show("메뉴 이름을 입력해주세요.");
                return;
            }
            else if (string.IsNullOrWhiteSpace(menuPrice))
            {
                MessageBox.Show("메뉴 가격을 입력해주세요.");
                return;
            }
        

            using (connection = new MySqlConnection(db))
            {
                connection.Open();

                // INSERT 문장을 작성합니다.
                string query = "INSERT INTO menu (menu_name, menu_price, feature_number) VALUES (@menuName, @menuPrice, @featureNumber);";

                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@menuName", menuName);
                command.Parameters.AddWithValue("@menuPrice", menuPrice);
                command.Parameters.AddWithValue("@featureNumber", featureNumber);

                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    //MessageBox.Show("데이터가 성공적으로 삽입되었습니다.");
                    selectmenu(); // 삽입 후 특징 목록을 다시 조회하여 업데이트합니다.
                }
                else
                {
                    MessageBox.Show("데이터 삽입에 실패했습니다.");
                }
            }
        }

        private void btnMpost_Click(object sender, EventArgs e)
        {
            insertmenu();   //txtMname, txtMprice, txtMfnumber 적힌 값을 menu 테이블에 추가
        }

        private void btnFdelete_Click(object sender, EventArgs e)
        {
            deletefeatrue();
        }
        private void deletefeatrue()    //(feature select)리스트 박스에서 선택된 줄 을 feature 테이블에서 삭제
        {
            // ListBox에서 선택된 아이템 확인
            if (listBox1.SelectedIndex != -1)
            {
                string selectedValue = listBox1.SelectedItem.ToString();

                // 선택된 아이템에서 번호 추출
                int indexOfColon = selectedValue.IndexOf(':');
                if (indexOfColon != -1)
                {
                    string featureNumber = selectedValue.Substring(0, indexOfColon).Trim();


                    // Delete 쿼리 실행
                    using (connection = new MySqlConnection(db))
                    {
                        connection.Open();

                        string query = "DELETE FROM feature WHERE feature_number = @featureNumber;";
                       

                        MySqlCommand command = new MySqlCommand(query, connection);
                        command.Parameters.AddWithValue("@featureNumber", featureNumber);

                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            //MessageBox.Show("데이터가 성공적으로 삭제되었습니다.");
                            selectfeature();  // 삭제 후 데이터를 다시 로드하여 리스트 업데이트
                        }
                        else
                        {
                            MessageBox.Show("데이터 삭제에 실패했습니다.");
                        }
                    }
                }
            }
        }
        private void deletemenu()        //(menu select)리스트 박스에서 선택된 줄 을 menu 테이블에서 삭제
        {

            // ListBox에서 선택된 아이템 확인
            if (listBox2.SelectedIndex != -1)
            {
                string selectedValue = listBox2.SelectedItem.ToString();

                // 선택된 아이템에서 번호 추출
                int indexOfColon = selectedValue.IndexOf('번');
                if (indexOfColon != -1)
                {
                    string menuNumber = selectedValue.Substring(0, indexOfColon).Trim();

                    // Delete 쿼리 실행
                    using (connection = new MySqlConnection(db))
                    {
                        connection.Open();

                        string query = "DELETE FROM menu WHERE menu_number = @menuNumber;";
                       

                        MySqlCommand command = new MySqlCommand(query, connection);
                        command.Parameters.AddWithValue("@menuNumber", menuNumber);

                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            //MessageBox.Show("데이터가 성공적으로 삭제되었습니다.");
                            selectmenu();  // 삭제 후 데이터를 다시 로드하여 리스트 업데이트
                        }
                        else
                        {
                            MessageBox.Show("데이터 삭제에 실패했습니다.");
                        }
                    }
                }
            }
        }

        private void btnMdelete_Click(object sender, EventArgs e)
        {
            deletemenu();       //(menu select)리스트 박스에서 선택된 줄 을 menu 테이블에서 삭제
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)      //리스트 박스 클릭시 textbox에 호출
        {
            if (listBox1.SelectedItem != null)
            {
                string selectedFeature = listBox1.SelectedItem.ToString();
                string[] featureData = selectedFeature.Split(':');
                

                if (featureData.Length == 2)
                {
                    string value1;
                    string value2 = featureData[1].Trim();

                    int colonIndex = selectedFeature.IndexOf(':');
                    value1 = selectedFeature.Substring(0, colonIndex).Trim();

                    // value2 값을 textbox에 표시
                    txtFname.Text = value2;
                }
            }
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)  //리스트 박스 클릭시 textbox에 호출
        {
            if (listBox2.SelectedItem != null)
            {
                string selectedItem = listBox2.SelectedItem.ToString();

                // 선택된 아이템의 데이터에서 필요한 정보 추출
                string[] data = selectedItem.Split(new string[] { ", " }, StringSplitOptions.None);
                string menuNumber = data[0].Split(':')[0].Trim();
                string menuName = data[0].Split(':')[1].Trim();
                string menuPrice = data[1].Split(':')[1].Trim();
                string featureNumber = data[2].Split(':')[1].Trim();

                // 추출한 정보를 각각의 textBox에 설정
                txtMname.Text = menuName;
                txtMprice.Text = menuPrice;
                txtMfnumber.Text = featureNumber;
            }
        }

        private void btnMupdate_Click(object sender, EventArgs e)       // listbox에서 호출된 내용을 기반으로 update(menu)
        {
            if (listBox2.SelectedItem != null)
            {
                string selectedItem = listBox2.SelectedItem.ToString();
                string[] data = selectedItem.Split(new string[] { ", " }, StringSplitOptions.None);
                string menuNumber = data[0].Split(':')[0].Trim();

                string menuName = txtMname.Text;
                string menuPrice = txtMprice.Text;
                string featureNumber = txtMfnumber.Text;


                using (connection = new MySqlConnection(db))
                {
                    try
                    {
                        connection.Open();

                        // 업데이트 쿼리 작성
                        string query = "UPDATE menu SET menu_name = @name, menu_price = @price, feature_number = @featureNumber WHERE menu_number = @menuNumber";
                        MySqlCommand command = new MySqlCommand(query, connection);
                        command.Parameters.AddWithValue("@name", menuName);
                        command.Parameters.AddWithValue("@price", menuPrice);
                        command.Parameters.AddWithValue("@featureNumber", featureNumber);
                        command.Parameters.AddWithValue("@menuNumber", menuNumber);

                        // 쿼리 실행
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            //MessageBox.Show("메뉴가 업데이트되었습니다.");
                            
                            selectmenu();
                        }
                        else
                        {
                            MessageBox.Show("메뉴 업데이트에 실패했습니다.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("오류가 발생했습니다: " + ex.Message);
                    }
          
                }
            }
        }

        private void btnFupdate_Click(object sender, EventArgs e)   // listbox에서 호출된 내용을 기반으로 update(feature)
        {
            if (listBox1.SelectedItem != null)
            {
                string selectedFeature = listBox1.SelectedItem.ToString();
                string[] featureData = selectedFeature.Split(':');

                if (featureData.Length == 2)
                {
                    string featureNumber;
                  

                    int colonIndex = selectedFeature.IndexOf(':');
                    featureNumber = selectedFeature.Substring(0, colonIndex).Trim();

                    string  featureName = txtFname.Text;

                  
                    using (connection = new MySqlConnection(db))
                    {
                        try
                        {
                            connection.Open();

                            // 업데이트 쿼리 작성
                            string query = "UPDATE feature SET feature_name = @name WHERE feature_number = @number";
                            MySqlCommand command = new MySqlCommand(query, connection);
                            command.Parameters.AddWithValue("@name", featureName);
                            command.Parameters.AddWithValue("@number", featureNumber);

                            // 쿼리 실행
                            int rowsAffected = command.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                               // MessageBox.Show("Feature가 업데이트되었습니다.");
                               
                                selectfeature();
                            }
                            else
                            {
                                MessageBox.Show("Feature 업데이트에 실패했습니다.");
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("오류가 발생했습니다: " + ex.Message);
                        }
                        finally
                        {
                            connection.Close();
                        }
                    }
                }
            }
        }

        private void Admin_Load(object sender, EventArgs e)
        {
            this.Text = "관리자 전용 화면";
        }
    }
}
