using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hypocycloid
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = this.CreateGraphics();

            // hypotrochoid
            double R = 50.0;
            double r = 20.0;
            double d = 30.0;
            Pen pen = new Pen(Color.Red, 1.0f);
            double k = 0.2; // 1 / number of "fronds"
            double l = 2.5;

            double midx = this.ClientRectangle.Width / 2.0;
            double midy = this.ClientRectangle.Height / 2.0;
            double prevx = double.NaN;
            double prevy = double.NaN;

            for (double theta = 0.0; theta < Math.PI * 2.0; theta += Math.PI / 180.0)
            {
                //               double x = (R + r) * Math.Cos(theta) + d * Math.Cos(((R + r) / r) * theta);
                //               double y = (R + r) * Math.Sin(theta) + d * Math.Sin(((R + r) / r) * theta);
                double x = midx + 50.0 * ((1 - k) * Math.Cos(theta) + l * k * Math.Cos(((1 - k) / k) * theta));
                double y = midy + 50.0 * ((1 - k) * Math.Sin(theta) - l * k * Math.Sin(((1 - k) / k) * theta));

                //graphics.DrawEllipse(pen, (float)(midx + x - 1.0), (float)(midy + y - 1.0), (float)2.0, (float)2.0);
                if (prevx != double.NaN)
                {
                    graphics.DrawLine(pen, (float)prevx, (float)prevy, (float)x, (float)y);
                }
                prevx = x;
                prevy = y;
            }
        }
    }
}
