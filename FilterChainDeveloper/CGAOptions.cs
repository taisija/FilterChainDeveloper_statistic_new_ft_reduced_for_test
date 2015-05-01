using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FilterChainDeveloper
{
    public partial class CGAOptions : Form
    {
        public CGAOptions()
        {
            InitializeComponent();
            fitnessSwitch = 2;
            crossoverSwitch = 2;
            this.linearFitnessFunctionRadioButton.Checked = true;
        }

        public int GetFitnessSwitch()
        {
            return fitnessSwitch;
        }

        public int GetCrossoverSwitch()
        {
            return crossoverSwitch;
        }

        private void AcceptButton_Click(object sender, EventArgs e)
        {
            if (this.PieceLinearFitnessFunctionRadioButton.Checked)
                fitnessSwitch = 2;
            else fitnessSwitch = 1;
            if (this.tournamentSortingRadioButton.Checked)
                crossoverSwitch = 2;
            else
                if (this.linearRankingRadioButton.Checked)
                    crossoverSwitch = 1;
                else
                    crossoverSwitch = 0;
            this.Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private int fitnessSwitch;
        private int crossoverSwitch;
    }
}
