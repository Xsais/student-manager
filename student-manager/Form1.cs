using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using student_manager.info;
using student_manager.ui.display;

namespace student_manager
{
    public partial class Form1 : Form
    {
        
        private readonly Dictionary<Menu, Tuple<ClickableDisplay, Control>> _avilableMenues = new Dictionary<Menu, Tuple<ClickableDisplay, Control>>();

        private Menu? _current;

        private Menu? Current
        {
            get => _current;
            set
            {

                if (value == _current)
                {

                    return;
                }

                if (_current.HasValue)
                {

                    var deselected = _avilableMenues[_current.Value];

                    deselected.Item1.IsSelected = false;
                    deselected.Item2.Visible = false;
                }

                if (value.HasValue)
                {

                    var selected = _avilableMenues[value.Value];
                    var selectedGroup = (EntityDisplayGroup)selected.Item2;

                    selected.Item1.IsSelected = true;
                    selected.Item2.Visible = true;

                    iPage.Count = selectedGroup.MaxPages;
                    iPage.Selected = 1;

                    selectedGroup.Selected = null;
                }

                _current = value;
            }
        }

        public Form1()
        {
            InitializeComponent();

            _avilableMenues.Add(Menu.Home, Tuple.Create<ClickableDisplay, Control>(cdHome, null));
            _avilableMenues.Add(Menu.Programs, Tuple.Create<ClickableDisplay, Control>(cdPrograms, edgPrograms));
            _avilableMenues.Add(Menu.Courses, Tuple.Create<ClickableDisplay, Control>(cdCourses, edgCourses));
            _avilableMenues.Add(Menu.Students, Tuple.Create<ClickableDisplay, Control>(cdStudents, edgStudents));
            _avilableMenues.Add(Menu.Professors, Tuple.Create<ClickableDisplay, Control>(cdProfessors, edgProfessors));

            cdPrograms.Click += (sender, e) => Current = Menu.Programs;
            cdCourses.Click += (sender, e) => Current = Menu.Courses;
            cdStudents.Click += (sender, e) => Current = Menu.Students;
            cdProfessors.Click += (sender, e) => Current = Menu.Professors;

            #region EventBinding_Pages

            edgPrograms.SelectionChanged += (sender, args) =>
            {
                if (!_current.HasValue || _current.Value != Menu.Programs)
                {

                    return;
                }

                var isVisible = edgStudents.Selected != null;

                picEdit.Visible = isVisible;
                picMinus.Visible = isVisible;
                picLink.Visible = isVisible;

                Console.WriteLine($"[{DateTime.Now}] Current Selection \"{edgStudents.Selected}\"");
            };

            edgPrograms.MaxChanged += (sender, args) =>
            {

                if (!_current.HasValue || _current.Value != Menu.Programs)
                {

                    return;
                }

                Console.WriteLine($"[{DateTime.Now}] The max page has changed to {edgStudents.MaxPages}");
                iPage.Count = edgStudents.MaxPages;
            };

            edgCourses.SelectionChanged += (sender, args) =>
            {
                if (!_current.HasValue || _current.Value != Menu.Courses)
                {

                    return;
                }

                var isVisible = edgStudents.Selected != null;

                picEdit.Visible = isVisible;
                picMinus.Visible = isVisible;
                picLink.Visible = isVisible;

                Console.WriteLine($"[{DateTime.Now}] Current Selection \"{edgStudents.Selected}\"");
            };

            edgCourses.MaxChanged += (sender, args) =>
            {

                if (!_current.HasValue || _current.Value != Menu.Courses)
                {

                    return;
                }

                Console.WriteLine($"[{DateTime.Now}] The max page has changed to {edgStudents.MaxPages}");
                iPage.Count = edgStudents.MaxPages;
            };

            edgStudents.SelectionChanged += (sender, args) =>
            {
                if (!_current.HasValue || _current.Value != Menu.Students)
                {

                    return;
                }

                var isVisible = edgStudents.Selected != null;

                picEdit.Visible = isVisible;
                picMinus.Visible = isVisible;
                picLink.Visible = isVisible;

                Console.WriteLine($"[{DateTime.Now}] Current Selection \"{edgStudents.Selected}\"");
            };

            edgStudents.MaxChanged += (sender, args) =>
            {
                if (!_current.HasValue || _current.Value != Menu.Students)
                {

                    return;
                }

                Console.WriteLine($"[{DateTime.Now}] The max page has changed to {edgStudents.MaxPages}");
                iPage.Count = edgStudents.MaxPages;
            };

            edgProfessors.SelectionChanged += (sender, args) =>
            {
                if (!_current.HasValue || _current.Value != Menu.Professors)
                {

                    return;
                }

                var isVisible = edgStudents.Selected != null;

                picEdit.Visible = isVisible;
                picMinus.Visible = isVisible;
                picLink.Visible = isVisible;

                Console.WriteLine($"[{DateTime.Now}] Current Selection \"{edgStudents.Selected}\"");
            };

            edgProfessors.MaxChanged += (sender, args) =>
            {
                if (!_current.HasValue || _current.Value != Menu.Professors)
                {

                    return;
                }

                Console.WriteLine($"[{DateTime.Now}] The max page has changed to {edgStudents.MaxPages}");
                iPage.Count = edgStudents.MaxPages;
            };

            #endregion

            iPage.SelectionChanged += (sender, args) =>
            {

                Console.WriteLine($"[{DateTime.Now}] Page change requested to page {iPage.Selected}");
                edgStudents.Page = iPage.Selected;
                cdPage.Title = iPage.Selected.ToString();
            };

            sbMain.Searched += (sender, e) =>
            {
                Console.WriteLine($"[{DateTime.Now}] New User Search: \"{sbMain.Text}\"");
            };

            edgProfessors.AddEntity(new Professor("PROF", new info.Name("Alex", "A"), DateTime.Now, Gender.Male, DateTime.Now, true));
            edgStudents.AddEntity(new Student("STU", new info.Name("Alex", "A"), DateTime.Now, Gender.Male, DateTime.Now));

            edgPrograms.AddEntity(new Professor("PROG", new info.Name("Alex", "A"), DateTime.Now, Gender.Male, DateTime.Now, true));

            edgCourses.AddEntity(new Professor("COU", new info.Name("Alex", "A"), DateTime.Now, Gender.Male, DateTime.Now, true));

            Current = Menu.Programs;
        }

        private enum Menu
        {
            Home,
            Programs,
            Courses,
            Students,
            Professors
        }
    }
}