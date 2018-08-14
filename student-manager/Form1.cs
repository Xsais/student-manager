using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IronPdf;
using student_manager.info;
using student_manager.info.entity;
using student_manager.info.opportunity;
using student_manager.ui.display;
using student_manager.ui.display.manipulate;
using student_manager.ui.functionality.links;

namespace student_manager
{
    public partial class Form1 : Form
    {
        private readonly Dictionary<LinkType, Tuple<ClickableDisplay, Control>> _avilableLinkTypees =
            new Dictionary<LinkType, Tuple<ClickableDisplay, Control>>();
        
        private static readonly OpenFileDialog _fileChooser = new OpenFileDialog();

        private static readonly HtmlToPdf _pdfConverter = new HtmlToPdf();

        private LinkType? _current;

        private readonly ToolTip _masterTip = new ToolTip();

        private const string _deletionTemplate = "Are you sure you want to {0} that {1}";

        private readonly Dictionary<LinkType, AlterBox> _alterLinkType = new Dictionary<LinkType, AlterBox>();

        private LinkType? Current
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
                        var deselected = _avilableLinkTypees[_current.Value];

                        deselected.Item1.Cursor = Cursors.Hand;
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
                        var selected = _avilableLinkTypees[value.Value];
                        var selectedGroup = (EntityDisplayGroup) selected.Item2;

                        selected.Item1.Cursor = Cursors.Default;
                        selected.Item1.IsSelected = true;

                        if (selectedGroup != null)
                        {
                            pnlEnties.Visible = true;
                            pnlHome.Visible = false;

                            selected.Item2.Visible = true;

                            iPage.Count = selectedGroup.MaxPages;

                            selectedGroup.Selected = null;

                            iPage.Selected = 1;

                            switch (value.Value)
                            {
                                case LinkType.Students:
                                    
                                    _masterTip.SetToolTip(picAdd, "Add Student");
                                    _masterTip.SetToolTip(picMinus, "Delete Student");
                                    _masterTip.SetToolTip(picLink, "Link Student");
                                    break;
                                case LinkType.Professors:
                                    
                                    _masterTip.SetToolTip(picAdd, "Add Professor");
                                    _masterTip.SetToolTip(picMinus, "Delete Professor");
                                    _masterTip.SetToolTip(picLink, "Link Professor");
                                    break;
                                case LinkType.Programs:
                                    
                                    _masterTip.SetToolTip(picAdd, "Add Program");
                                    _masterTip.SetToolTip(picMinus, "Delete Program");
                                    _masterTip.SetToolTip(picLink, "Link Program");
                                    break;
                                case LinkType.Courses:
                                    
                                    _masterTip.SetToolTip(picAdd, "Add Course");
                                    _masterTip.SetToolTip(picMinus, "Delete Course");
                                    _masterTip.SetToolTip(picLink, "Link Course");
                                    break;
                            }
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

                picMinus.Visible = false;
                picEdit.Visible = false;
                picLink.Visible = false;

                _current = value;
            }
        }

        public Form1()
        {
            InitializeComponent();

            #region Page Binding
            _avilableLinkTypees.Add(LinkType.Home, Tuple.Create<ClickableDisplay, Control>(cdHome, null));
            _avilableLinkTypees.Add(LinkType.Programs, Tuple.Create<ClickableDisplay, Control>(cdPrograms, edgPrograms));
            _avilableLinkTypees.Add(LinkType.Courses, Tuple.Create<ClickableDisplay, Control>(cdCourses, edgCourses));
            _avilableLinkTypees.Add(LinkType.Students, Tuple.Create<ClickableDisplay, Control>(cdStudents, edgStudents));
            _avilableLinkTypees.Add(LinkType.Professors, Tuple.Create<ClickableDisplay, Control>(cdProfessors, edgProfessors));
            #endregion

            Current = LinkType.Students;

            #region Alter Forms

            var alterPerson = new AlterPerson
            {
                Confirming = () =>
                {
                    if (_current == null)
                    {
                        return;
                    }

                    if (Current.Value == LinkType.Students)
                    {
                        confirm.ShowDialog(string.Format(_deletionTemplate, "edit", "Student"), result =>
                        {

                            if (!result)
                            {
                                return;
                            }
                            _alterLinkType[LinkType.Students].Confirm();
                            edgStudents.UpdateEntity(edgStudents.Selected);

                            edgStudents.Selected = null;
                        });
                    }
                    else if (Current.Value == LinkType.Professors)
                    {
                        confirm.ShowDialog(string.Format(_deletionTemplate, "edit", "Professor"), result =>
                        {

                            if (!result)
                            {
                                return;
                            }
                            _alterLinkType[LinkType.Professors].Confirm();
                            edgProfessors.UpdateEntity(edgProfessors.Selected);

                            edgProfessors.Selected = null;
                        });
                    }

                    return;
                }
            };

            _alterLinkType.Add(LinkType.Courses, null);
            _alterLinkType.Add(LinkType.Professors, alterPerson);
            _alterLinkType.Add(LinkType.Programs, null);
            _alterLinkType.Add(LinkType.Students, alterPerson);
            #endregion

            #region Switching Events
            cdHome.Click += (sender, e) =>
            {
                pnlHome.Visible = !pnlHome.Visible;
                pnlHome.Visible = !pnlHome.Visible;

                Current = LinkType.Home;
            };
            cdPrograms.Click += (sender, e) => Current = LinkType.Programs;
            cdCourses.Click += (sender, e) => Current = LinkType.Courses;
            cdStudents.Click += (sender, e) => Current = LinkType.Students;
            cdProfessors.Click += (sender, e) => Current = LinkType.Professors;
            #endregion

            #region Functionality Events
            picReport.Click += (sendeer, args) =>
            {
                    if (_current == null)
                    {
                        return;
                    }

                    var linkHTML = new Dictionary<Type, string>();

                    var pdfHTML = "<h1 style='text-align: center;'>Student Manager Report</h1>";

                    switch (Current.Value)
                    {
                        case LinkType.Students:
                            
                            #region Generate Student Report
                            pdfHTML += "<h2 style='text-align: center;'>Students</h2><br /><br />"
                                       + "<table cellpadding='0' cellspacing='0' border='1' style='text-align: center; width: 100%;'><tr>"
                                       + "<th>ID</th>"
                                       + "<th>Name</th>"
                                       + "<th>Birthday</th>"
                                       + "<th>Gender</th>"
                                       + "<th>Startdate</th></tr>";

                            foreach (var person in Student.All)
                            {
                                pdfHTML += $"<tr><td>{person.ID}</td>"
                                           + $"<td>{person.FullName}</td>"
                                           + $"<td>{person.BirthDate:YYYY-MM-DD}</td>"
                                           + $"<td>{person.Gender}</td>"
                                           + $"<td>{person.StartDate:YYYY-MM-DD}</td></tr>";

                                foreach (var personLink in person.Links)
                                {
                                    switch (personLink)
                                    {
                                        case Course _:
                                            try
                                            {
                                                linkHTML.Add(typeof(Course),
                                                    "<h2 style='text-align: center;'>Courses</h2>"
                                                    + "<table cellpadding='0' cellspacing='0' border='1' style='text-align: center; width: 100%;'><tr>"
                                                    + "<th>ID</th>"
                                                    + "<th>Name</th>"
                                                    + "<th>Capacity</th>"
                                                    + "<th>Credits</th></tr>"
                                                    + $"<tr><th colspan='4'>{person}<th></tr>");
                                            }
                                            catch (Exception e)
                                            {
                                            }

                                            linkHTML[typeof(Course)] += $"<tr><td>{((Course) personLink).ID}</td>"
                                                                        + $"<td>{((Course) personLink).Name}</td>"
                                                                        + $"<td>{((Course) personLink).Capacity}</td>"
                                                                        + $"<td>{Math.Round(((Course) personLink).Credits):F2}</td></tr>";
                                            break;
                                        case info.opportunity.Program _:

                                            try
                                            {
                                                linkHTML.Add(typeof(info.opportunity.Program),
                                                    "<h2 style='text-align: center;'>Programs</h2>"
                                                    + "<table cellpadding='0' cellspacing='0' border='1' style='text-align: center; width: 100%;'><tr>"
                                                    + "<th>ID</th>"
                                                    + "<th>Name</th>"
                                                    + "<th>Duration</th>"
                                                    + "<th>Co-OP</th>"
                                                    + "<th>Outcome</th></tr>"
                                                    + $"<tr><th colspan='5'>{person}<th></tr>");
                                            }
                                            catch (Exception e)
                                            {
                                            }

                                            linkHTML[typeof(info.opportunity.Program)] +=
                                                $"<tr><td>{((info.opportunity.Program) personLink).ID}</td>"
                                                + $"<td>{((info.opportunity.Program) personLink).Name}</td>"
                                                + $"<td>{((info.opportunity.Program) personLink).Duration.Days / 365} Years</td>"
                                                + $"<td>{((info.opportunity.Program) personLink).IsCOOP}</td>"
                                                + $"<td>{((info.opportunity.Program) personLink).Outcome.ToString()}</td></tr>";
                                            break;
                                    }
                                }
                            }

                            pdfHTML += "</table>";

                            if (linkHTML.Count > 0)
                            {
                                pdfHTML += "<div style='position: absolute; top: 100%; width: 95%;'>";

                                foreach (var liinkMarkup in linkHTML)
                                {
                                    pdfHTML += liinkMarkup.Value + "</table>";
                                }

                                pdfHTML += "</div>";
                            }

                            pdfHTML += "</div>";
                            #endregion
                            break;
                        case LinkType.Professors:

                            #region Generate Professor Report

                            pdfHTML += "<h2 style='text-align: center;'>Professors</h2><br /><br />"
                                       + "<table cellpadding='0' cellspacing='0' border='1' style='text-align: center; width: 100%;'><tr>"
                                       + "<th>ID</th>"
                                       + "<th>Name</th>"
                                       + "<th>Birthday</th>"
                                       + "<th>Gender</th>"
                                       + "<th>Startdate</th></tr>";

                            foreach (var person in Professor.All)
                            {
                                pdfHTML += $"<tr><td>{person.ID}</td>"
                                           + $"<td>{person.FullName}</td>"
                                           + $"<td>{person.BirthDate:YYYY-MM-DD}</td>"
                                           + $"<td>{person.Gender}</td>"
                                           + $"<td>{person.StartDate:YYYY-MM-DD}</td></tr>";

                                foreach (var personLink in person.Links)
                                {
                                    switch (personLink)
                                    {
                                        case Course _:
                                            try
                                            {
                                                linkHTML.Add(typeof(Course),
                                                    "<h2 style='text-align: center;'>Courses</h2>"
                                                    + "<table cellpadding='0' cellspacing='0' border='1' style='text-align: center; width: 100%;'><tr>"
                                                    + "<th>ID</th>"
                                                    + "<th>Name</th>"
                                                    + "<th>Capacity</th>"
                                                    + "<th>Credits</th></tr>"
                                                    + $"<tr><th colspan='4'>{person}<th></tr>");
                                            }
                                            catch (Exception e)
                                            {
                                            }

                                            linkHTML[typeof(Course)] += $"<tr><td>{((Course) personLink).ID}</td>"
                                                                        + $"<td>{((Course) personLink).Name}</td>"
                                                                        + $"<td>{((Course) personLink).Capacity}</td>"
                                                                        + $"<td>{Math.Round(((Course) personLink).Credits):F2}</td></tr>";
                                            break;
                                    }
                                }
                            }

                            pdfHTML += "</table>";

                            if (linkHTML.Count > 0)
                            {
                                pdfHTML += "<div style='position: absolute; top: 100%; width: 95%;'>";

                                foreach (var liinkMarkup in linkHTML)
                                {
                                    pdfHTML += liinkMarkup.Value + "</table>";
                                }

                                pdfHTML += "</div>";
                            }

                            pdfHTML += "</div>";
                            #endregion
                            break;
                    }

                _fileChooser.CheckFileExists = false;
                _fileChooser.Filter = "PDF|*.pdf";
                
                if (_fileChooser.ShowDialog() != DialogResult.OK)
                {
                    return;
                }
                Clipboard.SetText(pdfHTML);
                Console.WriteLine(_fileChooser.FileName);

                if (File.Exists(_fileChooser.FileName)
                    && MessageBox.Show("The file is not empty.\n Replace contents?") != DialogResult.OK)
                {
                    return;
                }

                _pdfConverter.RenderHtmlAsPdf(pdfHTML).SaveAs(_fileChooser.FileName);
            };

            picLink.Click += (sendeer, args) =>
            {
                if (_current == null)
                {
                    return;
                }

                if (Current.Value == LinkType.Students)
                {
                    new StudentLink((Student)edgStudents.Selected).ShowDialog();
                }
                else if (Current.Value == LinkType.Professors)
                {
                    new ProfessorLink((Professor)edgStudents.Selected).ShowDialog();
                }
                else if (Current.Value == LinkType.Programs)
                {
                }
                else if (Current.Value == LinkType.Courses)
                {
                }
            };

            picMinus.Click += (sender, args) =>
            {
                if (_current == null)
                {
                    return;
                }

                if (Current.Value == LinkType.Students)
                {
                    confirm.ShowDialog(string.Format(_deletionTemplate, "delete", "Student"), result =>
                    {
                        if (!result)
                        {
                            return;
                        }

                        ((Student)edgStudents.Selected).Disconnet();

                        edgStudents.RemoveEntry(edgStudents.Selected);
                    });
                }
                else if (Current.Value == LinkType.Professors)
                {
                    confirm.ShowDialog(string.Format(_deletionTemplate, "delete", "Professor"), result =>
                    {
                        if (!result)
                        {
                            return;
                        }
                        
                        ((Professor)edgProfessors.Selected).Disconnet();

                        edgProfessors.RemoveEntry(edgProfessors.Selected);
                    });
                }
                else if (Current.Value == LinkType.Programs)
                {
                    confirm.ShowDialog(string.Format(_deletionTemplate, "delete", "Program"), result =>
                    {
                        if (!result)
                        {
                            return;
                        }

                        ((info.opportunity.Program)edgPrograms.Selected).Disconnet();

                        edgPrograms.RemoveEntry(edgPrograms.Selected);
                    });
                }
                else if (Current.Value == LinkType.Courses)
                {
                    confirm.ShowDialog(string.Format(_deletionTemplate, "delete", "Course"), result =>
                    {
                        if (!result)
                        {
                            return;
                        }
                        
                        ((Course)edgCourses.Selected).Disconnet();

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

                if (Current.Value == LinkType.Students)
                {
                    edgStudents.Selected = null;

                    var student = new Student();

                    _alterLinkType[Current.Value].Entity = student;

                    if (_alterLinkType[Current.Value].ShowDialog() == DialogResult.OK)
                    {
                        edgStudents.AddEntity(student);
                    }
                    else
                    {
                        student.Disconnet();
                    }
                }
                else if (Current.Value == LinkType.Professors)
                {
                    edgProfessors.Selected = null;

                    var professor = new Professor();

                    _alterLinkType[Current.Value].Entity = professor;

                    if (_alterLinkType[Current.Value].ShowDialog() == DialogResult.OK)
                    {
                        edgProfessors.AddEntity(professor);
                    }
                    else
                    {
                        professor.Disconnet();
                    }
                }
            };

            picEdit.Click += (sender, args) =>
            {
                if (_current == null)
                {
                    return;
                }

                if (Current.Value == LinkType.Students)
                {
                    _alterLinkType[Current.Value].Entity = edgStudents.Selected;

                    if (_alterLinkType[Current.Value].ShowDialog() == DialogResult.OK)
                    {
                        edgStudents.UpdateEntity(edgStudents.Selected);
                    }
                }
                else if (_current != null && Current.Value == LinkType.Professors)
                {
                    _alterLinkType[Current.Value].Entity = edgProfessors.Selected;

                    if (_alterLinkType[Current.Value].ShowDialog() == DialogResult.OK)
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
                if (!_current.HasValue || _current.Value != LinkType.Programs)
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
                if (!_current.HasValue || _current.Value != LinkType.Programs)
                {
                    return;
                }

                Console.WriteLine($"[{DateTime.Now}] The max page has changed to {edgPrograms.MaxPages}");
                iPage.Count = edgPrograms.MaxPages;
            };

            edgPrograms.PageChanged += (sender, args) =>
            {
                if (Current != LinkType.Programs)
                {
                    return;
                }

                iPage.Selected = edgPrograms.Page;
            };

            #endregion

            #region Courses

            edgCourses.SelectionChanged += (sender, args) =>
            {
                if (!_current.HasValue || _current.Value != LinkType.Courses)
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
                if (!_current.HasValue || _current.Value != LinkType.Courses)
                {
                    return;
                }

                Console.WriteLine($"[{DateTime.Now}] The max page has changed to {edgCourses.MaxPages}");
                iPage.Count = edgCourses.MaxPages;
            };

            edgCourses.PageChanged += (sender, args) =>
            {
                if (Current != LinkType.Courses)
                {
                    return;
                }

                iPage.Selected = edgCourses.Page;
            };

            #endregion

            #region Students

            edgStudents.SelectionChanged += (sender, args) =>
            {
                if (!_current.HasValue || _current.Value != LinkType.Students)
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
                if (!_current.HasValue || _current.Value != LinkType.Students)
                {
                    return;
                }

                Console.WriteLine($"[{DateTime.Now}] The max page has changed to {edgStudents.MaxPages}");
                iPage.Count = edgStudents.MaxPages;
            };

            edgStudents.PageChanged += (sender, args) =>
            {
                if (Current != LinkType.Students)
                {
                    return;
                }

                iPage.Selected = edgStudents.Page;
            };

            #endregion

            #region Professor

            edgProfessors.SelectionChanged += (sender, args) =>
            {
                if (!_current.HasValue || _current.Value != LinkType.Professors)
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
                if (!_current.HasValue || _current.Value != LinkType.Professors)
                {
                    return;
                }

                Console.WriteLine($"[{DateTime.Now}] The max page has changed to {edgProfessors.MaxPages}");
                iPage.Count = edgProfessors.MaxPages;
            };

            edgProfessors.PageChanged += (sender, args) =>
            {
                if (Current != LinkType.Professors)
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

                if (Current.Value == LinkType.Students)
                {
                    edgStudents.Page = iPage.Selected;
                }
                else if (Current.Value == LinkType.Professors)
                {
                    edgProfessors.Page = iPage.Selected;
                }
                else if (Current.Value == LinkType.Programs)
                {
                    edgPrograms.Page = iPage.Selected;
                }
                else if (Current.Value == LinkType.Courses)
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

                if (Current.Value == LinkType.Students)
                {
                    if (string.IsNullOrWhiteSpace(sbEntites.Text))
                    {
                        edgStudents.ClearSearch();
                        return;
                    }
                    edgStudents.DrawFiltered("FullName", sbEntites.Text);
                }
                else if (Current.Value == LinkType.Professors)
                {
                    if (string.IsNullOrWhiteSpace(sbEntites.Text))
                    {
                        edgProfessors.ClearSearch();
                        return;
                    }
                    edgProfessors.DrawFiltered("FullName", sbEntites.Text);
                }
                else if (Current.Value == LinkType.Programs)
                {
                    if (string.IsNullOrWhiteSpace(sbEntites.Text))
                    {
                        edgPrograms.ClearSearch();
                        return;
                    }
                    edgPrograms.Page = iPage.Selected;
                }
                else if (Current.Value == LinkType.Courses)
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
            /*edgProfessors.AddEntity(new Professor("PROF10", "Alex", "A", DateTime.Now, Gender.Male, DateTime.Now));
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
            edgProfessors.AddEntity(new Professor("PROF5", "Jane", "A", DateTime.Now, Gender.Male, DateTime.Now));*/

            edgStudents.AddEntity(new Student("STU0", "Alex", "A", DateTime.Now, Gender.Male, DateTime.Now));
            /*edgStudents.AddEntity(new Student("STU10", "Alex", "A", DateTime.Now, Gender.Male, DateTime.Now));
            edgStudents.AddEntity(new Student("STU11", "Alex", "A", DateTime.Now, Gender.Male, DateTime.Now));
            edgStudents.AddEntity(new Student("STU12", "Alex", "A", DateTime.Now, Gender.Male, DateTime.Now));
            edgStudents.AddEntity(new Student("STU14", "Alex", "A", DateTime.Now, Gender.Male, DateTime.Now));
            edgStudents.AddEntity(new Student("STU15", "Alex", "A", DateTime.Now, Gender.Male, DateTime.Now));
            edgStudents.AddEntity(new Student("STU16", "Alex", "A", DateTime.Now, Gender.Male, DateTime.Now));
            edgStudents.AddEntity(new Student("STU17", "Alex", "A", DateTime.Now, Gender.Male, DateTime.Now));
            edgStudents.AddEntity(new Student("STU1", "Bob", "A", DateTime.Now, Gender.Male, DateTime.Now));
            edgStudents.AddEntity(new Student("STU2", "Amanda", "A", DateTime.Now, Gender.Male, DateTime.Now));
            edgStudents.AddEntity(new Student("STU3", "Felex", "A", DateTime.Now, Gender.Male, DateTime.Now));
            edgStudents.AddEntity(new Student("STU4", "Kevin", "A", DateTime.Now, Gender.Male, DateTime.Now));
            edgStudents.AddEntity(new Student("STU5", "Jane", "A", DateTime.Now, Gender.Male, DateTime.Now));*/

            var program = new info.opportunity.Program("PROG0", "Test Course", TimeSpan.FromDays(730), false, Outcomes.Diploma);

            var course = new info.opportunity.Course("CRO0", "Test Course", 100, 4);
            program.AddLink(course);

            edgPrograms.AddEntity(program);
            edgPrograms.AddEntity(new info.opportunity.Program("PROG1", "Test Course", TimeSpan.FromDays(730), false, Outcomes.Diploma));
            /*edgPrograms.AddEntity(new info.opportunity.Program("PROG1"));
            edgPrograms.AddEntity(new info.opportunity.Program("PROG2"));
            edgPrograms.AddEntity(new info.opportunity.Program("PROG3"));
            edgPrograms.AddEntity(new info.opportunity.Program("PROG4"));*/

            edgCourses.AddEntity(course);
            /*edgPrograms.AddEntity(new info.opportunity.Program("PROG1"));
            edgPrograms.AddEntity(new info.opportunity.Program("PROG2"));
            edgPrograms.AddEntity(new info.opportunity.Program("PROG3"));
            edgPrograms.AddEntity(new info.opportunity.Program("PROG4"));*/
            #endregion

            _masterTip.SetToolTip(picReport, "Export Report");
        }
    }
}