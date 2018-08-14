using student_manager.info;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace student_manager.ui.functionality.links
{
    public partial class ProfessorLink : Form
    {
        private Professor Professor { get; set; }

        private readonly ToolTip _masterTip = new ToolTip();

        public ProfessorLink(Professor professor)
        {
            InitializeComponent();

            picMinus.Click += (sender, e) =>
            {
                Professor.RemoveLink(edgCourses.Selected);

                edgCourses.Selected = null;
            };

            picAdd.Click += (sender, args) =>
            {
                Professor.AddLink(edgCourses.Selected);

                if (edgCourses.Selected != null)
                {
                    var isLinked = Professor.IsLinked(edgCourses.Selected);

                    picAdd.Visible = !isLinked;
                    picMinus.Visible = isLinked;
                }
                else
                {
                    picAdd.Visible = false;
                    picMinus.Visible = false;
                }

                edgCourses.Selected = null;
            };

            #region EventBinding_Pages

            #region Courses

            edgCourses.SelectionChanged += (sender, args) =>
            {
                var isVisible = Professor.IsLinked(edgCourses.Selected);

                picAdd.Visible = !isVisible;
                picMinus.Visible = isVisible;

                Console.WriteLine($"[{DateTime.Now}] Current Selection \"{edgCourses.Selected}\"");
            };

            edgCourses.MaxChanged += (sender, args) =>
            {

                Console.WriteLine($"[{DateTime.Now}] The max page has changed to {edgCourses.MaxPages}");
                iPage.Count = edgCourses.MaxPages;
            };

            edgCourses.PageChanged += (sender, args) =>
            {

                iPage.Selected = edgCourses.Page;
            };

            #endregion
            #endregion

            iPage.SelectionChanged += (sender, args) =>
            {
                Console.WriteLine($"[{DateTime.Now}] Page change requested to page {iPage.Selected}");
                cdPage.Title = iPage.Selected.ToString();

                edgCourses.Page = iPage.Selected;
            };

            sbEntites.Searched += (sender, e) =>
            {
                    if (string.IsNullOrWhiteSpace(sbEntites.Text))
                    {
                        edgCourses.ClearSearch();
                        return;
                    }
                    edgCourses.Page = iPage.Selected;
                Console.WriteLine($"[{DateTime.Now}] Search requested {sbEntites.Text}");
            };

            Professor = professor;

            edgCourses.AddAll(info.opportunity.Course.All);
        }
    }
}