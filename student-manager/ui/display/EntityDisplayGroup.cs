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
        private readonly HashSet<Entity> _avilableEntitys = new HashSet<Entity>();

        private readonly Dictionary<Entity, EntityDisplay> _alivalibleEntries = new Dictionary<Entity, EntityDisplay>();

        private int _startY;
        private int _spacing = 5;
        private int _displayed;
        public Entity Selected = null;

        public Color SelectionColor { get; set; } = SystemColors.Highlight;

        public int PerPage { get; set; } = 5;

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
        }

        public void RemoveEntry(Entity entity)
        {
            var display = _alivalibleEntries[entity];

            _alivalibleEntries.Remove(entity);
            Controls.Remove(display);

            _startY -= display.Height + Spacing;
        }

        private void DisplayEntry(Entity entity)
        {
            if (_displayed == PerPage)
            {
                return;
            }

            var visualDisplay = new EntityDisplay();

            visualDisplay.Cursor = Cursors.Hand;

            visualDisplay.Click += (sender, args) =>
            {
                ((EntityDisplay)sender).BackColor = SelectionColor;

                if (Selected != null)
                {

                    _alivalibleEntries[Selected].BackColor = BackColor;
                }

                Selected = _alivalibleEntries.First(entry => entry.Value.Equals(sender)).Key;
            };

            if (entity is Student student)
            {
                visualDisplay.Header = $"{student.FullName} ({student.ID})";
                visualDisplay.Flags = student.Gender.ToString();
                visualDisplay.SubHeading = $"Birth: {student.BirthDate:yyyy/MM/dd}";
                visualDisplay.Additional = $"Start: {student.BirthDate:yyyy/MM/dd}";
            }
            else if (entity is Professor prof)
            {
                visualDisplay.Header = $"{prof.FullName} ({prof.ID})";
                visualDisplay.Flags = prof.Gender.ToString();
                if (prof.IsFullTime)
                {
                    visualDisplay.Flags += " || Full Time";
                }

                visualDisplay.SubHeading = $"Birth: {prof.BirthDate:yyyy/MM/dd}";
                visualDisplay.Additional = $"Start: {prof.BirthDate:yyyy/MM/dd}";
            }
            else if (entity is Course course)
            {
                // TODO: Display Course
            }
            else if (entity is info.opportunity.Program program)
            {
                // TODO: Display Program
            }

            visualDisplay.Top = _startY;

            _startY += visualDisplay.Height + Spacing;

            _alivalibleEntries.Add(entity, visualDisplay);

            Controls.Add(visualDisplay);

            ++_displayed;
        }
    }
}