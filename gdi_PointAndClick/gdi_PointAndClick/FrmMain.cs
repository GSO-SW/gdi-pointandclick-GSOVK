using System.Collections.Generic;

namespace gdi_PointAndClick
{
    public partial class FrmMain : Form
    {
        List<Rectangle> rectangles = new List<Rectangle>();
        Random rectColor = new Random();
        Random rectSize = new Random();
        int maxRectSize = 80;
        int minRectSize = 15;
        int numRect = 0;

        public FrmMain()
        {
            InitializeComponent();
            ResizeRedraw = true;
        }

        private void FrmMain_Paint(object sender, PaintEventArgs e)
        {
            // Hilfsvarablen
            Graphics g = e.Graphics;
            int w = this.ClientSize.Width;
            int h = this.ClientSize.Height;

            // Zeichenmittel
            Brush b1 = new SolidBrush(Color.Red);
            Brush b2 = new SolidBrush(Color.Green);

            for (int i = 0; i < rectangles.Count; i++)
            {
                if ((rectangles[i].X % 2) == 0)
                {
                    g.FillRectangle(b1, rectangles[i]);
                }
                else
                {
                    g.FillRectangle(b2, rectangles[i]);
                }
            }

        }

        private void FrmMain_MouseClick(object sender, MouseEventArgs e)
        {
            Point mp = e.Location;
            int rectangleSize = rectSize.Next(minRectSize, maxRectSize);

            Rectangle r = new Rectangle(mp.X - rectangleSize / 2, mp.Y - rectangleSize / 2, rectangleSize, rectangleSize);
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