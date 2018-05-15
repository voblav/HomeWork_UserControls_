using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyLibUserControls
{
    public partial class AnalogClock : UserControl
    {
        private float[] _sin = new float[360];
        private float[] _cos = new float[360];

        private Color colArrYell = Color.Yellow;
        private Color colArrGreen = Color.Green;
        private Color colArrRed = Color.YellowGreen;
        private int timeZoner = 2;
        public AnalogClock()
        {
            InitializeComponent();
            for (int i = 0; i < 360; ++i)
            {
                _sin[i] = (float)Math.Sin(i * Math.PI / 180.0F);
                _cos[i] = (float)Math.Cos(i * Math.PI / 180.0F);
            }
        }

        private void AnalogClock_Load(object sender, EventArgs e)
        {

        }

        private void AnalogClock_Paint(object sender, PaintEventArgs e)
        {
            Graphics gr = e.Graphics;

            PointF centerPoint = new PointF(ClientSize.Width / 2.0F, ClientSize.Height / 2.0F);
            float radius = ClientSize.Width > ClientSize.Height ? ClientSize.Height / 2 - 20 : ClientSize.Width / 2 - 20;

            int angle = DateTime.Now.Second * 6 + 270;
            int angleMin = DateTime.Now.Minute * 6 + 270;
            int angleHour = (DateTime.Now.Hour - 2 + timeZoner) * 30 + 270;

            for (int i = 1; i < 13; ++i)
            {
                string dig = i.ToString();
                SizeF sd = gr.MeasureString(dig, this.Font);
                PointF rp = new PointF(centerPoint.X + (radius + 10) * _cos[(i * 30 + 270) % 360] - sd.Width / 2, centerPoint.Y + (radius + 10) * _sin[(i * 30 + 270) % 360] - sd.Height / 2);
                gr.DrawString(dig, this.Font, new SolidBrush(Color.Black), rp);
            }

            PointF endPointSec = new PointF(centerPoint.X + radius * _cos[angle % 360], centerPoint.Y + radius * _sin[angle % 360]);
            PointF endPointMin = new PointF(centerPoint.X + (radius - 15) * _cos[angleMin % 360], centerPoint.Y + (radius - 15) * _sin[angleMin % 360]);
            PointF endPointHour = new PointF(centerPoint.X + (radius - 30) * _cos[angleHour % 360], centerPoint.Y + (radius - 30) * _sin[angleHour % 360]);
            gr.DrawLine(new Pen(colArrYell, 4), centerPoint, endPointHour);    //hour.arrow
            gr.DrawLine(new Pen(colArrYell, 3), centerPoint, endPointMin);
            gr.DrawLine(new Pen(colArrYell, 2), centerPoint, endPointSec);
            gr.FillEllipse(new SolidBrush(colArrYell), centerPoint.X - 10, centerPoint.Y - 10, 20, 20);
        }

        private void TimerClock_Tick(object sender, EventArgs e)
        {
            Invalidate();
        }
    }
}
