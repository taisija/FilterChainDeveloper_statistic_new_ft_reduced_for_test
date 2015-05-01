namespace FilterChainDeveloper
{
    partial class UserSettings
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
            this.generetionNumberLable = new System.Windows.Forms.Label();
            this.generetionNumberTextBox = new System.Windows.Forms.TextBox();
            this.crossoverProbabilityLable = new System.Windows.Forms.Label();
            this.crossoverProbabilityTextBox = new System.Windows.Forms.TextBox();
            this.mutationProbabilityLable = new System.Windows.Forms.Label();
            this.mutationProbabilityTextBox = new System.Windows.Forms.TextBox();
            this.populationQuantityLable = new System.Windows.Forms.Label();
            this.populationQuantityTextBox = new System.Windows.Forms.TextBox();
            this.buttonStart = new System.Windows.Forms.Button();
            this.testNumLable = new System.Windows.Forms.Label();
            this.testNumTextBox = new System.Windows.Forms.TextBox();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.настройкиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveTemporaryDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fitnessOptionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.fitnessToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.folderBrowserDialogDL = new System.Windows.Forms.FolderBrowserDialog();
            this.menuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // generetionNumberLable
            // 
            this.generetionNumberLable.AutoSize = true;
            this.generetionNumberLable.Location = new System.Drawing.Point(415, 60);
            this.generetionNumberLable.Name = "generetionNumberLable";
            this.generetionNumberLable.Size = new System.Drawing.Size(97, 13);
            this.generetionNumberLable.TabIndex = 0;
            this.generetionNumberLable.Text = "Generetion number";
            // 
            // generetionNumberTextBox
            // 
            this.generetionNumberTextBox.Location = new System.Drawing.Point(412, 76);
            this.generetionNumberTextBox.Name = "generetionNumberTextBox";
            this.generetionNumberTextBox.Size = new System.Drawing.Size(115, 20);
            this.generetionNumberTextBox.TabIndex = 1;
            this.generetionNumberTextBox.Text = "1";
            // 
            // crossoverProbabilityLable
            // 
            this.crossoverProbabilityLable.AutoSize = true;
            this.crossoverProbabilityLable.Location = new System.Drawing.Point(415, 108);
            this.crossoverProbabilityLable.Name = "crossoverProbabilityLable";
            this.crossoverProbabilityLable.Size = new System.Drawing.Size(104, 13);
            this.crossoverProbabilityLable.TabIndex = 2;
            this.crossoverProbabilityLable.Text = "Crossover probability";
            // 
            // crossoverProbabilityTextBox
            // 
            this.crossoverProbabilityTextBox.Location = new System.Drawing.Point(412, 124);
            this.crossoverProbabilityTextBox.Name = "crossoverProbabilityTextBox";
            this.crossoverProbabilityTextBox.Size = new System.Drawing.Size(115, 20);
            this.crossoverProbabilityTextBox.TabIndex = 3;
            this.crossoverProbabilityTextBox.Text = "0,6";
            // 
            // mutationProbabilityLable
            // 
            this.mutationProbabilityLable.AutoSize = true;
            this.mutationProbabilityLable.Location = new System.Drawing.Point(415, 157);
            this.mutationProbabilityLable.Name = "mutationProbabilityLable";
            this.mutationProbabilityLable.Size = new System.Drawing.Size(98, 13);
            this.mutationProbabilityLable.TabIndex = 4;
            this.mutationProbabilityLable.Text = "Mutation probability";
            // 
            // mutationProbabilityTextBox
            // 
            this.mutationProbabilityTextBox.Location = new System.Drawing.Point(412, 173);
            this.mutationProbabilityTextBox.Name = "mutationProbabilityTextBox";
            this.mutationProbabilityTextBox.Size = new System.Drawing.Size(115, 20);
            this.mutationProbabilityTextBox.TabIndex = 5;
            this.mutationProbabilityTextBox.Text = "0,1";
            // 
            // populationQuantityLable
            // 
            this.populationQuantityLable.AutoSize = true;
            this.populationQuantityLable.Location = new System.Drawing.Point(415, 206);
            this.populationQuantityLable.Name = "populationQuantityLable";
            this.populationQuantityLable.Size = new System.Drawing.Size(97, 13);
            this.populationQuantityLable.TabIndex = 6;
            this.populationQuantityLable.Text = "Population quantity";
            // 
            // populationQuantityTextBox
            // 
            this.populationQuantityTextBox.Location = new System.Drawing.Point(412, 222);
            this.populationQuantityTextBox.Name = "populationQuantityTextBox";
            this.populationQuantityTextBox.Size = new System.Drawing.Size(115, 20);
            this.populationQuantityTextBox.TabIndex = 7;
            this.populationQuantityTextBox.Text = "80";
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(412, 324);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(115, 28);
            this.buttonStart.TabIndex = 8;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // testNumLable
            // 
            this.testNumLable.AutoSize = true;
            this.testNumLable.Location = new System.Drawing.Point(415, 254);
            this.testNumLable.Name = "testNumLable";
            this.testNumLable.Size = new System.Drawing.Size(66, 13);
            this.testNumLable.TabIndex = 10;
            this.testNumLable.Text = "Test number";
            // 
            // testNumTextBox
            // 
            this.testNumTextBox.Location = new System.Drawing.Point(412, 270);
            this.testNumTextBox.Name = "testNumTextBox";
            this.testNumTextBox.Size = new System.Drawing.Size(114, 20);
            this.testNumTextBox.TabIndex = 11;
            this.testNumTextBox.Text = "1";
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.настройкиToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(555, 24);
            this.menuStrip.TabIndex = 12;
            this.menuStrip.Text = "menuStrip1";
            // 
            // настройкиToolStripMenuItem
            // 
            this.настройкиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveTemporaryDataToolStripMenuItem,
            this.fitnessOptionsToolStripMenuItem});
            this.настройкиToolStripMenuItem.Name = "настройкиToolStripMenuItem";
            this.настройкиToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.настройкиToolStripMenuItem.Text = "Options";
            // 
            // saveTemporaryDataToolStripMenuItem
            // 
            this.saveTemporaryDataToolStripMenuItem.Name = "saveTemporaryDataToolStripMenuItem";
            this.saveTemporaryDataToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.saveTemporaryDataToolStripMenuItem.Text = "Data save options";
            this.saveTemporaryDataToolStripMenuItem.Click += new System.EventHandler(this.saveTemporaryDataToolStripMenuItem_Click);
            // 
            // fitnessOptionsToolStripMenuItem
            // 
            this.fitnessOptionsToolStripMenuItem.Name = "fitnessOptionsToolStripMenuItem";
            this.fitnessOptionsToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.fitnessOptionsToolStripMenuItem.Text = "GA options";
            this.fitnessOptionsToolStripMenuItem.Click += new System.EventHandler(this.fitnessOptionsToolStripMenuItem_Click);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(12, 324);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(376, 28);
            this.progressBar.TabIndex = 13;
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel,
            this.fitnessToolStripStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 375);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(555, 22);
            this.statusStrip.TabIndex = 14;
            this.statusStrip.Text = "statusStrip1";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // fitnessToolStripStatusLabel
            // 
            this.fitnessToolStripStatusLabel.Name = "fitnessToolStripStatusLabel";
            this.fitnessToolStripStatusLabel.Size = new System.Drawing.Size(130, 17);
            this.fitnessToolStripStatusLabel.Text = "    Current best fitness:  ";
            // 
            // UserSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(555, 397);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.testNumTextBox);
            this.Controls.Add(this.testNumLable);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.populationQuantityTextBox);
            this.Controls.Add(this.populationQuantityLable);
            this.Controls.Add(this.mutationProbabilityTextBox);
            this.Controls.Add(this.mutationProbabilityLable);
            this.Controls.Add(this.crossoverProbabilityTextBox);
            this.Controls.Add(this.crossoverProbabilityLable);
            this.Controls.Add(this.generetionNumberTextBox);
            this.Controls.Add(this.generetionNumberLable);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "UserSettings";
            this.Text = "FilterChainDeveloper";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label generetionNumberLable;
        private System.Windows.Forms.TextBox generetionNumberTextBox;
        private System.Windows.Forms.Label crossoverProbabilityLable;
        private System.Windows.Forms.TextBox crossoverProbabilityTextBox;
        private System.Windows.Forms.Label mutationProbabilityLable;
        private System.Windows.Forms.TextBox mutationProbabilityTextBox;
        private System.Windows.Forms.Label populationQuantityLable;
        private System.Windows.Forms.TextBox populationQuantityTextBox;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Label testNumLable;
        private System.Windows.Forms.TextBox testNumTextBox;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem настройкиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveTemporaryDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fitnessOptionsToolStripMenuItem;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ToolStripStatusLabel fitnessToolStripStatusLabel;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialogDL;
    }
}

