using System;
using System.Collections.Generic;
using System.Text;

namespace issueConsume
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
            transAction = new TransAction[] { new TransAction3(),new TransAction4()};
        }
        public void Query0(string t_item_no,ref string item_name,ref string shoppe_name,ref string barcode,ref string realTimeStock,ref string rt_stock,ref string work_date)
        {  
            //入参 货号
            //出参 "品名","专柜商品名","条码","货号","当前发货量","当前库存","更新时间"
            //消耗品表 consume_items,条码表 consume_barcode,发货表(consume_records),库存表 consume_stock
            Clear();
            parameter_in = new string[] { t_item_no };
            //parameter_out = new string[] { macro.nullValue, macro.nullValue, macro.nullValue };
            parametersIn.Add(parameter_in);
            //parametersOut.Add(parameter_out);
            //加入入参列表中
            transAction[0].Input(parametersIn);
            //得到出参列表
            transAction[0].OutPut(ref parametersOut);
            item_name = parametersOut[0][0];
            shoppe_name = parametersOut[0][1];
            barcode = parametersOut[0][2];
            realTimeStock = parametersOut[0][3];
            rt_stock = parametersOut[0][4];
            work_date = parametersOut[0][5];
        }

        public void Recpt_Query0(string item_no, ref string item_name, ref string barcode, ref string recptQty, ref string realTimeStock, ref string work_date)
        {//入参   货号
         //出参   "商品名称","条码","收货量","实时货存","更新时间"
         //条码表 consume_barcode,收货表(consume_recpt_records),库存表 consume_stock
            Clear();
            parameter_in = new string[] { item_no };
            //parameter_out = new string[] { macro.nullValue, macro.nullValue, macro.nullValue };
            parametersIn.Add(parameter_in);
            //parametersOut.Add(parameter_out);
            //加入入参列表中
            transAction[1].Input(parametersIn);
            //得到出参列表
            transAction[1].OutPut(ref parametersOut);
            item_name = parametersOut[0][0];
            barcode = parametersOut[0][1];
            recptQty = parametersOut[0][2];
            realTimeStock = parametersOut[0][3];
            work_date = parametersOut[0][4];
        }

        private void Clear()
        {
            parametersIn.Clear();
            parametersOut.Clear();
        }
    }
}
