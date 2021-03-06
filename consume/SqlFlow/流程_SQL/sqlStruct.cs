﻿using System;
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
    //插入图片
    class sql_struct_cameraDriver_ins : Sql_struct
    {
        public sql_struct_cameraDriver_ins()
        {
            sql = "insert into {0} (item_no,fileName,work_date) values ({1},\"{2}\",\"{3}\")";
            name = new string[] { "插入的表名", "货号", "文件名", "插入时间" };
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

    class sql_struct_query_issue_record : Sql_struct0
    {
        public sql_struct_query_issue_record()
        {
            sql = @"select f.*,e.fileName from
	            (select  a.name,
                 a.item_no,
                 a.spec,
                 a.company_name,
                 a.sup_no,
				 b.qty,
				 c.rt_stock,
				 b.work_date
				 from   v_consume_items_supplier a,consume_records b,consume_stock c
				 where  a.item_no=b.item_no
						and a.item_no=c.item_no
                        and a.item_no={0}
				 order by b.record_no desc) as f
                 left join consume_records_image e on f.WORK_DATE=e.WORK_DATE ";
            name = new string[] { "货号" };
            outName = new string[] { "品名", "货号", "规格", "厂商名称", "厂编", "发货量", "库存", "更新时间", "图片名称" };
        }
    }

    class sql_struct_query_recpt_record : Sql_struct0
    {
        public sql_struct_query_recpt_record()
        {
            sql = @"select f.*,e.fileName from
	            (select  a.name,
                 a.item_no,
                 a.spec,
                 a.company_name,
                 a.sup_no,
				 b.recpt,
				 c.rt_stock,
				 b.work_date
				 from   v_consume_items_supplier a,consume_recpt_records b,consume_stock c
				 where  a.item_no=b.item_no
						and a.item_no=c.item_no
                        and a.item_no={0}
				 order by b.record_no desc) as f
                 left join consume_recpt_records_image e on f.WORK_DATE=e.WORK_DATE ";
            name = new string[] { "货号" };
            outName = new string[] { "品名", "货号", "规格", "厂商名称", "厂编", "收货量", "库存", "更新时间", "图片名称" };
        }
    }

    class issue_name_query_issue_record : Sql_struct0
    {
        public issue_name_query_issue_record()
        {
            sql = @"select a.item_no,a.name,a.spec,a.company_name ,a.sup_no from v_consume_items_supplier as a";
            name = new string[] { "null" };
            outName = new string[] { "货号", "品名", "规格", "厂名", "厂编" };
        }
    }
    class issue_list_query_record : Sql_struct0
    {
        public issue_list_query_record()
        {
            sql = @"select b.*,
                           aa.QTY,
                           c.RT_STOCK,
                           aa.WORK_DATE
                    from
                    (select a.qty,
                           a.work_date,
	                       a.item_no 
                     from  consume_records a  
                     order by a.record_no desc LIMIT 0,1) aa,
	                    v_consume_items_supplier b,
                        consume_stock c
                    where aa.item_no =b.item_no
                       and aa.item_no=c.item_no
                       and aa.item_no={0}";
            name = new string[] { "货号" };
            outName = new string[] { "货号", "品名", "规格", "厂名", "厂编","当前发货量","当前库存","更新时间" };
        }
    }
    class recpt_list_query_record : Sql_struct0
    {
        public recpt_list_query_record()
        {
            sql = @"select b.*,
	                  aa.RECPT,
                    c.RT_STOCK,
                   aa.WORK_DATE
                  from
	  (select a.RECPT,
			  a.work_date,
			  a.item_no 
	   from  consume_recpt_records a  
	   order by a.record_no desc LIMIT 0,1) aa,
					v_consume_items_supplier b,
					           consume_stock c
                        where aa.item_no =b.item_no
                       and aa.item_no=c.item_no
                       and aa.item_no={0}";
            name = new string[] { "货号" };
            outName = new string[] { "货号", "品名", "规格", "厂名", "厂编", "当前收货量", "当前库存", "更新时间" };
        }
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


