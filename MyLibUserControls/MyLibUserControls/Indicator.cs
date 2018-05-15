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
    public partial class Indicator : UserControl
    {
        private float[] _sin = new float[360];
        private float[] _cos = new float[360];
        private int _value = 0;
        private int _maxValue = 100;

        [Browsable(true)]
        public ArrIndicatorMode IndicatorMode { get; set; } = ArrIndicatorMode.Full;

        [Browsable(true)]
        public Color ColorArrow { get; set; }

        [Browsable(true)]
        public Color ColorScale { get; set; }

        [Browsable(true)]
        public int MinValue { get; set; }

        [Browsable(true)]
        public int MaxValue
        {
            get => _maxValue;
            set => _maxValue = value <= MinValue ? MinValue : value;
        }

        [Browsable(true)]
        public int Value
        {
            get => _value;
            set
            {
                _value = value < MinValue || value > MaxValue ? MinValue : value;
                Invalidate();
            }
        }
        public Indicator()
        {
            InitializeComponent();

            for (int i = 0; i < 360; ++i)
            {
                _sin[i] = (float)Math.Sin(i * Math.PI / 180.0F);
                _cos[i] = (float)Math.Cos(i * Math.PI / 180.0F);
            }

        }

        private void Indicator_Load(object sender, EventArgs e)
        {

        }

        private void Indicator_Paint(object sender, PaintEventArgs e)
        {
            if (IndicatorMode == ArrIndicatorMode.Full)
            {
                FullIndicator(e);
            }
            else if (IndicatorMode == ArrIndicatorMode.Left)
            {
                LeftIndicator(e);
            }
            else
            {
                RightIndicator(e);
            }
        }

        public enum ArrIndicatorMode
        {
            Right, Left, Full
        }

        private void FullIndicator(PaintEventArgs e)
        {
            Graphics gr = e.Graphics;
            PointF centerPoint = new PointF((ClientSize.Width / 2.0F), ClientSize.Height - 10);
            float radius = ClientSize.Width > ClientSize.Height * 2 ? ClientSize.Height : ClientSize.Width / 2;

            for (int i = 0; i <= 100; i += 10)
            {
                float angleScale = 180F * (i / 100F) + 180F;
                float r = radius;
                PointF point1 = new PointF(centerPoint.X + (r - (r * 0.1F)) * _cos[(int)angleScale % 360], centerPoint.Y + (r - (r * 0.1F)) * _sin[(int)angleScale % 360]);
                PointF point2 = new PointF(centerPoint.X + (r - (r * 0.3F)) * _cos[(int)angleScale % 360], centerPoint.Y + (r - (r * 0.3F)) * _sin[(int)angleScale % 360]);
                gr.DrawLine(new Pen(ColorScale, 5), point1, point2);
            }

            var getProcent = (float)(((float)Value - (float)MinValue) * 100F) / ((float)MaxValue - (float)MinValue);

            float angle = 180F * (getProcent / 100F) + 180F;
            PointF pointArrow = new PointF(centerPoint.X + radius * _cos[(int)angle % 360], centerPoint.Y + radius * _sin[(int)angle % 360]);

            gr.DrawLine(new Pen(ColorArrow, 6), centerPoint, pointArrow);
            gr.FillEllipse(new SolidBrush(ColorArrow), centerPoint.X - 10, centerPoint.Y - 10, 20, 20);
            gr.DrawEllipse(new Pen(ColorScale, 5), centerPoint.X - radius, centerPoint.Y - radius, radius * 2, radius * 2);
        }

        private void LeftIndicator(PaintEventArgs e)
        {
            Graphics gr = e.Graphics;
            PointF centerPoint = new PointF(10, ClientSize.Height - 10);
            float radius = ClientSize.Width > ClientSize.Height ? ClientSize.Height : ClientSize.Width;

            for (int i = 0; i <= 100; i += 10)
            {
                float angleScale = 90F * (i / 100F) + 270F;
                float r = radius;
                PointF point1 = new PointF(centerPoint.X + (r * 0.75F) * _cos[(int)angleScale % 360], centerPoint.Y + (r * 0.75F) * _sin[(int)angleScale % 360]);
                PointF point2 = new PointF(centerPoint.X + (r * 0.6F) * _cos[(int)angleScale % 360], centerPoint.Y + (r * 0.6F) * _sin[(int)angleScale % 360]);
                gr.DrawLine(new Pen(ColorScale, 5), point1, point2);
            }

            gr.DrawLine(new Pen(ColorScale, 5), centerPoint, new PointF(centerPoint.X, centerPoint.Y - radius * 0.9F));
            gr.DrawLine(new Pen(ColorScale, 5), centerPoint, new PointF(centerPoint.X + radius * 0.9F, centerPoint.Y));
            gr.DrawEllipse(new Pen(ColorScale, 5), centerPoint.X - (radius * 0.9F), centerPoint.Y - (radius * 0.9F), (radius * 0.9F) * 2, (radius * 0.9F) * 2);
            var getProcent = (float)(((float)Value - (float)MinValue) * 100F) / ((float)MaxValue - (float)MinValue);

            float angle = 90F * (getProcent / 100F) + 270F;
            PointF pointArrow = new PointF(centerPoint.X + radius * 0.8F * _cos[(int)angle % 360], centerPoint.Y + radius * 0.8F * _sin[(int)angle % 360]);

            gr.DrawLine(new Pen(ColorArrow, 6), centerPoint, pointArrow);
            gr.FillEllipse(new SolidBrush(ColorArrow), centerPoint.X - 10, centerPoint.Y - 10, 20, 20);
        }

        private void RightIndicator(PaintEventArgs e)
        {
            Graphics gr = e.Graphics;

            PointF centerPoint = new PointF(ClientSize.Width - 10, ClientSize.Height - 10);

            float radius = ClientSize.Width > ClientSize.Height ? ClientSize.Height : ClientSize.Width;


            for (int i = 0; i <= 100; i += 10)
            {
                float angleScale = 90F * (i / 100F) + 180F;
                float r = radius;
                PointF point1 = new PointF(centerPoint.X + (r * 0.75F) * _cos[(int)angleScale % 360], centerPoint.Y + (r * 0.75F) * _sin[(int)angleScale % 360]);
                PointF point2 = new PointF(centerPoint.X + (r * 0.6F) * _cos[(int)angleScale % 360], centerPoint.Y + (r * 0.6F) * _sin[(int)angleScale % 360]);
                gr.DrawLine(new Pen(ColorScale, 5), point1, point2);
            }

            gr.DrawLine(new Pen(ColorScale, 5), centerPoint, new PointF(centerPoint.X, centerPoint.Y - radius * 0.9F));
            gr.DrawLine(new Pen(ColorScale, 5), centerPoint, new PointF(centerPoint.X - radius * 0.9F, centerPoint.Y));

            gr.DrawEllipse(new Pen(ColorScale, 5), centerPoint.X - radius * 0.9F, centerPoint.Y - radius * 0.9F,
                radius * 0.9F * 2, radius * 0.9F * 2);
            var getProcent = (float)(((float)Value - (float)MinValue) * 100F) / ((float)MaxValue - (float)MinValue);

            float angle = 90F * (getProcent / 100F) + 180F;
            PointF pointArrow = new PointF(centerPoint.X + radius * 0.8F * _cos[(int)angle % 360], centerPoint.Y + radius * 0.8F * _sin[(int)angle % 360]);

            gr.DrawLine(new Pen(ColorArrow, 6), centerPoint, pointArrow);
            gr.FillEllipse(new SolidBrush(ColorArrow), centerPoint.X - 10, centerPoint.Y - 10, 20, 20);
        }

        private void timerIndicator_Tick(object sender, EventArgs e)
        {
            Invalidate();
        }
    }
}
