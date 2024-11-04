using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Tracing;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quan_Ly_Ban_Thuoc.UserCtrl_Custom
{
    public partial class RoundedButton : Button
    {
        private int _borderRadius = 20;
        private Color _borderColor = Color.Black;
        private Color _buttonColor = Color.LightBlue;
        private Color _textColor = Color.White;
        private Image _icon;
        private string _buttonText = "Rounded Button";
        private Color _hoverButtonColor = Color.CornflowerBlue;
        private bool _isHovered;
        // Properties for customization
        public int BorderRadius
        {
            get { return _borderRadius; }
            set
            {
                _borderRadius = value;
                Invalidate(); // Redraw the control when the border radius changes
            }
        }

        public Color BorderColor
        {
            get { return _borderColor; }
            set
            {
                _borderColor = value;
                Invalidate();
            }
        }

        public Color ButtonColor
        {
            get { return _buttonColor; }
            set
            {
                _buttonColor = value;
                Invalidate();
            }
        }

        public Color TextColor
        {
            get { return _textColor; }
            set
            {
                _textColor = value;
                Invalidate();
            }
        }
        public Image Icon
        {
            get { return _icon; }
            set
            {
                _icon = value;
                this.Invalidate();  // Vẽ lại khi giá trị thay đổi
            }
        }
        public Color HoverButtonColor // Thuộc tính cho màu hover
        {
            get { return _hoverButtonColor; }
            set
            {
                _hoverButtonColor = value;
                this.Invalidate();
            }
        }

        public string ButtonText
        {
            get { return _buttonText; }
            set
            {
                _buttonText = value;
                Invalidate();
            }
        }

        public RoundedButton()
        {
            this.Size = new Size(150, 50);
            this.Paint += new PaintEventHandler(RoundedButton_Paint);
            this.MouseEnter += RoundedButton_MouseEnter;
            this.MouseLeave += RoundedButton_MouseLeave;
        }

        private void RoundedButton_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
            _isHovered = true;

        }

        private void RoundedButton_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
            _isHovered = false;
        }
        private void Container_BackColorChanged(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        private void RoundedButton_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // Create rounded rectangle
            GraphicsPath path = new GraphicsPath();
            path.AddArc(new Rectangle(0, 0, _borderRadius, _borderRadius), 180, 90);
            path.AddArc(new Rectangle(this.Width - _borderRadius - 1, 0, _borderRadius, _borderRadius), 270, 90);
            path.AddArc(new Rectangle(this.Width - _borderRadius - 1, this.Height - _borderRadius - 1, _borderRadius, _borderRadius), 0, 90);
            path.AddArc(new Rectangle(0, this.Height - _borderRadius - 1, _borderRadius, _borderRadius), 90, 90);
            path.CloseFigure();
            Color currentButtonColor = _isHovered ? _hoverButtonColor : _buttonColor;
            // Fill button background
            using (SolidBrush brush = new SolidBrush(currentButtonColor))
            {
                graphics.FillPath(brush, path);
            }


            // Draw border
            using (Pen pen = new Pen(_borderColor, 2))
            {
                graphics.DrawPath(pen, path);
            }

            // Draw text

            if (_icon != null)
            {
                int iconSize = this.Height - 5;  // Căn chỉnh kích thước icon so với chiều cao button
                Rectangle iconRect = new Rectangle(7, 5, iconSize, iconSize);  // Căn trái icon
                graphics.DrawImage(_icon, iconRect);

                // Thay đổi vị trí vẽ văn bản dựa trên biểu tượng
                int textX = iconRect.Right + 5; // Bắt đầu từ bên phải của biểu tượng
                Rectangle textRect = new Rectangle(textX, 0, this.Width - textX, this.Height);
                TextRenderer.DrawText(graphics, _buttonText, this.Font, textRect, _textColor, TextFormatFlags.VerticalCenter | TextFormatFlags.Left);
            }
            else
            {
                Rectangle textRect = new Rectangle(0, 0, this.Width, this.Height); // Chiếm toàn bộ diện tích của control
                TextRenderer.DrawText(graphics, _buttonText, this.Font, textRect, _textColor, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
            }


        }
    }
}
