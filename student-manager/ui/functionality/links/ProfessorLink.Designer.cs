namespace student_manager.ui.functionality.links
{
    partial class ProfessorLink
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProfessorLink));
            this.lblDivider = new System.Windows.Forms.Label();
            this.edgCourses = new student_manager.ui.display.EntityDisplayGroup();
            this.iPage = new student_manager.ui.display.Indicator();
            this.cdPage = new student_manager.ui.display.ClickableDisplay();
            this.sbEntites = new student_manager.ui.functionality.SearchBox();
            this.cdCourses = new student_manager.ui.display.ClickableDisplay();
            this.picAdd = new System.Windows.Forms.PictureBox();
            this.picMinus = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picAdd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMinus)).BeginInit();
            this.SuspendLayout();
            // 
            // lblDivider
            // 
            this.lblDivider.BackColor = System.Drawing.Color.Black;
            this.lblDivider.Location = new System.Drawing.Point(122, 0);
            this.lblDivider.Name = "lblDivider";
            this.lblDivider.Size = new System.Drawing.Size(1, 469);
            this.lblDivider.TabIndex = 30;
            // 
            // edgCourses
            // 
            this.edgCourses.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.edgCourses.BackColor = System.Drawing.SystemColors.Control;
            this.edgCourses.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.edgCourses.Location = new System.Drawing.Point(151, 99);
            this.edgCourses.Margin = new System.Windows.Forms.Padding(0);
            this.edgCourses.Name = "edgCourses";
            this.edgCourses.Page = 1;
            this.edgCourses.PerPage = 5;
            this.edgCourses.Selected = null;
            this.edgCourses.SelectionColor = System.Drawing.SystemColors.Highlight;
            this.edgCourses.Size = new System.Drawing.Size(535, 320);
            this.edgCourses.Spacing = 5;
            this.edgCourses.TabIndex = 23;
            // 
            // iPage
            // 
            this.iPage.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.iPage.Count = 0;
            this.iPage.HoverColor = System.Drawing.SystemColors.Highlight;
            this.iPage.IndicatorColor = System.Drawing.Color.Black;
            this.iPage.IndicatorCursor = System.Windows.Forms.Cursors.Hand;
            this.iPage.IndicatorSize = new System.Drawing.Size(8, 8);
            this.iPage.Location = new System.Drawing.Point(416, 455);
            this.iPage.Margin = new System.Windows.Forms.Padding(0);
            this.iPage.Name = "iPage";
            this.iPage.Selected = 0;
            this.iPage.SelectionColor = System.Drawing.SystemColors.Highlight;
            this.iPage.Size = new System.Drawing.Size(0, 0);
            this.iPage.Spacing = 5;
            this.iPage.TabIndex = 24;
            // 
            // cdPage
            // 
            this.cdPage.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cdPage.HighlightColor = System.Drawing.Color.Black;
            this.cdPage.IsSelected = false;
            this.cdPage.Location = new System.Drawing.Point(401, 425);
            this.cdPage.Margin = new System.Windows.Forms.Padding(0);
            this.cdPage.Name = "cdPage";
            this.cdPage.SelectionColor = System.Drawing.Color.Black;
            this.cdPage.Size = new System.Drawing.Size(26, 22);
            this.cdPage.TabIndex = 28;
            this.cdPage.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cdPage.Title = "1";
            this.cdPage.UnderlineColor = System.Drawing.Color.Black;
            this.cdPage.UnderlineHight = 2;
            // 
            // sbEntites
            // 
            this.sbEntites.BackColor = System.Drawing.SystemColors.Window;
            this.sbEntites.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sbEntites.Location = new System.Drawing.Point(439, 39);
            this.sbEntites.Margin = new System.Windows.Forms.Padding(0);
            this.sbEntites.MaximumSize = new System.Drawing.Size(262, 27);
            this.sbEntites.MinimumSize = new System.Drawing.Size(262, 27);
            this.sbEntites.Name = "sbEntites";
            this.sbEntites.Size = new System.Drawing.Size(262, 27);
            this.sbEntites.TabIndex = 29;
            // 
            // cdCourses
            // 
            this.cdCourses.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cdCourses.HighlightColor = System.Drawing.SystemColors.Highlight;
            this.cdCourses.IsSelected = false;
            this.cdCourses.Location = new System.Drawing.Point(13, 27);
            this.cdCourses.Margin = new System.Windows.Forms.Padding(0);
            this.cdCourses.Name = "cdCourses";
            this.cdCourses.SelectionColor = System.Drawing.SystemColors.Highlight;
            this.cdCourses.Size = new System.Drawing.Size(94, 26);
            this.cdCourses.TabIndex = 26;
            this.cdCourses.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.cdCourses.Title = "Courses";
            this.cdCourses.UnderlineColor = System.Drawing.Color.Black;
            this.cdCourses.UnderlineHight = 3;
            // 
            // picAdd
            // 
            this.picAdd.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.picAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picAdd.Image = ((System.Drawing.Image)(resources.GetObject("picAdd.Image")));
            this.picAdd.Location = new System.Drawing.Point(160, 75);
            this.picAdd.Margin = new System.Windows.Forms.Padding(0);
            this.picAdd.Name = "picAdd";
            this.picAdd.Size = new System.Drawing.Size(15, 17);
            this.picAdd.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picAdd.TabIndex = 25;
            this.picAdd.TabStop = false;
            this.picAdd.Visible = false;
            // 
            // picMinus
            // 
            this.picMinus.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.picMinus.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picMinus.Image = global::student_manager.Properties.Resources.minus;
            this.picMinus.Location = new System.Drawing.Point(160, 75);
            this.picMinus.Margin = new System.Windows.Forms.Padding(0);
            this.picMinus.Name = "picMinus";
            this.picMinus.Size = new System.Drawing.Size(15, 17);
            this.picMinus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picMinus.TabIndex = 32;
            this.picMinus.TabStop = false;
            this.picMinus.Visible = false;
            // 
            // ProfessorLink
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(715, 469);
            this.Controls.Add(this.picMinus);
            this.Controls.Add(this.lblDivider);
            this.Controls.Add(this.edgCourses);
            this.Controls.Add(this.iPage);
            this.Controls.Add(this.cdPage);
            this.Controls.Add(this.picAdd);
            this.Controls.Add(this.sbEntites);
            this.Controls.Add(this.cdCourses);
            this.Name = "ProfessorLink";
            this.Text = "ProfessorLink";
            ((System.ComponentModel.ISupportInitialize)(this.picAdd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMinus)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lblDivider;
        private display.EntityDisplayGroup edgCourses;
        private display.Indicator iPage;
        private display.ClickableDisplay cdPage;
        private SearchBox sbEntites;
        private display.ClickableDisplay cdCourses;
        private System.Windows.Forms.PictureBox picAdd;
        private System.Windows.Forms.PictureBox picMinus;
    }
}