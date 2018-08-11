namespace student_manager.ui.functionality
{
    partial class ErrorTextBox
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
            this.lblNotifications = new System.Windows.Forms.Label();
            this.txtText = new System.Windows.Forms.TextBox();
            this.lblPlace = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblNotifications
            // 
            this.lblNotifications.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblNotifications.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblNotifications.Location = new System.Drawing.Point(0, 20);
            this.lblNotifications.Name = "lblNotifications";
            this.lblNotifications.Size = new System.Drawing.Size(128, 2);
            this.lblNotifications.TabIndex = 0;
            // 
            // txtText
            // 
            this.txtText.BackColor = System.Drawing.SystemColors.Control;
            this.txtText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtText.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtText.Location = new System.Drawing.Point(0, 0);
            this.txtText.Name = "txtText";
            this.txtText.Size = new System.Drawing.Size(128, 15);
            this.txtText.TabIndex = 1;
            this.txtText.TextChanged += new System.EventHandler(this.InProgress);
            // 
            // lblPlace
            // 
            this.lblPlace.BackColor = System.Drawing.Color.Transparent;
            this.lblPlace.Location = new System.Drawing.Point(0, 0);
            this.lblPlace.Name = "lblPlace";
            this.lblPlace.Size = new System.Drawing.Size(128, 15);
            this.lblPlace.TabIndex = 2;
            // 
            // ErrorTextBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblNotifications);
            this.Controls.Add(this.txtText);
            this.Controls.Add(this.lblPlace);
            this.Name = "ErrorTextBox";
            this.Size = new System.Drawing.Size(128, 22);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNotifications;
        private System.Windows.Forms.TextBox txtText;
        private System.Windows.Forms.Label lblPlace;
    }
}
