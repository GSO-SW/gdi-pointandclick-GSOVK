using System.Collections;
using System.Collections.Generic;

namespace gdi_PointAndClick
{
    public partial class FrmMain : Form
    {
        static List<Rectangle> rectangles = new List<Rectangle>();
        readonly Random rectSize = new Random();
        readonly int maxRectSize = 80;
        readonly int minRectSize = 15;
        bool isDraggingRectangle = false;
        int selectedRectIndex = -1;
        Point clickOffset;

        public FrmMain()
        {
            InitializeComponent();
            ResizeRedraw = true;
            DoubleBuffered = true;
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
                if ((rect.Size.Width % 2) == 0)
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
            if (isDraggingRectangle) { return; }
            int rectangleSize = rectSize.Next(minRectSize, maxRectSize);

            Point mp = e.Location;
            int posX = mp.X - rectangleSize / 2;
            int posY = mp.Y - rectangleSize / 2;

            Rectangle r = new Rectangle(posX, posY, rectangleSize, rectangleSize);

            if (e.Button == MouseButtons.Right)
            {
                List<int> deleteIndex = new List<int>();
                for (int i = rectangles.Count - 1; i >= 0; i--)
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

        private void FrmMain_DragDrop(object sender, DragEventArgs e)
        {
        }

        private void FrmMain_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int i;
                for (i = 0; i < rectangles.Count; i++)
                {
                    if (rectangles[i].Contains(e.Location.X, e.Location.Y))
                    {
                        isDraggingRectangle = true;
                        selectedRectIndex = i;
                        clickOffset = new Point(e.Location.X - rectangles[i].X, e.Location.Y - rectangles[i].Y);
                    }
                }
            }
        }

        private void FrmMain_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDraggingRectangle && selectedRectIndex != -1)
            {
                Rectangle r = rectangles[selectedRectIndex];

                Point point = new Point(e.X - clickOffset.X, e.Y - clickOffset.Y);
                rectangles[selectedRectIndex] = new Rectangle(point, r.Size);
                Invalidate();
            }
        }

        private void FrmMain_MouseUp(object sender, MouseEventArgs e)
        {
            isDraggingRectangle = false;
            selectedRectIndex = -1;
        }
    }
}