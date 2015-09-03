using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using ToDraw;

namespace DrawSomething
{
    class DrawButtons
    {
        //控件的数目
        protected const int subControlNum = 80;
        public virtual void toDraw(Rectangle rect, ref  Draw rectdraw, Graphics drawG)
        {

        }
        public void draw(int boundWidth, int boundHeight, Rectangle[] rects, ref Draw rectdraw, Graphics drawG)
        {
            Bitmap bitmap = new Bitmap(boundWidth, boundHeight);
            Graphics graphics2 = Graphics.FromImage(bitmap);
            for (int i = 0; i < subControlNum; i++)
            {
                toDraw(rects[i], ref rectdraw, graphics2);
            }
            drawG.DrawImage(bitmap, 0, 0);
        }

        public void draw(Size boundSize, Rectangle[] rects, ref Draw rectdraw, Graphics drawG)
        {
            draw(boundSize.Width, boundSize.Height, rects, ref rectdraw, drawG);
        }
        public void draw(string[] name,Font[] font,Size boundSize, Rectangle[][] rects, ref Draw[] rectdraw, Graphics drawG)
        {
            Bitmap bitmap = new Bitmap(boundSize.Width, boundSize.Height);
            Graphics graphics2 = Graphics.FromImage(bitmap);
            for (int i = 0; i < subControlNum; i++)
            {
                rectdraw[0].draw(rects[0][i], drawG);
               // name[i] = string.Format("{0:D3}", i + 1);
               // rectdraw[1].draw(name[i],font[1],rects[1][i], drawG);
            }
            drawG.DrawImage(bitmap, 0, 0);
        }
    }
    class DrawRectButtons :DrawButtons
    {
        
         public override void toDraw(Rectangle rect, ref /*DrawRectButton*/Draw rectdraw, Graphics drawG)
        {
            rectdraw.draw(rect, drawG);
        }
    }
    class  DrawRectAndStrings : DrawButtons
    {

        private void DrawStringWrap(Graphics graphic, Font font, string text, Rectangle recangle)
        {   //在recangle的中间开始画文字
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
