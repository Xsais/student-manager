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
using student_manager.info.entity;
using student_manager.info.opportunity;

namespace student_manager.ui.display
{
    public partial class EntityDisplayGroup : UserControl
    {
        private readonly List<Entity> _avilableEntitys = new List<Entity>();

        private readonly Dictionary<Entity, EntityDisplay> _alivalibleEntries = new Dictionary<Entity, EntityDisplay>();

        public EventHandler MaxChanged;

        public int MaxPages
        {
            get => _maxPages;
            private set
            {
                value = Math.Max(value, 1);
                if (value == _maxPages)
                {

                    return;
                }
                _maxPages = value;
                MaxChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        private int _startY;
        private int _spacing = 5;
        private int _displayed;
        private int _page = 1;

        public int Page
        {
            get => _page;
            set
            {

                if (_avilableEntitys.Count == 0 || value <= 0 || value == _page)
                {

                    return;
                }

                _startY = 0;
                _displayed = 0;

                var startIndex = (_page - 1) * PerPage;
                var endIndex = Math.Min(startIndex + PerPage, _avilableEntitys.Count);

                for (; startIndex < endIndex; ++startIndex)
                {
                    
                    Controls.Remove(_alivalibleEntries[_avilableEntitys[startIndex]]);
                    _alivalibleEntries.Remove(_avilableEntitys[startIndex]);
                }
                
                startIndex = (value - 1) * PerPage;
                endIndex = Math.Min(startIndex + PerPage, _avilableEntitys.Count);

                for (; startIndex < endIndex; ++startIndex)
                {

                    DisplayEntry(_avilableEntitys[startIndex]);
                }
                _page = value;
                PageChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        public Entity Selected
        {
            get => _selected;
            set
            {
                if (value == _selected)
                {
                    return;
                }

                if (value != null)
                {
                    _alivalibleEntries[value].BackColor = SelectionColor;
                }

                if (Selected != null)
                {
                    _alivalibleEntries[_selected].BackColor = BackColor;
                }

                _selected = value;
                SelectionChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        public EventHandler SelectionChanged;
        private Entity _selected = null;

        public Color SelectionColor { get; set; } = SystemColors.Highlight;

        public int PerPage { get; set; } = 5;

        public EventHandler PageChanged;
        private int _maxPages = 1;

        public int Spacing
        {
            get => _spacing;
            set
            {
                if (_spacing == value || value < 0)
                {
                    return;
                }

                _spacing = value;
                var entryInndex = 0;

                foreach (var entry in _alivalibleEntries)
                {
                    entry.Value.Top = entryInndex * (entry.Value.Height + _spacing);
                    _startY = entry.Value.Top;

                    ++entryInndex;
                }

                _startY += _alivalibleEntries.Last().Value.Height + _spacing;
            }
        }

        public EntityDisplayGroup()
        {
            InitializeComponent();
        }

        public void AddEntity(Entity entity)
        {
            _avilableEntitys.Add(entity);

            DisplayEntry(entity);
            
            MaxPages = (int)Math.Ceiling((double)_avilableEntitys.Count / PerPage);
        }

        public void RemoveEntry(Entity entity)
        {

            if (_alivalibleEntries.Count <= 0)
            {
                
                return;
            }

            _avilableEntitys.Remove(entity);

            var display = _alivalibleEntries[entity];

            _alivalibleEntries.Remove(entity);
            Controls.Remove(display);

            _startY -= display.Height + Spacing;

            MaxPages = (int)Math.Ceiling((double)_avilableEntitys.Count / PerPage);

            _selected = null;

            --_displayed;
        }

        private void DisplayFields(Entity entity, EntityDisplay visualDisplay)
        {
            switch (entity)
            {
                case Student student:
                    visualDisplay.Header = $"{student.FullName} ({student.ID})";
                    visualDisplay.Flags = student.Gender.ToString();
                    visualDisplay.SubHeading = $"Birth: {student.BirthDate:yyyy/MM/dd}";
                    visualDisplay.Additional = $"Start: {student.BirthDate:yyyy/MM/dd}";
                    break;
                case Professor prof:
                    visualDisplay.Header = $"{prof.FullName} ({prof.ID})";
                    visualDisplay.Flags = prof.Gender.ToString();
                    if (prof.IsFullTime)
                    {
                        visualDisplay.Flags += " || Full Time";
                    }

                    visualDisplay.SubHeading = $"Birth: {prof.BirthDate:yyyy/MM/dd}";
                    visualDisplay.Additional = $"Start: {prof.BirthDate:yyyy/MM/dd}";
                    break;
                case Course course:
                    // TODO: Display Course
                    break;
                case info.opportunity.Program program:
                    // TODO: Display Program
                    break;
            }
        }

        private void DisplayEntry(Entity entity)
        {
            if (_displayed == PerPage)
            {
                return;
            }

            var visualDisplay = new EntityDisplay
            {
                Cursor = Cursors.Hand
            };


            visualDisplay.Click += (sender, args) =>
            {
                Selected = _alivalibleEntries.First(entry => entry.Value.Equals(sender)).Key;
            };

            DisplayFields(entity, visualDisplay);

            visualDisplay.Top = _startY;

            _startY += visualDisplay.Height + Spacing;

            _alivalibleEntries.Add(entity, visualDisplay);

            Controls.Add(visualDisplay);

            ++_displayed;
        }

        public void RemoveAll(IEnumerable<Entity> entitys)
        {
            foreach (var entity in entitys)
            {
                
                RemoveEntry(entity);
            }
        }

        public void AddAll(IEnumerable<Entity> entitys)
        {
            foreach (var entity in entitys)
            {
                
                AddEntity(entity);
            }
        }

        public void UpdateEntity(Entity entity)
        {
            DisplayFields(entity, _alivalibleEntries[entity]);
        }
    }
}