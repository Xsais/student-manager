/**
 * File: EntityDisplayGroup.cs
 * Assignment: Final_Project
 * Creation date: August 6, 2018
 * Last Modified: August 14, 2018
 * Description: Handles drawing multiple entitys to the screen
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
using student_manager.info.entity;
using student_manager.info.member;
using student_manager.info.opportunity;

namespace student_manager.ui.display
{
    public partial class EntityDisplayGroup : UserControl
    {
        // Handles displaying the tooltips
        private readonly ToolTip _masterTip = new ToolTip();

        private readonly List<Entity> _avilableEntitys = new List<Entity>();

        private List<Entity> _filteredAvilableEntitys;

        private readonly List<Entity> _specialEntities = new List<Entity>();

        private static readonly Color _specialColr = Color.FromArgb(75, Color.Gray);

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

                if (_selected != null)
                {
                    _alivalibleEntries[_selected].BackColor =
                        _specialEntities.Contains(_selected) ? _specialColr : BackColor;
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

        /// <summary>
        /// Calculates the maximum ammount of pages
        /// </summary>
        /// <returns>The maximum ammount of pages</returns>
        private int CalculatMax() =>
            (int) Math.Ceiling((double) (_filteredAvilableEntitys ?? _avilableEntitys).Count / PerPage);

        /// <summary>
        /// Adds an entity to be display 
        /// </summary>
        /// <param name="entity">The desired entity that should be displayed</param>
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

        /// <summary>
        /// Removes an entity to the display
        /// </summary>
        /// <param name="entity">The desired entity to be removed</param>
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

                if (_displayed == 4 && _page * PerPage <= _avilableEntitys.Count)
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

        /// <summary>
        /// Displays all necessary fields for the given type
        /// </summary>
        /// <param name="entity">The entity in wich to retreve data from</param>
        /// <param name="visualDisplay">the entity display in wich to update</param>
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
                case Course course:

                    visualDisplay.Header = $"{course.Name} ({course.ID})";
                    visualDisplay.SubHeading = $"Capacity: {course.Capacity}";
                    visualDisplay.Additional = $"Credits: {course.Credits:F2}";
                    break;
                case info.opportunity.Program program:

                    visualDisplay.Header = $"{program.Name} ({program.ID})";

                    if (program.IsCOOP)
                    {
                        visualDisplay.Flags = "Co-Op";
                    }

                    visualDisplay.SubHeading = $"Duration: {Math.Round(program.Duration.TotalDays / 365, 2)} Years";
                    visualDisplay.Additional = $"Outcome: {program.Outcome.ToString().Replace("_", " ")}";
                    break;
            }
        }

        /// <summary>
        /// Displays an entity to the screen
        /// </summary>
        /// <param name="entity">The desired entity to be displayed to the screen</param>
        private void DisplayEntry(Entity entity)
        {
            if (_displayed >= PerPage || _alivalibleEntries.Count(lookup => lookup.Key.Equals(entity)) != 0)
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

            _masterTip.SetToolTip(visualDisplay, $"{entity.GetType().ToString().Split('.').Last()}: {entity}");

            Controls.Add(visualDisplay);

            ++_displayed;
        }

        /// <summary>
        /// Removes all entitys from drisplay
        /// </summary>
        /// <param name="entitys">The list of entities to be removed</param>
        public void RemoveAll(IEnumerable<Entity> entitys)
        {
            foreach (var entity in entitys)
            {
                RemoveEntry(entity);
            }
        }

        /// <summary>
        /// Adds all entitys from a given collection to the screen
        /// </summary>
        /// <param name="entitys">The collection to be added</param>
        public void AddAll(IEnumerable<Entity> entitys)
        {
            if (entitys == null)
            {
                return;
            }

            foreach (var entity in entitys)
            {
                AddEntity(entity);
            }
        }

        /// <summary>
        /// Updates the information from a given entity
        /// </summary>
        /// <param name="entity">The entity to update</param>
        /// <param name="isSpecial">Is the entity to be visually marked</param>
        public void UpdateEntity(Entity entity, bool isSpecial = false)
        {
            if (isSpecial)
            {
                _alivalibleEntries[entity].BackColor = _specialColr;
                _specialEntities.Add(entity);
            }
            else
            {
                _alivalibleEntries[entity].BackColor = Color.Transparent;
                _specialEntities.Remove(entity);
            }

            DisplayFields(entity, _alivalibleEntries[entity]);
        }

        // Clears the current search filter
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

        // Stores the prvious search value
        private string _previousMatch;

        /// <summary>
        /// Filters the currently displayed list of entitys
        /// </summary>
        /// <param name="property">The property in wich to search by</param>
        /// <param name="match">The desired match for the given property</param>
        public void DrawFiltered(string property, string match)
        {
            if (_filteredAvilableEntitys != null && string.Equals(match, _previousMatch))
            {
                return;
            }

            _filteredAvilableEntitys = _avilableEntitys.Where(entity =>
            {
                var propertyInfo = entity.GetType().GetProperty(property);

                return propertyInfo != null &&
                       propertyInfo.GetValue(entity, null).ToString().ToLower().Contains(match.ToLower());
            }).ToList();

            if (_filteredAvilableEntitys == null)
            {
                return;
            }

            _alivalibleEntries.Clear();
            Controls.Clear();

            gotoPage(1);

            MaxPages = CalculatMax();

            _previousMatch = match.ToLower();
        }
    }
}