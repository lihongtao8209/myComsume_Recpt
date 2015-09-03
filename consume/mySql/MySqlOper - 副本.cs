using mySql.CLASS;
using MySQLDriverCS;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConnectMySql
{
    public class MySqlSimpleOper
    {
        //string connectionString = "";
        string sqlString = "";
        MySQLConnection conn = null;
        MySQLCommand cmd = null;
        MySQLDataReader oraRD = null;
        MySQLConnectionString connectionString = null;
        public MySqlSimpleOper(string dataSource, string user, string password, string sql = "")
        {
            connectionString = new MySQLConnectionString(dataSource, user, password);
            sqlString = sql;
        }

        public MySQLConnectionString ConnectionString
        {
            set
            {
                connectionString = value;
            }
            get
            {
                return connectionString;
            }
        }

        public string SqlString
        {
            set
            {
                sqlString = value;
            }
            get
            {
                return sqlString;
            }

        }

        //命令
        private void Command()
        {
            cmd = new MySQLCommand();
            cmd.Connection = conn;
        }

        //提交
        private int commit()
        {
            int result = cmd.ExecuteNonQuery();
            return result;
        }



        private void Gbk()
        {
            MySQLCommand cmd = new MySQLCommand("set names gbk", conn);
            int r=cmd.ExecuteNonQuery();
        }

        private void Open()
        {
            //连接
            conn = new MySQLConnection(connectionString.AsString);
            //打开
            conn.Open();
            //解决乱码
            Gbk();
            //输入命令
            cmd = new MySQLCommand(sqlString, conn);

        }
        private void Read(ref List<string[]> result)
        {

            oraRD = cmd.ExecuteReaderEx();
            int n = oraRD.FieldCount;
            while (oraRD.Read())
            {
                string[] oneResult = new string[n];
                for (int i = 0; i < n; i++)
                {
                    oneResult[i] = oraRD[i].ToString();
                }
                result.Add(oneResult);
            }
            oraRD.Close();
        }
        private void Update()
        {
            commit();
        }

        private void Close()
        {
            conn.Close();
            cmd.Dispose();
        }

 


        public void OracleRead(ref List<string[]> result)
        {
            try
            {
                Open();
                Read(ref result);
                Close();
            }
            catch (System.Exception ex)
            {
                throw new IAmMySqlException(ex.StackTrace + ":" + ex.Message + " 数据库串:" + connectionString + " SQL语句:" + sqlString);
            }
        }
        public void OracleUpdate()
        {
            try
            {
                Open();
                Update();
                Close();
            }
            catch (System.Exception ex)
            {
                throw new IAmMySqlException(ex.StackTrace + ":" + ex.Message + " 数据库串:" + connectionString + " SQL语句:" + sqlString);
            }
        }
    }
}
