namespace student_manager.ui.display
{
    partial class EntityDisplay
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
            this.lblheader = new System.Windows.Forms.Label();
            this.lblSub = new System.Windows.Forms.Label();
            this.lblAdditional = new System.Windows.Forms.Label();
            this.lblTag = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblheader
            // 
            this.lblheader.BackColor = System.Drawing.Color.Transparent;
            this.lblheader.CausesValidation = false;
            this.lblheader.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblheader.Location = new System.Drawing.Point(10, 12);
            this.lblheader.Name = "lblheader";
            this.lblheader.Size = new System.Drawing.Size(379, 20);
            this.lblheader.TabIndex = 0;
            this.lblheader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblheader.UseMnemonic = false;
            this.lblheader.Click += new System.EventHandler(this.ClickTrough);
            this.lblheader.DoubleClick += new System.EventHandler(this.DoubleClickThrough);
            // 
            // lblSub
            // 
            this.lblSub.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSub.BackColor = System.Drawing.Color.Transparent;
            this.lblSub.CausesValidation = false;
            this.lblSub.Location = new System.Drawing.Point(15, 38);
            this.lblSub.Name = "lblSub";
            this.lblSub.Size = new System.Drawing.Size(144, 13);
            this.lblSub.TabIndex = 1;
            this.lblSub.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblSub.UseMnemonic = false;
            this.lblSub.Click += new System.EventHandler(this.ClickTrough);
            this.lblSub.DoubleClick += new System.EventHandler(this.DoubleClickThrough);
            // 
            // lblAdditional
            // 
            this.lblAdditional.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAdditional.BackColor = System.Drawing.Color.Transparent;
            this.lblAdditional.CausesValidation = false;
            this.lblAdditional.Location = new System.Drawing.Point(315, 38);
            this.lblAdditional.Name = "lblAdditional";
            this.lblAdditional.Size = new System.Drawing.Size(201, 13);
            this.lblAdditional.TabIndex = 2;
            this.lblAdditional.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblAdditional.UseMnemonic = false;
            this.lblAdditional.Click += new System.EventHandler(this.ClickTrough);
            this.lblAdditional.DoubleClick += new System.EventHandler(this.DoubleClickThrough);
            // 
            // lblTag
            // 
            this.lblTag.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTag.BackColor = System.Drawing.Color.Transparent;
            this.lblTag.CausesValidation = false;
            this.lblTag.Location = new System.Drawing.Point(405, 10);
            this.lblTag.Name = "lblTag";
            this.lblTag.Size = new System.Drawing.Size(115, 15);
            this.lblTag.TabIndex = 3;
            this.lblTag.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblTag.UseMnemonic = false;
            this.lblTag.Click += new System.EventHandler(this.ClickTrough);
            this.lblTag.DoubleClick += new System.EventHandler(this.DoubleClickThrough);
            // 
            // EntityDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblTag);
            this.Controls.Add(this.lblAdditional);
            this.Controls.Add(this.lblSub);
            this.Controls.Add(this.lblheader);
            this.Name = "EntityDisplay";
            this.Size = new System.Drawing.Size(535, 60);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblheader;
        private System.Windows.Forms.Label lblSub;
        private System.Windows.Forms.Label lblAdditional;
        private System.Windows.Forms.Label lblTag;
    }
}
