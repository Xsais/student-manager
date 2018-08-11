using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using student_manager.info;

namespace student_manager.ui.functionality
{
    public partial class ErrorTextBox : UserControl
    {
        public override string Text
        {
            get => txtText.Text;
            set => txtText.Text = value;
        }

        public Color ErrorColor
        {
            get => _errorColor;
            set
            {
                if (Status == Status.Error)
                {
                    lblNotifications.BackColor = value;
                }

                _errorColor = value;
            }
        }

        public Color StatusColor
        {
            get => _statusColor;
            set
            {
                if (Status == Status.Normal)
                {
                    lblNotifications.BackColor = value;
                }

                _statusColor = value;
            }
        }

        public String PlaceHolder
        {
            get => lblPlace.Text;
            set => lblPlace.Text = value;
        }

        public Color PlaceColor
        {
            get => lblPlace.ForeColor;
            set => lblPlace.ForeColor = value;
        }

        public Status Status
        {
            get => _status;
            set
            {
                switch (value)
                {
                    case Status.Error:

                        lblNotifications.BackColor = ErrorColor;
                        break;
                    case Status.Normal:

                        lblNotifications.BackColor = StatusColor;
                        break;
                }

                _status = value;
            }
        }

        public new EventHandler TextChanged;
        private Status _status;
        private string _placeHolder;
        private Color _placeColor = SystemColors.GrayText;
        private Color _errorColor = Color.FromArgb(183, 28, 28);
        private Color _statusColor = Color.Black;

        public ErrorTextBox()
        {
            InitializeComponent();

            Status = Status.Normal;
        }

        private void InProgress(object sender, EventArgs e)
        {
            lblPlace.Text = string.IsNullOrWhiteSpace(txtText.Text) ? "" : PlaceHolder;

            TextChanged?.Invoke(sender, e);
        }
    }
}