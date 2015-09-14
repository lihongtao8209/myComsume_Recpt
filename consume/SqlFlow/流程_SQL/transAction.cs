using System;
using System.Collections.Generic;
using System.Text;
using ConnectMySql;
using System.Collections;
using System.Windows.Forms;
namespace SQL_FLOW
{

    abstract class TransAction
    {
        //设置SQL语句
        public virtual string SetSql(string sql, string[] args)
        {
            this.sql = string.Format(sql, args);
            return this.sql;
        }
        //得到SQL语句
        public virtual string GetSql()
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
    //
    class TransAction_Read : TransAction
    {
        protected Sql_struct m_sql_struct =null;
        public virtual void init()
        {

        }
        public override void Input(List<string[]> parameters)
        {
            init();
            base.Input(parameters[0], m_sql_struct);
        }
        public override void OutPut(ref List<string[]> paramers)
        {
            //取得结果
            mySqlSimpleOper = new MySqlSimpleOper(db_name, user, pwd, GetSql());
            mySqlSimpleOper.MySqlRead(ref paramers);
        }

    }
    //货名,专框名称,
    class TransAction0 : TransAction
    {
        public TransAction0()
        {
        }
        //输入条码
        public override void Input(List<string[]> parameters)
        {
            Sql_struct sql_struct = new Sql_struct0();
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
        public TransAction1()
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
        public override void Input(List<string[]> paramers)
        {
            Sql_struct[] sql_struct = new Sql_struct[] { new Sql_struct2(), new Sql_struct3() };
            base.Input(paramers, sql_struct);
        }


        public override void OutPut(ref List<string[]> parameters)
        {
            int i = 0;
            try
            {
                //
                Sql_result_struct sql_struct = new Sql_result_struct2();
                string[] parameter_out = new string[sql_struct.GetParamCount()];
                for (i = 0; i < parameter_out.Length; i++)
                {
                    parameter_out[i] = parameters[i][0];
                }
                //取得结果
                mySqlSimpleOper = new MySqlSimpleOper(db_name, user, pwd);
                mySqlSimpleOper.MySqlExecuteNoQuery(GetSqls(), ref parameter_out);
                for (i = 0; i < parameter_out.Length; i++)
                {
                    parameters[i][0] = parameter_out[i];
                }
            }
            catch (System.Exception ex)
            {
                // MessageBox.Show("失败!" + ex.StackTrace + ex.Message);
                throw new IAmMySqlException(ex.StackTrace + ex.Message + "执行sql失败" + parameters[i][0]);
            }
        }

    }

    //查询消耗品表(consume_items) 
    class TransAction3 : TransAction0
    {
        //输入条码
        //返回货号
        //输入条码
        public override void Input(List<string[]> parameters)
        {
            Sql_struct sql_struct = new Sql_struct4();
            base.Input(parameters[0], sql_struct);
        }
    }


    //插入收货表(consume_recpt_records) 更新库存表 (consume_stock) 
    class TransAction4 : TransAction
    {
        //更新--0 时实库存 1 插入时间 
        //插入--0 货号     1 名称     2 发货数量 3 插入时间 
        public override void Input(List<string[]> paramers)
        {
            Sql_struct[] sql_struct = new Sql_struct[] { new Sql_struct3(), new Sql_struct5() };
            base.Input(paramers, sql_struct);
        }
        public override void OutPut(ref List<string[]> parameters)
        {
            try
            {
                Sql_result_struct sql_struct = new Sql_result_struct2();
                string[] parameter_out = new string[sql_struct.GetParamCount()];
                for (int i = 0; i < parameter_out.Length; i++)
                {
                    parameter_out[i] = parameters[i][0];
                }
                //取得结果
                mySqlSimpleOper = new MySqlSimpleOper(db_name, user, pwd);
                mySqlSimpleOper.MySqlExecuteNoQuery(GetSqls(), ref parameter_out);
                for (int i = 0; i < parameter_out.Length; i++)
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

    //查询 库存表(consume_stock) 
    class TransAction5 : TransAction0
    {
        //显示 商口品名称,实时库存
        public override void Input(List<string[]> parameters)
        {
            Sql_struct sql_struct = new Sql_struct6();
            base.Input(parameters[0], sql_struct);
        }
    }


    //发货表(consume_records) 
    class TransAction_camera0 : TransAction0
    {
        //读 时间,品名,专柜名称
        public override void Input(List<string[]> parameters)
        {
            Sql_struct sql_struct = new sql_struct_cameraDriver_0();
            base.Input(parameters[0], sql_struct);
        }
    }

    //发货表_图像记录(consume_recpt_records_image) 
    //发货表_图像记录(consume_records_image) 
    class TransAction_camera_ins : TransAction
    {
        // 插入 货号,品名,插入时间
        // 插入 货号,品名,插入时间
        public override void Input(List<string[]> parameters)
        {
            Sql_struct sql_struct = new sql_struct_cameraDriver_ins();
            base.Input(parameters[0], sql_struct);
        }
        public override void OutPut(ref List<string[]> parameters)
        {
            try
            {
                //取得结果
                string[] parameter_out = new string[1];
                mySqlSimpleOper = new MySqlSimpleOper(db_name, user, pwd);
                mySqlSimpleOper.MySqlInsert(GetSql(), ref parameter_out);
                for (int i = 0; i < parameter_out.Length; i++)
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

    //收货表(consume_recpt_records) 
    class TransAction_camera_recpt0 : TransAction_camera0
    {
        //读 时间,品名,专柜名称
        public override void Input(List<string[]> parameters)
        {
            Sql_struct sql_struct = new sql_struct_cameraDriver_recpt_0();
            base.Input(parameters[0], sql_struct);
        }
    }

    // 发货查询 consume_items,consume_barcode ,consume_records,consume_stock,consume_records_image
    class TransAction_Query_issue_record : TransAction_camera0
    {
        public override string SetSql(string sql, string[] args)
        {
            //this.sql = string.Format(sql, args);
            this.sql = sql;
            return this.sql;
        }

        public override void Input(List<string[]> parameters)
        {
            Sql_struct sql_struct = new sql_struct_query_issue_record();
            base.Input(parameters[0], sql_struct);
        }
    }
    //  收货查询 consume_items,consume_barcode ,consume_recpt_records,consume_stock,consume_recpt_records_image

    class TransAction_Query_recpt_record : TransAction_Query_issue_record
    {
        public override void Input(List<string[]> parameters)
        {
            Sql_struct sql_struct = new sql_struct_query_recpt_record();
            base.Input(parameters[0], sql_struct);
        }
    }

    //发货查询
    //输入 品名
    //输出 "货号","品名","规格","厂编","厂名","发货数量","库存","更新时间"
    class T_issue_name_query_issue_record : TransAction_Read
    {
        public override void init()
        {
            m_sql_struct = new issue_name_query_issue_record();
        }
    }

}
