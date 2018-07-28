namespace student_manager.ui.display
{
    partial class ClickableDisplay
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
            this.lblUderLine = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblUderLine
            // 
            this.lblUderLine.BackColor = System.Drawing.Color.Black;
            this.lblUderLine.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblUderLine.Location = new System.Drawing.Point(0, 21);
            this.lblUderLine.Name = "lblUderLine";
            this.lblUderLine.Size = new System.Drawing.Size(81, 4);
            this.lblUderLine.TabIndex = 1;
            this.lblUderLine.Text = "label1";
            // 
            // lblTitle
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(81, 25);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Click += new System.EventHandler(this.TitleClicked);
            this.lblTitle.MouseLeave += new System.EventHandler(this.DeHighlightClickable);
            this.lblTitle.MouseHover += new System.EventHandler(this.HiglightClickable);
            // 
            // ClickableDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblUderLine);
            this.Controls.Add(this.lblTitle);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Name = "ClickableDisplay";
            this.Size = new System.Drawing.Size(81, 25);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lblUderLine;
        private System.Windows.Forms.Label lblTitle;
    }
}
