using System;
using System.Windows.Forms;
namespace Tool
{
    public class ControlTool
    {
        //切换焦点
        public void Focus(Control c)
        {
            c.Focus();
        }
        //可用
        public void Edit(TextBox c, bool t = true)
        {
            c.ReadOnly = !t;
        }
        //设为空
        public void Empty(Control c)
        {
            c.Text = "";
        }
        //可用
        public void Enable(TextBox c)
        {
            Edit(c, true);
            Focus(c);
        }
    }
}
