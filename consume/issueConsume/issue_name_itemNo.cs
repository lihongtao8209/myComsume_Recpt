using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using SQL_FLOW;
using Macro;
using Check;
using Tool;
using System.Diagnostics;

namespace issueConsume
{
    public partial class issue_name_itemNo : UserControl
    {
        //代理
        public delegate void Del_ItemNo();
        //事件
        public event Del_ItemNo Event_ItemNo;
        //货号
        string m_item_no = macro.nullValue;
        //品名
        string m_item_name = macro.nullValue;
        //类型
        string m_item_type = macro.nullValue;
        //实时库存
        string m_realtime_stock = macro.nullValue;
        //发货量
        string m_issueItemQty = macro.nullValue;
        //
        SQL_FLOW.IssueHelper issueHelper = new SQL_FLOW.IssueHelper();
        //
        Tools.DoCheck doCheck = new Tools.DoCheck();
        //
        ControlTool controlTool = new ControlTool();
        //
        public issue_name_itemNo()
        {
            InitializeComponent();
            ctrl_name_itemNo1.Event_ctrl_name_itemNo_KeyDown += new ctrl_name_itemNo.Del_ctrl_name_itemNo_KeyDown(ctrl_name_itemNo_KeyDown);
        }

        public string Item_no
        {
            get
            {
                return m_item_no;
            }
        }

        public void SetResult(ref List<string[]> result)
        {
            ctrl_name_itemNo1.consume_items_supplier_result = result;
        }

        //按下回车键
        public void ctrl_name_itemNo_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                //查询
                Query_name_itemNo();
                //显示
                ShowInfo();
            }
            catch (IAmCheckException ex)
            {
                MessageBox.Show(ex.Message);
                //清空
                controlTool.Empty(t_itemNo_name);
            }
            catch (Tools.IAmMySqlException ex)
            {
                MessageBox.Show(ex.Message);
                //清空
                controlTool.Empty(t_itemNo_name);
            }
            finally
            {

            }
        }

        private void Query_name_itemNo()
        {
            Query0();
            Query1();
        }
        private void Query1()
        {
            //查询实时库存
            issueHelper.Query1(m_item_no, ref m_realtime_stock);
        }
        private void Query0()
        {
            List<string[]> r = null;
            if (ctrl_name_itemNo1.inPutType == Tools.macro.isInputItemNo)
            {
                r = ctrl_name_itemNo1.consume_items_supplier_result.FindAll(s =>
                   {
                       if (s[0] == ctrl_name_itemNo1.inPutData)
                       {
                           return true;
                       }
                       return false;
                   }

               );
                if (r.Count != 1)
                {
                    throw new Tools.IAmMySqlException("得到的数据不正确" + r.Count.ToString());
                }
                l_name_itemNo.Text = "货号";
                l_itemNo_name.Text = "品名";
                t_itemNo_name.Text = r[0][1];
            }
            if (ctrl_name_itemNo1.inPutType == Tools.macro.isInputItemName)
            {
                r = ctrl_name_itemNo1.consume_items_supplier_result.FindAll(s =>
                {
                    if (s[1] == ctrl_name_itemNo1.inPutData)
                    {
                        return true;
                    }
                    return false;
                }

               );
                if (r.Count != 1)
                {
                    throw new Tools.IAmMySqlException("得到的数据不正确" + r.Count.ToString());
                }
                l_name_itemNo.Text = "品名";
                l_itemNo_name.Text = "货号";
                t_itemNo_name.Text = r[0][0];
            }
            t_spc.Text = r[0][2];
            m_item_name = r[0][1];
            m_item_no = r[0][0];
        }

        //
        private void ShowInfo()
        {
            if (m_realtime_stock != "")
            {
                t_stock.Text = m_realtime_stock;
            }

            //发货数量显示焦点
            controlTool.Focus(t_issueItemQty);
            //可编辑
            controlTool.Edit(t_issueItemQty);
        }

        //检查发货数量
        private void check_issueItemQty()
        {
            Dictionary<int, int> checkDic = new Dictionary<int, int>();
            //不为空
            checkDic.Add(CheckKey.EmptyCheck, EmptyCheck_Value.notSetEmpty);
            //正数,0,负数
            checkDic.Add(CheckKey.PreConditonCheck, PreConditonCheck_Value.onlyDigitalAndNegative);
            //大于1位
            checkDic.Add(CheckKey.MinDigitCheck, MinDigitCheck_Value.issueItemQtyDigit);
            //小于4位
            checkDic.Add(CheckKey.MaxDigitCheck, MaxDigitCheck_Value.issueItemQtyDigit);
            doCheck.Check(t_issueItemQty.Text, checkDic);
        }
        private void insert_update_issueItemQty()
        {
            int result = macro.failed;
            result = issueHelper.insert_update(m_item_no, m_item_name, m_item_type, "null", m_realtime_stock, m_issueItemQty);
            if (result == macro.succeed)
            {
                t_stock.Text = m_realtime_stock;
            }
        }
        private void calcRealTimeStock_issueItemQty()
        {
            //发货量不应该输入0
            doCheck.toCheck(CheckKey.IsZeroCheckStr, CheckStr_Vlaue.realTimeStock, t_issueItemQty.Text);
            m_issueItemQty = t_issueItemQty.Text;
            //实时库存不能为空
            doCheck.toCheck(CheckKey.IsNullCheckStr, CheckStr_Vlaue.realTimeStock, m_realtime_stock);
            int realtimeStock = Convert.ToInt32(m_realtime_stock) - Convert.ToInt32(m_issueItemQty);
            //实时库存只能是正数和0
            doCheck.toCheck(CheckKey.PreConditonCheck, PreConditonCheck_Value.onlyPostiveNumber, realtimeStock.ToString());
            m_realtime_stock = realtimeStock.ToString();
        }

        private void reset_calcRealTimeStock_issueItemQty()
        {
            int realtimeStock = Convert.ToInt32(m_realtime_stock) + Convert.ToInt32(m_issueItemQty);
            t_stock.Text = realtimeStock.ToString();
        }

        private void t_issueItemQty_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    //检查
                    check_issueItemQty();
                    //计算实时库存
                    calcRealTimeStock_issueItemQty();
                    //判断只能为数字
                    //插入 货号,品名,数量,专柜名称,插入时间
                    //插入,更新
                    insert_update_issueItemQty();
                    //不可辑编
                    controlTool.Edit(t_issueItemQty, false);
                    //发送事件
                    Event_ItemNo();
                    //转移焦点
                    controlTool.Enable(t_itemNo_name);
                }
                catch (System.FormatException ex) { MessageBox.Show(ex.Message); }
                catch (System.OverflowException ex) { MessageBox.Show(ex.Message); }
                catch (IAmCheckException ex) { MessageBox.Show(ex.Message); }
                catch (IAmMySqlException ex) { reset_calcRealTimeStock_issueItemQty(); MessageBox.Show(ex.Message); }
                finally
                {
                    //清空
                    controlTool.Empty(t_issueItemQty);
                }

            }
        }
    }
}
