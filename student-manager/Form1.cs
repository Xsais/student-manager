using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Channels;
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
        private readonly Dictionary<Menu, Tuple<ClickableDisplay, Control>> _avilableMenues =
            new Dictionary<Menu, Tuple<ClickableDisplay, Control>>();

        private Menu? _current;

        private static string _deletionTemplate = "Are you sure you want to {0} that {1}";

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
                    }
                    catch (KeyNotFoundException ex)
                    {
                    }
                }

                if (value.HasValue)
                {
                    try
                    {
                        var selected = _avilableMenues[value.Value];
                        var selectedGroup = (EntityDisplayGroup) selected.Item2;

                        selected.Item1.IsSelected = true;

                        if (selectedGroup != null)
                        {
                            pnlEnties.Visible = true;
                            pnlHome.Visible = false;

                            selected.Item2.Visible = true;

                            iPage.Count = selectedGroup.MaxPages;

                            selectedGroup.Selected = null;

                            iPage.Selected = 1;
                        } else
                        {

                            pnlEnties.Visible = false;
                            pnlHome.Visible = true;
                        }
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

            #region Page Binding
            _avilableMenues.Add(Menu.Home, Tuple.Create<ClickableDisplay, Control>(cdHome, null));
            _avilableMenues.Add(Menu.Programs, Tuple.Create<ClickableDisplay, Control>(cdPrograms, edgPrograms));
            _avilableMenues.Add(Menu.Courses, Tuple.Create<ClickableDisplay, Control>(cdCourses, edgCourses));
            _avilableMenues.Add(Menu.Students, Tuple.Create<ClickableDisplay, Control>(cdStudents, edgStudents));
            _avilableMenues.Add(Menu.Professors, Tuple.Create<ClickableDisplay, Control>(cdProfessors, edgProfessors));
            #endregion

            Current = Menu.Professors;

            #region Alter Forms
            bool idVerifier(string input)
            {
                if (!_current.HasValue)
                {
                    return false;
                }
                
                switch (_current.Value)
                {

                    case Menu.Students:

                        return edgStudents[input] != null;
                    case Menu.Professors:

                        return edgProfessors[input] != null;
                    case Menu.Programs:
                        return true;
                    case Menu.Courses:
                        return true;
                    default:

                        return false;
                }
            }

            var alterPerson = new AlterPerson
            {
                IDVerifacator = idVerifier,
                Confirming = () =>
                {
                    if (_current == null)
                    {
                        return;
                    }

                    if (Current.Value == Menu.Students)
                    {
                        confirm.ShowDialog(string.Format(_deletionTemplate, "edit", "Student"), (result) =>
                        {

                            if (!result)
                            {
                                return;
                            }
                            _alterMenu[Menu.Students].Confirm();
                            edgStudents.UpdateEntity(edgStudents.Selected);

                            edgStudents.Selected = null;
                        });
                    }
                    else if (Current.Value == Menu.Professors)
                    {
                        confirm.ShowDialog(string.Format(_deletionTemplate, "edit", "Professor"), (result) =>
                        {

                            if (!result)
                            {
                                return;
                            }
                            _alterMenu[Menu.Professors].Confirm();
                            edgProfessors.UpdateEntity(edgProfessors.Selected);

                            edgProfessors.Selected = null;
                        });
                    }

                    return;
                }
            };

            _alterMenu.Add(Menu.Courses, null);
            _alterMenu.Add(Menu.Professors, alterPerson);
            _alterMenu.Add(Menu.Programs, null);
            _alterMenu.Add(Menu.Students, alterPerson);
            #endregion

            #region Switching Events
            cdHome.Click += (sender, e) =>
            {
                pnlHome.Visible = !pnlHome.Visible;
                pnlHome.Visible = !pnlHome.Visible;

                Current = Menu.Home;
            };
            cdPrograms.Click += (sender, e) => Current = Menu.Programs;
            cdCourses.Click += (sender, e) => Current = Menu.Courses;
            cdStudents.Click += (sender, e) => Current = Menu.Students;
            cdProfessors.Click += (sender, e) => Current = Menu.Professors;
            #endregion

            #region Functionality Events
            picMinus.Click += (sender, args) =>
            {
                if (_current == null)
                {
                    return;
                }

                if (Current.Value == Menu.Students)
                {
                    confirm.ShowDialog(string.Format(_deletionTemplate, "delete", "Student"), (result) =>
                    {
                        if (!result)
                        {
                            return;
                        }

                        edgStudents.RemoveEntry(edgStudents.Selected);
                    });
                }
                else if (Current.Value == Menu.Professors)
                {
                    confirm.ShowDialog(string.Format(_deletionTemplate, "delete", "Professor"), (result) =>
                    {
                        if (!result)
                        {
                            return;
                        }

                        edgProfessors.RemoveEntry(edgProfessors.Selected);
                    });
                }
                else if (Current.Value == Menu.Programs)
                {
                    confirm.ShowDialog(string.Format(_deletionTemplate, "delete", "Program"), (result) =>
                    {
                        if (!result)
                        {
                            return;
                        }

                        edgPrograms.RemoveEntry(edgPrograms.Selected);
                    });
                }
                else if (Current.Value == Menu.Courses)
                {
                    confirm.ShowDialog(string.Format(_deletionTemplate, "delete", "Course"), (result) =>
                    {
                        if (!result)
                        {
                            return;
                        }

                        edgCourses.RemoveEntry(edgCourses.Selected);
                    });
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
                    edgStudents.Selected = null;

                    var student = new Student();

                    _alterMenu[Current.Value].Entity = student;

                    if (_alterMenu[Current.Value].ShowDialog() == DialogResult.OK)
                    {
                        edgStudents.AddEntity(student);
                    }
                }
                else if (Current.Value == Menu.Professors)
                {
                    edgProfessors.Selected = null;

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
            #endregion

            #region EventBinding_Pages

            #region Programs

            edgPrograms.SelectionChanged += (sender, args) =>
            {
                if (!_current.HasValue || _current.Value != Menu.Programs)
                {
                }

                var isVisible = edgPrograms.Selected != null;

                picEdit.Visible = isVisible;
                picMinus.Visible = isVisible;
                picLink.Visible = isVisible;

                Console.WriteLine($"[{DateTime.Now}] Current Selection \"{edgPrograms.Selected}\"");
            };

            edgPrograms.MaxChanged += (sender, args) =>
            {
                if (!_current.HasValue || _current.Value != Menu.Programs)
                {
                    return;
                }

                Console.WriteLine($"[{DateTime.Now}] The max page has changed to {edgPrograms.MaxPages}");
                iPage.Count = edgPrograms.MaxPages;
            };

            edgPrograms.PageChanged += (sender, args) =>
            {
                if (Current != Menu.Programs)
                {
                    return;
                }

                iPage.Selected = edgPrograms.Page;
            };

            #endregion

            #region Courses

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

                Console.WriteLine($"[{DateTime.Now}] Current Selection \"{edgCourses.Selected}\"");
            };

            edgCourses.MaxChanged += (sender, args) =>
            {
                if (!_current.HasValue || _current.Value != Menu.Courses)
                {
                    return;
                }

                Console.WriteLine($"[{DateTime.Now}] The max page has changed to {edgCourses.MaxPages}");
                iPage.Count = edgCourses.MaxPages;
            };

            edgCourses.PageChanged += (sender, args) =>
            {
                if (Current != Menu.Courses)
                {
                    return;
                }

                iPage.Selected = edgCourses.Page;
            };

            #endregion

            #region Students

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

            edgStudents.PageChanged += (sender, args) =>
            {
                if (Current != Menu.Students)
                {
                    return;
                }

                iPage.Selected = edgStudents.Page;
            };

            #endregion

            #region Professor

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

                Console.WriteLine($"[{DateTime.Now}] Current Selection \"{edgProfessors.Selected}\"");
            };

            edgProfessors.MaxChanged += (sender, args) =>
            {
                if (!_current.HasValue || _current.Value != Menu.Professors)
                {
                    return;
                }

                Console.WriteLine($"[{DateTime.Now}] The max page has changed to {edgProfessors.MaxPages}");
                iPage.Count = edgProfessors.MaxPages;
            };

            edgProfessors.PageChanged += (sender, args) =>
            {
                if (Current != Menu.Professors)
                {
                    return;
                }

                iPage.Selected = edgProfessors.Page;
            };

            #endregion

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
                }
                else if (Current.Value == Menu.Professors)
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

            sbEntites.Searched += (sender, e) =>
            {

                if (_current == null)
                {
                    return;
                }

                if (Current.Value == Menu.Students)
                {
                    if (string.IsNullOrWhiteSpace(sbEntites.Text))
                    {
                        edgStudents.ClearSearch();
                        return;
                    }
                    edgStudents.DrawFiltered("FullName", sbEntites.Text);
                }
                else if (Current.Value == Menu.Professors)
                {
                    if (string.IsNullOrWhiteSpace(sbEntites.Text))
                    {
                        edgProfessors.ClearSearch();
                        return;
                    }
                    edgProfessors.DrawFiltered("FullName", sbEntites.Text);
                }
                else if (Current.Value == Menu.Programs)
                {
                    if (string.IsNullOrWhiteSpace(sbEntites.Text))
                    {
                        edgPrograms.ClearSearch();
                        return;
                    }
                    edgPrograms.Page = iPage.Selected;
                }
                else if (Current.Value == Menu.Courses)
                {
                    if (string.IsNullOrWhiteSpace(sbEntites.Text))
                    {
                        edgCourses.ClearSearch();
                        return;
                    }
                    edgCourses.Page = iPage.Selected;
                }
                Console.WriteLine($"[{DateTime.Now}] Search requested {sbEntites.Text}");
            };

            #region Testing_Data
            edgProfessors.AddEntity(new Professor("PROF0", "Alex", "A", DateTime.Now, Gender.Male, DateTime.Now));
            edgProfessors.AddEntity(new Professor("PROF10", "Alex", "A", DateTime.Now, Gender.Male, DateTime.Now));
            edgProfessors.AddEntity(new Professor("PROF11", "Alex", "A", DateTime.Now, Gender.Male, DateTime.Now));
            edgProfessors.AddEntity(new Professor("PROF12", "Alex", "A", DateTime.Now, Gender.Male, DateTime.Now));
            edgProfessors.AddEntity(new Professor("PROF14", "Alex", "A", DateTime.Now, Gender.Male, DateTime.Now));
            edgProfessors.AddEntity(new Professor("PROF15", "Alex", "A", DateTime.Now, Gender.Male, DateTime.Now));
            edgProfessors.AddEntity(new Professor("PROF16", "Alex", "A", DateTime.Now, Gender.Male, DateTime.Now));
            edgProfessors.AddEntity(new Professor("PROF17", "Alex", "A", DateTime.Now, Gender.Male, DateTime.Now));
            edgProfessors.AddEntity(new Professor("PROF1", "Bob", "A", DateTime.Now, Gender.Male, DateTime.Now));
            edgProfessors.AddEntity(new Professor("PROF2", "Amanda", "A", DateTime.Now, Gender.Male, DateTime.Now));
            edgProfessors.AddEntity(new Professor("PROF3", "Felex", "A", DateTime.Now, Gender.Male, DateTime.Now));
            edgProfessors.AddEntity(new Professor("PROF4", "Kevin", "A", DateTime.Now, Gender.Male, DateTime.Now));
            edgProfessors.AddEntity(new Professor("PROF5", "Jane", "A", DateTime.Now, Gender.Male, DateTime.Now));

            edgStudents.AddEntity(new Student("STU", "Alex", "A", DateTime.Now, Gender.Male, DateTime.Now));

            edgPrograms.AddEntity(new Professor("PROG", "Alex", "A", DateTime.Now, Gender.Male, DateTime.Now));

            edgCourses.AddEntity(new Professor("COU", "Alex", "A", DateTime.Now, Gender.Male, DateTime.Now));
            #endregion
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