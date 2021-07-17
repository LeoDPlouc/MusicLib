using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MusicLib.Control
{
    public partial class Next_Button : UserControl
    {
        Pen pen = new Pen(Brushes.Purple, 1);
        Brush brush = Brushes.Purple;
        bool hover = false;

        public Next_Button()
        {
            InitializeComponent();
        }

        private void Play_Button_MouseLeave(object sender, EventArgs e)
        {
            hover = false;
            Invalidate();
        }

        private void Play_Button_MouseEnter(object sender, EventArgs e)
        {
            hover = true;
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {

            base.OnPaint(pevent);
            var g = pevent.Graphics;
            g.Clear(Color.Transparent);

            drawNext(g);
        }
        private void drawNext(Graphics g)
        {
            var tri = new Point[] 
            { 
                new Point(0, 0), 
                new Point(2 * DisplayRectangle.Width / 3, DisplayRectangle.Height / 2), 
                new Point(0, DisplayRectangle.Height) 
            };
            var r2 = new Rectangle(2 * DisplayRectangle.Width / 3, 0, DisplayRectangle.Width / 3 - 1, DisplayRectangle.Height - 1);

            if (hover)
            {
                g.FillPolygon(brush, tri);
                g.FillRectangle(brush, r2);
            }
            else
            {
                g.DrawPolygon(pen, tri);
                g.DrawRectangle(pen, r2);
            }
        }
    }
}
