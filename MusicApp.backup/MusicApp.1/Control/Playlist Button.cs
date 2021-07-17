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
    public partial class Playlist_Button : UserControl
    {
        Pen pen = new Pen(Brushes.Purple, 1);
        Brush brush = Brushes.Purple;
        bool hover = false;
        
        public bool On { get; set; }

        public Playlist_Button()
        {
            On = false;

            InitializeComponent(); 
        }

        private void Playlist_Button_Click(object sender, EventArgs e)
        {
            On = !On;
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

            drawPlaylist(g);
        }
        private void drawPlaylist(Graphics g)
        {
            var tri = new Point[]
            {
                new Point(0, 0),
                new Point(DisplayRectangle.Width/ 6, DisplayRectangle.Height / (2*7)),
                new Point(0, DisplayRectangle.Height / 7)
            };
            var r1 = new Rectangle(DisplayRectangle.Width / 6, DisplayRectangle.Y, 5 * DisplayRectangle.Width / 6 - 1, DisplayRectangle.Height / 7);
            var r2 = new Rectangle(DisplayRectangle.Width / 6, 2 * DisplayRectangle.Height / 7, 5 * DisplayRectangle.Width / 6 - 1, DisplayRectangle.Height / 7);
            var r3 = new Rectangle(DisplayRectangle.Width / 6, 4 * DisplayRectangle.Height / 7, 5 * DisplayRectangle.Width / 6 - 1, DisplayRectangle.Height / 7);
            var r4 = new Rectangle(DisplayRectangle.Width / 6, 6 * DisplayRectangle.Height / 7, 5 * DisplayRectangle.Width / 6 - 1, DisplayRectangle.Height / 7);

            if (hover)
            {
                g.FillPolygon(brush, tri);
                g.FillRectangle(brush, r1);
                g.FillRectangle(brush, r2);
                g.FillRectangle(brush, r3);
                g.FillRectangle(brush, r4);
            }
            else
            {
                g.DrawPolygon(pen, tri);
                g.DrawRectangle(pen, r1);
                g.DrawRectangle(pen, r2);
                g.DrawRectangle(pen, r3);
                g.DrawRectangle(pen, r4);
            }
        }
    }
}
