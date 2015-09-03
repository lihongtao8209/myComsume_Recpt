using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Windows.Forms;
using ConnectMySql;
namespace issueConsume
{

    abstract class TransAction
    {
        //设置SQL语句
        public string SetSql(string sql,string[] args)
        {
            this.sql = string.Format(sql, args);
            return this.sql;
        }
        //得到SQL语句
        public string GetSql()
        {
            return sql;
        }
        public string[] GetSqls()
        {
            return sqls;
        }
        //入参
        protected void Input(string[] parameters, Sql_struct sql_struct)
        {
            for (int i = 0; i < parameters.Length; i++)
            {
                if (parameters[i] == "")
                {
                    throw new Exception("输入的" + sql_struct.GetName()[i] + "为空");
                }
            }
            if (sql_struct.GetParamCount() == parameters.Length)
            {
                SetSql(sql_struct.GetSql(), parameters);
            }
            else
            {
                throw new Exception("SQL语句输入错误！" + SetSql(sql_struct.GetSql(), parameters));
            }
        }
        protected void Input(List<string[]> parameters, Sql_struct[] sql_struct)
        {
            int length = sql_struct.Length;
            sqls = new string[length];
            for (int i = 0; i < length; i++)
            {
                Input(parameters[i], sql_struct[i]);
                sqls[i] = GetSql();
            }
        }
        abstract public void Input(List<string[]> parameters);
        //出参
        abstract public void OutPut(ref List<string[]> parameters);
        //MySQL类
        protected MySqlSimpleOper mySqlSimpleOper;
        //SQL语句
        protected string sql;
        protected string[] sqls;
        //
        protected const string db_name = "consume_db";
        protected const string user = "root";
        protected const string pwd = "123456";
    }
    //货名,专框名称,
    class TransAction0 : TransAction
    {
        public  TransAction0()
        {
        }
        //输入条码
        public override void Input(List<string[]> parameters)
        {
           Sql_struct sql_struct=new Sql_struct0();
           base.Input(parameters[0], sql_struct);
        }
        //0 货号 1 类型 2 品名
        public override void OutPut(ref List<string[]> paramers)
        {
            //
            //Sql_result_struct sql_struct = new Sql_result_struct0();
            //paramers[0] = new string[sql_struct.GetParamCount()];
            //取得结果
            mySqlSimpleOper = new MySqlSimpleOper(db_name, user, pwd, GetSql());
            mySqlSimpleOper.MySqlRead(ref paramers);
        }

    }
    //读取实时库存
    class TransAction1 : TransAction
    {
        public  TransAction1()
        {

        }
        public override void Input(List<string[]> parameters)
        {
            Sql_struct sql_struct = new Sql_struct1();
            base.Input(parameters[0], sql_struct);
        }
        //库存
        public override void OutPut(ref  List<string[]> parameters)
        {
            //
            //Sql_result_struct sql_struct = new Sql_result_struct1();
            //parameters[0] = new string[sql_struct.GetParamCount()];
            //取得结果
            mySqlSimpleOper = new MySqlSimpleOper(db_name, user, pwd, GetSql());
            mySqlSimpleOper.MySqlRead(ref parameters);
        }
    }
    //插入发货表(consume_records) 更新库存 consume_stock
    class TransAction2 : TransAction
    {
        
        public TransAction2()
        {
            
        }
        //插入--0 货号             1 名称     2 数量 3 插入时间 4 专柜名称
        //更新--0 时实库存-发放数量 1 插入时间 2 货号
        public override void Input(List<string []> paramers)
        {
            Sql_struct[] sql_struct = new Sql_struct[] { new Sql_struct2(), new Sql_struct3() };
            base.Input(paramers, sql_struct);
        }
        public override void OutPut(ref List<string[]> parameters)
        {
            try
            {
                //
                Sql_result_struct sql_struct = new Sql_result_struct2();
                string [] parameter_out = new string[sql_struct.GetParamCount()];
                for (int i = 0; i < parameter_out.Length;i++)
                {
                    parameter_out[i] = parameters[i][0];
                }
                //取得结果
                mySqlSimpleOper = new MySqlSimpleOper(db_name, user, pwd);
                mySqlSimpleOper.MySqlExecuteNoQuery(GetSqls(), ref parameter_out);
                for (int i = 0; i < parameter_out.Length;i++ )
                {
                    parameters[i][0] = parameter_out[i];
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("失败!" + ex.StackTrace + ex.Message);
                throw;
            }
        }

     }
    //消耗品表 consume_items,条码表 consume_barcode,发货表(consume_records),库存表 consume_stock
    class TransAction3 : TransAction
    {
        public TransAction3()
        {
            
        }
        public override void Input(List<string[]> paramers)
        {//查询 "品名","专柜商品名","条码","货号","当前发货量","当前库存","更新时间"
            Sql_struct sql_struct = new Sql_struct4();
            base.Input(paramers[0], sql_struct);
        }
        public override void OutPut(ref List<string[]> parameters)
        {
            try
            {
                mySqlSimpleOper = new MySqlSimpleOper(db_name, user, pwd, GetSql());
                mySqlSimpleOper.MySqlRead(ref parameters);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("失败!" + ex.StackTrace + ex.Message);
                throw;
            }
        }
    }
    //库存表(consume_stock) 条码表(consume_barcode) 收货表(consume_recpt_recordsJ)
    class TransAction4 : TransAction0
    {
        public override void Input(List<string[]> paramers)
        {//查询 "商品名称","条码","收货量","实时货存","更新时间"
            Sql_struct sql_struct = new Sql_struct5();
            base.Input(paramers[0], sql_struct);
        }
    }

    //读 发货表(consume_recordsJ)
}
