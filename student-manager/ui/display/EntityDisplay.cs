/**
 * File: EntityDisplay.cs
 * Assignment: Final_Project
 * Creation date: August 6, 2018
 * Last Modified: August 14, 2018
 * Description: Displays a single entity to the scren
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

namespace student_manager.ui.display
{
    public partial class EntityDisplay : UserControl
    {
        public string Header
        {
            get => lblheader.Text;
            set => lblheader.Text = value;
        }

        public string SubHeading
        {
            get => lblSub.Text;
            set => lblSub.Text = value;
        }

        public string Additional
        {
            get => lblAdditional.Text;
            set => lblAdditional.Text = value;
        }

        public string Flags
        {
            get => lblTag.Text;
            set => lblTag.Text = value;
        }

        /// <summary>
        /// Init and creaates the neccesary controls
        /// </summary>
        public EntityDisplay()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Allows the fields to trigger the click event
        /// </summary>
        /// <param name="sender">The sending object</param>
        /// <param name="e">The sending event arguments</param>
        private void ClickTrough(object sender, EventArgs e) => OnClick(e);


        /// <summary>
        /// Allows the fields to trigger the doubleclick event
        /// </summary>
        /// <param name="sender">The sending object</param>
        /// <param name="e">The sending event arguments</param>
        private void DoubleClickThrough(object sender, EventArgs e) => OnDoubleClick(e);
    }
}