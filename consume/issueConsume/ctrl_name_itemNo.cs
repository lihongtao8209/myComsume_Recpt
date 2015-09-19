using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Tool;
using Tools;
namespace issue_recpt_Consume
{

    public partial class ctrl_name_itemNo : UserControl
    {
        public delegate void Del_ctrl_name_itemNo(object sender, object e);
        public event Del_ctrl_name_itemNo Event_ctrl_name_itemNo_KeyDown;
        public event Del_ctrl_name_itemNo Event_ctrl_name_itemNo_List_Selected;
        Tools.DoCheck doCheck = new Tools.DoCheck();
        bool notCheck = false;
        //判断输入的是货号,还是品名
        public int inPutType
        {
            get;
            set;
        }
        public string inPutData
        {
            get
            {
                return t_name_itemNo.Text;
            }
        }
        public ctrl_name_itemNo()
        {
            InitializeComponent();
            this.Height = this.t_name_itemNo.Height;
        }

        public List<string[]> consume_items_supplier_result
        {
            get;
            set;
        }

        public void Enable_TextBox()
        {
            t_name_itemNo.Enabled = true;
            t_name_itemNo.Focus();
            t_name_itemNo.SelectAll();
        }
        public void Enable_ListBox()
        {
            lb_result.SelectedItem = lb_result.Items[0];
            lb_result.Focus();
        }

        public void Empty_ListBox()
        {
            t_name_itemNo.Text = "";
        }

        protected void Expand(bool isExpand = true)
        {
            if (isExpand==true)
            {
                this.Height = this.t_name_itemNo.Height + this.lb_result.Height;
            }
            else
            {
                this.Height = this.t_name_itemNo.Height;
            }
        }
        private void t_name_itemNo_TextChanged(object sender, EventArgs e)
        {
            if (consume_items_supplier_result == null)
                return;
            lb_result.Items.Clear();
            //1.如果是数字
            if (notCheck == false)
            {
                doCheck.toCheck(Tools.CheckKey.StrTypeCheck, Tools.StrTypeCheck_Value.onlyDigit, t_name_itemNo.Text);
                if (doCheck.doCheck_Result.IsStrTypeCheck_Result == true)
                {
                    inPutType = Tools.macro.isInputItemNo;
                    for (int i = 0; i < consume_items_supplier_result.Count; i++)
                    {
                        if (consume_items_supplier_result[i][0].StartsWith(t_name_itemNo.Text))
                        {
                            this.lb_result.Items.Add(consume_items_supplier_result[i][1]);
                        }
                    }

                }
                //2.如果从开始是字母
                doCheck.toCheck(Tools.CheckKey.StrTypeCheck, Tools.StrTypeCheck_Value.onlyAlphabet, t_name_itemNo.Text);
                if (doCheck.doCheck_Result.IsStrTypeCheck_Result == true)
                {
                    inPutType = Tools.macro.isInputItemNo;
                    for (int i = 0; i < consume_items_supplier_result.Count; i++)
                    {
                        //获得道路名称各汉字拼音首字母缩写
                        string strName = (Tools.ChineseSpell.GetChineseSpell(consume_items_supplier_result[i][1])).ToLower();
                        string strtxtName = Tools.ChineseSpell.GetChineseSpell(t_name_itemNo.Text.ToLower()).ToLower();
                        //根据拼音进行匹配（利用Contain和Substring函数进行判定）            
                        if (strName.Contains(strtxtName))
                        {
                            this.lb_result.Items.Add(consume_items_supplier_result[i][1]);
                        }
                    }
                }
                doCheck.toCheck(Tools.CheckKey.StrTypeCheck, Tools.StrTypeCheck_Value.onlyChineseIdeograph, t_name_itemNo.Text);
                //3.如果从开始是汉字
                if (doCheck.doCheck_Result.IsStrTypeCheck_Result == true)
                {
                    inPutType = Tools.macro.isInputItemName;
                    for (int i = 0; i < consume_items_supplier_result.Count; i++)
                    {
                        if (consume_items_supplier_result[i][1].Contains(t_name_itemNo.Text))
                        {
                            this.lb_result.Items.Add(consume_items_supplier_result[i][1]);
                        }
                    }
                }
            }
            if (this.lb_result.Items.Count == 0)
            {
                this.Height = this.t_name_itemNo.Height;
                //throw new IAmctrl_name_itemNo(t_name_itemNo.Text + " 输入的内容不正确");
            }
            else
            {
                this.Height = this.t_name_itemNo.Height + this.lb_result.Height;
            }

        }



        private void lb_result_MouseClick(object sender, MouseEventArgs e)
        {
            int index = lb_result.IndexFromPoint(e.X, e.Y);
            lb_result.SelectedIndex = index;
            if (lb_result.SelectedIndex != -1)
            {
                t_name_itemNo.Text = lb_result.SelectedItem.ToString();
                t_name_itemNo.SelectionStart = t_name_itemNo.TextLength;
                this.Height = this.t_name_itemNo.Height;
                notCheck = true;
                if (Event_ctrl_name_itemNo_List_Selected != null)
                {
                    Event_ctrl_name_itemNo_List_Selected(sender, e);
                }
            }
        }

        private void t_name_itemNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                doCheck.toCheck(Tools.CheckKey.IsNullCheckStr, Tools.CheckStr_Vlaue.inputData, t_name_itemNo.Text);
                notCheck = false;
                if (Event_ctrl_name_itemNo_KeyDown!=null)
                {
                    Event_ctrl_name_itemNo_KeyDown(sender, e);
                }
            }

            if (e.KeyCode == Keys.Back)
            {
                notCheck = false;
            }

            if (e.KeyCode == Keys.Down)
            {
                if (lb_result.Items[0]!=null)
                {
                    Enable_ListBox();
                }
            }
        }

        private void lb_result_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                t_name_itemNo.Text = lb_result.SelectedItem.ToString();
                t_name_itemNo.Focus();
                Expand(false);
                if (Event_ctrl_name_itemNo_List_Selected != null)
                {
                    Event_ctrl_name_itemNo_List_Selected(sender, e);
                }
            }
        }

        private void ctrl_name_itemNo_Leave(object sender, EventArgs e)
        {
            MessageBox.Show("1");
        }





    }
}
