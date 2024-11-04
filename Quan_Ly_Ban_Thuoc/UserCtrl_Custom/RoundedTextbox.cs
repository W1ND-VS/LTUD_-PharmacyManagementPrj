using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Quan_Ly_Ban_Thuoc.UserCtrl_Custom

{
    [DefaultEvent("_TextChanged")]
    public partial class RoundedTextbox : UserControl
    {
        private Color BorderColor = Color.MediumSlateBlue;
        private int BorderSize = 2;
        private bool UnderLineStyle = false;
        private string PlaceholderText = "";
        private bool isPlaceholder = false;
        private Color PlaceholderColor = Color.White;



        public RoundedTextbox()
        {
            InitializeComponent();
            SetPlaceholder();
        }

        //Event
        public event EventHandler _TextChanged;



        public Color BorderColor1
        {
            get { return BorderColor; }
            set { BorderColor = value; this.Invalidate(); }
        }
        public int BorderSize1
        {
            get { return BorderSize; }
            set { BorderSize = value; this.Invalidate(); }
        }
        public bool UnderLineStyle1
        {
            get { return UnderLineStyle; }
            set { UnderLineStyle = value; this.Invalidate(); }
        }
        public bool PasswordChar
        {
            get { return textBox1.UseSystemPasswordChar; }
            set { textBox1.UseSystemPasswordChar = value; }
        }
        public bool Multiline
        {
            get { return textBox1.Multiline; }
            set { textBox1.Multiline = value; this.Invalidate(); }
        }

        public override Color BackColor
        {
            get { return base.BackColor; }
            set { base.BackColor = value; textBox1.BackColor = value; }
        }
        public override Color ForeColor { get { return base.ForeColor; } set { base.ForeColor = value; textBox1.ForeColor = value; this.Invalidate(); } }
        public override Font Font { get { return base.Font; } set { base.Font = value; textBox1.Font = value; if (this.DesignMode) UpdateControlHeight(); } }

        public string Texts
        {
            get
            {
                if (isPlaceholder) return "";
                else return textBox1.Text;
            }
            set
            {
                textBox1.Text = value;
                SetPlaceholder();
            }
        }

        public string PlaceholderText1
        {
            get { return PlaceholderText; }
            set
            {
                PlaceholderText = value;
                textBox1.Text = "";
                SetPlaceholder();
            }
        }
        public bool IsPlaceholder
        {
            get { return isPlaceholder; }
            set { isPlaceholder = value; }
        }
        public Color PlaceholderColor1
        {
            get { return PlaceholderColor; }
            set
            {
                PlaceholderColor = value;
                if (isPlaceholder)
                    textBox1.ForeColor = value;
            }
        }

        private void SetPlaceholder()
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) && PlaceholderText != "")
            {
                isPlaceholder = true;
                textBox1.Text = PlaceholderText;
                textBox1.ForeColor = PlaceholderColor;
            }
        }
        private void RemovePlaceholder()
        {
            if (isPlaceholder && PlaceholderText != "")
            {
                isPlaceholder = false;
                textBox1.Text = "";
                textBox1.ForeColor = this.ForeColor;

            }
        }


        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics gr = e.Graphics;
            GraphicsPath path = new GraphicsPath();
            using (Pen pen = new Pen(BorderColor1, BorderSize1))
            {
                pen.Alignment = System.Drawing.Drawing2D.PenAlignment.Inset;

                if (UnderLineStyle)
                {
                    gr.DrawLine(pen, 0, this.Height - 1, this.Width, this.Height - 1);
                }
                else
                {
                    gr.DrawRectangle(pen, 0, 0, this.Width - 0.5F, this.Height - 0.5F);
                }


            }

        }
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            if (this.DesignMode)
            {
                UpdateControlHeight();

            }

        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            UpdateControlHeight();
        }

        private void UpdateControlHeight()
        {
            if (textBox1.Multiline == false)
            {
                int txtheight = TextRenderer.MeasureText("text", this.Font).Height + 1;
                textBox1.Multiline = true;
                textBox1.MinimumSize = new Size(0, txtheight);
                textBox1.Multiline = false;

                this.Height = textBox1.Height + this.Padding.Top + this.Padding.Bottom;

            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (_TextChanged != null)
                _TextChanged(sender, e);
        }

 

    


        private void RoundedTextbox_Enter(object sender, EventArgs e)
        {
            this.Invalidate();
            RemovePlaceholder();
        }

        private void RoundedTextbox_Leave_1(object sender, EventArgs e)
        {
            this.Invalidate();
            SetPlaceholder();
        }
    }
}
