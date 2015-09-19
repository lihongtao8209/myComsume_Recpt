using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using Check;
using Macro;
using myException;
using issue_recpt_Consume;
using Tool;
namespace issueConsume
{

    public partial class issue : UserControl
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
        IssueHelper issueHelper = new IssueHelper();
        //
        DoCheck doCheck = new DoCheck();
        //
        ControlTool controlTool = new ControlTool();


        public string Item_no
        {
            get
            {
                return m_item_no;
            }
        }

        public issue()
        {
            InitializeComponent();
        }

        private void t_barcode_KeyDown(object sender, KeyEventArgs e)
        {//RF枪扫描 手动输入回车
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    //检查
                    Check_barcode();
                    //查询
                    Query_barcode();
                    //显示
                    ShowInfo();
                }
                catch (IAmCheckException ex)
                {   //清空
                    controlTool.Empty(t_barcode);
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void Query_barcode()
        {
            //输入条码
            issueHelper.Query0(t_barcode.Text, ref m_item_no, ref m_item_type, ref m_item_name);
            //查询实时库存
            issueHelper.Query1(m_item_no, ref m_realtime_stock);
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

            doCheck.Check(t_barcode.Text, checkDic);
        }

        private void issue_Load(object sender, EventArgs e)
        {
            controlTool.Focus(t_barcode);
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
                    controlTool.Enable(t_barcode);
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

        private void insert_update_issueItemQty()
        {
            int result = macro.failed;
            result = issueHelper.insert_update(m_item_no, m_item_name, m_item_type, t_shoppeName.Text, m_realtime_stock,m_issueItemQty);
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
        //
        private void ShowInfo()
        {
            if (m_item_name != "")
            {
                t_name.Text = m_item_name;
            }

            if (m_realtime_stock != "")
            {
                t_stock.Text = m_realtime_stock;
            }

            if (m_item_type == macro.isShoppeGood)
            {//专柜商品
                controlTool.Focus(t_shoppeName);
                controlTool.Edit(t_shoppeName);
            }
            else
            {
                //发货数量显示焦点
                controlTool.Focus(t_issueItemQty);
                //可编辑
                controlTool.Edit(t_issueItemQty);
            }
        }


        private void t_shoppeName_KeyDown(object sender, KeyEventArgs e)
        {//输入专柜商品名
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    //不为空
                    doCheck.toCheck(CheckKey.IsNullCheckStr, CheckStr_Vlaue.shoppeName, t_shoppeName.Text);
                    //最大为33个字符
                    doCheck.toCheck(CheckKey.MaxDigitCheck, MaxDigitCheck_Value.name, t_shoppeName.Text);
                    //不可辑编
                    //Edit(t_shoppeName, false);
                    //转移焦点
                    controlTool.Enable(t_issueItemQty);
                }
                catch (IAmCheckException ex)
                {
                    MessageBox.Show(ex.Message);
                    controlTool.Empty(t_shoppeName);
                }

            }
        }


    }
}
