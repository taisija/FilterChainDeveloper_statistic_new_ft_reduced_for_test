namespace FilterChainDeveloper
{
    partial class COptions
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
            this.acceptButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.SaveFilterListCheckBox = new System.Windows.Forms.CheckBox();
            this.SaveImageAllRadioButton = new System.Windows.Forms.RadioButton();
            this.SaveBestAllImageRadioButton = new System.Windows.Forms.RadioButton();
            this.SaveFirstLastAllImageRadioButton = new System.Windows.Forms.RadioButton();
            this.SaveFirstLastBestImageRadioButton = new System.Windows.Forms.RadioButton();
            this.filtrationResultGroupBox = new System.Windows.Forms.GroupBox();
            this.filtrationResultGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // acceptButton
            // 
            this.acceptButton.Location = new System.Drawing.Point(31, 226);
            this.acceptButton.Name = "acceptButton";
            this.acceptButton.Size = new System.Drawing.Size(103, 27);
            this.acceptButton.TabIndex = 4;
            this.acceptButton.Text = "Accept";
            this.acceptButton.UseVisualStyleBackColor = true;
            this.acceptButton.Click += new System.EventHandler(this.acceptButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(364, 226);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(102, 27);
            this.cancelButton.TabIndex = 5;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // SaveFilterListCheckBox
            // 
            this.SaveFilterListCheckBox.AutoSize = true;
            this.SaveFilterListCheckBox.Checked = true;
            this.SaveFilterListCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.SaveFilterListCheckBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SaveFilterListCheckBox.Location = new System.Drawing.Point(31, 183);
            this.SaveFilterListCheckBox.Name = "SaveFilterListCheckBox";
            this.SaveFilterListCheckBox.Size = new System.Drawing.Size(227, 17);
            this.SaveFilterListCheckBox.TabIndex = 6;
            this.SaveFilterListCheckBox.Text = "Save the filter chains for the above images";
            this.SaveFilterListCheckBox.UseVisualStyleBackColor = true;
            // 
            // SaveImageAllRadioButton
            // 
            this.SaveImageAllRadioButton.AutoSize = true;
            this.SaveImageAllRadioButton.Checked = true;
            this.SaveImageAllRadioButton.Location = new System.Drawing.Point(13, 30);
            this.SaveImageAllRadioButton.Name = "SaveImageAllRadioButton";
            this.SaveImageAllRadioButton.Size = new System.Drawing.Size(302, 17);
            this.SaveImageAllRadioButton.TabIndex = 8;
            this.SaveImageAllRadioButton.TabStop = true;
            this.SaveImageAllRadioButton.Text = "Save the filtration results for all individuals of all populations";
            this.SaveImageAllRadioButton.UseVisualStyleBackColor = true;
            // 
            // SaveBestAllImageRadioButton
            // 
            this.SaveBestAllImageRadioButton.AutoSize = true;
            this.SaveBestAllImageRadioButton.Location = new System.Drawing.Point(13, 53);
            this.SaveBestAllImageRadioButton.Name = "SaveBestAllImageRadioButton";
            this.SaveBestAllImageRadioButton.Size = new System.Drawing.Size(312, 17);
            this.SaveBestAllImageRadioButton.TabIndex = 9;
            this.SaveBestAllImageRadioButton.Text = "Save the filtration results for best individuals of all populations";
            this.SaveBestAllImageRadioButton.UseVisualStyleBackColor = true;
            // 
            // SaveFirstLastAllImageRadioButton
            // 
            this.SaveFirstLastAllImageRadioButton.AutoSize = true;
            this.SaveFirstLastAllImageRadioButton.Location = new System.Drawing.Point(13, 76);
            this.SaveFirstLastAllImageRadioButton.Name = "SaveFirstLastAllImageRadioButton";
            this.SaveFirstLastAllImageRadioButton.Size = new System.Drawing.Size(348, 17);
            this.SaveFirstLastAllImageRadioButton.TabIndex = 10;
            this.SaveFirstLastAllImageRadioButton.Text = "Save the filtration results for all individuals of first and last populations";
            this.SaveFirstLastAllImageRadioButton.UseVisualStyleBackColor = true;
            // 
            // SaveFirstLastBestImageRadioButton
            // 
            this.SaveFirstLastBestImageRadioButton.AutoSize = true;
            this.SaveFirstLastBestImageRadioButton.Location = new System.Drawing.Point(13, 99);
            this.SaveFirstLastBestImageRadioButton.Name = "SaveFirstLastBestImageRadioButton";
            this.SaveFirstLastBestImageRadioButton.Size = new System.Drawing.Size(358, 17);
            this.SaveFirstLastBestImageRadioButton.TabIndex = 11;
            this.SaveFirstLastBestImageRadioButton.Text = "Save the filtration results for best individuals of first and last populations";
            this.SaveFirstLastBestImageRadioButton.UseVisualStyleBackColor = true;
            // 
            // filtrationResultGroupBox
            // 
            this.filtrationResultGroupBox.Controls.Add(this.SaveFirstLastBestImageRadioButton);
            this.filtrationResultGroupBox.Controls.Add(this.SaveFirstLastAllImageRadioButton);
            this.filtrationResultGroupBox.Controls.Add(this.SaveBestAllImageRadioButton);
            this.filtrationResultGroupBox.Controls.Add(this.SaveImageAllRadioButton);
            this.filtrationResultGroupBox.Location = new System.Drawing.Point(18, 28);
            this.filtrationResultGroupBox.Name = "filtrationResultGroupBox";
            this.filtrationResultGroupBox.Size = new System.Drawing.Size(459, 138);
            this.filtrationResultGroupBox.TabIndex = 12;
            this.filtrationResultGroupBox.TabStop = false;
            this.filtrationResultGroupBox.Text = "Filtration results";
            // 
            // COptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(493, 271);
            this.Controls.Add(this.filtrationResultGroupBox);
            this.Controls.Add(this.SaveFilterListCheckBox);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.acceptButton);
            this.Name = "COptions";
            this.Text = "Save options";
            this.filtrationResultGroupBox.ResumeLayout(false);
            this.filtrationResultGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button acceptButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.CheckBox SaveFilterListCheckBox;
        private System.Windows.Forms.RadioButton SaveImageAllRadioButton;
        private System.Windows.Forms.RadioButton SaveBestAllImageRadioButton;
        private System.Windows.Forms.RadioButton SaveFirstLastAllImageRadioButton;
        private System.Windows.Forms.RadioButton SaveFirstLastBestImageRadioButton;
        private System.Windows.Forms.GroupBox filtrationResultGroupBox;
    }
}