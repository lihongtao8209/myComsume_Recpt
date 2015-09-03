using System;
using System.Collections.Generic;
using System.Text;

namespace SQL_FLOW
{
    class Sql_struct
    {
        protected string sql;
        //入参
        protected string[] name;
        protected string[] outName;
        public int GetParamCount()
        {
            return name.Length;
        }
        public string GetSql()
        {
            return sql;
        }
        public string[] GetName()
        {
            return name;
        }
    }
    class Sql_struct0 : Sql_struct
    {
        public Sql_struct0()
        {
            sql = "select  a.item_no, type, name from consume_items a,consume_barcode b where a.item_no=b.item_no and b.bar_code={0}";
            name = new string[] { "条码" };
        }
    }
    class Sql_struct1 : Sql_struct
    {
        public Sql_struct1()
        {
            sql = "select rt_stock from consume_stock where item_no ={0}";
            name = new string[] { "货号" };
        }
    }
    class Sql_struct2 : Sql_struct
    {
        public Sql_struct2()
        {
            sql = "insert into consume_records (item_no,name,qty,shpe_name,work_date) values({0},\"{1}\",{2},\"{3}\",{4})";
            name = new string[] { "货号", "商品名称", "发放数量", "专柜名称", "插入时间" };
        }

    }

    class Sql_struct3 : Sql_struct
    {
        public Sql_struct3()
        {
            sql = "update consume_stock set rt_stock = {0}, upd_date={1} where item_no = {2}";
            name = new string[] { "时实库存-发放数量", "插入时间", "货号" };
            outName = new string[] { "update" };
        }

    }

    class Sql_struct4 : Sql_struct
    {
        public Sql_struct4()
        {
            sql = "select item_no from consume_barcode where bar_code={0}";
            name = new string[] { "货号" };
        }
    }

    class Sql_struct5 : Sql_struct
    {
        public Sql_struct5()
        {
            sql = "insert into consume_recpt_records(item_no,name,recpt,work_date) values ({0},\"{1}\",{2},{3})";
            name = new string[] { "货号", "名称", "收货数量", "插入时间" };
            outName = new string[] { "insert" };
        }
    }
   
    class Sql_struct6 : Sql_struct
    {
        public Sql_struct6()
        {
            sql = @"select a.name,a.rt_stock from consume_stock a where  a.item_no={0}";
            name = new string[] { "货号" };
        }
    }

    class sql_struct_cameraDriver_0 : Sql_struct0
    {
        public sql_struct_cameraDriver_0()
        {
            sql = @"select a.work_date,a.name,a.shpe_name from  consume_records a where  a.item_no={0} order by a.record_no desc LIMIT 0,1";
            name = new string[] { "插入时间" };
        }
    }
    /*
    class sql_struct_cameraDriver_ins: Sql_struct
    {
        public sql_struct_cameraDriver_ins()
        {
            sql = "insert into consume_records_image (item_no,name,work_date) values ({0},\"{1}\",\"{2}\")";
            name = new string[] { "货号","文件名","插入时间" };
            outName = new string[] { "insert" };
        }
    }
     * */

    class sql_struct_cameraDriver_ins : Sql_struct
    {
        public sql_struct_cameraDriver_ins()
        {
            sql = "insert into {0} (item_no,name,work_date) values ({1},\"{2}\",\"{3}\")";
            name = new string[] { "插入的表名","货号", "文件名", "插入时间" };
            outName = new string[] { "insert" };
        }
    }

    class sql_struct_cameraDriver_recpt_0 : Sql_struct0
    {
        public sql_struct_cameraDriver_recpt_0()
        {
            sql = @"select a.work_date,a.name from  consume_recpt_records a where a.item_no={0} order by a.record_no desc LIMIT 0,1";
            name = new string[] { "插入时间" };
        }
    }

    

    //////////////////////////////////////////////////////////////////////////

    class Sql_result_struct
    {
        protected string[] name;
        public int GetParamCount()
        {
            return name.Length;
        }
    }

    class Sql_result_struct0 : Sql_result_struct
    {
        public Sql_result_struct0()
        {
            name = new string[] { "货号", "类型", "品名" };
        }
    }
    class Sql_result_struct1 : Sql_result_struct
    {
        public Sql_result_struct1()
        {
            name = new string[] { "实时库存" };
        }
    }
    class Sql_result_struct2 : Sql_result_struct
    {
        public Sql_result_struct2()
        {
            name = new string[] { "insert", "update" };
        }
    }


    //////////////////////////////////////////////////////////////////////////

}
