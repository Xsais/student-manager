﻿/**
 * File: ClickableDisplay.cx
 * Assignment: Final_Project
 * Creation date: August 6, 2018
 * Last Modified: August 14, 2018
 * Description: Handles displaying a material button
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
    public partial class ClickableDisplay : UserControl
    {
        private bool _isSelected;

        public Color HighlightColor { get; set; } = SystemColors.Highlight;

        public Color UnderlineColor { get; set; } = Color.Black;

        public int UnderlineHight
        {
            get => lblUderLine.Height;
            set => lblUderLine.Height = value;
        }

        public Cursor Cursor
        {
            get => lblTitle.Cursor;
            set => lblTitle.Cursor = value;
        }

        public Color SelectionColor { get; set; } = SystemColors.Highlight;

        public bool IsSelected
        {
            get => _isSelected;
            set
            {
                _isSelected = value;
                if (UnderlineColor.Equals(SelectionColor))
                {
                    return;
                }

                if (!_isSelected)
                {
                    lblUderLine.BackColor = UnderlineColor;
                    return;
                }

                lblUderLine.BackColor = SelectionColor;
            }
        }

        public ContentAlignment TextAlign
        {
            get => lblTitle.TextAlign;
            set => lblTitle.TextAlign = value;
        }

        public override Font Font
        {
            get => lblTitle.Font;
            set => lblTitle.Font = value;
        }

        public string Title
        {
            get => lblTitle.Text;
            set => lblTitle.Text = value;
        }

        /// <summary>
        /// Init and displays the required controls
        /// </summary>
        public ClickableDisplay()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Highlights a specific clickable display
        /// </summary>
        /// <param name="sender">The sending class</param>
        /// <param name="e">The sending arguments</param>
        private void HiglightClickable(object sender, EventArgs e)
        {
            if (IsSelected || HighlightColor.Equals(UnderlineColor))
            {
                return;
            }

            lblUderLine.BackColor = HighlightColor;
        }

        /// <summary>
        /// de selects a specific clickable display
        /// </summary>
        /// <param name="sender">The sending class</param>
        /// <param name="e">The sending arguments</param>
        private void DeHighlightClickable(object sender, EventArgs e)
        {
            if (IsSelected || HighlightColor.Equals(UnderlineColor))
            {
                return;
            }

            lblUderLine.BackColor = UnderlineColor;
        }

        /// <summary>
        /// Detects when the user clicks
        /// </summary>
        /// <param name="sender">The sending class</param>
        /// <param name="e">The sending arguments</param>
        private void TitleClicked(object sender, EventArgs e)
        {
            InvokeOnClick(this, e);
        }
    }
}