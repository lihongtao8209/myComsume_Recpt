
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
//using MySQLDriverCS;
using ConnectMySql;
using myException;
using System.Text.RegularExpressions;

namespace test
{
    struct Check
    {
        struct PreConditonCheck
        {

        }
        struct NullCheck
        {

        }
        struct NdigitCheck
        {

        }
    }
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }




        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                Check c = new Check();
                Type t = c.GetType();

                const string sql_ins = "insert into consume_records (item_no,name, qty,work_date,shpe_name ) values  {0},{1},{2},{3},{4}";

                object[] args = new object[] { "0", "1", "2", "3", "4" };
                string a = string.Format(sql_ins, args);



               
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<string[]> result = new List<string[]>();
            string sql = "select * from consume_items_supplier";
            MySqlSimpleOper mysql = new MySqlSimpleOper("127.0.0.1", "consume_db", "root", "123456", sql);
            mysql.MySqlRead(ref result);

            /*
            //sql = "update consume_records set qty=4";
            //mysql.SqlString = sql;
            //mysql.OracleUpdate();

            string[] sqls = new string[4];
            sqls[0] = @"insert into consume_records (item_no,name,qty,shpe_name,work_date) values (123456,'123',1,'测试',now())";
            //sqls[0] = @"insert into consume_records (item_no,name,qty,shpe_name,work_date) values (123456,'123',1,'测试','2015-08-19')";
            //sqls[1] = @"insert into consume_records (item_no,name,qty,shpe_name,work_date) values (123456,'123',1,'测试','2015-08-21')";
            //sqls[2] = @"update consume_records set qty=5 where qty=1 and work_date='2015-08-19'";
            //sqls[3] = @"insert into consume_records (record_no,item_no,name,qty,shpe_name,work_date) values (1,123456,'123',1,'测试','2015-08-19')";
            mysql.MySqlExecuteNoQuery(sqls);

            sql = @"delete from consume_records where qty=2";
            mysql.MySqlDelete(sql);
             * */
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string str = "";
            str = string.Format("{0:00}", 2);
            try
            {
                str = daytime_query1.GetDate();
            }
            catch (IAmMyDayTimeQueryException ex)
            {
                MessageBox.Show(ex.Message);
            }
            MessageBox.Show(str);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Regex regex = new Regex(@"^(?<fpath>([a-zA-Z]:\\)([\s\.\-\w]+\\)*)(?<fname>[\w]+)(?<namext>(\.[\w]+)*)(?<suffix>\.[\w]+)");

            Match result = regex.Match(@"D:\Program Files\AliWangWang\7.10.07C\emotions\TaoDoll\Sniffer.dat");

            if (result.Success)
            {
                MessageBox.Show("[Full]:" + result.Value);

                MessageBox.Show("[Part1]:" + result.Result("${fpath}"));
                MessageBox.Show("[Part2]:" + result.Result("${fname}"));
                MessageBox.Show("[Part2]:" + result.Result("${suffix}"));
            }

        }
    }
}
