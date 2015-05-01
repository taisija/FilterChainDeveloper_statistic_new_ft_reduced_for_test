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
    public partial class COptions : Form
    {
        public COptions()
        {
            InitializeComponent();
            saveImageSwitch = 2;
            saveListSwitch = true;
        }
        public int GetSaveImageSwitch()
        {
            return saveImageSwitch;
        }
        public bool GetSaveListSwitch()
        {
            return saveListSwitch;
        }
        private void acceptButton_Click(object sender, EventArgs e)
        {
            if (this.SaveFirstLastBestImageRadioButton.Checked)
            {
                saveImageSwitch = 1;
                if (this.SaveFilterListCheckBox.Checked) saveListSwitch = true;
                else saveListSwitch = false;
            }
            else
            {
                if (this.SaveFirstLastAllImageRadioButton.Checked)
                {
                    saveImageSwitch = 3;
                    if (this.SaveFilterListCheckBox.Checked) saveListSwitch = true;
                    else saveListSwitch = false;
                }
                else
                {
                    if (this.SaveBestAllImageRadioButton.Checked)
                    {
                        saveImageSwitch = 2;
                        if (this.SaveFilterListCheckBox.Checked) saveListSwitch = true;
                        else saveListSwitch = false;
                    }
                    else
                    {
                        if (this.SaveImageAllRadioButton.Checked)
                        {
                            saveImageSwitch = 4;
                            if (this.SaveFilterListCheckBox.Checked) saveListSwitch = true;
                            else saveListSwitch = false;
                        }
                    }
                }
            }
            this.Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private byte saveImageSwitch;
        private bool saveListSwitch;
    }
}
