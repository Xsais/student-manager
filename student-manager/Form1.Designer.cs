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
            this.pnlStudents = new System.Windows.Forms.Panel();
            this.searchBox = new student_manager.ui.functionality.SearchBox();
            this.picLink = new System.Windows.Forms.PictureBox();
            this.picEdit = new System.Windows.Forms.PictureBox();
            this.picMinus = new System.Windows.Forms.PictureBox();
            this.picAdd = new System.Windows.Forms.PictureBox();
            this.edStudents = new student_manager.ui.display.EntityDisplayGroup();
            this.cdProfessors = new student_manager.ui.display.ClickableDisplay();
            this.cdStudents = new student_manager.ui.display.ClickableDisplay();
            this.cdCourses = new student_manager.ui.display.ClickableDisplay();
            this.cdPrograms = new student_manager.ui.display.ClickableDisplay();
            this.cdHome = new student_manager.ui.display.ClickableDisplay();
            this.pnlStudents.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLink)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMinus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAdd)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlStudents
            // 
            this.pnlStudents.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pnlStudents.Controls.Add(this.searchBox);
            this.pnlStudents.Controls.Add(this.picLink);
            this.pnlStudents.Controls.Add(this.picEdit);
            this.pnlStudents.Controls.Add(this.picMinus);
            this.pnlStudents.Controls.Add(this.picAdd);
            this.pnlStudents.Controls.Add(this.edStudents);
            this.pnlStudents.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlStudents.Location = new System.Drawing.Point(145, 0);
            this.pnlStudents.Name = "pnlStudents";
            this.pnlStudents.Size = new System.Drawing.Size(646, 461);
            this.pnlStudents.TabIndex = 0;
            this.pnlStudents.Text = "grpStudents";
            // 
            // searchBox
            // 
            this.searchBox.BackColor = System.Drawing.SystemColors.Window;
            this.searchBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.searchBox.Location = new System.Drawing.Point(337, 32);
            this.searchBox.MaximumSize = new System.Drawing.Size(261, 31);
            this.searchBox.MinimumSize = new System.Drawing.Size(261, 31);
            this.searchBox.Name = "searchBox";
            this.searchBox.Size = new System.Drawing.Size(261, 31);
            this.searchBox.TabIndex = 6;
            // 
            // picLink
            // 
            this.picLink.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picLink.Image = ((System.Drawing.Image)(resources.GetObject("picLink.Image")));
            this.picLink.Location = new System.Drawing.Point(575, 91);
            this.picLink.Name = "picLink";
            this.picLink.Size = new System.Drawing.Size(17, 17);
            this.picLink.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picLink.TabIndex = 5;
            this.picLink.TabStop = false;
            this.picLink.Visible = false;
            // 
            // picEdit
            // 
            this.picEdit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picEdit.Image = ((System.Drawing.Image)(resources.GetObject("picEdit.Image")));
            this.picEdit.Location = new System.Drawing.Point(137, 91);
            this.picEdit.Name = "picEdit";
            this.picEdit.Size = new System.Drawing.Size(17, 17);
            this.picEdit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picEdit.TabIndex = 3;
            this.picEdit.TabStop = false;
            this.picEdit.Visible = false;
            // 
            // picMinus
            // 
            this.picMinus.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picMinus.Image = ((System.Drawing.Image)(resources.GetObject("picMinus.Image")));
            this.picMinus.Location = new System.Drawing.Point(105, 91);
            this.picMinus.Name = "picMinus";
            this.picMinus.Size = new System.Drawing.Size(17, 17);
            this.picMinus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picMinus.TabIndex = 2;
            this.picMinus.TabStop = false;
            this.picMinus.Visible = false;
            // 
            // picAdd
            // 
            this.picAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picAdd.Image = ((System.Drawing.Image)(resources.GetObject("picAdd.Image")));
            this.picAdd.Location = new System.Drawing.Point(73, 91);
            this.picAdd.Name = "picAdd";
            this.picAdd.Size = new System.Drawing.Size(17, 17);
            this.picAdd.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picAdd.TabIndex = 1;
            this.picAdd.TabStop = false;
            // 
            // edStudents
            // 
            this.edStudents.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.edStudents.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.edStudents.Location = new System.Drawing.Point(63, 115);
            this.edStudents.Name = "edStudents";
            this.edStudents.PerPage = 5;
            this.edStudents.Selected = null;
            this.edStudents.SelectionColor = System.Drawing.SystemColors.Highlight;
            this.edStudents.Size = new System.Drawing.Size(535, 300);
            this.edStudents.Spacing = 5;
            this.edStudents.TabIndex = 0;
            // 
            // cdProfessors
            // 
            this.cdProfessors.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cdProfessors.HighlightColor = System.Drawing.SystemColors.Highlight;
            this.cdProfessors.IsSelected = false;
            this.cdProfessors.Location = new System.Drawing.Point(12, 274);
            this.cdProfessors.Name = "cdProfessors";
            this.cdProfessors.SelectionColor = System.Drawing.SystemColors.Highlight;
            this.cdProfessors.Size = new System.Drawing.Size(110, 29);
            this.cdProfessors.TabIndex = 5;
            this.cdProfessors.Title = "Professors";
            this.cdProfessors.UnderlineColor = System.Drawing.Color.Black;
            // 
            // cdStudents
            // 
            this.cdStudents.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cdStudents.HighlightColor = System.Drawing.SystemColors.Highlight;
            this.cdStudents.IsSelected = false;
            this.cdStudents.Location = new System.Drawing.Point(12, 215);
            this.cdStudents.Name = "cdStudents";
            this.cdStudents.SelectionColor = System.Drawing.SystemColors.Highlight;
            this.cdStudents.Size = new System.Drawing.Size(110, 29);
            this.cdStudents.TabIndex = 4;
            this.cdStudents.Title = "Students";
            this.cdStudents.UnderlineColor = System.Drawing.Color.Black;
            // 
            // cdCourses
            // 
            this.cdCourses.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cdCourses.HighlightColor = System.Drawing.SystemColors.Highlight;
            this.cdCourses.IsSelected = false;
            this.cdCourses.Location = new System.Drawing.Point(12, 152);
            this.cdCourses.Name = "cdCourses";
            this.cdCourses.SelectionColor = System.Drawing.SystemColors.Highlight;
            this.cdCourses.Size = new System.Drawing.Size(110, 29);
            this.cdCourses.TabIndex = 3;
            this.cdCourses.Title = "Courses";
            this.cdCourses.UnderlineColor = System.Drawing.Color.Black;
            // 
            // cdPrograms
            // 
            this.cdPrograms.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cdPrograms.HighlightColor = System.Drawing.SystemColors.Highlight;
            this.cdPrograms.IsSelected = false;
            this.cdPrograms.Location = new System.Drawing.Point(12, 91);
            this.cdPrograms.Name = "cdPrograms";
            this.cdPrograms.SelectionColor = System.Drawing.SystemColors.Highlight;
            this.cdPrograms.Size = new System.Drawing.Size(110, 29);
            this.cdPrograms.TabIndex = 2;
            this.cdPrograms.Title = "Programs";
            this.cdPrograms.UnderlineColor = System.Drawing.Color.Black;
            // 
            // cdHome
            // 
            this.cdHome.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cdHome.HighlightColor = System.Drawing.SystemColors.Highlight;
            this.cdHome.IsSelected = false;
            this.cdHome.Location = new System.Drawing.Point(12, 32);
            this.cdHome.Name = "cdHome";
            this.cdHome.SelectionColor = System.Drawing.SystemColors.Highlight;
            this.cdHome.Size = new System.Drawing.Size(110, 29);
            this.cdHome.TabIndex = 1;
            this.cdHome.Title = "Home";
            this.cdHome.UnderlineColor = System.Drawing.Color.Black;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(791, 461);
            this.Controls.Add(this.cdProfessors);
            this.Controls.Add(this.cdStudents);
            this.Controls.Add(this.cdCourses);
            this.Controls.Add(this.cdPrograms);
            this.Controls.Add(this.cdHome);
            this.Controls.Add(this.pnlStudents);
            this.Font = new System.Drawing.Font("Roboto", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "Form1";
            this.Text = "Form1";
            this.pnlStudents.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picLink)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMinus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAdd)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlStudents;
        private ui.display.ClickableDisplay cdHome;
        private ui.display.ClickableDisplay cdPrograms;
        private ui.display.ClickableDisplay cdCourses;
        private ui.display.ClickableDisplay cdStudents;
        private ui.display.ClickableDisplay cdProfessors;
        private System.Windows.Forms.PictureBox picEdit;
        private System.Windows.Forms.PictureBox picMinus;
        private System.Windows.Forms.PictureBox picAdd;
        private ui.display.EntityDisplayGroup edStudents;
        private System.Windows.Forms.PictureBox picLink;
        private ui.functionality.SearchBox searchBox;
    }
}

