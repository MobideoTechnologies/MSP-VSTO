using RoundTextBoxProject.Extensions;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace ProjectAddIn3.Controls
{
    public partial class SubProjectsControl : UserControl
    {
        private int _radius = 10;
        private float _borderWidth = 1.0f;
        private SolidBrush _backgroundBrush = new SolidBrush(SystemColors.Control);
        private Color _backgroundColor = SystemColors.Control;
        private Color _borderColor = SystemColors.GrayText;
        private Pen _borderPen = new Pen(ControlPaint.Light(SystemColors.GrayText, 0.0f), 0);
        public int Radius
        {
            get { return _radius; }
            set
            {
                _radius = value;
                Invalidate();
            }
        }
        public Color BackgroundColor
        {
            get { return _backgroundColor; }
            set
            {
                _backgroundBrush = new SolidBrush(_backgroundColor = value);
                Invalidate();
            }
        }

        public Color BorderColor
        {
            get { return _borderColor; }
            set
            {
                _borderColor = value;
                _borderPen = new Pen(ControlPaint.Light(_borderColor, 0.0f), _borderWidth);
                Invalidate();
            }
        }

        public float BorderWidth
        {
            get { return _borderWidth; }
            set
            {
                _borderWidth = value;
                _borderPen = new Pen(ControlPaint.Light(_borderColor, 0.0f), _borderWidth);
                Invalidate();
            }
        }

        private void drawBorder(Graphics g) =>
            g.DrawRoundedRectangle(_borderPen, 10, 10, Width - 20, Height - 20, _radius);

        private void drawBackground(Graphics g) =>
                    g.FillRoundedRectangle(_backgroundBrush, 10, 10, Width - 20, Height - 20, _radius);


        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            drawBorder(g);
            drawBackground(g);
        }
        public SubProjectsControl()
        {
            InitializeComponent();
        }

        private void SubProjectsControl_Load(object sender, System.EventArgs e)
        {

        }
    }
}
