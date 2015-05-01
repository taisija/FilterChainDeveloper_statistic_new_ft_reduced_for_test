using System;
using System.Collections.Generic;
//using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;


namespace FilterChainDeveloper
{
    public partial class UserSettings : Form
    {
        private CPopulation population;
        private DataLoader DataL;
        public UserSettings()
        {
            InitializeComponent();
            saveListSwitch = true;
            saveImageSwitch = 2;
            fitnessOption = 2;
            crossoverOption = 2;
            population = new CPopulation();
            loker = new object();
            lokerProgress = new object();
            myTimer = new System.Windows.Forms.Timer();
            myTimer.Tick += timer_Tick;
            myTimer.Interval = 5000;
            myTimer.Enabled = true;
            progressBar.Minimum = 0;
            endActionFlag = true;
            myTimer.Start();
            canStart = true;
            application = null;
            count = 0;
            CChromosome.SetLibraryCapacity(30);
            if (folderBrowserDialogDL.ShowDialog() == DialogResult.OK)
            {
                DataL = new DataLoader(folderBrowserDialogDL.SelectedPath, folderBrowserDialogDL.SelectedPath);
                DataL.ReadSourceParameters(1000, 6, 20);
            }
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            buttonStart.Enabled = canStart;
            Graphics g = e.Graphics;
            Color color = Color.Black;
            Pen pen = new Pen(color, 2);
            Pen bluePen = new Pen(Color.Blue, 2);
            Pen greenPen = new Pen(Color.Green,2);
            int indentionH = 40, indentionW = 15;
            int lengthH = this.Height - 130 - indentionH;
            int lengthW = this.Width - 175 - indentionW;
            g.DrawLine(pen, new Point(15, this.Height - 130), new Point(this.Width - 175, this.Height - 130));
            g.DrawLine(pen, new Point(this.Width - 185, this.Height - 133), new Point(this.Width - 175, this.Height - 130));
            g.DrawLine(pen, new Point(this.Width - 185, this.Height - 128), new Point(this.Width - 175, this.Height - 130));
            g.DrawLine(pen, new Point(indentionW, this.Height - 130), new Point(indentionW, indentionH));
            g.DrawLine(pen, new Point(indentionW, indentionH), new Point(indentionW + 2, indentionH + 10));
            g.DrawLine(pen, new Point(indentionW, indentionH), new Point(indentionW - 3, indentionH + 10));
            int cur = population.GetCurrentGeneration();
            int num = population.GetGenerationNum();
            int rad = 4;
            for (int i = 0; i < cur; i++)
            {
                g.DrawEllipse(bluePen, indentionW + lengthW * i / num - rad + 3, lengthH * (1 - (float)population.GetMaxFitnessIndividualValue(i)*(float)0.9 ) + indentionH - rad, rad, rad);
                g.DrawEllipse(greenPen, indentionW + lengthW * i / num - rad + 3, lengthH * (1 - (float)population.GetAverageFitnessIndividualValue(i) * (float)0.9) + indentionH - rad, rad, rad);
            }
            if (endActionFlag && (cur == (num - 1)))
            {
                g.DrawEllipse(bluePen, indentionW + lengthW * cur / num - rad + 3, lengthH * (1 - (float)population.GetMaxFitnessIndividualValue(cur) * (float)0.9) + indentionH - rad, rad, rad);
                g.DrawEllipse(greenPen, indentionW + lengthW * cur / num - rad + 3, lengthH * (1 - (float)population.GetAverageFitnessIndividualValue(cur) * (float)0.9) + indentionH - rad, rad, rad);
                progressBar.Value = 0;
            }
        }
        private void timer_Tick(object sender, EventArgs e)
        {
           /* lock (lokerProgress)
            {*/
                progressBar.Value = population.GetCurrentGeneration();
                this.toolStripStatusLabel.Text = population.GetPopulationStatusString();
                this.fitnessToolStripStatusLabel.Text = "    Current best fitness: " + population.GetBestFitness().ToString();
           // }
            this.Refresh();
            if (endActionFlag)
            {
                myTimer.Stop();
            }
        }


//-----

        private void writeToExcelFile()
        {
            int n = int.Parse(this.generetionNumberTextBox.Text);
            System.Globalization.CultureInfo cultInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
            System.Globalization.CultureInfo cultUIInfo = System.Threading.Thread.CurrentThread.CurrentUICulture;
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-US");
            for (int i = 1; i <= n; i++)
                xlWorkSheet.Cells.set_Item(i + 1, count % 50 + 1, (object)population.GetMaxFitnessIndividualValue(i - 1));
            System.Threading.Thread.CurrentThread.CurrentCulture = cultInfo;
            System.Threading.Thread.CurrentThread.CurrentUICulture = cultUIInfo;
        }

        private void addToExcelFile(int row, int column, double value)
        {
            System.Globalization.CultureInfo cultInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
            System.Globalization.CultureInfo cultUIInfo = System.Threading.Thread.CurrentThread.CurrentUICulture;
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-US");
            xlWorkSheet.Cells.set_Item(row, column, (object)value);
            System.Threading.Thread.CurrentThread.CurrentCulture = cultInfo;
            System.Threading.Thread.CurrentThread.CurrentUICulture = cultUIInfo;
        }

        private void closeCurrentExcelFile()
        {
            System.Globalization.CultureInfo cultInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
            System.Globalization.CultureInfo cultUIInfo = System.Threading.Thread.CurrentThread.CurrentUICulture;
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-US");
            xlWorkBook.Save();
            application.Quit();
            application = null;
            System.Threading.Thread.CurrentThread.CurrentCulture = cultInfo;
            System.Threading.Thread.CurrentThread.CurrentUICulture = cultUIInfo;
        }
        /*
        private void createNewExcelFile(int num)
        {
            System.Globalization.CultureInfo cultInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
            System.Globalization.CultureInfo cultUIInfo = System.Threading.Thread.CurrentThread.CurrentUICulture;
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-US");
            if (application != null)
            {
                xlWorkBook.Save();
                application.Quit();
                application = null;
            }
            application = new Microsoft.Office.Interop.Excel.Application();
            missing = System.Reflection.Missing.Value;
            application.Caption = "Test";
            application.Visible = false;
            xlWorkBook = application.Workbooks.Open
            (
                @"d:\test\test" + num.ToString() + ".xlsx",
                missing,
                missing,
                missing,
                missing,
                missing,
                missing,
                missing,
                missing,
                missing,
                missing,
                missing,
                missing,
                missing,
                missing
            );

            xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
            System.Threading.Thread.CurrentThread.CurrentCulture = cultInfo;
            System.Threading.Thread.CurrentThread.CurrentUICulture = cultUIInfo;
        }*/

        private string getColumnByNum(int num)
        {
            int n = num - 1;
            string s = Char.ConvertFromUtf32(n % 26 + (int)'A');
            while (n / 26 > 0)
            {
                n = n / 26 - 1;
                s = Char.ConvertFromUtf32((int)'A' + n % 26) + s;
            }
            return s;
        }

        private void addStatistics()
        {
            System.Globalization.CultureInfo cultInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
            System.Globalization.CultureInfo cultUIInfo = System.Threading.Thread.CurrentThread.CurrentUICulture;
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-US");
            int n = population.GetMaxIndividualLength();
            int[] indexes = population.GetMaxIndividualNodesIndexes();
            double val;
            int filter_num = 36;
            if (median[(count / stat_period)%50] <= population.GetBestFitness())
            {
                /*for (int i = 1; i <= n; i++)
                {
                    val = (double)xlWorkSheet_stat.get_Range(getColumnByNum(indexes[i - 1] + 2) + (count / stat_period + 2).ToString(), missing).Value2;
                    xlWorkSheet_stat.Cells.set_Item(count / stat_period + 2, indexes[i - 1] + 2, (object)(val + 1));
                }
                val = (double)xlWorkSheet_stat.get_Range(getColumnByNum(filter_num + 2) + (count / stat_period + 2).ToString(), missing).Value2;
                xlWorkSheet_stat.Cells.set_Item(count / stat_period + 2, filter_num + 2, (object)(val + 1));
                val = (double)xlWorkSheet_stat.get_Range(getColumnByNum(filter_num + 3) + (count / stat_period + 2).ToString(), missing).Value2;
                xlWorkSheet_stat.Cells.set_Item(count / stat_period + 2, filter_num + 3, (object)(val + population.GetBestFitness()));*/
            }
            else
            {
                for (int i = 1; i <= n; i++)
                {
                    //val = (double)xlWorkSheet_stat.get_Range(getColumnByNum(indexes[i - 1] + 2) + (count / stat_period + 55).ToString(), missing).Value2;
                    //xlWorkSheet_stat.Cells.set_Item(count / stat_period + 55, indexes[i - 1] + 2, (object)(val + 1));
                }
               /* val = (double)xlWorkSheet_stat.get_Range(getColumnByNum(filter_num + 2) + (count / stat_period + 55).ToString(), missing).Value2;
                xlWorkSheet_stat.Cells.set_Item(count / stat_period + 55, filter_num + 2, (object)(val + 1));
                val = (double)xlWorkSheet_stat.get_Range(getColumnByNum(filter_num + 3) + (count / stat_period + 55).ToString(), missing).Value2;
                xlWorkSheet_stat.Cells.set_Item(count / stat_period + 55, filter_num + 3, (object)(val + population.GetBestFitness()));*/
            }
            System.Threading.Thread.CurrentThread.CurrentCulture = cultInfo;
            System.Threading.Thread.CurrentThread.CurrentUICulture = cultUIInfo;
        }

        private void closeExcelFile()
        {
            System.Globalization.CultureInfo cultInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
            System.Globalization.CultureInfo cultUIInfo = System.Threading.Thread.CurrentThread.CurrentUICulture;
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-US");
            xlWorkBook_stat.Save();
            application_stat.Quit();
            application_stat = null;
            System.Threading.Thread.CurrentThread.CurrentCulture = cultInfo;
            System.Threading.Thread.CurrentThread.CurrentUICulture = cultUIInfo;
        }

        private void openExcelFile(string longName)
        {
            System.Globalization.CultureInfo cultInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
            System.Globalization.CultureInfo cultUIInfo = System.Threading.Thread.CurrentThread.CurrentUICulture;
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-US");

            application_stat = new Microsoft.Office.Interop.Excel.Application();
            missing_stat = System.Reflection.Missing.Value;
            application_stat.Caption = "statistics";
            application_stat.Visible = false;
            xlWorkBook_stat = application_stat.Workbooks.Open
            (
                longName,
                missing,
                missing,
                missing,
                missing,
                missing,
                missing,
                missing,
                missing,
                missing,
                missing,
                missing,
                missing,
                missing,
                missing
            );

            xlWorkSheet_stat = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook_stat.Worksheets.get_Item(1);
            System.Threading.Thread.CurrentThread.CurrentCulture = cultInfo;
            System.Threading.Thread.CurrentThread.CurrentUICulture = cultUIInfo;
        }

        private void createNewExcelFile(int num)
        {
            System.Globalization.CultureInfo cultInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
            System.Globalization.CultureInfo cultUIInfo = System.Threading.Thread.CurrentThread.CurrentUICulture;
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-US");
            if (application != null)
            {
                xlWorkBook.Save();
                application.Quit();
                application = null;
            }
            application = new Microsoft.Office.Interop.Excel.Application();
            missing = System.Reflection.Missing.Value;
            application.Caption = "Test";
            application.Visible = false;
            xlWorkBook = application.Workbooks.Open
            (
                @"d:\test\test0 (" + (num / stat_period + 1).ToString() + ").xlsx",
                missing,
                missing,
                missing,
                missing,
                missing,
                missing,
                missing,
                missing,
                missing,
                missing,
                missing,
                missing,
                missing,
                missing
            );

            xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
            System.Threading.Thread.CurrentThread.CurrentCulture = cultInfo;
            System.Threading.Thread.CurrentThread.CurrentUICulture = cultUIInfo;
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            sender1 = sender;
            e1 = e;
            if ((count % stat_period) == 0)
            {
                switch (count / stat_period)
                {
                    case 0:
                        createNewExcelFile(count);
                        openExcelFile(@"d:\image_param\im_stat.xlsx");
                        break;
                    case 1:
                        createNewExcelFile(count);
                        //openExcelFile(@"d:\image_param\im_stat.xlsx");
                        break;
                    case 2:
                        createNewExcelFile(count);
                        //openExcelFile(@"d:\image_param\im_stat.xlsx");
                        break;
                    case 3:
                        createNewExcelFile(count);
                        //openExcelFile(@"d:\image_param\im_stat.xlsx");
                        break;
                    case 4:
                        createNewExcelFile(count);
                        break;
                    case 5:
                        createNewExcelFile(count);
                        //openExcelFile(@"d:\image_param\im_stat.xlsx");
                        break;
                    case 6:
                        createNewExcelFile(count);
                        //openExcelFile(@"d:\image_param\im_stat.xlsx");
                        break;
                    case 7:
                        createNewExcelFile(count);
                        //openExcelFile(@"d:\image_param\im_stat.xlsx");
                        break;
                    case 8:
                        createNewExcelFile(count);
                        break;
                    case 9:
                        createNewExcelFile(count);
                        //openExcelFile(@"d:\image_param\im_stat.xlsx");
                        break;
                    case 10:
                        createNewExcelFile(count);
                        //openExcelFile(@"d:\image_param\im_stat.xlsx");
                        break;
                    case 11:
                        createNewExcelFile(count);
                        break;
                    case 12:
                        createNewExcelFile(count);
                        //openExcelFile(@"d:\image_param\im_stat.xlsx");
                        break;
                    case 13:
                        createNewExcelFile(count);
                        //openExcelFile(@"d:\image_param\im_stat.xlsx");
                        break;
                    case 14:
                        createNewExcelFile(count);
                        break;
                    case 15:
                        createNewExcelFile(count);
                        //openExcelFile(@"d:\image_param\im_stat.xlsx");
                        break;
                    case 16:
                        createNewExcelFile(count);
                        break;
                    case 17:
                        createNewExcelFile(count);
                        break;
                    case 18:
                        createNewExcelFile(count);
                        //openExcelFile(@"d:\image_param\im_stat.xlsx");
                        break;
                    case 19:
                        createNewExcelFile(count);
                        break;
                    case 20:
                        createNewExcelFile(count);
                        //openExcelFile(@"d:\image_param\im_stat.xlsx");
                        break;
                    case 21:
                        createNewExcelFile(count);
                        break;
                    case 22:
                        createNewExcelFile(count);
                        break;
                    case 23:
                        createNewExcelFile(count);
                        //openExcelFile(@"d:\image_param\im_stat.xlsx");
                        break;
                    case 24:
                        createNewExcelFile(count);
                        //openExcelFile(@"d:\image_param\im_stat.xlsx");
                        break;
                    case 25:
                        createNewExcelFile(count);
                        //openExcelFile(@"d:\image_param\im_stat.xlsx");
                        break;
                    case 26:
                        createNewExcelFile(count);
                        //openExcelFile(@"d:\image_param\im_stat.xlsx");
                        break;
                    case 27:
                        createNewExcelFile(count);
                        //openExcelFile(@"d:\image_param\im_stat.xlsx");
                        break;
                    case 28:
                        createNewExcelFile(count);
                        break;
                    case 29:
                        createNewExcelFile(count);
                        //openExcelFile(@"d:\image_param\im_stat.xlsx");
                        break;
                    case 30:
                        createNewExcelFile(count);
                        //openExcelFile(@"d:\image_param\im_stat.xlsx");
                        break;
                    case 31:
                        createNewExcelFile(count);
                        break;
                    case 32:
                        createNewExcelFile(count);
                        break;
                    case 33:
                        createNewExcelFile(count);
                        break;
                    case 34:
                        createNewExcelFile(count);
                        //openExcelFile(@"d:\image_param\im_stat.xlsx");
                        break;
                    case 35:
                        createNewExcelFile(count);
                        //openExcelFile(@"d:\image_param\im_stat.xlsx");
                        break;
                    case 36:
                        createNewExcelFile(count);
                        //openExcelFile(@"d:\image_param\im_stat.xlsx");
                        break;
                    case 37:
                        createNewExcelFile(count);
                        break;
                    case 38:
                        createNewExcelFile(count);
                        break;
                    case 39:
                        createNewExcelFile(count);
                        //openExcelFile(@"d:\image_param\im_stat.xlsx");
                        break;
                    case 40:
                        createNewExcelFile(count);
                        //openExcelFile(@"d:\image_param\im_stat.xlsx");
                        break;
                    case 41:
                        createNewExcelFile(count);
                        break;
                    case 42:
                        createNewExcelFile(count);
                        break;
                    case 43:
                        createNewExcelFile(count);
                        //openExcelFile(@"d:\image_param\im_stat.xlsx");
                        break;
                    case 44:
                        createNewExcelFile(count);
                        //openExcelFile(@"d:\image_param\im_stat.xlsx");
                        break;
                    case 45:
                        createNewExcelFile(count);
                        openExcelFile(@"d:\image_param\im_stat.xlsx");
                        break;
                    case 46:
                        createNewExcelFile(count);
                        //openExcelFile(@"d:\image_param\im_stat.xlsx");
                        break;
                    case 47:
                        createNewExcelFile(count);
                        //openExcelFile(@"d:\image_param\im_stat.xlsx");
                        break;
                    case 48:
                        createNewExcelFile(count);
                        break;
                    case 49:
                        createNewExcelFile(count);
                        break;
                }
            }
            //-----
            canStart = false;
            //buttonStart.Enabled = false;
            CChromosome.SetCounter(0);
            if ((int.Parse(this.testNumTextBox.Text) > 0) && (int.Parse(this.populationQuantityTextBox.Text) > 0) && (int.Parse(this.generetionNumberTextBox.Text) > 0) && (0 < double.Parse(this.crossoverProbabilityTextBox.Text)) && (double.Parse(this.crossoverProbabilityTextBox.Text) < 1) && (double.Parse(this.mutationProbabilityTextBox.Text) > 0) && (double.Parse(this.mutationProbabilityTextBox.Text) < 1))
            {
                //this.statusBarLabel.Text = "initialisation...";
                if (DataL != null)
                {
                    population.SetTestImageNum(1);
                    //------
                    string newPath = @"d:\test\" + count.ToString();

                    // Create the subfolder
                    System.IO.Directory.CreateDirectory(newPath);
                    System.IO.FileStream file_txt = System.IO.File.Create(newPath + "\\" + count.ToString() + ".txt");
                    file_txt.Close();
                    file_txt = System.IO.File.Create(newPath + "\\" + count.ToString() + "_average.txt");
                    file_txt.Close();

                    //-------
                    if (population.Initialise(int.Parse(this.populationQuantityTextBox.Text), int.Parse(this.generetionNumberTextBox.Text), int.Parse(this.testNumTextBox.Text), count, DataL))
                    {
                        lock (loker)
                        {
                            this.toolStripStatusLabel.Text = "initialisation...";
                            lock (lokerProgress)
                            {
                                progressBar.Maximum = int.Parse(this.generetionNumberTextBox.Text);
                            }

                            population.SetFitnessType(fitnessOption);
                            this.toolStripStatusLabel.Text = "fitness evaluation...";
                            population.FitnessEval();
                            //population.SetLibraryOptions();
                            //this.statusBarLabel.Text = "best fitness:" + population.GetBestFitness().ToString() + " fitness evaluation...";
                            var tm = DateTime.Now;
                            string str = tm.ToString();
                            if (saveImageSwitch != 0)
                                if (saveImageSwitch < 3)
                                {
                                    population.SaveBestIndividualFiltrationResult(0);
                                    if (saveListSwitch) population.SaveBestIndividual(0);
                                }
                                else
                                {
                                    population.SaveAllIndividualFiltrationResult(0);
                                    if (saveListSwitch) population.SaveAllIndividual(0);
                                }
                            endActionFlag = false;
                            myTimer.Start();
                        }
                        Thread st = new Thread(Start);
                        st.IsBackground = true;
                        st.Start();
                    }
                    else
                    {
                        this.toolStripStatusLabel.Text = " ";
                        canStart = true;
                        buttonStart.Enabled = true;
                    }
                }
            }
        }
        
        private void Start()
        {
            lock (loker)
            {
                endActionFlag = false;
                population.SetCurrentGeneration(1);
                for (int i = 1; i < int.Parse(this.generetionNumberTextBox.Text); i++)
                {
                    lock (lokerProgress)
                    {
                        population.SetCurrentGeneration(i);
                    }
                    // tm = DateTime.Now;
                   /* lock (lokerProgress)
                    {
                        population.Crossover(double.Parse(this.crossoverProbabilityTextBox.Text), i, crossoverOption, 0, 1.5);
                      //  if (count < 50)
                            population.SaveToLibrary(0);
                      //  else
                        //    population.SaveToLibrary(1);
                        population.SetLibraryOptions();
                    }
                    //str += (" " + (DateTime.Now - tm).ToString() + " ");
                    //  tm = DateTime.Now;
                    lock (lokerProgress)
                    {
                        population.Mutanion(double.Parse(this.mutationProbabilityTextBox.Text), i);
                    }*/
                    lock (lokerProgress)
                    {
                        population.FitnessEval();
                    }
                    if (saveImageSwitch != 0)
                        if (saveImageSwitch == 2)
                        {
                            lock (lokerProgress)
                            {
                                population.SaveBestIndividualFiltrationResult(i);
                                if (saveListSwitch) population.SaveBestIndividual(i);
                            }
                        }
                        else
                        {
                            if (saveImageSwitch == 4)
                            {
                                lock (lokerProgress)
                                {
                                    population.SaveAllIndividualFiltrationResult(i);
                                    if (saveListSwitch) population.SaveAllIndividual(i);
                                }
                            }
                        }
                    //str += (" " + (DateTime.Now - tm).ToString() + "    ");

                    //this.statusBarLabel.Text = "best fitness:" + population.GetBestFitness().ToString() + " in " + (i + 1).ToString() + " population";
                }
                /* lock (loker)
                 {*/
                if (saveImageSwitch != 0)
                    if (saveImageSwitch == 1)
                    {
                        lock (lokerProgress)
                        {
                            population.SaveBestIndividualFiltrationResult(int.Parse(this.generetionNumberTextBox.Text));
                            if (saveListSwitch) population.SaveBestIndividual(int.Parse(this.generetionNumberTextBox.Text));
                        }

                    }
                    else
                    {
                        if (saveImageSwitch == 3)
                        {
                            lock (lokerProgress)
                            {
                                population.SaveAllIndividualFiltrationResult(int.Parse(this.generetionNumberTextBox.Text));
                                if (saveListSwitch) population.SaveAllIndividual(int.Parse(this.generetionNumberTextBox.Text));
                            }
                        }
                    }
                // }
                lock (lokerProgress)
                {
                    //population.SetCurrentGeneration(0);
                    endActionFlag = true;
                    //myTimer.Stop();
                }
            }
            canStart = true;
            //---
            population.SaveBestFitness();
            writeToExcelFile();
            addStatistics();
            count++;
            if (count == 125)
            {
                closeCurrentExcelFile();
                closeExcelFile();
            }
            if (count < 125) buttonStart_Click(sender1, e1);
            //---
        }
        private void saveTemporaryDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            COptions optionForm = new COptions();
            optionForm.ShowDialog();
            saveListSwitch = optionForm.GetSaveListSwitch();
            saveImageSwitch = optionForm.GetSaveImageSwitch();
        }

        object sender1;
        EventArgs e1;
        Microsoft.Office.Interop.Excel.Application application;
        object missing;
        Microsoft.Office.Interop.Excel.Workbook xlWorkBook;
        Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet;

        int count;
        int stat_period = 1;

        Microsoft.Office.Interop.Excel.Application application_stat;
        object missing_stat;
        Microsoft.Office.Interop.Excel.Workbook xlWorkBook_stat;
        Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet_stat;

        private int saveImageSwitch;
        private bool canStart;
        private bool saveListSwitch;
        private int fitnessOption;
        private int crossoverOption;
        private Object loker;
        private Object lokerProgress;
        private System.Windows.Forms.Timer myTimer;
        private void fitnessOptionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CGAOptions fitnessOptionForm = new CGAOptions();
            fitnessOptionForm.ShowDialog();
            fitnessOption = fitnessOptionForm.GetFitnessSwitch();
            crossoverOption = fitnessOptionForm.GetCrossoverSwitch();
        }
        private bool endActionFlag;
        private double[] median = 
        {
            0.9,
0.974052645,
0.971382364,
0.926183234,
0.983014276,
0.975748566,
0.985161719,
0.943805971,
0.928728744,
0.9,
0.943585318,
0.950823484,
0.964505556,
0.972248811,
0.9,
0.945584184,
0.9,
0.943462174,
0.943478179,
0.955659905,
0.944135932,
0.905716642,
0.974066306,
0.962092323,
0.916532255,
0.987622757,
0.977486672,
0.982173823,
0.938873829,
0.97738589,
0.976976522,
0.94097218,
0.942926649,
0.921038018,
0.939636752,
0.933948917,
0.938296854,
0.983069498,
0.953666935,
0.9,
0.958843216,
0.9,
0.968284441,
0.968755365,
0.915845539,
0.9633552,
0.949238867,
0.950850144,
0.984221649,
0.96358646
        };
    }
}
