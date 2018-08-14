/**
 * File: ErrorTextBox.cs
 * Assignment: Final_Project
 * Creation date: August 6, 2018
 * Last Modified: August 14, 2018
 * Description: Handles a material text box
 *
 * Group Members:
 *    - Emily Ramanna
 *    - James Grau
 *    - Nathaniel Primo
**/

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
        private string _errorText;

        public override string Text
        {
            get => txtText.Text;
            set => txtText.Text = value;
        }

        public string DisplayName { get; set; }

        public string ErrorText
        {
            get => _errorText;
            set
            {
                if (Status == Status.Error)
                {
                    lblPlace.Text = value;
                }

                _errorText = value;
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
                    lblPlace.ForeColor = value;
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

        private string _placeText;

        public String PlaceHolder
        {
            get => _placeText;
            set
            {
                if (Status == Status.Normal)
                {
                    lblPlace.Text = value;
                }

                _placeText = value;
            }
        }

        private Color _placeColor;

        public Color PlaceColor
        {
            get => _placeColor;
            set
            {
                if (Status == Status.Normal)
                {
                    lblPlace.ForeColor = value;
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

                        lblPlace.Text = _errorText;
                        lblPlace.ForeColor = ErrorColor;
                        break;
                    case Status.Normal:

                        lblNotifications.BackColor = StatusColor;

                        lblPlace.Text = _placeText;
                        lblPlace.ForeColor = _placeColor;
                        break;
                }

                _status = value;
            }
        }

        public new EventHandler TextChanged;
        private Status _status;
        private Color _errorColor = Color.FromArgb(183, 28, 28);
        private Color _statusColor = Color.Black;

        public ErrorTextBox()
        {
            InitializeComponent();

            Status = Status.Normal;
        }

        /// <summary>
        /// Occurs when the user is currently typing
        /// </summary>
        /// <param name="sender">The sending object</param>
        /// <param name="e">The sending arguments</param>
        private void InProgress(object sender, EventArgs e)
        {
            lblPlace.Visible = string.IsNullOrEmpty(txtText.Text);

            TextChanged?.Invoke(sender, e);
        }

        /// <summary>
        /// Allows the addition of addition text
        /// </summary>
        /// <param name="sender">The sending object</param>
        /// <param name="e">The sending arguments</param>
        private void StartProgress(object sender, EventArgs e)
        {
            txtText.Focus();
        }
    }
}