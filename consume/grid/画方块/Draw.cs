using System;
using System.Collections.Generic;
using System.Drawing;

using System.Text;
using System.Windows.Forms;

namespace ToDraw
{
    class Draw
    {
        public virtual void draw(int drawX, int drawY, int drawWidth, int drawHeight, Graphics drawG)
        {

        }
        public virtual void draw(Rectangle r, Graphics g)
        {

        }
        public virtual void draw(string name, Font font, Rectangle r, Graphics g)
        {

        }
    }
    class DrawRectButton : Draw
    {
        public DrawRectButton()
        {
        }
        public override void draw(int drawX, int drawY, int drawWidth, int drawHeight, Graphics drawG)
        {
            ControlPaint.DrawButton(drawG, drawX, drawY, drawWidth, drawHeight, ButtonState.Flat);
        }
        public override void draw(Rectangle r, Graphics g)
        {
            draw(r.X, r.Y, r.Width, r.Height, g);
        }
    }
    class DrawStringButton : Draw
    {
        public override void draw(string name, Font font, Rectangle r, Graphics g)
        {
            g.DrawString(name, font, Brushes.Red, r.X, r.Y);
        }
    }
    //  [3/8/2015 lht]写文本
    class DrawText : Draw
    {
        public override void draw(string name, Font font, Rectangle r, Graphics g)
        {
            DrawStringWrap(g, font, name, new Rectangle(r.X,r.Y,r.Width,r.Height/2));
        }
        private void DrawStringWrap(Graphics graphic, Font font, string text, Rectangle recangle)
        {
            List<string> textRows = GetStringRows(graphic, font, text, recangle.Width);
            int rowHeight = (int)(Math.Ceiling(graphic.MeasureString("测试", font).Height));
            int maxRowCount = recangle.Height / rowHeight;
            int drawRowCount = (maxRowCount < textRows.Count) ? maxRowCount : textRows.Count;
            int top = (recangle.Height - rowHeight * drawRowCount) / 2;
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Near;
            sf.LineAlignment = StringAlignment.Center;
            for (int i = 0; i < drawRowCount; i++)
            {
                Rectangle fontRectanle = new Rectangle(recangle.Left, top + rowHeight * i, recangle.Width, rowHeight);
                graphic.DrawString(textRows[i], font, new SolidBrush(Color.Black), fontRectanle, sf);
            }
        }
        /// <summary>
        /// 将文本分行
        /// </summary>
        /// <param name="graphic">绘图图面</param>
        /// <param name="font">字体</param>
        /// <param name="text">文本</param>
        /// <param name="width">行宽</param>
        /// <returns></returns>
        private List<string> GetStringRows(Graphics graphic, Font font, string text, int width)
        {
            int RowBeginIndex = 0;
            int rowEndIndex = 0;
            int textLength = text.Length;
            List<string> textRows = new List<string>();

            for (int index = 0; index < textLength; index++)
            {
                rowEndIndex = index;
                if (index == textLength - 1)
                {
                    textRows.Add(text.Substring(RowBeginIndex));
                }
                else if (rowEndIndex + 1 < text.Length && text.Substring(rowEndIndex, 2) == "\r\n")
                {
                    textRows.Add(text.Substring(RowBeginIndex, rowEndIndex - RowBeginIndex));
                    rowEndIndex = index += 2;
                    RowBeginIndex = rowEndIndex;
                }
                else if (graphic.MeasureString(text.Substring(RowBeginIndex, rowEndIndex - RowBeginIndex + 1), font).Width > width)
                {
                    textRows.Add(text.Substring(RowBeginIndex, rowEndIndex - RowBeginIndex));
                    RowBeginIndex = rowEndIndex;
                }
            }

            return textRows;
        }
    }

}
   
