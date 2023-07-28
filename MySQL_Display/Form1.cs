using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace MySQL_Display
{
    public partial class Form1 : Form
    {

        MySqlConnection connection = new MySqlConnection("Server=localhost;User ID=root;Password=123321");
        List<string> choose_item = new List<string>();

        // 主函数调用空参构造器，以初始化窗口
        public Form1()
        {
            InitializeComponent();
        }

        
        private void MainForm_Load(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            try
            {
                connection.Open();

                // 库名fabic
                var getRow = new MySqlCommand("SELECT COLUMN_NAME FROM information_schema.COLUMNS WHERE TABLE_SCHEMA = 'fabic' AND TABLE_NAME = 'fabic_color';", connection);

                var Rowname = getRow.ExecuteReader();

                //List<string> row_name_list = new List<String>();

                while (Rowname.Read())
                {
                    listBox1.Items.Add(Rowname.GetString(0));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("代码中的连接数据库的参数可能不对！"); 
            }
            finally
            {
                connection.Close();
            }            
        }

        private void listBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            choose_item.Clear();
            // 所选项遍历进集合choose_item
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

                // 获取所选波长范围
                String wave_min = textBox1.Text;
                String wave_max = textBox2.Text;

                // 避免空值
                if (wave_max.Length==0)
                {
                    wave_max = long.MaxValue.ToString();
                }
                if (wave_min.Length == 0)
                {
                    wave_min= long.MinValue.ToString();
                }

                // 拼接字符串
                StringBuilder col_name = new StringBuilder();
                foreach (var item in choose_item)
                {
                    string tmp_col = "`"+item.ToString()+"`";

                    if (col_name.Length == 0) 
                    { 
                        col_name.Append(tmp_col);
                    }
                    else
                    {
                        col_name.Append(","+tmp_col);
                    }

                }

                // 拼接SQL
                String commmand_string = "Select "+col_name.ToString()+ " from fabic.fabic_color where fact_wave between "+wave_min+" and "+wave_max+";";

                var getRow = new MySqlCommand(commmand_string, connection);

                var query_result = getRow.ExecuteReader();

                DataTable dataTable = new DataTable();
                query_result.Read();

                dataTable.Load(query_result);

                dataGridView1.DataSource = dataTable;
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("代码中的拼接SQL可能不对！"); 
            }
            finally 
            { 
                connection.Close(); 
            }

        }
    }
}
