namespace student_manager.ui.display.manipulate
{
    partial class AlterPerson
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
            this.lblID = new System.Windows.Forms.Label();
            this.lblFirst = new System.Windows.Forms.Label();
            this.lblLast = new System.Windows.Forms.Label();
            this.lblBirth = new System.Windows.Forms.Label();
            this.lblGender = new System.Windows.Forms.Label();
            this.lblStart = new System.Windows.Forms.Label();
            this.cbGender = new System.Windows.Forms.ComboBox();
            this.dpStart = new System.Windows.Forms.DateTimePicker();
            this.dpBirth = new System.Windows.Forms.DateTimePicker();
            this.errLast = new student_manager.ui.functionality.ErrorTextBox();
            this.errFirst = new student_manager.ui.functionality.ErrorTextBox();
            this.errID = new student_manager.ui.functionality.ErrorTextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblID.Location = new System.Drawing.Point(12, 55);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(79, 18);
            this.lblID.TabIndex = 0;
            this.lblID.Text = "ID Number";
            // 
            // lblFirst
            // 
            this.lblFirst.AutoSize = true;
            this.lblFirst.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFirst.Location = new System.Drawing.Point(12, 101);
            this.lblFirst.Name = "lblFirst";
            this.lblFirst.Size = new System.Drawing.Size(81, 18);
            this.lblFirst.TabIndex = 1;
            this.lblFirst.Text = "First Name";
            // 
            // lblLast
            // 
            this.lblLast.AutoSize = true;
            this.lblLast.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLast.Location = new System.Drawing.Point(12, 147);
            this.lblLast.Name = "lblLast";
            this.lblLast.Size = new System.Drawing.Size(80, 18);
            this.lblLast.TabIndex = 2;
            this.lblLast.Text = "Last Name";
            // 
            // lblBirth
            // 
            this.lblBirth.AutoSize = true;
            this.lblBirth.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBirth.Location = new System.Drawing.Point(22, 197);
            this.lblBirth.Name = "lblBirth";
            this.lblBirth.Size = new System.Drawing.Size(61, 18);
            this.lblBirth.TabIndex = 3;
            this.lblBirth.Text = "Birthday";
            // 
            // lblGender
            // 
            this.lblGender.AutoSize = true;
            this.lblGender.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGender.Location = new System.Drawing.Point(22, 243);
            this.lblGender.Name = "lblGender";
            this.lblGender.Size = new System.Drawing.Size(57, 18);
            this.lblGender.TabIndex = 4;
            this.lblGender.Text = "Gender";
            // 
            // lblStart
            // 
            this.lblStart.AutoSize = true;
            this.lblStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStart.Location = new System.Drawing.Point(12, 280);
            this.lblStart.Name = "lblStart";
            this.lblStart.Size = new System.Drawing.Size(74, 18);
            this.lblStart.TabIndex = 5;
            this.lblStart.Text = "Start Date";
            // 
            // cbGender
            // 
            this.cbGender.FormattingEnabled = true;
            this.cbGender.Items.AddRange(new object[] {
            "Male",
            "Femae"});
            this.cbGender.Location = new System.Drawing.Point(99, 240);
            this.cbGender.Name = "cbGender";
            this.cbGender.Size = new System.Drawing.Size(324, 21);
            this.cbGender.TabIndex = 12;
            // 
            // dpStart
            // 
            this.dpStart.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpStart.Location = new System.Drawing.Point(99, 279);
            this.dpStart.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dpStart.Name = "dpStart";
            this.dpStart.Size = new System.Drawing.Size(324, 20);
            this.dpStart.TabIndex = 13;
            // 
            // dpBirth
            // 
            this.dpBirth.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpBirth.Location = new System.Drawing.Point(99, 195);
            this.dpBirth.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dpBirth.Name = "dpBirth";
            this.dpBirth.Size = new System.Drawing.Size(324, 20);
            this.dpBirth.TabIndex = 14;
            // 
            // errLast
            // 
            this.errLast.DisplayName = "Last Name";
            this.errLast.ErrorColor = System.Drawing.Color.FromArgb(((int)(((byte)(183)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.errLast.ErrorText = null;
            this.errLast.Location = new System.Drawing.Point(99, 142);
            this.errLast.Name = "errLast";
            this.errLast.PlaceColor = System.Drawing.SystemColors.GrayText;
            this.errLast.PlaceHolder = "Last Name";
            this.errLast.Size = new System.Drawing.Size(324, 22);
            this.errLast.Status = student_manager.info.Status.Normal;
            this.errLast.StatusColor = System.Drawing.Color.Black;
            this.errLast.TabIndex = 17;
            this.errLast.Validated += new System.EventHandler(this.ValidateRequired);
            // 
            // errFirst
            // 
            this.errFirst.DisplayName = "Fist Name";
            this.errFirst.ErrorColor = System.Drawing.Color.FromArgb(((int)(((byte)(183)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.errFirst.ErrorText = null;
            this.errFirst.Location = new System.Drawing.Point(99, 97);
            this.errFirst.Name = "errFirst";
            this.errFirst.PlaceColor = System.Drawing.SystemColors.GrayText;
            this.errFirst.PlaceHolder = "First Name";
            this.errFirst.Size = new System.Drawing.Size(324, 22);
            this.errFirst.Status = student_manager.info.Status.Normal;
            this.errFirst.StatusColor = System.Drawing.Color.Black;
            this.errFirst.TabIndex = 18;
            this.errFirst.Validated += new System.EventHandler(this.ValidateRequired);
            // 
            // errID
            // 
            this.errID.DisplayName = "ID";
            this.errID.ErrorColor = System.Drawing.Color.FromArgb(((int)(((byte)(183)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.errID.ErrorText = null;
            this.errID.Location = new System.Drawing.Point(97, 51);
            this.errID.Name = "errID";
            this.errID.PlaceColor = System.Drawing.SystemColors.GrayText;
            this.errID.PlaceHolder = "ID Number";
            this.errID.Size = new System.Drawing.Size(324, 22);
            this.errID.Status = student_manager.info.Status.Normal;
            this.errID.StatusColor = System.Drawing.Color.Black;
            this.errID.TabIndex = 19;
            this.errID.Validated += new System.EventHandler(this.ValidateID);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(380, 311);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 20;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.AbortRequested);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(288, 311);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 21;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.SavePerson);
            // 
            // AlterPerson
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(467, 346);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.errID);
            this.Controls.Add(this.errFirst);
            this.Controls.Add(this.errLast);
            this.Controls.Add(this.dpBirth);
            this.Controls.Add(this.dpStart);
            this.Controls.Add(this.cbGender);
            this.Controls.Add(this.lblStart);
            this.Controls.Add(this.lblGender);
            this.Controls.Add(this.lblBirth);
            this.Controls.Add(this.lblLast);
            this.Controls.Add(this.lblFirst);
            this.Controls.Add(this.lblID);
            this.Name = "AlterPerson";
            this.ShowIcon = false;
            this.Text = "AlterPerson";
            this.Controls.SetChildIndex(this.lblID, 0);
            this.Controls.SetChildIndex(this.lblFirst, 0);
            this.Controls.SetChildIndex(this.lblLast, 0);
            this.Controls.SetChildIndex(this.lblBirth, 0);
            this.Controls.SetChildIndex(this.lblGender, 0);
            this.Controls.SetChildIndex(this.lblStart, 0);
            this.Controls.SetChildIndex(this.cbGender, 0);
            this.Controls.SetChildIndex(this.dpStart, 0);
            this.Controls.SetChildIndex(this.dpBirth, 0);
            this.Controls.SetChildIndex(this.errLast, 0);
            this.Controls.SetChildIndex(this.errFirst, 0);
            this.Controls.SetChildIndex(this.errID, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.btnSave, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.Label lblFirst;
        private System.Windows.Forms.Label lblLast;
        private System.Windows.Forms.Label lblBirth;
        private System.Windows.Forms.Label lblGender;
        private System.Windows.Forms.Label lblStart;
        private System.Windows.Forms.ComboBox cbGender;
        private System.Windows.Forms.DateTimePicker dpStart;
        private System.Windows.Forms.DateTimePicker dpBirth;
        private functionality.ErrorTextBox errLast;
        private functionality.ErrorTextBox errFirst;
        private functionality.ErrorTextBox errID;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
    }
}