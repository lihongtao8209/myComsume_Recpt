using mySql.CLASS;
using MySQLDriverCS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ConnectMySql
{
    public class MySqlSimpleOper
    {
        static string serverIp = "";
        string sqlString = "";
        string []sqlStringArray;
        MySQLConnection conn = null;
        MySQLCommand cmd = null;
        MySQLDataReader oraRD = null;
        MySQLConnectionString connectionString = null;
        public MySqlSimpleOper(string dataSource, string user, string password, string sql = "")
        {
            connectionString = new MySQLConnectionString(serverIp,dataSource, user, password);
            sqlString = sql;
        }

        public MySqlSimpleOper(string serverIp,string dataSource, string user, string password, string sql = "")
        {
            connectionString = new MySQLConnectionString(serverIp,dataSource, user, password);
            sqlString = sql;
        }

        public MySqlSimpleOper(string dataSource, string user, string password)
        {
            connectionString = new MySQLConnectionString(serverIp,dataSource, user, password);
        }

        public MySqlSimpleOper(string dataSource, string user, string password,string [] sqlArray)
        {
            connectionString = new MySQLConnectionString(serverIp,dataSource, user, password);
            sqlStringArray = sqlArray;
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

        static public void SetServerIp(string ip)
        {
            serverIp = ip;
        }

        //连接
        private void OpenConnection()
        {
            //连接
            conn = new MySQLConnection(connectionString.AsString);
            //打开
            conn.Open();
        }

        //命令
        private void OpenCommand()
        {
            cmd = new MySQLCommand();
            cmd.Connection = conn;
        }

        private void SetCommand(string commandText)
        {
            if (commandText == "")
            {
                throw new IAmMySqlException("输入的sql字符串不能为空!");
            }
            else
            {
                cmd.CommandText = commandText;
            }
        }
 
        private string Command
        {
            set
            {
                cmd.CommandText = value;
            }
        }
        //检查是否是SQL语句
        private bool isSql(string sqlString)
        {
            if (sqlString == "" || sqlString==null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        //提交
        private int Commit()
        {
            int result = cmd.ExecuteNonQuery();
            return result;
        }

        private int CommitCommand(string commandText)
        {
            Command = commandText;
            return Commit();
        }

        //防止乱码
        private void Gbk()
        {
            CommitCommand("set names gbk");
        }

        private void init()
        {
            //打开连接
            OpenConnection();
            //打开命令
            OpenCommand();
            //防止乱码
            Gbk();
            //设置命令
            SetCommand(sqlString);
        }

        private void Open()
        {
            //打开连接
            OpenConnection();
            //打开命令
            OpenCommand();
            //防止乱码
            Gbk();
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


        private void DoExecuteNoQuery(ref string[] commandTextArray)
        {
            for (int i = 0; i < commandTextArray.Length; i++)
            {
                if (isSql(commandTextArray[i]))
                {
                    sqlString = commandTextArray[i];
                    CommitCommand(sqlString);
                }
            }
        }

        private void DoExecuteNoQuery(ref string[] commandTextArray, ref string[] affected)
        {
            for (int i = 0; i < commandTextArray.Length; i++)
            {
                if (isSql(commandTextArray[i]))
                {
                    sqlString = commandTextArray[i];
                    affected[i]= CommitCommand(sqlString).ToString();
                }
            }
        }

        private void Update()
        {
            Commit();
        }

        private void Close()
        {
            conn.Close();
            cmd.Dispose();
        }
        //读取
        public void MySqlRead(ref List<string[]> result)
        {
            try
            {
                init();
                Read(ref result);
                Close();
            }
            catch (System.Exception ex)
            {
                throw new IAmMySqlException(ex.StackTrace + ":" + ex.Message + " 数据库串:" + connectionString.AsString+ " SQL语句:" + sqlString);
            }
            if (result.Count == 0)
            {
                throw new IAmMySqlException("没有在数据库中查到数据.数据库串:" + connectionString.AsString + " SQL语句:" + sqlString);
            }
        }
        //更新
        public void MySqlUpdate()
        {
            try
            {
                init();
                Update();
                Close();
            }
            catch (System.Exception ex)
            {
                throw new IAmMySqlException(ex.StackTrace + ":" + ex.Message + " 数据库串:" + connectionString.AsString + " SQL语句:" + sqlString);
            }
        }
        //插入
        public void MySqlInsert(string sqlString, ref  string[] affected)
        {
            string[] sqlStringArray = new string[1];
            sqlStringArray[0] = sqlString;
            MySqlExecuteNoQuery(sqlStringArray,ref affected);
        }
        //插入
        public void MySqlInsert(string sqlString)
        {
            string []sqlStringArray = new string[1];
            sqlStringArray[0] = sqlString;
            MySqlExecuteNoQuery( sqlStringArray);
        }
        public void MySqlInsert()
        {
            sqlStringArray = new string[1];
            sqlStringArray[0] = sqlString;
            MySqlExecuteNoQuery( sqlStringArray);
        }
        //删除
        public void MySqlDelete(string sqlString)
        {
            string[] sqlStringArray = new string[1];
            sqlStringArray[0] = sqlString;
            MySqlExecuteNoQuery( sqlStringArray);
        }

        //插入、删除、更新操作
        public void MySqlExecuteNoQuery( string[] SqlStringArray)
        {
            try
            {
                Open();
                DoExecuteNoQuery(ref SqlStringArray);
                Close();
            }
            catch (System.Exception ex)
            {
                throw new IAmMySqlException(ex.StackTrace + ":" + ex.Message + " 数据库串:" + connectionString.AsString + " SQL语句:" + sqlString);
            }
        }
        //插入、删除、更新操作
        public void MySqlExecuteNoQuery( string[] SqlStringArray, ref string[] affected)
        {
            try
            {
                Open();
                DoExecuteNoQuery(ref SqlStringArray,ref affected);
                Close();
            }
            catch (System.Exception ex)
            {
                throw new IAmMySqlException(ex.StackTrace + ":" + ex.Message + " 数据库串:" + connectionString.AsString + " SQL语句:" + sqlString);
            }
        }

        public void MySqlProcedure()
        {
            //打开连接
            Open();
           // CommitCommand("CALL consume_db.new_procedure(167178)");
            OpenCommand();
            Command = "new_procedure3";
            
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            MySQLParameter par1 = new MySQLParameter("item_no", DbType.String, "167178");
            MySQLParameter[] parameters = {
                   new MySQLParameter("?item_no",System.Data.DbType.Int32, "This value is ignored")
                    };
            parameters[0].Value = "167178";
            cmd.Parameters.AddRange(parameters);
            MySQLDataAdapter ad = new MySQLDataAdapter(cmd);
            DataSet ds = new DataSet();
            ad.Fill(ds);
            /*
            StringBuilder abc = new StringBuilder(20);
            MySQLParameter par3 = new MySQLParameter("?file_name", abc);
            par3.Direction = ParameterDirection.Output;

            par3.Scale = 100;
            par3.Size = 100;

            cmd.Parameters.Add(par3);*/

        }

    }
}
