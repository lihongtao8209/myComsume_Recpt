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

        public issue_name_itemNo()
        {
            InitializeComponent();
        }

        public string Item_no
        {
            get
            {
                return m_item_no;
            }
        }

        public List<string[]> consume_items_supplier_result
        {
            get;
            set;
        }

        private void comb_name_itemNo_KeyDown(object sender, KeyEventArgs e)
        {
            //输入品名或者货号 
            if (e.KeyCode == Keys.Enter)
            {

            }
            else
            {


            }
        }

        private void comb_name_itemNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            /*
            Debug.WriteLine(e.KeyChar);
            //1.如果从开始是数字
            doCheck.toCheck(Tools.CheckKey.StrTypeCheck, Tools.StrTypeCheck_Value.onlyDigit, e.KeyChar.ToString());
            if (doCheck.doCheck_Result.IsStrTypeCheck_Result==true)
            {
                return;
            }
            //2.如果从开始是字母
            doCheck.toCheck(Tools.CheckKey.StrTypeCheck, Tools.StrTypeCheck_Value.onlyAlphabet, e.KeyChar.ToString());
            if (doCheck.doCheck_Result.IsStrTypeCheck_Result==true)
            {
                return;
            }
            doCheck.toCheck(Tools.CheckKey.StrTypeCheck,Tools.StrTypeCheck_Value.onlyChineseIdeograph,e.KeyChar.ToString());
            //3.如果从开始是汉字
            if (doCheck.doCheck_Result.IsStrTypeCheck_Result==true)
            {
                return;
            }
            */
        }

        private void comb_name_itemNo_TextChanged(object sender, EventArgs e)
        {
          //  comb_name_itemNo.DroppedDown = true;
          //  comb_name_itemNo.Items.Clear();
            RemoveAll();
         //   doCheck.toCheck(Tools.CheckKey.StrTypeCheck, Tools.StrTypeCheck_Value.onlyDigit, comb_name_itemNo.Text.ToString());
          //  if (doCheck.doCheck_Result.IsStrTypeCheck_Result == true)
            {
                for (int i = 0; i < consume_items_supplier_result.Count;i++ )
                {
                    if (consume_items_supplier_result[i][0].Contains(comb_name_itemNo.Text))
                    {
                        comb_name_itemNo.Items.Add(consume_items_supplier_result[i][0]);
                      
                    }
                }
            }
     //       comb_name_itemNo.DroppedDown = false;
        }
        private void RemoveAll()
        {
            for (int i = 0; i < comb_name_itemNo.Items.Count;i++ )
            {
                comb_name_itemNo.Items.RemoveAt(i);
            }
        }
    }
}
