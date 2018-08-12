namespace student_manager
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.picLink = new System.Windows.Forms.PictureBox();
            this.picEdit = new System.Windows.Forms.PictureBox();
            this.picMinus = new System.Windows.Forms.PictureBox();
            this.picAdd = new System.Windows.Forms.PictureBox();
            this.pnlEnties = new System.Windows.Forms.Panel();
            this.edgProfessors = new student_manager.ui.display.EntityDisplayGroup();
            this.edgCourses = new student_manager.ui.display.EntityDisplayGroup();
            this.edgPrograms = new student_manager.ui.display.EntityDisplayGroup();
            this.edgStudents = new student_manager.ui.display.EntityDisplayGroup();
            this.iPage = new student_manager.ui.display.Indicator();
            this.cdPage = new student_manager.ui.display.ClickableDisplay();
            this.sbEntites = new student_manager.ui.functionality.SearchBox();
            this.pnlHome = new System.Windows.Forms.Panel();
            this.lblDivider = new System.Windows.Forms.Label();
            this.cdProfessors = new student_manager.ui.display.ClickableDisplay();
            this.cdStudents = new student_manager.ui.display.ClickableDisplay();
            this.cdCourses = new student_manager.ui.display.ClickableDisplay();
            this.cdPrograms = new student_manager.ui.display.ClickableDisplay();
            this.cdHome = new student_manager.ui.display.ClickableDisplay();
            this.cdPageCount = new student_manager.ui.display.ClickableDisplay();
            ((System.ComponentModel.ISupportInitialize)(this.picLink)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMinus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAdd)).BeginInit();
            this.pnlEnties.SuspendLayout();
            this.SuspendLayout();
            // 
            // picLink
            // 
            this.picLink.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.picLink.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picLink.Image = ((System.Drawing.Image)(resources.GetObject("picLink.Image")));
            this.picLink.Location = new System.Drawing.Point(532, 67);
            this.picLink.Margin = new System.Windows.Forms.Padding(0);
            this.picLink.Name = "picLink";
            this.picLink.Size = new System.Drawing.Size(15, 17);
            this.picLink.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picLink.TabIndex = 5;
            this.picLink.TabStop = false;
            this.picLink.Visible = false;
            // 
            // picEdit
            // 
            this.picEdit.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.picEdit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picEdit.Image = ((System.Drawing.Image)(resources.GetObject("picEdit.Image")));
            this.picEdit.Location = new System.Drawing.Point(94, 67);
            this.picEdit.Margin = new System.Windows.Forms.Padding(0);
            this.picEdit.Name = "picEdit";
            this.picEdit.Size = new System.Drawing.Size(15, 17);
            this.picEdit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picEdit.TabIndex = 3;
            this.picEdit.TabStop = false;
            this.picEdit.Visible = false;
            // 
            // picMinus
            // 
            this.picMinus.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.picMinus.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picMinus.Image = ((System.Drawing.Image)(resources.GetObject("picMinus.Image")));
            this.picMinus.Location = new System.Drawing.Point(67, 67);
            this.picMinus.Margin = new System.Windows.Forms.Padding(0);
            this.picMinus.Name = "picMinus";
            this.picMinus.Size = new System.Drawing.Size(15, 17);
            this.picMinus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picMinus.TabIndex = 2;
            this.picMinus.TabStop = false;
            this.picMinus.Visible = false;
            // 
            // picAdd
            // 
            this.picAdd.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.picAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picAdd.Image = ((System.Drawing.Image)(resources.GetObject("picAdd.Image")));
            this.picAdd.Location = new System.Drawing.Point(39, 67);
            this.picAdd.Margin = new System.Windows.Forms.Padding(0);
            this.picAdd.Name = "picAdd";
            this.picAdd.Size = new System.Drawing.Size(15, 17);
            this.picAdd.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picAdd.TabIndex = 1;
            this.picAdd.TabStop = false;
            // 
            // pnlEnties
            // 
            this.pnlEnties.BackColor = System.Drawing.SystemColors.Control;
            this.pnlEnties.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pnlEnties.Controls.Add(this.edgProfessors);
            this.pnlEnties.Controls.Add(this.edgCourses);
            this.pnlEnties.Controls.Add(this.edgPrograms);
            this.pnlEnties.Controls.Add(this.edgStudents);
            this.pnlEnties.Controls.Add(this.iPage);
            this.pnlEnties.Controls.Add(this.cdPage);
            this.pnlEnties.Controls.Add(this.picLink);
            this.pnlEnties.Controls.Add(this.picEdit);
            this.pnlEnties.Controls.Add(this.picMinus);
            this.pnlEnties.Controls.Add(this.picAdd);
            this.pnlEnties.Controls.Add(this.sbEntites);
            this.pnlEnties.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlEnties.Location = new System.Drawing.Point(117, 0);
            this.pnlEnties.Margin = new System.Windows.Forms.Padding(0);
            this.pnlEnties.Name = "pnlEnties";
            this.pnlEnties.Size = new System.Drawing.Size(598, 469);
            this.pnlEnties.TabIndex = 0;
            this.pnlEnties.Text = "grpStudents";
            // 
            // edgProfessors
            // 
            this.edgProfessors.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.edgProfessors.BackColor = System.Drawing.SystemColors.Control;
            this.edgProfessors.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.edgProfessors.Location = new System.Drawing.Point(30, 91);
            this.edgProfessors.Margin = new System.Windows.Forms.Padding(0);
            this.edgProfessors.Name = "edgProfessors";
            this.edgProfessors.Page = 1;
            this.edgProfessors.PerPage = 5;
            this.edgProfessors.Selected = null;
            this.edgProfessors.SelectionColor = System.Drawing.SystemColors.Highlight;
            this.edgProfessors.Size = new System.Drawing.Size(535, 320);
            this.edgProfessors.Spacing = 5;
            this.edgProfessors.TabIndex = 0;
            this.edgProfessors.Visible = false;
            // 
            // edgCourses
            // 
            this.edgCourses.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.edgCourses.BackColor = System.Drawing.SystemColors.Control;
            this.edgCourses.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.edgCourses.Location = new System.Drawing.Point(30, 91);
            this.edgCourses.Margin = new System.Windows.Forms.Padding(0);
            this.edgCourses.Name = "edgCourses";
            this.edgCourses.Page = 1;
            this.edgCourses.PerPage = 5;
            this.edgCourses.Selected = null;
            this.edgCourses.SelectionColor = System.Drawing.SystemColors.Highlight;
            this.edgCourses.Size = new System.Drawing.Size(535, 320);
            this.edgCourses.Spacing = 5;
            this.edgCourses.TabIndex = 0;
            this.edgCourses.Visible = false;
            // 
            // edgPrograms
            // 
            this.edgPrograms.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.edgPrograms.BackColor = System.Drawing.SystemColors.Control;
            this.edgPrograms.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.edgPrograms.Location = new System.Drawing.Point(30, 91);
            this.edgPrograms.Margin = new System.Windows.Forms.Padding(0);
            this.edgPrograms.Name = "edgPrograms";
            this.edgPrograms.Page = 1;
            this.edgPrograms.PerPage = 5;
            this.edgPrograms.Selected = null;
            this.edgPrograms.SelectionColor = System.Drawing.SystemColors.Highlight;
            this.edgPrograms.Size = new System.Drawing.Size(535, 320);
            this.edgPrograms.Spacing = 5;
            this.edgPrograms.TabIndex = 0;
            this.edgPrograms.Visible = false;
            // 
            // edgStudents
            // 
            this.edgStudents.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.edgStudents.BackColor = System.Drawing.SystemColors.Control;
            this.edgStudents.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.edgStudents.Location = new System.Drawing.Point(30, 91);
            this.edgStudents.Margin = new System.Windows.Forms.Padding(0);
            this.edgStudents.Name = "edgStudents";
            this.edgStudents.Page = 1;
            this.edgStudents.PerPage = 5;
            this.edgStudents.Selected = null;
            this.edgStudents.SelectionColor = System.Drawing.SystemColors.Highlight;
            this.edgStudents.Size = new System.Drawing.Size(535, 320);
            this.edgStudents.Spacing = 5;
            this.edgStudents.TabIndex = 0;
            this.edgStudents.Visible = false;
            // 
            // iPage
            // 
            this.iPage.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.iPage.Count = 0;
            this.iPage.HoverColor = System.Drawing.SystemColors.Highlight;
            this.iPage.IndicatorColor = System.Drawing.Color.Black;
            this.iPage.IndicatorCursor = System.Windows.Forms.Cursors.Hand;
            this.iPage.IndicatorSize = new System.Drawing.Size(8, 8);
            this.iPage.Location = new System.Drawing.Point(295, 447);
            this.iPage.Margin = new System.Windows.Forms.Padding(0);
            this.iPage.Name = "iPage";
            this.iPage.Selected = 0;
            this.iPage.SelectionColor = System.Drawing.SystemColors.Highlight;
            this.iPage.Size = new System.Drawing.Size(0, 0);
            this.iPage.Spacing = 5;
            this.iPage.TabIndex = 0;
            // 
            // cdPage
            // 
            this.cdPage.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cdPage.HighlightColor = System.Drawing.Color.Black;
            this.cdPage.IsSelected = false;
            this.cdPage.Location = new System.Drawing.Point(280, 417);
            this.cdPage.Margin = new System.Windows.Forms.Padding(0);
            this.cdPage.Name = "cdPage";
            this.cdPage.SelectionColor = System.Drawing.Color.Black;
            this.cdPage.Size = new System.Drawing.Size(26, 22);
            this.cdPage.TabIndex = 7;
            this.cdPage.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cdPage.Title = "1";
            this.cdPage.UnderlineColor = System.Drawing.Color.Black;
            this.cdPage.UnderlineHight = 2;
            // 
            // sbEntites
            // 
            this.sbEntites.BackColor = System.Drawing.SystemColors.Window;
            this.sbEntites.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sbEntites.Location = new System.Drawing.Point(318, 31);
            this.sbEntites.Margin = new System.Windows.Forms.Padding(0);
            this.sbEntites.MaximumSize = new System.Drawing.Size(262, 27);
            this.sbEntites.MinimumSize = new System.Drawing.Size(262, 27);
            this.sbEntites.Name = "sbEntites";
            this.sbEntites.Size = new System.Drawing.Size(262, 27);
            this.sbEntites.TabIndex = 8;
            // 
            // pnlHome
            // 
            this.pnlHome.BackColor = System.Drawing.SystemColors.Control;
            this.pnlHome.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pnlHome.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlHome.Location = new System.Drawing.Point(-481, 0);
            this.pnlHome.Margin = new System.Windows.Forms.Padding(0);
            this.pnlHome.Name = "pnlHome";
            this.pnlHome.Size = new System.Drawing.Size(598, 469);
            this.pnlHome.TabIndex = 9;
            this.pnlHome.Text = "grpStudents";
            this.pnlHome.Visible = false;
            // 
            // lblDivider
            // 
            this.lblDivider.BackColor = System.Drawing.Color.Black;
            this.lblDivider.Location = new System.Drawing.Point(115, 0);
            this.lblDivider.Name = "lblDivider";
            this.lblDivider.Size = new System.Drawing.Size(1, 469);
            this.lblDivider.TabIndex = 6;
            // 
            // cdProfessors
            // 
            this.cdProfessors.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cdProfessors.HighlightColor = System.Drawing.SystemColors.Highlight;
            this.cdProfessors.IsSelected = false;
            this.cdProfessors.Location = new System.Drawing.Point(10, 274);
            this.cdProfessors.Name = "cdProfessors";
            this.cdProfessors.SelectionColor = System.Drawing.SystemColors.Highlight;
            this.cdProfessors.Size = new System.Drawing.Size(94, 26);
            this.cdProfessors.TabIndex = 5;
            this.cdProfessors.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.cdProfessors.Title = "Professors";
            this.cdProfessors.UnderlineColor = System.Drawing.Color.Black;
            this.cdProfessors.UnderlineHight = 3;
            // 
            // cdStudents
            // 
            this.cdStudents.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cdStudents.HighlightColor = System.Drawing.SystemColors.Highlight;
            this.cdStudents.IsSelected = false;
            this.cdStudents.Location = new System.Drawing.Point(10, 215);
            this.cdStudents.Margin = new System.Windows.Forms.Padding(0);
            this.cdStudents.Name = "cdStudents";
            this.cdStudents.SelectionColor = System.Drawing.SystemColors.Highlight;
            this.cdStudents.Size = new System.Drawing.Size(94, 26);
            this.cdStudents.TabIndex = 4;
            this.cdStudents.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.cdStudents.Title = "Students";
            this.cdStudents.UnderlineColor = System.Drawing.Color.Black;
            this.cdStudents.UnderlineHight = 3;
            // 
            // cdCourses
            // 
            this.cdCourses.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cdCourses.HighlightColor = System.Drawing.SystemColors.Highlight;
            this.cdCourses.IsSelected = false;
            this.cdCourses.Location = new System.Drawing.Point(10, 152);
            this.cdCourses.Margin = new System.Windows.Forms.Padding(0);
            this.cdCourses.Name = "cdCourses";
            this.cdCourses.SelectionColor = System.Drawing.SystemColors.Highlight;
            this.cdCourses.Size = new System.Drawing.Size(94, 26);
            this.cdCourses.TabIndex = 3;
            this.cdCourses.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.cdCourses.Title = "Courses";
            this.cdCourses.UnderlineColor = System.Drawing.Color.Black;
            this.cdCourses.UnderlineHight = 3;
            // 
            // cdPrograms
            // 
            this.cdPrograms.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cdPrograms.HighlightColor = System.Drawing.SystemColors.Highlight;
            this.cdPrograms.IsSelected = false;
            this.cdPrograms.Location = new System.Drawing.Point(10, 91);
            this.cdPrograms.Margin = new System.Windows.Forms.Padding(0);
            this.cdPrograms.Name = "cdPrograms";
            this.cdPrograms.SelectionColor = System.Drawing.SystemColors.Highlight;
            this.cdPrograms.Size = new System.Drawing.Size(94, 26);
            this.cdPrograms.TabIndex = 2;
            this.cdPrograms.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.cdPrograms.Title = "Programs";
            this.cdPrograms.UnderlineColor = System.Drawing.Color.Black;
            this.cdPrograms.UnderlineHight = 3;
            // 
            // cdHome
            // 
            this.cdHome.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cdHome.HighlightColor = System.Drawing.SystemColors.Highlight;
            this.cdHome.IsSelected = false;
            this.cdHome.Location = new System.Drawing.Point(10, 32);
            this.cdHome.Margin = new System.Windows.Forms.Padding(0);
            this.cdHome.Name = "cdHome";
            this.cdHome.SelectionColor = System.Drawing.SystemColors.Highlight;
            this.cdHome.Size = new System.Drawing.Size(94, 26);
            this.cdHome.TabIndex = 1;
            this.cdHome.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.cdHome.Title = "Home";
            this.cdHome.UnderlineColor = System.Drawing.Color.Black;
            this.cdHome.UnderlineHight = 3;
            // 
            // cdPageCount
            // 
            this.cdPageCount.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cdPageCount.HighlightColor = System.Drawing.Color.Black;
            this.cdPageCount.IsSelected = false;
            this.cdPageCount.Location = new System.Drawing.Point(280, 417);
            this.cdPageCount.Margin = new System.Windows.Forms.Padding(0);
            this.cdPageCount.Name = "cdPageCount";
            this.cdPageCount.SelectionColor = System.Drawing.Color.Black;
            this.cdPageCount.Size = new System.Drawing.Size(26, 22);
            this.cdPageCount.TabIndex = 7;
            this.cdPageCount.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cdPageCount.Title = "1";
            this.cdPageCount.UnderlineColor = System.Drawing.Color.Black;
            this.cdPageCount.UnderlineHight = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(715, 469);
            this.Controls.Add(this.lblDivider);
            this.Controls.Add(this.cdPrograms);
            this.Controls.Add(this.cdStudents);
            this.Controls.Add(this.cdProfessors);
            this.Controls.Add(this.cdHome);
            this.Controls.Add(this.cdCourses);
            this.Controls.Add(this.pnlHome);
            this.Controls.Add(this.pnlEnties);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.picLink)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMinus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAdd)).EndInit();
            this.pnlEnties.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private ui.display.ClickableDisplay cdHome;
        private ui.display.ClickableDisplay cdPrograms;
        private ui.display.ClickableDisplay cdCourses;
        private ui.display.ClickableDisplay cdStudents;
        private ui.display.ClickableDisplay cdProfessors;
        private System.Windows.Forms.PictureBox picEdit;
        private System.Windows.Forms.PictureBox picMinus;
        private System.Windows.Forms.PictureBox picAdd;
        private System.Windows.Forms.PictureBox picLink;
        private ui.display.EntityDisplayGroup edgStudents;
        private ui.display.EntityDisplayGroup edgProfessors;
        private ui.display.EntityDisplayGroup edgCourses;
        private ui.display.EntityDisplayGroup edgPrograms;
        private ui.display.ClickableDisplay cdPage;
        private ui.display.Indicator iPage;
        private System.Windows.Forms.Panel pnlEnties;
        private System.Windows.Forms.Label lblDivider;
        private System.Windows.Forms.Panel pnlHome;
        private ui.display.ClickableDisplay cdPageCount;
        private ui.functionality.SearchBox sbEntites;
    }
}

