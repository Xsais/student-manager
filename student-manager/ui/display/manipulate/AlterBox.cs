/**
 * File: AlterBox.cs
 * Assignment: Final_Project
 * Creation date: August 6, 2018
 * Last Modified: August 14, 2018
 * Description: Handles altering a specific entity
 *
 * Group Members:
 *    - Emily Ramanna
 *    - James Grau
 *    - Nathaniel Primo
**/

using student_manager.info;
using student_manager.info.entity;
using student_manager.info.opportunity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace student_manager.ui.display.manipulate
{
    public abstract partial class AlterBox : Form
    {
        protected Entity _entity;

        public Action Confirming;

        /// <summary>
        /// Allows for the approval of changes to be made
        /// </summary>
        /// <param name="confirmed">is the changes approved</param>
        public abstract void Confirm(bool confirmed = true);

        protected bool _isClean = true;

        protected abstract bool isValidID(string ID);

        public virtual Entity Entity
        {
            get => _entity;
            set
            {
                if (value == null || value == _entity)
                {
                    return;
                }

                switch (value)
                {
                    case Student _:

                        lblTitle.Text = value.IsEmpty() ? "New Student" : "Edit Student";

                        break;
                    case Professor _:

                        lblTitle.Text = value.IsEmpty() ? "New Professor" : "Edit Professor";

                        break;
                    case Course _:

                        lblTitle.Text = value.IsEmpty() ? "New Course" : "Edit Course";

                        break;
                    case info.opportunity.Program _:

                        lblTitle.Text = value.IsEmpty() ? "New Program" : "Edit Program";

                        break;
                }

                _entity = value;
            }
        }

        /// <summary>
        /// Init the box and needed controls
        /// </summary>
        protected AlterBox()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Allows the event to be raired when the user cancels the request
        /// </summary>
        /// <param name="sender">The sending object</param>
        /// <param name="e">The sending arguments</param>
        private void CancelRequested(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}