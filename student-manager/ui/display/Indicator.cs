/**
 * File: Indicator.cs
 * Assignment: Final_Project
 * Creation date: August 6, 2018
 * Last Modified: August 14, 2018
 * Description: Handles visually displaying a count to the screen
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
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Schema;

namespace student_manager.ui.display
{
    public partial class Indicator : UserControl
    {
        // Stores the total squares displayed on the screen
        private int _count;

        // Stores the size of eac indicator
        private Size _indicatorSize = new Size(10, 10);

        // Stores the color of each indicator
        private Color _indicatorColor = Color.Black;

        // Stores the idex of the selected rectangle
        private int _selectedIndex = -1;

        // Stores the staring x position to start drawing
        private int _startX;

        // Stores the color of the rectangle when selected
        private Color _selectionColor = SystemColors.Highlight;

        // Stores the spacing the is drawn between each rectangle
        private int _spacing = 5;

        // Occurs when the current selected rectangle changes
        public EventHandler SelectionChanged;

        // Updates the spacing between each rectangle
        public int Spacing
        {
            get => _spacing;
            set
            {
                if (value < 0)
                {
                    return;
                }

                _startX = 0;

                // changes the x location of each rectangle drawn to the screen
                for (var i = 0; i < Controls.Count; i++)
                {
                    ((Label) Controls[i]).Left = _startX;

                    _startX += _indicatorSize.Width + Spacing;
                }

                _spacing = value;
            }
        }

        // Changes the selected rectangle
        public int Selected
        {
            get => _selectedIndex + 1;
            set
            {
                if (value < 0 || value == _selectedIndex + 1)
                {
                    return;
                }

                if (value == 0 && _selectedIndex != -1)
                {
                    Controls[_selectedIndex].BackColor = _indicatorColor;
                    return;
                }

                _selectedIndex = value - 1;

                // highlights the selected rectangle
                if (_selectedIndex != -1)
                {
                    Controls[_selectedIndex].BackColor = _indicatorColor;
                }

                Controls[_selectedIndex].BackColor = _selectionColor;

                SelectionChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        public Cursor IndicatorCursor { get; set; } = Cursors.Hand;

        // Changes the  color of each indicator that is currently drawn to the screen
        public Color IndicatorColor
        {
            get => _indicatorColor;
            set
            {
                if (value == _indicatorColor)
                {
                    return;
                }

                for (var i = 0; i < Controls.Count; i++)
                {
                    if (i != _selectedIndex)
                    {
                        ((Label) Controls[i]).BackColor = value;
                    }
                }

                _indicatorColor = value;
            }
        }

        // Changes the color of the currently selected rectangle
        public Color SelectionColor
        {
            get => _selectionColor;
            set
            {
                if (value == _selectionColor || _selectedIndex == -1)
                {
                    return;
                }

                Controls[_selectedIndex].BackColor = value;
                _selectionColor = value;
            }
        }

        public Color HoverColor { get; set; } = SystemColors.Highlight;

        // Changes the size of each rectangle that is currently drawn to the screen
        public Size IndicatorSize
        {
            get => _indicatorSize;
            set
            {
                if (value.Height + value.Width < 0 || value == _indicatorSize)
                {
                    return;
                }

                _startX = 0;

                // Keeps the rectangle in the same location while increasing the price
                for (var i = 0; i < Controls.Count; i++)
                {
                    var indicator = ((Label) Controls[i]);

                    indicator.Left = _startX;
                    indicator.Size = value;

                    _startX += value.Width + Spacing;
                }

                _indicatorSize = value;

                // Sets the new size of the window using the newly created size
                Size = new Size(Controls.Count * _indicatorSize.Width + (Controls.Count - 1) * Spacing,
                    _indicatorSize.Height);
            }
        }

        // Changes the amount of rectangle currently bieng drawn to the screen
        public int Count
        {
            get => _count;
            set
            {
                if (value == _count)
                {
                    return;
                }

                // cleas the selection if there is no more rectangles
                if (value < 0 || value == 0)
                {
                    Selected = -1;
                    Controls.Clear();
                }

                // Adds or removes a rectang depending if adding or removing
                if (_count > value)
                {
                    var endIndex = _count - value;

                    for (var i = Controls.Count - 1; i > endIndex; --i)
                    {
                        _startX -= _indicatorSize.Width + Spacing;

                        Controls[i].Left = _startX;
                    }

                    Controls.RemoveAt(endIndex);
                }
                else
                {
                    var endIndex = value - _count;

                    // Adds the diffrece rectangles to the screen
                    for (var startIndex = 0; startIndex < endIndex; ++startIndex)
                    {
                        _startX = Controls.Count * (_indicatorSize.Width + Spacing);

                        var indicator = new Label
                        {
                            Size = _indicatorSize,
                            BackColor = _indicatorColor,
                            Left = _startX,
                            Cursor = IndicatorCursor
                        };

                        // Events needed to track selected and color change
                        indicator.MouseEnter += (sender, e) =>
                        {
                            var moused = (Label) sender;

                            if (Controls.GetChildIndex(moused) == _selectedIndex)
                            {
                                return;
                            }

                            moused.BackColor = _selectionColor;
                        };

                        indicator.MouseLeave += (sender, e) =>
                        {
                            var moused = (Label) sender;

                            if (Controls.GetChildIndex(moused) == _selectedIndex)
                            {
                                return;
                            }

                            moused.BackColor = _indicatorColor;
                        };

                        indicator.Click += (sender, e) => { Selected = Controls.GetChildIndex((Label) sender) + 1; };

                        Controls.Add(indicator);
                    }
                }

                // Increasing the size while keeping the current position

                #region Size Shift

                var oldWidth = _count * _indicatorSize.Width + (_count - 1) * Spacing;

                var newWidth = value * _indicatorSize.Width + (value - 1) * Spacing;

                Left += (oldWidth - newWidth) / 2;

                Size = new Size(newWidth, _indicatorSize.Height);

                _count = value;

                #endregion
            }
        }

        /// <summary>
        /// Init and creates all controls
        /// </summary>
        public Indicator()
        {
            InitializeComponent();
        }
    }
}