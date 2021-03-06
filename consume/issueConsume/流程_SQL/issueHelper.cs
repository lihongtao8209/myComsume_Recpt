﻿using issueConsume;
using Macro;
using SqlFlow;
using System;
using System.Collections.Generic;
using System.Text;

namespace issue_recpt_Consume
{
    class IssueHelper
    {
        TransAction[] transAction;
        List<string[]> parametersIn = new List<string[]>();
        List<string[]> parametersOut = new List<string[]>();
        string[] parameter_in;
        string[] parameter_out;
        public IssueHelper()
        {
            transAction = new TransAction[] { new TransAction0(), new TransAction1(), new TransAction2(),new TransAction3(),new TransAction4(),new TransAction5()};
        }

        /// <summary>
        /// 发货 界面
        /// </summary>
        /// 

        public void Query0(string t_barcode,ref string item_no,ref string item_type,ref string item_name)
        {   //查询 货号、耗材名、类型(用来判断是否为专柜商品)
            //入参 条码
            //出参  "货号","类型","品名"
            //表   consume_items consume_barcode
            Clear();
            parameter_in = new string[] { t_barcode };
            //parameter_out = new string[] { macro.nullValue, macro.nullValue, macro.nullValue };
            parametersIn.Add(parameter_in);
            //parametersOut.Add(parameter_out);
            //加入入参列表中
            transAction[0].Input(parametersIn);
            //得到出参列表
            transAction[0].OutPut(ref parametersOut);
            item_no = parametersOut[0][0];
            item_type = parametersOut[0][1];
            item_name = parametersOut[0][2];
        }
        public void Query1(string item_no, ref string realtimeStock)
        {
            //查询 实时库存
            //入参 货号
            //出参 条码
            //表 consume_stock
            Clear();
            parameter_in = new string[] { item_no };
            //parameter_out = new string[] { "实时库存" };
            parametersIn.Add(parameter_in);
            //parametersOut.Add(parameter_out);
            transAction[1].Input(parametersIn);
            transAction[1].OutPut(ref parametersOut);
            realtimeStock=parametersOut[0][0];
        }
        public int insert_update(string item_no, string item_name, string item_type, string shoppeName, string realtimeStock,string issueQty)
        {
            //判断只能为数字
            //插入 货号,品名,发货数量,专柜名称,插入时间
            //表consume_records
            Clear();
            if (item_type == macro.isShoppeGood)
            {//专柜商品
                parameter_in = new string[] { item_no, item_name, issueQty, shoppeName, "now()" };
            }
            else
            {//非专柜商品
                parameter_in = new string[] { item_no, item_name, issueQty, macro.nullValue, "now()" };
            }
            parameter_out = new string[] { "insert" };
            parametersIn.Add(parameter_in);
            parametersOut.Add(parameter_out);
            //更新 时实库存-发放数量,插入时间,货号
            //表consume_stock
            parameter_in = new string[] { realtimeStock, "now()", item_no };
            parameter_out = new string[] { "update" };
            parametersIn.Add(parameter_in);
            parametersOut.Add(parameter_out);

            transAction[2].Input(parametersIn);
            transAction[2].OutPut(ref parametersOut);
            //insert,update 的结果 parametersOut 都应该为 1
            if (parametersOut[0][0] == macro.affected0Row)
            {
                //如果没有插入
                return macro.failed;
            }
            if (parametersOut[1][0] == macro.affected0Row)
            {
                //如果更新失败,删除插入的数据
                return macro.failed;
            }
            return macro.succeed;
        }

        /// <summary>
        /// 收货 界面
        /// </summary>
        //查询 货号
        //入参 条码
        //出参 货号
        //表   consume_barcode
        public void Recpt_Query0(string t_barcode, ref string item_no)
        {   
            Clear();
            parameter_in = new string[] { t_barcode };
            parametersIn.Add(parameter_in);
            //加入入参列表中
            transAction[3].Input(parametersIn);
            //得到出参列表
            transAction[3].OutPut(ref parametersOut);
            item_no = parametersOut[0][0];
        }
        public void Recpt_Query1(string item_no, ref string item_name, ref string realTimeStock)
        {
            Clear();
            parameter_in = new string[] { item_no };
            parametersIn.Add(parameter_in);
            //加入入参列表中
            transAction[5].Input(parametersIn);
            //得到出参列表
            transAction[5].OutPut(ref parametersOut);
            item_name = parametersOut[0][0];
            realTimeStock = parametersOut[0][1];
        }
        //更新 库存表(consume_stock) 收货表(consume_recpt_records)
        //插入 "货号", "名称", "收货数量", "插入时间"
        //更新 "时实库存-发放数量", "插入时间"
        public int Recpt_insert_update(string item_no, string item_name, string realTimeStock, string recpt_qty)
        {
            Clear();

            //表consume_recpt_records 插入
            parameter_in = new string[] { realTimeStock, "now()", item_no };
            parameter_out = new string[] { "insert" };
            parametersIn.Add(parameter_in);
            parametersOut.Add(parameter_out);

            //表consume_stock 更新
            parameter_in = new string[] { item_no,item_name,recpt_qty, "now()" };
            parameter_out = new string[] { "update" };
            parametersIn.Add(parameter_in);
            parametersOut.Add(parameter_out);

            transAction[4].Input(parametersIn);
            transAction[4].OutPut(ref parametersOut);
            //insert,update 的结果 parametersOut 都应该为 1
            if (parametersOut[0][0] == macro.affected0Row)
            {
                //如果没有更新成功
                return macro.failed;
            }
            if (parametersOut[1][0] == macro.affected0Row)
            {
                //如果更新失败,删除插入的数据
                return macro.failed;
            }
            return macro.succeed;
        }



        //入参 货号
        //出参 "商品名称","条码","收货量","实时货存","更新时间"
        /*
        public void Query5(string item_no, ref string item_name, ref string bar_code, ref string recpt_qty, ref string realTimeQty, ref string work_date)
        {
            Clear();
            parameter_in = new string[] { item_no };
            parametersIn.Add(parameter_in);
            //加入入参列表中
            transAction[0].Input(parametersIn);
            //得到出参列表
            transAction[0].OutPut(ref parametersOut);
            item_name = parametersOut[0][0];
            bar_code = parametersOut[0][1];
            recpt_qty = parametersOut[0][2];
            realTimeQty = parametersOut[0][3];
            work_date = parametersOut[0][4];
        }
         * */
        private void Clear()
        {
            parametersIn.Clear();
            parametersOut.Clear();
        }
    }
}
