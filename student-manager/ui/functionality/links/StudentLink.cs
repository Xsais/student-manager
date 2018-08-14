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

namespace student_manager.ui.functionality.links
{
    public partial class StudentLink : Form
    {
        private Student _student;

        public Student Student
        {
            get => _student;
            private set => _student = value;
        }

        private readonly ToolTip _masterTip = new ToolTip();
        
        private readonly Dictionary<LinkType, Tuple<ClickableDisplay, Control>> _avilableLinkTypees =
            new Dictionary<LinkType, Tuple<ClickableDisplay, Control>>();

        private LinkType? _current;

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

                            selected.Item2.Visible = true;

                            iPage.Count = selectedGroup.MaxPages;

                            selectedGroup.Selected = null;

                            iPage.Selected = 1;

                            switch (value.Value)
                            {
                                case LinkType.Programs:
                                    
                                    _masterTip.SetToolTip(picAdd, "Link Program");
                                    break;
                                case LinkType.Courses:
                                    
                                    _masterTip.SetToolTip(picAdd, "Link Course");
                                    break;
                            }
                        }
                    }
                    catch (KeyNotFoundException ex)
                    {
                    }

                    picAdd.Visible = false;
                    picMinus.Visible = false;
                }

                _current = value;
            }
        }

        public StudentLink(Student student)
        {
            InitializeComponent();
            
            _avilableLinkTypees.Add(LinkType.Programs, Tuple.Create<ClickableDisplay, Control>(cdPrograms, edgPrograms));
            _avilableLinkTypees.Add(LinkType.Courses, Tuple.Create<ClickableDisplay, Control>(cdCourses, edgCourses));
            
            cdPrograms.Click += (sender, e) => Current = LinkType.Programs;
            cdCourses.Click += (sender, e) => Current = LinkType.Courses;

            picMinus.Click += (sender, e) => {
                
                if (_current == null)
                {
                    return;
                }

                if (Current.Value == LinkType.Courses)
                {

                    _student.RemoveLink(edgCourses.Selected);
                    edgCourses.UpdateEntity(edgCourses.Selected);
                    
                    edgPrograms.Selected = null;
                }
                else if (Current.Value == LinkType.Programs)
                {

                    _student.RemoveLink(edgPrograms.Selected);
                    edgPrograms.UpdateEntity(edgPrograms.Selected);

                    _student.RemoveLinks(edgPrograms.Selected.PullLinks(LinkType.Courses));

                    edgPrograms.Selected = null;
                    cdCourses.Visible = false;
                }
            };

            picAdd.Click += (sender, args) =>
            {
                if (_current == null)
                {
                    return;
                }

                if (Current.Value == LinkType.Courses)
                {
                    
                    _student.AddLink(edgCourses.Selected);
                    edgCourses.UpdateEntity(edgCourses.Selected, true);
                    
                    edgCourses.Selected = null;

                    picAdd.Visible = false;
                    picMinus.Visible = false;
                }
                else if (Current.Value == LinkType.Programs)
                {

                    _student.AddLink(edgPrograms.Selected);
                    edgPrograms.UpdateEntity(edgPrograms.Selected, true);
                    
                    edgCourses.AddAll(edgPrograms.Selected.PullLinks(LinkType.Courses));

                    if (edgPrograms.Selected != null)
                    {
                        var isLinked = _student.IsLinked(edgPrograms.Selected);

                        picAdd.Visible = !isLinked;
                        picMinus.Visible = isLinked;
                    } else
                    {

                        picAdd.Visible = false;
                        picMinus.Visible = false;
                    }
                    
                    edgPrograms.Selected = null;
                    cdCourses.Visible = true;
                }
            };

            #region EventBinding_Pages
            #region Programs

            edgPrograms.SelectionChanged += (sender, args) =>
            {
                if (!_current.HasValue || _current.Value != LinkType.Programs)
                {
                    return;
                }

                if (edgPrograms.Selected != null)
                {
                    var isVisible = _student.IsLinked(edgPrograms.Selected);

                    picAdd.Visible = !isVisible;
                    picMinus.Visible = isVisible;
                } else
                {

                    picAdd.Visible = false;
                    picMinus.Visible = false;
                }

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

                var isVisible = _student.IsLinked(edgCourses.Selected);

                picAdd.Visible = !isVisible;
                picMinus.Visible = isVisible;

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
            #endregion

            Current = LinkType.Programs;
            
            iPage.SelectionChanged += (sender, args) =>
            {
                Console.WriteLine($"[{DateTime.Now}] Page change requested to page {iPage.Selected}");
                cdPage.Title = iPage.Selected.ToString();

                if (_current == null)
                {
                    return;
                }

                if (Current.Value == LinkType.Programs)
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

                if (Current.Value == LinkType.Programs)
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

            Student = student;
            
            edgPrograms.AddAll(info.opportunity.Program.All);

            var courses = student.PullLinks(LinkType.Courses);

            cdCourses.Visible = courses != null;
            
            edgCourses.AddAll(courses);
        }
    }
}
