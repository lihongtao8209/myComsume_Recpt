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
                 
            }
            catch (System.Exception ex)
            {
            	
            }
        }
      

     
    }
}
