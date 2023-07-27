using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MySQL_Display
{
    public class Tools
    {
        /*public class Mysqlcon
        {

            // 数据链接字段
            public string con= "Server=localhost;User ID=root;Password=123321;Database=fabic";

            public Mysqlcon()
            {
               
            }

            public Mysqlcon(string con)
            {
                this.con = con;
            }


            // 链接数据库
            public MySqlConnection Mysqlcon()
            {
                MySqlConnection connection = new MySqlConnection(con);
                try
                {
                    connection.Open();
                    MessageBox.Show("数据库连接成功");
                    return connection;
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
        }*/
    }
}
