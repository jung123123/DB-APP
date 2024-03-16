using Google.Protobuf.WellKnownTypes;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Bcpg.Sig;
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
    public partial class Orderr : Form
    {

        private string db = "server=127.0.0.1;port=3306;database=food;uid=root;password=root1234!;charset=utf8mb4;";
        private MySqlConnection connection;

        private string featureNumber;       // 받아온 featureNumber 값
        private string guestNumber;         // 받아온 guestNumber 값
        private string menuNumber;          // 받아온 menuNumber 값
        private string selectedFeature;     // 보내줄 selectedFeature (menu 화면에 다시 featureName 로 보내줌)

        private string selectedOrderNumber; 

        public Orderr(string feature, string guestNumber, string menuNumber)
        {
            InitializeComponent();

            this.featureNumber = feature;
            this.guestNumber = guestNumber;
            this.menuNumber = menuNumber;

            selectedFeature = GetFeatureName(featureNumber);

            Console.WriteLine("feature>>>>>>>>>>>>>>>>>" + feature);
            Console.WriteLine("guestNumber>>>>>>>>>>>>>>>>>" + guestNumber);
            Console.WriteLine("menuNumber>>>>>>>>>>>>>>>>>" + menuNumber);
            OrderrSelect();     //Orderr 테이블 Select

        }

        private void OrderrSelect()     //Orderr 테이블 Select  
        {
            using (connection = new MySqlConnection(db))
            {
                connection.Open();

                string query = "SELECT orderr.menu_number, menu.menu_name, menu.menu_price, order_quantity,order_number  " +
                       "FROM orderr " +
                       "JOIN menu ON orderr.menu_number = menu.menu_number " +
                       "WHERE orderr.guest_number = @guestNumber;";


                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@guestNumber", guestNumber);

                MySqlDataReader reader = command.ExecuteReader();

                listBox1.Items.Clear();
                while (reader.Read())
                {

                    string menuPrice = reader.GetString("menu_price");  // "menu_price" 열의 데이터 가져오기
                    string menuName = reader.GetString("menu_name");// "menu_name" 열의 데이터 가져오기
                    string orderQuantity = reader.GetString("order_quantity");// "order_quantity" 열의 데이터 가져오기
                    string orderNumber = reader.GetString("order_number");// "order_number" 열의 데이터 가져오기

                    string output = "메뉴 이름:" + menuName + ", 가격:" + menuPrice + ", 수량:" + orderQuantity;  // 두 개의 데이터를 결합하여 출력

                    listBox1.Items.Add(output);
                    selectedOrderNumber = orderNumber;
                }

                reader.Close();
            }
        }


        private void Orderr_FormClosing(object sender, FormClosingEventArgs e)
        {
            Main form = Application.OpenForms.OfType<Main>().FirstOrDefault();
            form?.Close();

            Application.Exit();
        }


        private string GetFeatureName(string featureNumber) //menu 화면에 다시 featureName 로 보내주기 위해 featureNumber를 이용해 feature_name값 을 구함
        {
            using (connection = new MySqlConnection(db))
            {
                connection.Open();

                string query = "SELECT feature_name FROM feature WHERE feature_number = @featureNumber;";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@featureNumber", featureNumber);

                string featureName = command.ExecuteScalar()?.ToString();
                return featureName;
            }
        }


        private void btnMenu_Click(object sender, EventArgs e)  //뒤로가기 버튼 클릭시 shoppbag 테이블 DELETE
        {
            using (connection = new MySqlConnection(db))
            {
                connection.Open();

                string query = "DELETE FROM shoppbag;";
                MySqlCommand command = new MySqlCommand(query, connection);

                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    //MessageBox.Show("shoppbag 테이블의 데이터가 성공적으로 삭제되었습니다.");
                }
                else
                {
                    //MessageBox.Show("데이터 삭제에 실패했습니다.");
                }
            }

            Menu menuForm = new Menu(selectedFeature, guestNumber); //Menu 화면에 데이터 전달 FeatureName,guestNumber
            menuForm.StartPosition = FormStartPosition.Manual;  // 폼의 위치를 수동으로 설정
            menuForm.Location = Location;
            menuForm.Show();
            Hide();
        }
        private string GetMenuNumberByName(string menuName) //menu 테이블에서 menu_name 으로 menu_number 구하기
        {
            using (connection = new MySqlConnection(db))
            {
                connection.Open();

                string query = "SELECT menu_number FROM menu WHERE menu_name = @menuName;";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@menuName", menuName);

                string menuNumber = command.ExecuteScalar()?.ToString();
                return menuNumber;
            }
        }


        private void btnDelete_Click(object sender, EventArgs e)    // 삭제 버튼 클릭 시 리스트 박스에 선택된 orderr 테이블 삭제 menu_number가 같으면 다 삭제
        {
            if (listBox1.SelectedIndex != -1)
            {
                string selectedOrder = listBox1.SelectedItem.ToString();
                string menuName = selectedOrder.Substring(selectedOrder.IndexOf(':') + 1, selectedOrder.IndexOf(',') - selectedOrder.IndexOf(':') - 1).Trim();

                using (connection = new MySqlConnection(db))
                {
                    connection.Open();

                    string query = "DELETE FROM orderr WHERE guest_number = @guestNumber AND menu_number = @menuNumber;";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@guestNumber", guestNumber);
                    command.Parameters.AddWithValue("@menuNumber", GetMenuNumberByName(menuName));  ////menu 테이블에서 menu_name 으로 menu_number 구하기

                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                       // MessageBox.Show("선택한 orderr 데이터가 성공적으로 삭제되었습니다.");
                        OrderrSelect(); // 데이터 삭제 후 리스트 업데이트  Orderr 테이블 Select
                    }
                    else
                    {
                        MessageBox.Show("데이터 삭제에 실패했습니다.");
                    }
                }
            }
            else
            {
                MessageBox.Show("삭제할 데이터를 선택해주세요.");
            }
        }

        private void btnPuls_Click(object sender, EventArgs e)  // + 버튼 클릭 시 orderr 테이블 수량(+1)만 업데이트 
        {
            if (listBox1.SelectedIndex != -1)
            {
                string selectedOrder = listBox1.SelectedItem.ToString();
                string menuName = selectedOrder.Substring(selectedOrder.IndexOf(':') + 1, selectedOrder.IndexOf(',') - selectedOrder.IndexOf(':') - 1).Trim();

                using (connection = new MySqlConnection(db))
                {
                    connection.Open();

                    string query = "UPDATE orderr SET order_quantity = order_quantity + 1 WHERE guest_number = @guestNumber AND menu_number = @menuNumber;";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@guestNumber", guestNumber);
                    command.Parameters.AddWithValue("@menuNumber", GetMenuNumberByName(menuName));//menu 테이블에서 menu_name 으로 menu_number 구하기

                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                       // MessageBox.Show("선택한 주문 수량이 성공적으로 증가되었습니다.");
                        OrderrSelect(); // 데이터 업데이트
                    }
                    else
                    {
                        MessageBox.Show("주문 수량 증가에 실패했습니다.");
                    }
                }
            }
            else
            {
                MessageBox.Show("수량을 증가시킬 주문을 선택해주세요.");
            }
        }

        private void btnMius_Click(object sender, EventArgs e)// - 버튼 클릭 시 orderr 테이블 수량(-1)만 업데이트 
        {
            if (listBox1.SelectedIndex != -1)
            {
                string selectedOrder = listBox1.SelectedItem.ToString();
                string menuName = selectedOrder.Substring(selectedOrder.IndexOf(':') + 1, selectedOrder.IndexOf(',') - selectedOrder.IndexOf(':') - 1).Trim();

                using (connection = new MySqlConnection(db))
                {
                    connection.Open();

                    string query = "UPDATE orderr SET order_quantity = CASE WHEN order_quantity > 1 THEN order_quantity - 1 ELSE 1 END WHERE guest_number = @guestNumber AND menu_number = @menuNumber;";// 단 1이하로 떨어 지지 않는다
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@guestNumber", guestNumber);
                    command.Parameters.AddWithValue("@menuNumber", GetMenuNumberByName(menuName));

                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("선택한 주문 수량이 성공적으로 감소되었습니다.");
                        OrderrSelect(); // 데이터 업데이트
                    }
                    else
                    {
                        MessageBox.Show("주문 수량 감소에 실패했습니다.");
                    }
                }
            }
            else
            {
                MessageBox.Show("수량을 감소시킬 주문을 선택해주세요.");
            }
        }

        private string GetOrderNumberBy(string menuNumber, string guestNumber, string orderQuantity)//orderr 테이블 에서 menu_number guest_number order_quantity 를 이용해 order_number 구하기
        {
            using (connection = new MySqlConnection(db))
            {
                connection.Open();

                string query = "SELECT order_number FROM orderr WHERE menu_number = @menuNumber AND guest_number = @guestNumber AND order_quantity = @orderQuantity;";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@menuNumber", menuNumber);
                command.Parameters.AddWithValue("@guestNumber", guestNumber);
                command.Parameters.AddWithValue("@orderQuantity", orderQuantity);

                string orderNumber = command.ExecuteScalar()?.ToString();
                return orderNumber;

            }
        }


        private void btnBuy_Click(object sender, EventArgs e)       // 결제 버튼 클릭 후 shoppbag 테이블에 데이터를 추가후 shoppbag 화면 으로 이동
        {
            //ShoppBag shoppbagForm = new ShoppBag(featureNumber, guestNumber, menuNumber);
            //shoppbagForm.StartPosition = FormStartPosition.Manual;  // 폼의 위치를 수동으로 설정
            //shoppbagForm.Location = Location;
            //shoppbagForm.Show();
            //Hide();


            Console.WriteLine("----------------------btnBuy_Click 실행 부분 ========================");

            using (connection = new MySqlConnection(db))
            {
                connection.Open();  //sql문 시작을위해 존재 

                if (connection.State == ConnectionState.Open)
                {

                    foreach (var item in listBox1.Items)
                    {
                        string selectedOrder = item.ToString();
                        string orderQuantity = selectedOrder.Substring(selectedOrder.LastIndexOf(':') + 1).Trim();
                        string menuName = selectedOrder.Substring(selectedOrder.IndexOf(':') + 1, selectedOrder.IndexOf(',') - selectedOrder.IndexOf(':') - 1).Trim();
                        string menuNumer = GetMenuNumberByName(menuName);
                        Console.WriteLine("orderQuantity =>>>>>>>>>>>>>>>>>>>>>" + orderQuantity);
                        string orderNumber = GetOrderNumberBy(menuNumer, guestNumber, orderQuantity);       //orderr 테이블 에서 menu_number guest_number order_quantity 를 이용해 order_number 구하기

                        connection.Open();  // GetOrderNumberBy에서  using (connection = new MySqlConnection(db)) 으로 자동으로  connection.Close();되어 다시 서버 연결


                        Console.WriteLine("menuNumer =>>>>>>>>>>>>>>>>>>>>>" + menuNumer);
                        Console.WriteLine("guestNumber =>>>>>>>>>>>>>>>>>>>>>" + guestNumber);
                        Console.WriteLine("orderNumber =>>>>>>>>>>>>>>>>>>>>>" + orderNumber);



                        string query = "INSERT INTO shoppbag (guest_number, menu_number, order_number ) VALUES (@guestNumber, @menuNumber, @orderNumber);";

                        MySqlCommand command = new MySqlCommand(query, connection);

                        command.Parameters.AddWithValue("@guestNumber", guestNumber);
                        command.Parameters.AddWithValue("@menuNumber", menuNumer);
                        command.Parameters.AddWithValue("@orderNumber", orderNumber);

                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                           // MessageBox.Show("데이터가 성공적으로 삽입되었습니다.");

                            ShoppBag shoppbagForm = new ShoppBag(featureNumber, guestNumber, menuNumber);       //ShoppBag 화면에 featureNumber guestNumber menuNumber 데이터 전달 
                            shoppbagForm.StartPosition = FormStartPosition.Manual;  // 폼의 위치를 수동으로 설정
                            shoppbagForm.Location = Location;
                            shoppbagForm.Show();
                            Hide();
                        }
                        else
                        {
                            MessageBox.Show("데이터 삽입에 실패했습니다.");
                        }

                        command.Dispose();

                    }
                    connection.Close();
                }
                else
                {
                    Console.WriteLine("----------------------연결 이슈 ========================");
                }

            }
            

        }

        private void Orderr_Load(object sender, EventArgs e)
        {
            this.Text = "키오스크";
        }
    }
}
