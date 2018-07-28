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
        private int _count;

        private Size _indicatorSize = new Size(10, 10);
        private Color _indicatorColor = Color.Black;
        private int _selectedIndex = -1;
        private int _startX;
        private Color _selectionColor = SystemColors.Highlight;
        private int _spacing = 5;
        public EventHandler SelectionChanged;

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

                for (var i = 0; i < Controls.Count; i++)
                {
                    ((Label) Controls[i]).Left = _startX;

                    _startX += _indicatorSize.Width + Spacing;
                }

                _spacing = value;

                Size = new Size(Controls.Count * _indicatorSize.Width + (Controls.Count - 1) * Spacing,
                    _indicatorSize.Height);
            }
        }

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

                if (_selectedIndex != -1)
                {
                    Controls[_selectedIndex].BackColor = _indicatorColor;
                }

                _selectedIndex = value - 1;

                Controls[_selectedIndex].BackColor = _selectionColor;

                SelectionChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        public Cursor IndicatorCursor { get; set; } = Cursors.Hand;

        public Color IndicatorColor
        {
            get => _indicatorColor;
            set
            {
                if (value == null || value == _indicatorColor)
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

        public Color SelectionColor
        {
            get => _selectionColor;
            set
            {
                if (value == null || value == _selectionColor || _selectedIndex == -1)
                {
                    return;
                }

                Controls[_selectedIndex].BackColor = value;
                _selectionColor = value;
            }
        }

        public Color HoverColor { get; set; } = SystemColors.Highlight;

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

                for (var i = 0; i < Controls.Count; i++)
                {
                    var indicator = ((Label) Controls[i]);

                    indicator.Left = _startX;
                    indicator.Size = value;

                    _startX += value.Width + Spacing;
                }

                _indicatorSize = value;

                Size = new Size(Controls.Count * _indicatorSize.Width + (Controls.Count - 1) * Spacing,
                    _indicatorSize.Height);
            }
        }

        public int Count
        {
            get => _count;
            set
            {
                if (value == _count)
                {
                    return;
                }

                if (value < 0 || value == 0)
                {
                    Selected = -1;
                    Controls.Clear();
                }

                if (_count > value)
                {
                    var startIndex = _count - value;

                    _startX -= (_indicatorSize.Width + Spacing) * startIndex;

                    startIndex -= 1;

                    for (; startIndex < Controls.Count; ++startIndex)
                    {
                        Controls.RemoveAt(startIndex);
                    }
                }
                else
                {
                    var endIndex = value - _count;

                    for (var startIndex = 0; startIndex < endIndex; ++startIndex)
                    {
                        var indicator = new Label
                        {
                            Size = _indicatorSize,
                            BackColor = IndicatorColor,
                            Left = _startX,
                            Cursor = IndicatorCursor
                        };

                        indicator.MouseHover += (sender, e) =>
                        {
                            var moused = (Label) sender;

                            if (Controls.GetChildIndex(moused) == _selectedIndex)
                            {
                                return;
                            }

                            moused.BackColor = HoverColor;
                        };

                        indicator.MouseLeave += (sender, e) =>
                        {
                            var moused = (Label) sender;

                            if (Controls.GetChildIndex(moused) == _selectedIndex)
                            {
                                return;
                            }

                            moused.BackColor = IndicatorColor;
                        };

                        indicator.Click += (sender, e) => { Selected = Controls.GetChildIndex((Label) sender) + 1; };


                        Controls.Add(indicator);

                        _startX += _indicatorSize.Width + Spacing;
                    }
                }

                var oldWidth = _count * _indicatorSize.Width + (_count - 1) * Spacing;

                var newWidth = value * _indicatorSize.Width + (value - 1) * Spacing;

                Left += (oldWidth - newWidth) / 2;

                Size = new Size(newWidth, Size.Height);

                _count = value;
            }
        }

        public Indicator()
        {
            InitializeComponent();

            Size = Size.Empty;
        }
    }
}