namespace student_manager.ui.functionality
{
    partial class ConfirmBox
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
            this.lblDarken = new System.Windows.Forms.Label();
            this.pnlBox = new System.Windows.Forms.Panel();
            this.lblCancel = new System.Windows.Forms.Label();
            this.lblOk = new System.Windows.Forms.Label();
            this.lblText = new System.Windows.Forms.Label();
            this.pnlBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblDarken
            // 
            this.lblDarken.BackColor = System.Drawing.Color.Black;
            this.lblDarken.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDarken.Location = new System.Drawing.Point(0, 0);
            this.lblDarken.Name = "lblDarken";
            this.lblDarken.Size = new System.Drawing.Size(731, 508);
            this.lblDarken.TabIndex = 0;
            this.lblDarken.Click += new System.EventHandler(this.Reject);
            // 
            // pnlBox
            // 
            this.pnlBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pnlBox.BackColor = System.Drawing.SystemColors.Window;
            this.pnlBox.Controls.Add(this.lblCancel);
            this.pnlBox.Controls.Add(this.lblOk);
            this.pnlBox.Controls.Add(this.lblText);
            this.pnlBox.Location = new System.Drawing.Point(116, 167);
            this.pnlBox.Margin = new System.Windows.Forms.Padding(0);
            this.pnlBox.Name = "pnlBox";
            this.pnlBox.Size = new System.Drawing.Size(500, 175);
            this.pnlBox.TabIndex = 1;
            // 
            // lblCancel
            // 
            this.lblCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCancel.AutoSize = true;
            this.lblCancel.BackColor = System.Drawing.Color.Transparent;
            this.lblCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(67)))), ((int)(((byte)(54)))));
            this.lblCancel.Location = new System.Drawing.Point(340, 142);
            this.lblCancel.Name = "lblCancel";
            this.lblCancel.Size = new System.Drawing.Size(70, 13);
            this.lblCancel.TabIndex = 2;
            this.lblCancel.Text = "DISAGREE";
            this.lblCancel.Click += new System.EventHandler(this.Reject);
            // 
            // lblOk
            // 
            this.lblOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblOk.AutoSize = true;
            this.lblOk.BackColor = System.Drawing.Color.Transparent;
            this.lblOk.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblOk.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOk.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            this.lblOk.Location = new System.Drawing.Point(429, 142);
            this.lblOk.Name = "lblOk";
            this.lblOk.Size = new System.Drawing.Size(49, 13);
            this.lblOk.TabIndex = 1;
            this.lblOk.Text = "AGREE";
            this.lblOk.Click += new System.EventHandler(this.Accepted);
            // 
            // lblText
            // 
            this.lblText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblText.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblText.Location = new System.Drawing.Point(38, 30);
            this.lblText.Name = "lblText";
            this.lblText.Size = new System.Drawing.Size(425, 67);
            this.lblText.TabIndex = 0;
            this.lblText.Text = "Are you sure you want to delete that Program?";
            // 
            // ConfirmBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.pnlBox);
            this.Controls.Add(this.lblDarken);
            this.Name = "ConfirmBox";
            this.Size = new System.Drawing.Size(731, 508);
            this.pnlBox.ResumeLayout(false);
            this.pnlBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblDarken;
        private System.Windows.Forms.Panel pnlBox;
        private System.Windows.Forms.Label lblCancel;
        private System.Windows.Forms.Label lblOk;
        private System.Windows.Forms.Label lblText;
    }
}
