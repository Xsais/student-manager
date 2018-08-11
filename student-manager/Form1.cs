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
using student_manager.info.opportunity;
using student_manager.ui.display;
using student_manager.ui.display.manipulate;

namespace student_manager
{
    public partial class Form1 : Form
    {
        
        private readonly Dictionary<Menu, Tuple<ClickableDisplay, Control>> _avilableMenues = new Dictionary<Menu, Tuple<ClickableDisplay, Control>>();

        private Menu? _current;

        private readonly Dictionary<Menu, AlterBox> _alterMenu = new Dictionary<Menu, AlterBox>();

        private Menu? Current
        {
            get => _current;
            set
            {

                if (value != null && value == _current)
                {

                    return;
                }

                if (_current.HasValue)
                {
                    try
                    {
                        var deselected = _avilableMenues[_current.Value];

                        deselected.Item1.IsSelected = false;

                        if (deselected.Item2 != null)
                        {
                            deselected.Item2.Visible = false;
                        }
                    } catch (KeyNotFoundException ex)
                    {

                    }
                }

                if (value.HasValue)
                {
                    try
                    {
                    var selected = _avilableMenues[value.Value];
                    var selectedGroup = (EntityDisplayGroup)selected.Item2;

                    selected.Item1.IsSelected = true;

                        if (selectedGroup != null)
                        {
                            selected.Item2.Visible = true;

                            iPage.Count = selectedGroup.MaxPages;

                            selectedGroup.Selected = null;
                        }
                    iPage.Selected = 1;
                    }
                    catch (KeyNotFoundException ex)
                    {
                    }
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

            AlterPerson alterPerson = new AlterPerson();
            
            _alterMenu.Add(Menu.Courses, null);
            _alterMenu.Add(Menu.Professors, alterPerson);
            _alterMenu.Add(Menu.Programs, null);
            _alterMenu.Add(Menu.Students, alterPerson);

            cdHome.Click += (sender, e) => {

                pnlHome.Visible = !pnlHome.Visible;
                pnlHome.Visible = !pnlHome.Visible;

                Current = Menu.Home;
            };
            cdPrograms.Click += (sender, e) => Current = Menu.Programs;
            cdCourses.Click += (sender, e) => Current = Menu.Courses;
            cdStudents.Click += (sender, e) => Current = Menu.Students;
            cdProfessors.Click += (sender, e) => Current = Menu.Professors;

            picMinus.Click += (sender, args) =>
            {

                if (_current == null)
                {
                    return;
                }
                if (Current.Value == Menu.Students)
                {
                    edgStudents.RemoveEntry(edgStudents.Selected);
                }
                else if (Current.Value == Menu.Professors)
                {
                    edgProfessors.RemoveEntry(edgProfessors.Selected);
                }
                else if (Current.Value == Menu.Programs)
                {
                    edgPrograms.RemoveEntry(edgPrograms.Selected);
                }
                else if (Current.Value == Menu.Courses)
                {
                    edgCourses.RemoveEntry(edgCourses.Selected);
                }
            };

            picAdd.Click += (sender, args) =>
            {

                if (_current == null)
                {
                    return;
                }
                if (Current.Value == Menu.Students)
                {

                    var student = new Student();

                    _alterMenu[Current.Value].Entity = student;

                    if (_alterMenu[Current.Value].ShowDialog() == DialogResult.OK)
                    {
                        edgStudents.AddEntity(student);
                    }
                } else if (Current.Value == Menu.Professors)
                {

                    var professor = new Professor();

                    _alterMenu[Current.Value].Entity = professor;

                    if (_alterMenu[Current.Value].ShowDialog() == DialogResult.OK)
                    {
                        edgProfessors.AddEntity(professor);
                    }
                }
            };

            picEdit.Click += (sender, args) =>
            {

                if (_current == null)
                {
                    return;
                }

                if (Current.Value == Menu.Students)
                {
                    _alterMenu[Current.Value].Entity = edgStudents.Selected;

                    if (_alterMenu[Current.Value].ShowDialog() == DialogResult.OK)
                    {

                        edgStudents.UpdateEntity(edgStudents.Selected);
                    }
                }
                else if (_current != null && Current.Value == Menu.Professors)
                {
                    _alterMenu[Current.Value].Entity = edgProfessors.Selected;

                    if (_alterMenu[Current.Value].ShowDialog() == DialogResult.OK)
                    {

                        edgProfessors.UpdateEntity(edgProfessors.Selected);
                    }
                }
            };

            #region EventBinding_Pages

            edgPrograms.SelectionChanged += (sender, args) =>
            {
                if (!_current.HasValue || _current.Value != Menu.Programs)
                {

                    return;
                }

                var isVisible = edgPrograms.Selected != null;

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
                iPage.Count = edgPrograms.MaxPages;
            };

            edgCourses.SelectionChanged += (sender, args) =>
            {
                if (!_current.HasValue || _current.Value != Menu.Courses)
                {

                    return;
                }

                var isVisible = edgCourses.Selected != null;

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
                iPage.Count = edgCourses.MaxPages;
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

                var isVisible = edgProfessors.Selected != null;

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
                iPage.Count = edgProfessors.MaxPages;
            };

            #endregion

            iPage.SelectionChanged += (sender, args) =>
            {

                Console.WriteLine($"[{DateTime.Now}] Page change requested to page {iPage.Selected}");
                cdPage.Title = iPage.Selected.ToString();

                if (_current == null)
                {
                    return;
                }
                if (Current.Value == Menu.Students)
                {
                    edgStudents.Page = iPage.Selected;
                } else if (Current.Value == Menu.Professors)
                {
                    edgProfessors.Page = iPage.Selected;
                }
                else if (Current.Value == Menu.Programs)
                {
                    edgPrograms.Page = iPage.Selected;
                }
                else if (Current.Value == Menu.Courses)
                {
                    edgCourses.Page = iPage.Selected;
                }
            };

            sbMain.Searched += (sender, e) =>
            {
                Console.WriteLine($"[{DateTime.Now}] New User Search: \"{sbMain.Text}\"");
            };

            edgProfessors.AddEntity(new Professor("PROF0", "Alex", "A", DateTime.Now, Gender.Male, DateTime.Now, true));
            edgProfessors.AddEntity(new Professor("PROF1", "Alex", "A", DateTime.Now, Gender.Male, DateTime.Now, true));
            edgProfessors.AddEntity(new Professor("PROF2", "Alex", "A", DateTime.Now, Gender.Male, DateTime.Now, true));
            edgProfessors.AddEntity(new Professor("PROF3", "Alex", "A", DateTime.Now, Gender.Male, DateTime.Now, true));
            edgProfessors.AddEntity(new Professor("PROF4", "Alex", "A", DateTime.Now, Gender.Male, DateTime.Now, true));
            edgProfessors.AddEntity(new Professor("PROF5", "Alex", "A", DateTime.Now, Gender.Male, DateTime.Now, true));

            edgStudents.AddEntity(new Student("STU", "Alex", "A", DateTime.Now, Gender.Male, DateTime.Now));

            edgPrograms.AddEntity(new Professor("PROG", "Alex", "A", DateTime.Now, Gender.Male, DateTime.Now, true));

            edgCourses.AddEntity(new Professor("COU", "Alex", "A", DateTime.Now, Gender.Male, DateTime.Now, true));

            Current = Menu.Professors;
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