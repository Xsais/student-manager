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

        private List<Entity> _filteredAvilableEntitys;

        private readonly Dictionary<Entity, EntityDisplay> _alivalibleEntries = new Dictionary<Entity, EntityDisplay>();

        public EventHandler MaxChanged;

        public Entity this[string id] => _avilableEntitys.FirstOrDefault(entity => entity.ID.Equals(id));

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

                gotoPage(value);
            }
        }

        private void gotoPage(int page)
        {

            _startY = 0;
            _displayed = 0;

            Controls.Clear();
            _alivalibleEntries.Clear();

            var usedList = _filteredAvilableEntitys ?? _avilableEntitys;

            var startIndex = (page - 1) * PerPage;
            var endIndex = Math.Min(startIndex + PerPage, usedList.Count);

            for (; startIndex < endIndex; ++startIndex)
            {
                DisplayEntry(usedList[startIndex]);
            }

            _page = page;
            PageChanged?.Invoke(this, EventArgs.Empty);
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
        private Entity _selected;

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

        private int CalculatMax() => (int)Math.Ceiling((double)(_filteredAvilableEntitys ?? _avilableEntitys).Count / PerPage);

        public void AddEntity(Entity entity)
        {
            ClearSearch();

            _avilableEntitys.Add(entity);

            DisplayEntry(entity);

            var previousMax = _maxPages;

            MaxPages = CalculatMax();


            if (_maxPages <= previousMax)
            {
                return;
            }

            ++Page;
        }

        public void RemoveEntry(Entity entity)
        {
            if (_alivalibleEntries.Count <= 0)
            {
                return;
            }

            var entityIndex = _avilableEntitys.IndexOf(entity);

            _avilableEntitys.RemoveAt(entityIndex);

            try
            {
                var display = _alivalibleEntries[entity];

                --_displayed;

                entityIndex = entityIndex % PerPage;

                _startY = (entityIndex * display.Height) + (entityIndex * Spacing);

                Selected = null;

                Controls.Remove(display);

                _alivalibleEntries.Remove(entity);

                for (; entityIndex < Controls.Count; ++entityIndex)
                {
                    Controls[entityIndex].Top = _startY;

                    _startY += display.Height + Spacing;
                }

                if (_displayed - 1 > 0)
                {
                    DisplayEntry(_avilableEntitys[Math.Min(_displayed + (PerPage * Page), _avilableEntitys.Count) - 1]);
                }
                else if (_displayed == 0)
                {
                    --Page;
                }

                MaxPages = CalculatMax();
            }
            catch (KeyNotFoundException ex)
            {
            }
        }

        private static void DisplayFields(Entity entity, EntityDisplay visualDisplay)
        {
            switch (entity)
            {
                case Person person:
                    visualDisplay.Header = $"{person.FullName} ({person.ID})";
                    visualDisplay.Flags = person.Gender.ToString();
                    visualDisplay.SubHeading = $"Birth: {person.BirthDate:yyyy/MM/dd}";
                    visualDisplay.Additional = $"Start: {person.BirthDate:yyyy/MM/dd}";
                    break;
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
            if (_displayed >= PerPage)
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

        public void ClearSearch()
        {
            if (_filteredAvilableEntitys == null)
            {
                return;
            }
            _filteredAvilableEntitys = null;
            gotoPage(1);

            MaxPages = CalculatMax();
        }

        private string _previousMatch;

        public void DrawFiltered(string property, string match)
        {
            if (_filteredAvilableEntitys != null && string.Equals(match, _previousMatch))
            {
                return;
            }
            _filteredAvilableEntitys = _avilableEntitys.Where(entity =>
            {
                var propertyInfo = entity.GetType().GetProperty(property);

                return propertyInfo != null && propertyInfo.GetValue(entity, null).ToString().Contains(match);
            }).ToList();

            if (_filteredAvilableEntitys == null)
            {
                return;
            }

            _alivalibleEntries.Clear();
            Controls.Clear();

            gotoPage(1);

            MaxPages = CalculatMax();

            _previousMatch = match;
        }
    }
}