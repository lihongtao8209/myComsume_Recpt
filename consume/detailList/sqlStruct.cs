using System;
using System.Collections.Generic;
using System.Text;

namespace issueConsume
{
    class Sql_struct
    {
        protected string sql;
        protected string[] name;
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
            name = new string[] { "条码"};
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
            name = new string[] { "货号", "名称", "发放数量", "专柜名称" ,"插入时间"};
        }

    }

    class Sql_struct3 : Sql_struct
    {
        public Sql_struct3()
        {
            sql="update consume_stock set rt_stock = {0}, upd_date={1} where item_no = {2}";
            name = new string[] { "时实库存-发放数量", "插入时间", "货号" };
        }
    }

    class Sql_struct4 : Sql_struct
    {
        public Sql_struct4()
        {
            sql = @"select  a.name,
             c.shpe_name,
			 b.BAR_CODE,
			 c.qty,
			 d.rt_stock,
			 c.work_date
             from   consume_items a,consume_barcode b,consume_records c,consume_stock d
             where  a.item_no=b.item_no
                    and a.item_no=c.item_no
                    and a.item_no=d.item_no
                    and d.item_no={0}
             order by c.record_no desc   LIMIT 0,1";
            name = new string[] {"货号"};
            //name = new string[] {"品名","专柜商品名","条码","当前发货量","当前库存","更新时间"};
        }
    }

    class Sql_struct5 : Sql_struct
    {
        public Sql_struct5()
        {
            sql = @"select a.name,
                         b.bar_code,
                         c.recpt,
                         a.rt_stock,
                         c.work_date
                    from 
  		                 consume_stock a,
  		                 consume_barcode b,
  		                 consume_recpt_records c
                    where a.item_no=b.item_no
                    and a.item_no=c.item_no
                    and a.item_no={0}
                    order by c.record_no desc   LIMIT 0,1";
            name = new string[] { "货号" };
           // name = new string[] { "商品名称", "条码", "收货量", "实时货存", "更新时间" };
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
            name = new string[] {"货号","类型","品名"};
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
            name = new string[] { "insert","update" };
        }
    } 
    //////////////////////////////////////////////////////////////////////////

}
