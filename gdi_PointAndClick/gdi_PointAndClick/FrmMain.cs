using System.Collections.Generic; // benötigt für Listen

namespace gdi_PointAndClick
{
    public partial class FrmMain : Form
    {
        List<Rectangle> rectangles = new List<Rectangle>();
        Random rectSize = new Random();
        int maxRectSize = 250;
        int minRectSize = 15;

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
            Brush b = new SolidBrush(Color.Lavender);


            for (int i = 0; i < rectangles.Count; i++)
            {
                g.FillRectangle(b, rectangles[i]);
            }

        }

        private void FrmMain_MouseClick(object sender, MouseEventArgs e)
        {
            Point mp = e.Location;
            int rectangleSize = rectSize.Next(minRectSize, maxRectSize);

            Rectangle r = new Rectangle(mp.X - rectangleSize /2, mp.Y - rectangleSize /2, rectangleSize , rectangleSize);
            foreach (Rectangle rectangle in rectangles)
            {
                if (rectangle.IntersectsWith(r))
                {
                    return;
                }
            }
            rectangles.Add(r);  // Kurze Variante: rectangles.Add( new Rectangle(...)  );

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
    }
}