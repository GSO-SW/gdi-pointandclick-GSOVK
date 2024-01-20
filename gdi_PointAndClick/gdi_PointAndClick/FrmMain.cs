using System.Collections;
using System.Collections.Generic;

namespace gdi_PointAndClick
{
    public partial class FrmMain : Form
    {
        List<Rectangle> rectangles = new List<Rectangle>();
        readonly Random rectSize = new Random();
        readonly int maxRectSize = 80;
        readonly int minRectSize = 15;

        public FrmMain()
        {
            InitializeComponent();
            ResizeRedraw = true;
        }

        private void FrmMain_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            int w = this.ClientSize.Width;
            int h = this.ClientSize.Height;

            Brush b1 = new SolidBrush(Color.Red);
            Brush b2 = new SolidBrush(Color.Green);
            Brush b3 = new SolidBrush(Color.Violet);

            foreach (Rectangle rect in rectangles)
            {
                if ((rect.X % 2) == 0)
                {
                    g.FillRectangle(b1, rect);
                }
                else
                {
                    g.FillRectangle(b2, rect);
                }

                foreach (Rectangle rectIntersect in rectangles)
                {
                    if (rectIntersect == rect) continue;
                    g.FillRectangle(b3, Rectangle.Intersect(rect, rectIntersect));
                }
            }
        }

        private void FrmMain_MouseClick(object sender, MouseEventArgs e)
        {
            int rectangleSize = rectSize.Next(minRectSize, maxRectSize);

            Point mp = e.Location;
            int posX = mp.X - rectangleSize / 2;
            int posY = mp.Y - rectangleSize / 2;

            Rectangle r = new Rectangle(posX, posY, rectangleSize, rectangleSize);

            if (e.Button == MouseButtons.Right)
            {
                List<int> deleteIndex = new List<int>();
                for (int i = rectangles.Count -1; i >= 0; i--)
                {
                    if (rectangles[i].Contains(mp.X, mp.Y))
                    {
                        rectangles.RemoveAt(i);
                    }
                }
                Refresh();
                return;
            }

            foreach (Rectangle rectangle in rectangles)
            {
                if (rectangle.Contains(mp.X, mp.Y))
                {
                    return;
                }
            }
            rectangles.Add(r);
            Refresh();
        }

        private void FrmMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                rectangles.Clear();
                Refresh();
            }
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {

        }
    }
}