using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Macro;
using Check;
using issue_recpt_Consume;
using Tool;
using myException;

namespace recptConsume
{
    public partial class recpt_name_itemNo : UserControl
    {
        //代理
        public delegate void Del_recpt_ItemNo();
        //事件
        public event Del_recpt_ItemNo Event_recpt_ItemNo;
        //货号
        string m_item_no = macro.nullValue;
        //品名
        string m_item_name = macro.nullValue;
        //实时库存
        string m_realtime_stock = macro.nullValue;
        //发货数量
        string m_recptItemQty = macro.nullValue;
        //
        Tools.DoCheck doCheck = new Tools.DoCheck();
        //
        SQL_FLOW.IssueHelper issueHelper = new SQL_FLOW.IssueHelper();
        //
        ControlTool controlTool = new ControlTool();
        public recpt_name_itemNo()
        {
            InitializeComponent();
            ctrl_name_itemNo1.Event_ctrl_name_itemNo_KeyDown += new ctrl_name_itemNo.Del_ctrl_name_itemNo(ctrl_name_itemNo_KeyDown);
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
        public void ctrl_name_itemNo_KeyDown(object sender, object e)
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
                ctrl_name_itemNo1.Empty_ListBox();
            }
            catch (Tools.IAmMySqlException ex)
            {
                MessageBox.Show(ex.Message);
                //清空
                ctrl_name_itemNo1.Empty_ListBox();
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



        private void t_barcode_KeyDown(object sender, KeyEventArgs e)
        {//扫描条码
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    //查询
                    Query_barcode();
                    //显示
                    ShowInfo();
                }
                catch (myException.IAmCheckException ex)
                {   //清空
                    // controlTool.Empty(t_name_itemNo);
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void t_recptItemQty_KeyDown(object sender, KeyEventArgs e)
        {//收货数量
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    //检查
                    check_recptItemQty();
                    //计算实时库存
                    calcRealTimeStock_recptItemQty();
                    //判断只能为数字
                    //插入 货号,品名,数量,专柜名称,插入时间
                    //插入,更新
                    insert_update_recptItemQty();
                    //不可辑编
                    controlTool.Edit(t_recptItemQty, false);
                    //发送事件
                    Event_recpt_ItemNo();
                    //转移焦点
                    ctrl_name_itemNo1.Enable_TextBox();
                }
                catch (System.FormatException ex) { MessageBox.Show(ex.Message); }
                catch (System.OverflowException ex) { MessageBox.Show(ex.Message); }
                catch (IAmCheckException ex) { MessageBox.Show(ex.Message); }
                catch (IAmMySqlException ex) { reset_calcRealTimeStock_recptItemQty(); MessageBox.Show(ex.Message); }
                finally
                {
                    //清空
                    controlTool.Empty(t_recptItemQty);
                }

            }
        }

        private void Check_barcode()
        {
            Dictionary<int, int> checkDic = new Dictionary<int, int>();
            //不为空
            checkDic.Add(CheckKey.EmptyCheck, EmptyCheck_Value.notSetEmpty);
            //不能为空,只能为数字
            checkDic.Add(CheckKey.PreConditonCheck, PreConditonCheck_Value.onlyDigital);
            //大于8位
            checkDic.Add(CheckKey.MinDigitCheck, MinDigitCheck_Value.barCodeMinDigit);
            //小于13位
            checkDic.Add(CheckKey.MaxDigitCheck, MaxDigitCheck_Value.barCodeMaxDigit);

            doCheck.Check(ctrl_name_itemNo1.inPutData, checkDic);
        }

        private void Query_barcode()
        {
            //输入条码,查询货号
            //  issueHelper.Recpt_Query0(t_name_itemNo.Text, ref m_item_no);
            doCheck.toCheck(CheckKey.IsZeroCheckStr, CheckStr_Vlaue.itemNo, m_item_no);
            //查询 品名 实时库存
            issueHelper.Recpt_Query1(m_item_no, ref m_item_name, ref m_realtime_stock);
        }

        private void ShowInfo()
        {
            //商品名称
            if (m_item_name != "")
            {
                t_itemNo_name.Text = m_item_name;
            }
            //实时库存
            if (m_realtime_stock != "")
            {
                t_stock.Text = m_realtime_stock;
            }
            //货号
            t_spc.Text = m_item_no;

            //发货数量显示焦点
            controlTool.Focus(t_recptItemQty);
            //可编辑
            controlTool.Edit(t_recptItemQty);

        }

        private void check_recptItemQty()
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
            doCheck.Check(t_recptItemQty.Text, checkDic);
        }

        private void calcRealTimeStock_recptItemQty()
        {
            //收货量不应该输入0
            doCheck.toCheck(CheckKey.IsZeroCheckStr, CheckStr_Vlaue.realTimeStock, t_recptItemQty.Text);
            m_recptItemQty = t_recptItemQty.Text;
            //实时库存不能为空
            //doCheck.toCheck(CheckKey.IsNullCheckStr, CheckStr_Vlaue.realTimeStock, m_realtime_stock);
            int realtimeStock = Convert.ToInt32(m_realtime_stock) + Convert.ToInt32(m_recptItemQty);
            //实时库存只能是正数和0
            doCheck.toCheck(CheckKey.PreConditonCheck, PreConditonCheck_Value.onlyPostiveNumber, realtimeStock.ToString());
            m_realtime_stock = realtimeStock.ToString();
        }

        private void reset_calcRealTimeStock_recptItemQty()
        {
            int realtimeStock = Convert.ToInt32(m_realtime_stock) - Convert.ToInt32(m_recptItemQty);
            t_stock.Text = realtimeStock.ToString();
        }

        private void insert_update_recptItemQty()
        {
            int result = macro.failed;
            result = issueHelper.Recpt_insert_update(m_item_no, m_item_name, m_realtime_stock, t_recptItemQty.Text);
            if (result == macro.succeed)
            {
                t_stock.Text = m_realtime_stock;
            }
        }
    }
}
