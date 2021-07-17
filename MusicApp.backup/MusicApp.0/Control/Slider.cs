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
    public partial class Slider : UserControl
    {
        public float Value { get; set; }

        public event EventHandler SliderValueChanged;
        public Slider()
        {
            InitializeComponent();
        }

        private void Slider_MouseDown(object sender, MouseEventArgs e)
        {
            Value = e.X * 100 / Width;

            OnSliderValueChange(new EventArgs());

            Invalidate();
        }

        private void OnSliderValueChange(EventArgs e)
        {
            SliderValueChanged?.Invoke(this, e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            int w = (int)(Width * Value / 100);

            e.Graphics.Clear(Color.Transparent);
            e.Graphics.DrawRectangle(Pens.Purple, 0, 0, Width - 1, Height - 1);
            e.Graphics.FillRectangle(Brushes.Purple, 0, 0, w, Height);
        }
    }
}
