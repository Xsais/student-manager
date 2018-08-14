namespace student_manager.ui.functionality.links
{
    partial class StudentLink
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StudentLink));
            this.picAdd = new System.Windows.Forms.PictureBox();
            this.lblDivider = new System.Windows.Forms.Label();
            this.picMinus = new System.Windows.Forms.PictureBox();
            this.edgCourses = new student_manager.ui.display.EntityDisplayGroup();
            this.edgPrograms = new student_manager.ui.display.EntityDisplayGroup();
            this.iPage = new student_manager.ui.display.Indicator();
            this.cdPage = new student_manager.ui.display.ClickableDisplay();
            this.sbEntites = new student_manager.ui.functionality.SearchBox();
            this.cdPrograms = new student_manager.ui.display.ClickableDisplay();
            this.cdCourses = new student_manager.ui.display.ClickableDisplay();
            ((System.ComponentModel.ISupportInitialize)(this.picAdd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMinus)).BeginInit();
            this.SuspendLayout();
            // 
            // picAdd
            // 
            this.picAdd.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.picAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picAdd.Image = ((System.Drawing.Image)(resources.GetObject("picAdd.Image")));
            this.picAdd.Location = new System.Drawing.Point(156, 75);
            this.picAdd.Margin = new System.Windows.Forms.Padding(0);
            this.picAdd.Name = "picAdd";
            this.picAdd.Size = new System.Drawing.Size(15, 17);
            this.picAdd.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picAdd.TabIndex = 12;
            this.picAdd.TabStop = false;
            this.picAdd.Visible = false;
            // 
            // lblDivider
            // 
            this.lblDivider.BackColor = System.Drawing.Color.Black;
            this.lblDivider.Location = new System.Drawing.Point(118, 0);
            this.lblDivider.Name = "lblDivider";
            this.lblDivider.Size = new System.Drawing.Size(1, 469);
            this.lblDivider.TabIndex = 20;
            // 
            // picMinus
            // 
            this.picMinus.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.picMinus.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picMinus.Image = global::student_manager.Properties.Resources.minus;
            this.picMinus.Location = new System.Drawing.Point(156, 75);
            this.picMinus.Margin = new System.Windows.Forms.Padding(0);
            this.picMinus.Name = "picMinus";
            this.picMinus.Size = new System.Drawing.Size(15, 17);
            this.picMinus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picMinus.TabIndex = 22;
            this.picMinus.TabStop = false;
            this.picMinus.Visible = false;
            // 
            // edgCourses
            // 
            this.edgCourses.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.edgCourses.BackColor = System.Drawing.SystemColors.Control;
            this.edgCourses.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.edgCourses.Location = new System.Drawing.Point(147, 99);
            this.edgCourses.Margin = new System.Windows.Forms.Padding(0);
            this.edgCourses.Name = "edgCourses";
            this.edgCourses.Page = 1;
            this.edgCourses.PerPage = 5;
            this.edgCourses.Selected = null;
            this.edgCourses.SelectionColor = System.Drawing.SystemColors.Highlight;
            this.edgCourses.Size = new System.Drawing.Size(535, 320);
            this.edgCourses.Spacing = 5;
            this.edgCourses.TabIndex = 21;
            this.edgCourses.Visible = false;
            // 
            // edgPrograms
            // 
            this.edgPrograms.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.edgPrograms.BackColor = System.Drawing.SystemColors.Control;
            this.edgPrograms.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.edgPrograms.Location = new System.Drawing.Point(147, 99);
            this.edgPrograms.Margin = new System.Windows.Forms.Padding(0);
            this.edgPrograms.Name = "edgPrograms";
            this.edgPrograms.Page = 1;
            this.edgPrograms.PerPage = 5;
            this.edgPrograms.Selected = null;
            this.edgPrograms.SelectionColor = System.Drawing.SystemColors.Highlight;
            this.edgPrograms.Size = new System.Drawing.Size(535, 320);
            this.edgPrograms.Spacing = 5;
            this.edgPrograms.TabIndex = 10;
            this.edgPrograms.Visible = false;
            // 
            // iPage
            // 
            this.iPage.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.iPage.Count = 0;
            this.iPage.HoverColor = System.Drawing.SystemColors.Highlight;
            this.iPage.IndicatorColor = System.Drawing.Color.Black;
            this.iPage.IndicatorCursor = System.Windows.Forms.Cursors.Hand;
            this.iPage.IndicatorSize = new System.Drawing.Size(8, 8);
            this.iPage.Location = new System.Drawing.Point(412, 455);
            this.iPage.Margin = new System.Windows.Forms.Padding(0);
            this.iPage.Name = "iPage";
            this.iPage.Selected = 0;
            this.iPage.SelectionColor = System.Drawing.SystemColors.Highlight;
            this.iPage.Size = new System.Drawing.Size(0, 0);
            this.iPage.Spacing = 5;
            this.iPage.TabIndex = 11;
            // 
            // cdPage
            // 
            this.cdPage.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cdPage.HighlightColor = System.Drawing.Color.Black;
            this.cdPage.IsSelected = false;
            this.cdPage.Location = new System.Drawing.Point(397, 425);
            this.cdPage.Margin = new System.Windows.Forms.Padding(0);
            this.cdPage.Name = "cdPage";
            this.cdPage.SelectionColor = System.Drawing.Color.Black;
            this.cdPage.Size = new System.Drawing.Size(26, 22);
            this.cdPage.TabIndex = 17;
            this.cdPage.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cdPage.Title = "1";
            this.cdPage.UnderlineColor = System.Drawing.Color.Black;
            this.cdPage.UnderlineHight = 2;
            // 
            // sbEntites
            // 
            this.sbEntites.BackColor = System.Drawing.SystemColors.Window;
            this.sbEntites.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sbEntites.Location = new System.Drawing.Point(435, 39);
            this.sbEntites.Margin = new System.Windows.Forms.Padding(0);
            this.sbEntites.MaximumSize = new System.Drawing.Size(262, 27);
            this.sbEntites.MinimumSize = new System.Drawing.Size(262, 27);
            this.sbEntites.Name = "sbEntites";
            this.sbEntites.Size = new System.Drawing.Size(262, 27);
            this.sbEntites.TabIndex = 18;
            // 
            // cdPrograms
            // 
            this.cdPrograms.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cdPrograms.HighlightColor = System.Drawing.SystemColors.Highlight;
            this.cdPrograms.IsSelected = false;
            this.cdPrograms.Location = new System.Drawing.Point(9, 27);
            this.cdPrograms.Margin = new System.Windows.Forms.Padding(0);
            this.cdPrograms.Name = "cdPrograms";
            this.cdPrograms.SelectionColor = System.Drawing.SystemColors.Highlight;
            this.cdPrograms.Size = new System.Drawing.Size(94, 26);
            this.cdPrograms.TabIndex = 13;
            this.cdPrograms.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.cdPrograms.Title = "Programs";
            this.cdPrograms.UnderlineColor = System.Drawing.Color.Black;
            this.cdPrograms.UnderlineHight = 3;
            // 
            // cdCourses
            // 
            this.cdCourses.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cdCourses.HighlightColor = System.Drawing.SystemColors.Highlight;
            this.cdCourses.IsSelected = false;
            this.cdCourses.Location = new System.Drawing.Point(9, 86);
            this.cdCourses.Margin = new System.Windows.Forms.Padding(0);
            this.cdCourses.Name = "cdCourses";
            this.cdCourses.SelectionColor = System.Drawing.SystemColors.Highlight;
            this.cdCourses.Size = new System.Drawing.Size(94, 26);
            this.cdCourses.TabIndex = 15;
            this.cdCourses.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.cdCourses.Title = "Courses";
            this.cdCourses.UnderlineColor = System.Drawing.Color.Black;
            this.cdCourses.UnderlineHight = 3;
            this.cdCourses.Visible = false;
            // 
            // StudentLink
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(715, 469);
            this.Controls.Add(this.picMinus);
            this.Controls.Add(this.edgCourses);
            this.Controls.Add(this.lblDivider);
            this.Controls.Add(this.edgPrograms);
            this.Controls.Add(this.iPage);
            this.Controls.Add(this.cdPage);
            this.Controls.Add(this.picAdd);
            this.Controls.Add(this.sbEntites);
            this.Controls.Add(this.cdCourses);
            this.Controls.Add(this.cdPrograms);
            this.Name = "StudentLink";
            this.Text = "StudentLink";
            ((System.ComponentModel.ISupportInitialize)(this.picAdd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMinus)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private display.EntityDisplayGroup edgPrograms;
        private display.Indicator iPage;
        private display.ClickableDisplay cdPage;
        private System.Windows.Forms.PictureBox picAdd;
        private SearchBox sbEntites;
        private display.ClickableDisplay cdPrograms;
        private System.Windows.Forms.Label lblDivider;
        private display.EntityDisplayGroup edgCourses;
        private System.Windows.Forms.PictureBox picMinus;
        private display.ClickableDisplay cdCourses;
    }
}