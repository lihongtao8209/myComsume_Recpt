using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Button;
using ToDraw;
using DrawSomething;

namespace grid
{
    public partial class grid: UserControl
    {
        RectButton rectButton = new RectButton();
        ScaleButton scaleButton = new ScaleButton();
        Draw draw = new DrawRectButton();
        Draw draw1 = new DrawStringButton();
        DrawButtons draws = new DrawButtons();
        StringButton stringLabel = new StringButton();
        ScaleStringButton scaleStringButton = new ScaleStringButton();
        Font font = new Font("SimSun", 9.0f);
        Font[] fonts = new Font[2];
        Rectangle[][] rectsArray = new Rectangle[2][];
        Draw[] drawArray = new Draw[2];
        DrawText drawText = new DrawText();
        string[] name = new string[100];
        int FormWidth = 0;
        int FormHeight = 0;
        int FormScaleWidth = 0;
        int FormScaleHeight = 0;
        float rateWidth = 0;
        float rateHeight = 0;
        //PickBoxStatus[] pickBoxStatus = new PickBoxStatus[12];
        public grid()
        {
            InitializeComponent();
            FormWidth = this.Width;
            FormHeight = this.Height;
        }

        private void grid_Paint(object sender, PaintEventArgs e)
        {
            Font[] fonts = new Font[1];
            Rectangle[][] rectsArray = new Rectangle[1][];
            Draw[] drawArray = new Draw[1];

            drawArray[0] = draw;
           // drawArray[1] = draw1;
            rectsArray[0] = scaleButton.Regs;
            //rectsArray[1] = scaleStringButton.Regs;
            fonts[0] = this.font;
           // fonts[1] = font;
            draws.draw(name, fonts, this.ClientSize, rectsArray, ref drawArray, e.Graphics);
        }

        private void grid_Resize(object sender, EventArgs e)
        {
            FormScaleWidth = this.Width;
            FormScaleHeight = this.Height;
            rateWidth = FormScaleWidth * 1.0f / FormWidth * 1.0f;
            rateHeight = FormScaleHeight * 1.0f / FormHeight * 1.0f;
            scaleButton.CalcScale(rateWidth, rateHeight);
            scaleStringButton.CalcScale(scaleButton.Regs, Math.Min(rateWidth, rateHeight), ref font);
        }
    }
}
