
using Macro;
using System;
using System.Collections.Generic;
using System.Text;

namespace SQL_FLOW
{
    public class IssueHelper
    {
        TransAction[] transAction;
        TransAction[] cameraTransAction;
        TransAction[] queryTransAction;
        TransAction[] listViewTransAction;
        List<string[]> parametersIn = new List<string[]>();
        List<string[]> parametersOut = new List<string[]>();
        string[] parameter_in;
        string[] parameter_out;
        public IssueHelper()
        {
            //transAction = new TransAction[] { new TransAction0(), new TransAction1(), new TransAction2(),new TransAction3(),new TransAction4(),new TransAction5()};
            transAction = new TransAction[] { new T_issue_name_query_issue_record(), new TransAction1(), new TransAction2(), new TransAction3(), new TransAction4(), new TransAction5() };
            listViewTransAction = new TransAction[]{new T_issue_list_query_issue_record()};
            cameraTransAction = new TransAction[] { new TransAction_camera0(), new TransAction_camera_recpt0(), new TransAction_camera_ins()};
            queryTransAction = new TransAction[] { new TransAction_Query_issue_record(),new TransAction_Query_recpt_record()};
        }

        /// <summary>
        /// 发货 界面
        /// </summary>
        /// 
        /*
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
        }*/
        
        public void Query00(string t_name,ref string item_no,ref string name,ref string spec,ref string sup_no,ref string companyName,ref string issueQty,ref string realTimeStock,ref string work_date)
        {//"货号","规格","品名","厂名", "厂编"
            Clear();
            parameter_in = new string[] { t_name };
            parametersIn.Add(parameter_in);
            //加入入参列表中
            transAction[0].Input(parametersIn);
            //得到出参列表
            transAction[0].OutPut(ref parametersOut);
            item_no = parametersOut[0][0];
            name = parametersOut[0][1];
            spec = parametersOut[0][2];
            sup_no = parametersOut[0][3];
            companyName = parametersOut[0][4];
            issueQty = parametersOut[0][5];
            realTimeStock = parametersOut[0][6];
            work_date = parametersOut[0][7];
        }

        public void Query0(ref List<string[]> parametersOut)
        { 
            Clear();
            parameter_in = new string[] { "null" };
            parametersIn.Add(parameter_in);
            //加入入参列表中
            transAction[0].Input(parametersIn);
            //得到出参列表
            transAction[0].OutPut(ref parametersOut);
        }

        public void Issue_ListView_Query(string item_no, ref List<string[]> parametersOut)
        {
            Clear();
            parameter_in = new string[] { item_no };
            parametersIn.Add(parameter_in);
            //加入入参列表中
            listViewTransAction[0].Input(parametersIn);
            //得到出参列表
            listViewTransAction[0].OutPut(ref parametersOut);
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

        public void Camera_Query0(string item_no, ref string work_date,ref string name,ref string shpe_name)
        {   //查询 工作时间 品名 专柜商品
            //入参 货号
            //出参  工作时间 品名 专柜商品
            //表   consume_records
            Clear();
            parameter_in = new string[] { item_no };
            parametersIn.Add(parameter_in);
            //加入入参列表中
            cameraTransAction[0].Input(parametersIn);
            //得到出参列表
            cameraTransAction[0].OutPut(ref parametersOut);
            work_date = parametersOut[0][0];
            name = parametersOut[0][1];
            shpe_name = parametersOut[0][2];
        }



        public void Camera_Recpt_Query0(string item_no, ref string work_date, ref string name)
        {   //查询 工作时间 品名 
            //入参 货号
            //出参 工作时间 品名 
            //表   consume_recpt_records
            Clear();
            parameter_in = new string[] { item_no };
            parametersIn.Add(parameter_in);
            //加入入参列表中
            cameraTransAction[1].Input(parametersIn);
            //得到出参列表
            cameraTransAction[1].OutPut(ref parametersOut);
            work_date = parametersOut[0][0];
            name = parametersOut[0][1];
        }


        public int Camera_insert(string item_no, string file_name, string work_date ,bool recpt=false)
        {   //插入 货号 文件名 工作时间
            //入参 货号 文件名 工作时间
            //出参 
            //表   consume_recpt_record_image consume_record_image
            Clear();
            if (recpt == false)
            {
                parameter_in = new string[] { "consume_records_image",item_no, file_name, work_date };
            }
            else
            {
                parameter_in = new string[] { "consume_recpt_records_image", item_no, file_name, work_date };
            }
            parameter_out = new string[] { "insert" };
            parametersIn.Add(parameter_in);
            parametersOut.Add(parameter_out);

            cameraTransAction[2].Input(parametersIn);
            cameraTransAction[2].OutPut(ref parametersOut);
            //insert,update 的结果 parametersOut 都应该为 1
            if (parametersOut[0][0] == macro.affected0Row)
            {
                //如果没有更新成功
                return macro.failed;
            }       
            return macro.succeed;
        }

        public void Query_issue_record(ref  List<string[]> result)
        {
             Clear();
            parameter_in = new string[] { "null" };
            parametersIn.Add(parameter_in);
            //加入入参列表中
            queryTransAction[0].Input(parametersIn);
            //得到出参列表
            queryTransAction[0].OutPut(ref parametersOut);
            result = parametersOut;
        }

        public void Query_recpt_record(ref  List<string[]> result)
        {
            Clear();
            parameter_in = new string[] { "null" };
            parametersIn.Add(parameter_in);
            //加入入参列表中
            queryTransAction[1].Input(parametersIn);
            //得到出参列表
            queryTransAction[1].OutPut(ref parametersOut);
            result = parametersOut;
        }

    
        
        private void Clear()
        {
            parametersIn.Clear();
            parametersOut.Clear();
        }
    }
}
