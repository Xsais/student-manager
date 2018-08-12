using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace student_manager.ui.functionality
{
    public partial class ConfirmBox : UserControl
    {
        private double _opacity = 1;

        public Action<bool> Response { private get; set; }

        public string Title { get => lblText.Text; set => lblText.Text = value; }

        [TypeConverter(typeof(OpacityConverter))]
        public double Opacity
        {
            get => _opacity; set
            {
                if (value < 0 || value > 1 || _opacity == value)
                {
                    return;
                }
                
                lblDarken.BackColor = Color.FromArgb((int)(value * 255), lblDarken.BackColor.R, lblDarken.BackColor.G, lblDarken.BackColor.B);
                _opacity = value;
            }
        }

        public void ShowDialog(string title, Action<bool> fallBack)
        {
            Response = fallBack;
            Title = title;
            Visible = true;
        }

        public ConfirmBox()
        {
            InitializeComponent();
        }

        private void Accepted(object sender, EventArgs e)
        {
            Response?.Invoke(true);

            Response = null;
            Visible = false;
        }

        private void Reject(object sender, EventArgs e)
        {
            Response?.Invoke(false);

            Response = null;
            Visible = false;
        }
    }
}
