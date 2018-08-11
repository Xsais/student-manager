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
        private bool _shownPlaceHolder;

        public override string Text
        {
            get => string.Equals(txtText.Text, PlaceHolder) ? "" : txtText.Text;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {

                    ShowPlaceHolder(this, EventArgs.Empty);
                    return;
                }

                HidePlaceHolder(this, EventArgs.Empty);
                txtText.Text = value;
            }
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
            get => _placeHolder;
            set
            {
                if (_shownPlaceHolder)
                {
                    txtText.Text = value;
                }

                _placeHolder = value;
            }
        }

        public Color PlaceColor
        {
            get => _placeColor;
            set
            {
                if (_shownPlaceHolder)
                {
                    txtText.ForeColor = value;
                }

                _placeColor = value;
            }
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
            _shownPlaceHolder = string.IsNullOrWhiteSpace(txtText.Text);
            TextChanged?.Invoke(sender, e);
        }

        private void HidePlaceHolder(object sender, EventArgs e)
        {
            if (!_shownPlaceHolder)
            {
                return;
            }

            txtText.Text = "";
            txtText.ForeColor = ForeColor;
        }

        private void ShowPlaceHolder(object sender, EventArgs e)
        {
            if (!_shownPlaceHolder)
            {
                return;
            }

            txtText.Text = PlaceHolder;
            txtText.ForeColor = PlaceColor;
        }
    }
}