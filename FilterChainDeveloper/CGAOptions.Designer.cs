namespace FilterChainDeveloper
{
    partial class CGAOptions
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
            this.linearFitnessFunctionRadioButton = new System.Windows.Forms.RadioButton();
            this.PieceLinearFitnessFunctionRadioButton = new System.Windows.Forms.RadioButton();
            this.fitnessTypeGroupBox = new System.Windows.Forms.GroupBox();
            this.AcceptButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.principleOfParentalChoiceGroupBox = new System.Windows.Forms.GroupBox();
            this.linearRankingRadioButton = new System.Windows.Forms.RadioButton();
            this.rouletteWheelRadioButton = new System.Windows.Forms.RadioButton();
            this.tournamentSortingRadioButton = new System.Windows.Forms.RadioButton();
            this.fitnessTypeGroupBox.SuspendLayout();
            this.principleOfParentalChoiceGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // linearFitnessFunctionRadioButton
            // 
            this.linearFitnessFunctionRadioButton.AutoSize = true;
            this.linearFitnessFunctionRadioButton.Location = new System.Drawing.Point(6, 29);
            this.linearFitnessFunctionRadioButton.Name = "linearFitnessFunctionRadioButton";
            this.linearFitnessFunctionRadioButton.Size = new System.Drawing.Size(128, 17);
            this.linearFitnessFunctionRadioButton.TabIndex = 0;
            this.linearFitnessFunctionRadioButton.TabStop = true;
            this.linearFitnessFunctionRadioButton.Text = "Linear fitness function";
            this.linearFitnessFunctionRadioButton.UseVisualStyleBackColor = true;
            // 
            // PieceLinearFitnessFunctionRadioButton
            // 
            this.PieceLinearFitnessFunctionRadioButton.AutoSize = true;
            this.PieceLinearFitnessFunctionRadioButton.Checked = true;
            this.PieceLinearFitnessFunctionRadioButton.Location = new System.Drawing.Point(6, 52);
            this.PieceLinearFitnessFunctionRadioButton.Name = "PieceLinearFitnessFunctionRadioButton";
            this.PieceLinearFitnessFunctionRadioButton.Size = new System.Drawing.Size(154, 17);
            this.PieceLinearFitnessFunctionRadioButton.TabIndex = 1;
            this.PieceLinearFitnessFunctionRadioButton.TabStop = true;
            this.PieceLinearFitnessFunctionRadioButton.Text = "Piece linear fitness function";
            this.PieceLinearFitnessFunctionRadioButton.UseVisualStyleBackColor = true;
            // 
            // fitnessTypeGroupBox
            // 
            this.fitnessTypeGroupBox.Controls.Add(this.PieceLinearFitnessFunctionRadioButton);
            this.fitnessTypeGroupBox.Controls.Add(this.linearFitnessFunctionRadioButton);
            this.fitnessTypeGroupBox.Location = new System.Drawing.Point(25, 22);
            this.fitnessTypeGroupBox.Name = "fitnessTypeGroupBox";
            this.fitnessTypeGroupBox.Size = new System.Drawing.Size(190, 83);
            this.fitnessTypeGroupBox.TabIndex = 2;
            this.fitnessTypeGroupBox.TabStop = false;
            this.fitnessTypeGroupBox.Text = "Fitness types";
            // 
            // AcceptButton
            // 
            this.AcceptButton.Location = new System.Drawing.Point(25, 269);
            this.AcceptButton.Name = "AcceptButton";
            this.AcceptButton.Size = new System.Drawing.Size(75, 26);
            this.AcceptButton.TabIndex = 3;
            this.AcceptButton.Text = "Accept";
            this.AcceptButton.UseVisualStyleBackColor = true;
            this.AcceptButton.Click += new System.EventHandler(this.AcceptButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(140, 269);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 26);
            this.cancelButton.TabIndex = 4;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // principleOfParentalChoiceGroupBox
            // 
            this.principleOfParentalChoiceGroupBox.Controls.Add(this.tournamentSortingRadioButton);
            this.principleOfParentalChoiceGroupBox.Controls.Add(this.linearRankingRadioButton);
            this.principleOfParentalChoiceGroupBox.Controls.Add(this.rouletteWheelRadioButton);
            this.principleOfParentalChoiceGroupBox.Location = new System.Drawing.Point(25, 129);
            this.principleOfParentalChoiceGroupBox.Name = "principleOfParentalChoiceGroupBox";
            this.principleOfParentalChoiceGroupBox.Size = new System.Drawing.Size(190, 110);
            this.principleOfParentalChoiceGroupBox.TabIndex = 5;
            this.principleOfParentalChoiceGroupBox.TabStop = false;
            this.principleOfParentalChoiceGroupBox.Text = "Principle of parental choice ";
            // 
            // linearRankingRadioButton
            // 
            this.linearRankingRadioButton.AutoSize = true;
            this.linearRankingRadioButton.Location = new System.Drawing.Point(6, 52);
            this.linearRankingRadioButton.Name = "linearRankingRadioButton";
            this.linearRankingRadioButton.Size = new System.Drawing.Size(92, 17);
            this.linearRankingRadioButton.TabIndex = 1;
            this.linearRankingRadioButton.Text = "Linear ranking";
            this.linearRankingRadioButton.UseVisualStyleBackColor = true;
            // 
            // rouletteWheelRadioButton
            // 
            this.rouletteWheelRadioButton.AutoSize = true;
            this.rouletteWheelRadioButton.Location = new System.Drawing.Point(6, 29);
            this.rouletteWheelRadioButton.Name = "rouletteWheelRadioButton";
            this.rouletteWheelRadioButton.Size = new System.Drawing.Size(96, 17);
            this.rouletteWheelRadioButton.TabIndex = 0;
            this.rouletteWheelRadioButton.Text = "Roulette wheel";
            this.rouletteWheelRadioButton.UseVisualStyleBackColor = true;
            // 
            // tournamentSortingRadioButton
            // 
            this.tournamentSortingRadioButton.AutoSize = true;
            this.tournamentSortingRadioButton.Checked = true;
            this.tournamentSortingRadioButton.Location = new System.Drawing.Point(6, 77);
            this.tournamentSortingRadioButton.Name = "tournamentSortingRadioButton";
            this.tournamentSortingRadioButton.Size = new System.Drawing.Size(116, 17);
            this.tournamentSortingRadioButton.TabIndex = 2;
            this.tournamentSortingRadioButton.TabStop = true;
            this.tournamentSortingRadioButton.Text = "Tournament sorting";
            this.tournamentSortingRadioButton.UseVisualStyleBackColor = true;
            // 
            // CGAOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(240, 314);
            this.Controls.Add(this.principleOfParentalChoiceGroupBox);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.AcceptButton);
            this.Controls.Add(this.fitnessTypeGroupBox);
            this.Name = "CGAOptions";
            this.Text = "GA options";
            this.fitnessTypeGroupBox.ResumeLayout(false);
            this.fitnessTypeGroupBox.PerformLayout();
            this.principleOfParentalChoiceGroupBox.ResumeLayout(false);
            this.principleOfParentalChoiceGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RadioButton linearFitnessFunctionRadioButton;
        private System.Windows.Forms.RadioButton PieceLinearFitnessFunctionRadioButton;
        private System.Windows.Forms.GroupBox fitnessTypeGroupBox;
        private System.Windows.Forms.Button AcceptButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.GroupBox principleOfParentalChoiceGroupBox;
        private System.Windows.Forms.RadioButton tournamentSortingRadioButton;
        private System.Windows.Forms.RadioButton linearRankingRadioButton;
        private System.Windows.Forms.RadioButton rouletteWheelRadioButton;
    }
}