using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClockControlLibrary
{
    public partial class Clock : UserControl
    {
        [Browsable(true)]
        [Category("Design")]
        [Editor("Color", "Color")]
        [DefaultValue(typeof(Color), "DarkBlue")]
        public Color ArrowColorHour { get; set; } = Color.DarkBlue;


        [Browsable(true)]
        [Category("Design")]
        [Editor("Color", "Color")]
        [DefaultValue(typeof(Color), "DarkBlue")]
        public Color ArrowColorMinute { get; set; } = Color.DarkBlue;

        [Browsable(true)]
        [Category("Design")]
        [Editor("Color", "Color")]
        [DefaultValue(typeof(Color), "DarkBlue")]
        public Color ArrowColorSecond { get; set; } = Color.DarkBlue;


        float[] sin = new float[360];
        float[] cos = new float[360];
        PointF centerPoint;
        int baseRadius;
        float scaleUnit;
        public Clock()
        {
            InitializeComponent();

            for (int i = 0; i < 360; ++i)
            {
                sin[i] = (float)Math.Sin(i * Math.PI / 180.0);
                cos[i] = (float)Math.Cos(i * Math.PI / 180.0);
            }
          
        }

        private void Clock_Paint(object sender, PaintEventArgs e)
        {
           scaleUnit = ClientRectangle.Width > ClientRectangle.Height ?
                  ClientRectangle.Height / 260F : ClientRectangle.Width / 284F;

            baseRadius = ClientRectangle.Width > ClientRectangle.Height ?
                ClientRectangle.Height / 2 - 20 : ClientRectangle.Width / 2 - 20;
            centerPoint = new PointF(ClientRectangle.Width / 2,
                ClientRectangle.Height / 2);

            baseRadius -= 20;
            float sizeNum = scaleUnit * 10F;

            Font = new Font(Font.Name, sizeNum);


            Graphics gr = e.Graphics;
            GraphicsPath path = new GraphicsPath();
            path.AddEllipse(new RectangleF(
                centerPoint.X - baseRadius + 2,
                centerPoint.Y - baseRadius + 2,
                baseRadius * 2 - 4,
                baseRadius * 2 - 4));

            Brush brush = new PathGradientBrush(path)
            {
                CenterColor = Color.White,
                CenterPoint = new PointF(centerPoint.X + (baseRadius + scaleUnit * 10) * cos[(360 + 270) % 360],
                centerPoint.Y + (baseRadius + scaleUnit * 10) * sin[(360 + 270) % 360] + 18),
             
                SurroundColors = new Color[] {
                  Color.LightGray,  Color.LightSkyBlue,Color.PowderBlue,
                Color.LightGray,Color.LightSkyBlue,Color.PowderBlue,
                Color.LightGray,Color.LightSkyBlue,Color.PowderBlue,
                Color.LightGray,Color.LightSkyBlue,Color.LightBlue
               }
            };

            gr.FillPath(brush, path);

            gr.DrawEllipse(new Pen(Color.DarkCyan, scaleUnit * 2F), new RectangleF(
                centerPoint.X - baseRadius + 2,
                centerPoint.Y - baseRadius + 2,
                baseRadius * 2 - 4,
                baseRadius * 2 - 4));


            for (int i = 1; i < 13; ++i)
            {
                string str = i.ToString();
                SizeF size = gr.MeasureString(str, Font);

                gr.DrawString(str, Font, Brushes.DarkBlue,
                    new PointF(
                    centerPoint.X + (baseRadius + scaleUnit * 10) * cos[(i * 30 + 270) % 360] - size.Width / 2,
                    centerPoint.Y + (baseRadius + scaleUnit * 10) * sin[(i * 30 + 270) % 360] - size.Height / 2));

            }
            DrawLine(gr, 3F, 13,2,  10,30);
            DrawLine( gr, 1F, 61,2,  8, 6);
          
            DateTime dt = DateTime.Now;

            DrawArrow(gr, new Pen(ArrowColorSecond, 1 * scaleUnit), baseRadius - 10, dt.Second * 6 + 270);
            DrawArrow(gr, new Pen(ArrowColorMinute, 3 * scaleUnit), baseRadius - 20, dt.Minute * 6 + 270);
            DrawArrow(gr, new Pen(ArrowColorHour, 5 * scaleUnit), baseRadius - 30, (dt.Hour % 12) * 30 + dt.Minute / 2 + 270);

        }

        void DrawLine(Graphics gr, float size,int num,int length1, int length2,int angle)
        {
            for (int i = 1; i < num; i++)
            {
                gr.DrawLine(new Pen(Color.DarkBlue, size),
                         new PointF(
                centerPoint.X + (baseRadius-length1 * scaleUnit) * cos[(i * angle) % 360],
                centerPoint.Y + (baseRadius-length1 * scaleUnit) * sin[(i * angle) % 360]),

                   new PointF(
                centerPoint.X + (baseRadius-length2 * scaleUnit) * cos[(i * angle) % 360],
                centerPoint.Y + (baseRadius-length2 * scaleUnit) * sin[(i * angle) % 360]));

            }


        }
        void DrawArrow(Graphics gr, Pen pen, int length, int angle)
        {
            gr.DrawLine(pen,
                centerPoint, new PointF(
                    centerPoint.X + length * cos[angle % 360],
                    centerPoint.Y + length * sin[angle % 360]));

        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            Invalidate();
        }

        private void AnalogClock_Load(object sender, EventArgs e)
        {

        }
    }
}
