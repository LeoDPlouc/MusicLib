using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TagLib.Asf;

namespace MusicLib.Control
{
    public partial class Play_Button : Button
    {
        Pen pen;
        Brush brush;

        public event EventHandler<PlayButtonEventArgs> StateChanged;

        public PlayButtonEventArgs.States State { get { return play ? PlayButtonEventArgs.States.Play : PlayButtonEventArgs.States.Pause; } }

        private bool hover;
        private bool play;

        public Play_Button()
        {
            InitializeComponent();

            pen = new Pen(Brushes.Purple, 1);
            brush = Brushes.Purple;

            play = false;
            hover = false;
        }

        public void ChangeState()
        {
            ForceChangeState();
            OnStateChange(new PlayButtonEventArgs { State = play ? PlayButtonEventArgs.States.Play : PlayButtonEventArgs.States.Pause });
        }
        public void ForceChangeState()
        {
            play = !play;
            Invalidate();
        }
        public void Play()
        {
            ForcePlay();
            OnStateChange(new PlayButtonEventArgs { State = PlayButtonEventArgs.States.Play });
        }
        public void ForcePlay()
        {
            play = true;
            Invalidate();
        }
        public void Pause()
        {
            ForcePause();
            OnStateChange(new PlayButtonEventArgs { State = PlayButtonEventArgs.States.Pause });
        }
        public void ForcePause()
        {
            play = false;
            Invalidate();
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

        private void Play_Button_MouseClick(object sender, MouseEventArgs e)
        {
            ChangeState();
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {

            base.OnPaint(pevent);
            var g = pevent.Graphics;
            g.Clear(Color.Transparent);

            if (play) DrawPause(g);
            else DrawPlay(g);
            
        }
        protected void OnStateChange(PlayButtonEventArgs e)
        {
            StateChanged?.Invoke(this, e);
        }

        private void DrawPlay(Graphics g)
        {
            var points = new Point[]
            {
                new Point(0, 0),
                new Point(DisplayRectangle.Width, DisplayRectangle.Height /2),
                new Point(0, DisplayRectangle.Height)
            };

            if (hover) g.FillPolygon(brush, points);
            else g.DrawPolygon(pen, points);
        }
        private void DrawPause(Graphics g)
        {
            var r1 = new Rectangle(0, 0, DisplayRectangle.Width / 3 - 1, DisplayRectangle.Height - 1);
            var r2 = new Rectangle(2 * DisplayRectangle.Width / 3, 0, DisplayRectangle.Width / 3 - 1, DisplayRectangle.Height - 1);

            if(hover)
            {
                g.FillRectangle(brush, r1);
                g.FillRectangle(brush, r2);
            }
            else
            {
                g.DrawRectangle(pen, r1);
                g.DrawRectangle(pen, r2);
            }
        }
    }

    public class PlayButtonEventArgs : EventArgs
    {
        public enum States
        {
            Play = 0,
            Pause = 1
        }

        public States State { get; set; }
    }
}
