using System;
using System.Windows.Forms;
namespace Tool
{
    public class ControlTool
    {
        //�л�����
        public void Focus(Control c)
        {
            c.Focus();
        }
        //����
        public void Edit(TextBox c, bool t = true)
        {
            c.ReadOnly = !t;
        }
        //��Ϊ��
        public void Empty(Control c)
        {
            c.Text = "";
        }
        //����
        public void Enable(TextBox c)
        {
            Edit(c, true);
            Focus(c);
        }
    }
}
