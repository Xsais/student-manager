namespace student_manager.ui.functionality
{
    partial class SearchBox
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtSearchBox = new System.Windows.Forms.TextBox();
            this.pcExit = new System.Windows.Forms.PictureBox();
            this.picSearch = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pcExit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSearch)).BeginInit();
            this.SuspendLayout();
            // 
            // txtSearchBox
            // 
            this.txtSearchBox.BackColor = System.Drawing.SystemColors.Window;
            this.txtSearchBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSearchBox.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtSearchBox.Location = new System.Drawing.Point(5, 7);
            this.txtSearchBox.Margin = new System.Windows.Forms.Padding(3, 5, 0, 5);
            this.txtSearchBox.Name = "txtSearchBox";
            this.txtSearchBox.Size = new System.Drawing.Size(228, 13);
            this.txtSearchBox.TabIndex = 7;
            this.txtSearchBox.TextChanged += new System.EventHandler(this.Searching);
            // 
            // pcExit
            // 
            this.pcExit.BackColor = System.Drawing.SystemColors.Window;
            this.pcExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pcExit.Image = global::student_manager.Properties.Resources.exit;
            this.pcExit.Location = new System.Drawing.Point(239, 5);
            this.pcExit.Margin = new System.Windows.Forms.Padding(0, 5, 3, 5);
            this.pcExit.Name = "pcExit";
            this.pcExit.Size = new System.Drawing.Size(16, 16);
            this.pcExit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcExit.TabIndex = 9;
            this.pcExit.TabStop = false;
            this.pcExit.Visible = false;
            this.pcExit.Click += new System.EventHandler(this.ClearSearch);
            // 
            // picSearch
            // 
            this.picSearch.BackColor = System.Drawing.SystemColors.Window;
            this.picSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picSearch.Image = global::student_manager.Properties.Resources.search;
            this.picSearch.Location = new System.Drawing.Point(236, 3);
            this.picSearch.Margin = new System.Windows.Forms.Padding(0, 5, 3, 5);
            this.picSearch.Name = "picSearch";
            this.picSearch.Size = new System.Drawing.Size(21, 21);
            this.picSearch.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picSearch.TabIndex = 8;
            this.picSearch.TabStop = false;
            this.picSearch.Click += new System.EventHandler(this.Search);
            // 
            // SearchBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.pcExit);
            this.Controls.Add(this.picSearch);
            this.Controls.Add(this.txtSearchBox);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.MaximumSize = new System.Drawing.Size(262, 27);
            this.MinimumSize = new System.Drawing.Size(262, 27);
            this.Name = "SearchBox";
            this.Size = new System.Drawing.Size(260, 25);
            ((System.ComponentModel.ISupportInitialize)(this.pcExit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSearch)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picSearch;
        private System.Windows.Forms.TextBox txtSearchBox;
        private System.Windows.Forms.PictureBox pcExit;
    }
}
