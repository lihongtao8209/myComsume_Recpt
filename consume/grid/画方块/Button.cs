using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Button
{
    class Button
    {
        //控件的数目
        protected const int subControlNum = 80;
        protected const int subCtlNumPerRow = 10;
        //每一行控件的数目
        //宽
        protected int width = 70;
        //高
        protected int height = 100/4;
        //间隔宽
        protected int swidth = 22;
        //间隔高
        protected int sheight = 14;
        //起始X坐标
        protected int locationX = 8;
        //起始Y坐标
        protected int locationY = 17;
        //button的位置
        protected Point[] bAllLocation=new Point[subControlNum];
        protected Rectangle[] regs = new Rectangle[subControlNum];
        public Button()
        {

            InitButton();
        }
        //宽高,间隔宽高,XY坐标
        public virtual void Init(int _width, int _height, int _swidth, int _sheight, int _locationX, int _locationY)
        {
            width = _width;
            height = _height;
            swidth = _swidth;
            sheight = _sheight;
            locationX = _locationX;
            locationY = _locationY;
        }
        public virtual void Init()
        {

        }
        public virtual void InitButton()
        {
            for (int i = 0; i < subControlNum; i++)
            {
                InitLocalations(i);
                InitOthers(i);
            }
        }

        protected void InitLocalations(int i)
        {
            bAllLocation[i] = new Point(locationX + (width + swidth) * (i % subCtlNumPerRow), locationY + (height + sheight) * (i / subCtlNumPerRow));
        }
        protected virtual void InitOthers(int i)
        {

        }

    }
    class RectButton : Button
    {
        public Rectangle[] Regs
        {
            get { return regs; }
        }

        protected override void InitOthers(int i)
        {
            regs[i] = new Rectangle(bAllLocation[i].X, bAllLocation[i].Y, width, height);
        }
    }
    class ScaleButton :RectButton
    {
        protected Rectangle[] oraginalRegs = new Rectangle[subControlNum];
        public ScaleButton()
        {
            for (int i = 0; i < oraginalRegs.Length; i++)
            {
                regs[i] = oraginalRegs[i];
            }
        }
        protected override void InitOthers(int i)
        {
            oraginalRegs[i] = new Rectangle(bAllLocation[i].X, bAllLocation[i].Y, width, height);
        }
        protected float scaleRateX
        {
            get;
            set;
        }
        protected float scaleRateY
        {
            get;
            set;
        }
        protected void Scale(float rateX,float rateY)
        {
            scaleRateX = rateX;
            scaleRateY = rateY;
        }

        protected void Calc()
        {
            int len=regs.Length;
            for (int i=0;i<len;i++)
            {
                regs[i].X = (int)(oraginalRegs[i].X * scaleRateX);
                regs[i].Y = (int)(oraginalRegs[i].Y * scaleRateY);
                regs[i].Width = (int)(oraginalRegs[i].Width * scaleRateX);
                regs[i].Height = (int)(oraginalRegs[i].Height * scaleRateY);
            }
        }
        public void CalcScale(float rateX, float rateY)
        {
            Scale(rateX,rateY);
            Calc();
        }
        public void CalcScale(float rateX, float rateY, float rateWidth, float rateHeight)
        {
            int len = regs.Length;
            for (int i = 0; i < len; i++)
            {
                regs[i].X = (int)(oraginalRegs[i].X * rateX);
                regs[i].Y = (int)(oraginalRegs[i].Y * rateY);
                regs[i].Width = (int)(oraginalRegs[i].Width * rateWidth);
                regs[i].Height = (int)(oraginalRegs[i].Height * rateHeight);
            }
        }
    }

    class StringButton : Button
    {
        public Rectangle[] Regs
        {
            get { return regs; }
        }
    }
    class ScaleStringButton : StringButton
    {
        float FontSize = 9.0f;
        Font font ;
        public Point[] Location
        {
            get { return bAllLocation; }
        }
        public ScaleStringButton()
        {
            font = new Font("SimSun", FontSize);
            Size textSize = TextRenderer.MeasureText("000", font);
            for (int i = 0; i < regs.Length; i++)
            {
                bAllLocation[i].X = bAllLocation[i].X +(width-textSize.Width)/2;
                bAllLocation[i].Y = bAllLocation[i].Y + height + 1;
                regs[i].Location = bAllLocation[i];
                regs[i].Width = textSize.Width;
                regs[i].Height = textSize.Height;
            }

        }
        public void CalcScale(Rectangle[] Regs, float scale,ref Font font)
        {
            try
            {
                float scaleFontSize = scale * FontSize;
                font = new Font("SimSun", (int)(scaleFontSize + 0.5f));
                Size textSize = TextRenderer.MeasureText("000", font);
                for (int i = 0; i < Regs.Length; i++)
                {
                    bAllLocation[i].X = Regs[i].X + (Regs[i].Width - textSize.Width) / 2;
                    bAllLocation[i].Y = Regs[i].Y + Regs[i].Height + 1;
                    regs[i].Location = bAllLocation[i];
                    regs[i].Width = textSize.Width;
                    regs[i].Height = textSize.Height;
                }
            }
            catch (System.Exception ex)
            {
            	
            }
            
        }
    }
}
