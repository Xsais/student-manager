/**
 * File: SearchBox.cs
 * Assignment: Final_Project
 * Creation date: August 6, 2018
 * Last Modified: August 14, 2018
 * Description: Crates a visual search box
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

namespace student_manager.ui.functionality
{
    public partial class SearchBox : UserControl
    {
        public EventHandler Searched;

        public override string Text
        {
            get => txtSearchBox.Text;
            set => txtSearchBox.Text = value;
        }

        public SearchBox()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Ocurs when the user searches
        /// </summary>
        /// <param name="sender">The sending object</param>
        /// <param name="e">The sending arguments</param>
        private void Search(object sender, EventArgs e)
        {
            Searched?.Invoke(this, e);
        }

        /// <summary>
        /// Occurs when the user is typing
        /// </summary>
        /// <param name="sender">The sending object</param>
        /// <param name="e">The sending arguments</param>
        private void Searching(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(Text))
            {
                if (picSearch.Visible)
                {
                    picSearch.Visible = false;
                    pcExit.Visible = true;
                }
            }
            else
            {
                picSearch.Visible = true;
                pcExit.Visible = false;
            }
        }

        /// <summary>
        /// Clears the current search
        /// </summary>
        /// <param name="sender">The sending object</param>
        /// <param name="e">The sending arguments</param>
        private void ClearSearch(object sender, EventArgs e)
        {
            txtSearchBox.Text = "";
            Searched?.Invoke(this, e);
        }
    }
}