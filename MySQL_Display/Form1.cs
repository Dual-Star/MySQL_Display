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

namespace MySQL_Display
{
    public partial class Form1 : Form
    {

        MySqlConnection connection = new MySqlConnection("Server=localhost;User ID=root;Password=123321");

        // 主函数调用空参构造器，以初始化窗口
        public Form1()
        {
            InitializeComponent();
        }

        
        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("代码中的连接数据库的参数可能不对！");
            }
            finally
            {
                connection.Close();
            }

            var getRow = new MySqlCommand("SELECT COLUMN_NAME FROM information_schema.COLUMNS WHERE TABLE_SCHEMA = 'fabic' AND TABLE_NAME = 'fabic_color';",connection);

            var Rowname = getRow.ExecuteReader();

            //List<string> row_name_list = new List<String>();

            while (Rowname.Read())
            {
                listBox1.Items.Add(Rowname.GetString(0));
            }
        }

        private void listBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            
            // 所选项遍历进集合choose_item
            List<string> choose_item = new List<string>();
            foreach (var item in listBox1.SelectedItems)
            {
                choose_item.Add(item.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("代码中的连接数据库的参数可能不对！");
            }
            finally
            {
                connection.Close();
            }

            // 获取所选波长范围
            String wave_min = textBox1.Text;
            String wave_max = textBox2.Text;

            string commmand_string =;
            var getRow = new MySqlCommand("SELECT COLUMN_NAME FROM information_schema.COLUMNS WHERE TABLE_SCHEMA = 'fabic' AND TABLE_NAME = 'fabic_color';", connection);

            var Rowname = getRow.ExecuteReader();


            while (Rowname.Read())
            {
                listBox1.Items.Add(Rowname.GetString(0));
            }
        }
    }
}
