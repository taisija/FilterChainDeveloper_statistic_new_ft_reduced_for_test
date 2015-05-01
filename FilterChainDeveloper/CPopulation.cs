using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Windows.Forms;
using System.IO;


namespace FilterChainDeveloper
{
    class CPopulation
    {
        public CPopulation()
        {
            currentGeneration = 0;
            maxFitnessIndividualValue = 0;
        }
        public void SaveAllIndividual(int generationNum)
        {
            for (int i = 0; i < populationSize; i++)
            {
                individualsList[i].SaveFilterList(generationNum, i, counter);
            }
        }
        public void SaveAllIndividualFiltrationResult(int generationNum)
        {
            for (int i = 0; i < populationSize; i++)
            {
                individualsList[i].SaveFilteredImages(generationNum, i, counter);
            }
        }
        public void SaveBestIndividual(int generationNum)
        {
            maxFitnessIndividual.SaveFilterList(generationNum, maxFitnessIndividualInd, counter);
        }
        public void SaveBestIndividualFiltrationResult(int generationNum)
        {
            maxFitnessIndividual.SaveFilteredImages(generationNum, maxFitnessIndividualInd, counter);
        }

        public int[] GetMaxIndividualNodesIndexes()
        {
            return maxFitnessIndividual.GetIndexesOfAllNodes();
        }

        public int GetMaxIndividualLength()
        {
            return maxFitnessIndividual.GetIndividualLength();
        }

        public void SaveBestFitness()
        {
            maxFitnessIndividual.SaveFilterFitness(generationNum, maxFitnessIndividualInd, counter);

            string newPath = @"d:\test\" + counter.ToString();

            //System.IO.File.Create(newPath + "\\" + counter.ToString() + "_average.txt");
            StreamWriter f = new StreamWriter(newPath + "\\" + counter.ToString() + "_average.txt", true);
            for (int i = 0; i < generationNum; i++)
                f.WriteLine(averageFitnessIndividualValueList[i]);
            f.Close();
        }

        public bool Initialise(int PopulationSize, int GenerationNum, int TestNum, int count, DataLoader DL)
        {
            statusString = "initialisation..";
            populationSize = DL.DataLen.Length-1;
            generationNum = GenerationNum;
            averageFitnessIndividualValueList = new double[generationNum];
            maxFitnessIndividualValueList = new double[generationNum];
            testNum = TestNum;
            setPoolNum = 0;
            fitnrssList = new double[populationSize];
            individualsList = new CChromosome[populationSize];
            individualsPool = new CChromosome[populationSize];
            rankingTable = new double[populationSize];
            fitnessSort = new int[populationSize];
            Random rand = new Random();
            individualsList[0] = new CChromosome(DL,0);
            maxFitnessIndividual = null;
            maxFitnessIndividualInd = 0;
            maxFitnessIndividualValue = 0;
            currentGeneration = 0;
            libType = 0;

            //---
            counter = count;
            //---

            if ((!LoadTestImage()) || (individualsList[0] == null))
                return false;
            for (int i = 1; i < populationSize; i++)
            {
                individualsList[i] = new CChromosome(DL,i);
                fitnessSort[i] = i;
            }
            return true;
        }
        /*
        public void Mutanion(double MutationProbabl, int CurrentGeneration)
        {
            statusString = "mutation..";
            Random rand = new Random();
            for (int i = 0; i < populationSize * MutationProbabl*10; i++)
            {
                individualsList[rand.Next(0, populationSize - 1)].Mutation(GetMutationType(CurrentGeneration));
            }
        }
        */
       // double[] sortTest;
        /*
        private void FitnessSort()
        {
            int tmp,j;
           // sortTest = new double[populationSize];
            for (int i = 0; i < populationSize; i++)
            {
                tmp = fitnessSort[i];
                for (j = i - 1; j >= 0 && individualsList[fitnessSort[j]].GetFitness() > individualsList[tmp].GetFitness(); j--)
                    fitnessSort[j + 1] = fitnessSort[j];
                fitnessSort[j + 1] = tmp;
            }
        }*/

        private void Ranking()
        {
            rankingTable[0] = a / populationSize;
            for (int i = 1; i < populationSize; i++)
            {
                rankingTable[i] = rankingTable[i - 1] + (a - ((a + a - 2) * i) / (populationSize - 1)) / populationSize;
            }
        }
        /*
        public void Crossover(double CrossoverProbabl, int CurrentGeneration, int PrincipleOfParentalChoice, int CrossoverType, double a)
        {
            statusString = "crossover..";
            principleOfParentalChoice = PrincipleOfParentalChoice;
            crossoverType = CrossoverType;
            Random rand = new Random();
            List<CNode> firstSubsecquence, secondSubsecquence;
            CChromosome tmpSp;
            int tmpInd, tmp;
            double firstParent, secondParent;
            int firstParentInd=0, secondParentInd=0;
            for (int i = 0; i < populationSize; i++)
            {
                if (!individualsList[i].GetIntegrity())
                    Debug.Assert(false);
            }
            for (int i = 0; i < populationSize * CrossoverProbabl; i++)
            {
                //choose parent
                switch (principleOfParentalChoice)
                {
                    case 0:
                        //roulette wheel
                        firstParent = rand.NextDouble() * fitnrssList[populationSize - 1];
                        do
                        {
                            secondParent = rand.NextDouble() * fitnrssList[populationSize - 1];
                            for (int j = 0; j < (populationSize - 1); j++)
                            {
                                if ((fitnrssList[j] < firstParent) && (fitnrssList[j + 1] > firstParent)) firstParentInd = j + 1;
                                if ((fitnrssList[j] < secondParent) && (fitnrssList[j + 1] > secondParent)) secondParentInd = j + 1;
                            }
                        }
                        while (firstParentInd == secondParentInd);
                        break;
                    case 1:
                        //linear ranking
                        FitnessSort();
                        Ranking();
                        firstParent = rand.NextDouble();
                        do
                        {
                            secondParent = rand.NextDouble();
                            for (int j = 0; j < (populationSize - 1); j++)
                            {
                                if ((rankingTable[j] < firstParent) && (rankingTable[j + 1] > firstParent)) firstParentInd = fitnessSort[j + 1];
                                if ((rankingTable[j] < secondParent) && (rankingTable[j + 1] > secondParent)) secondParentInd = fitnessSort[j + 1];
                            }
                        }
                        while (firstParentInd == secondParentInd);
                        break;
                    default:
                        //tournament sorting
                        if (setPoolNum < currentGeneration)
                        {
                            setPoolNum++;
                            for (int j = 0; j < (populationSize - 1); j++)
                            {
                                tmpInd = rand.Next(populationSize - 1);
                                tmpSp = individualsList[tmpInd];
                                for (int k = 0; k < 3; k++)
                                {
                                    tmp = rand.Next(populationSize - 1);
                                    if (tmp != 0)
                                    {
                                        if (tmpInd != 0)
                                        {
                                            if ((fitnrssList[tmpInd] - fitnrssList[tmpInd - 1]) < (fitnrssList[tmp] - fitnrssList[tmp-1]))
                                            {
                                                tmpInd = tmp;
                                                tmpSp = individualsList[tmp];
                                            }
                                        }
                                        else
                                        {
                                            if (fitnrssList[tmpInd] < (fitnrssList[tmp] - fitnrssList[tmp - 1]))
                                            {
                                                tmpInd = tmp;
                                                tmpSp = individualsList[tmp];
                                            }
                                        }
                                    }
                                    else
                                    {
                                        if (tmpInd != 0)
                                        {
                                            if ((fitnrssList[tmpInd] - fitnrssList[tmpInd - 1]) < fitnrssList[tmp])
                                            {
                                                tmpInd = tmp;
                                                tmpSp = individualsList[tmp];
                                            }
                                        }
                                        else
                                        {
                                            if (fitnrssList[tmpInd] < fitnrssList[tmp])
                                            {
                                                tmpInd = tmp;
                                                tmpSp = individualsList[tmp];
                                            }
                                        }
                                    }

                                }
                                individualsPool[j] = tmpSp;//new CChromosome(tmpSp);
                            }
                        }
                        firstParentInd = rand.Next(populationSize - 1);
                        firstParentIndividual = individualsPool[firstParentInd];
                        do
                        {
                            secondParentInd = rand.Next(populationSize - 1);
                        }
                        while (firstParentInd == secondParentInd);
                        secondParentIndividual = individualsPool[secondParentInd];
                        break;
                }
                
                //crossover
                int fInd = GetFirstMinFitnessIndividualIndex();
                int sInd = GetSecondMinFitnessIndividualIndex(fInd);

                firstParentIndividual = new CChromosome(individualsList[firstParentInd]);
                secondParentIndividual = new CChromosome(individualsList[secondParentInd]);

                firstSubsecquence = firstParentIndividual.GetSubsequence(GetCrossoverType(CurrentGeneration));
                secondSubsecquence = secondParentIndividual.GetSubsequence(GetCrossoverType(CurrentGeneration));

                firstParentIndividual.Crossover(secondSubsecquence);
                secondParentIndividual.Crossover(firstSubsecquence);

                firstParentIndividual.FitnessEval(testImageList, testImageListMask, testImageSize, testImageNum, testNum);
                secondParentIndividual.FitnessEval(testImageList, testImageListMask, testImageSize, testImageNum, testNum);

                //reduction
                if (firstParentIndividual.GetFitness() > individualsList[fInd].GetFitness())
                {
                    individualsList[fInd] = firstParentIndividual;
                    if (secondParentIndividual.GetFitness() > individualsList[sInd].GetFitness())
                    {
                        individualsList[sInd] = secondParentIndividual;
                    }
                }
                else
                {
                    if (secondParentIndividual.GetFitness() > individualsList[fInd].GetFitness())
                    {
                        individualsList[fInd] = secondParentIndividual;
                    }
                }

                SetFitnessListIntegrity();

                for (int iii = 0; iii < populationSize; iii++)
                {
                    if (!individualsList[iii].GetIntegrity())
                        Debug.Assert(false);
                }
            }
        }
        public void SetLibraryOptions()
        {
            maxFitnessIndividual.SetFitnessIncreaseSpeed();
        }*/
        /*
        public void SaveToLibrary(int libraryType)
        {
            List<CNode> segment;
            if (libraryType == 0)
            {
                for (int i = 0; i < populationSize; i++)
                {
                    segment = individualsList[i].GetFirstMinSegment();
                    if (segment != null) individualsList[i].SaveToLibrary(segment);
                }
            }
            else
            {
                for (int i = 0; i < populationSize; i++)
                {
                    segment = individualsList[i].GetFirstMaxSegment();
                    if (segment != null) individualsList[i].SaveToLibrary(segment);
                }
            }
        }
        */
        public void PopulationReduction(int reductionType)
        {

        }
        public void SetPopulationSize(int size)
        {
            populationSize = size;
        }
        public void SetGenerationNum(int num)
        {
            generationNum = num;
        }
        public void SetTestImageNum(int TestImageNum)
        {
            testImageNum = TestImageNum;
            testImageList = new byte[testImageNum][,];
            testImageListMask = new byte[testImageNum][,];
            testImageSize = new int[2, testImageNum];
        }
        public void SetCurrentGeneration(int CurrentGeneration)
        {
            currentGeneration = CurrentGeneration;
        }
        public int GetCurrentGeneration()
        {
            return currentGeneration;
        }
        public int GetFirstMinFitnessIndividualIndex()
        {
            double fitness = individualsList[0].GetFitness(), fit = 0;
            int index = 0;
            for (int i = 1; i < populationSize; i++)
            {
                fit = individualsList[i].GetFitness();
                if (fit < fitness)
                {
                    fitness = fit;
                    index = i;
                }
            }
            return index;
        }
        public int GetSecondMinFitnessIndividualIndex(int FirstMinFitnessIndividualIndex)
        {
            double fitness = individualsList[0].GetFitness(), fit = 0;
            int index = 0;
            for (int i = 1; i < populationSize; i++)
            {
                fit = individualsList[i].GetFitness();
                if ((fit < fitness) && (index != FirstMinFitnessIndividualIndex))
                {
                    fitness = fit;
                    index = i;
                }
            }
            return index;
        }
        public void FitnessEval()
        {
            statusString = "fitness evaluation..";
            for (int iii = 0; iii < populationSize; iii++)
            {
                if (!individualsList[iii].GetIntegrity())
                    Debug.Assert(false);
            }
            individualsList[0].FitnessEval(testImageList, testImageListMask, testImageSize, testImageNum, testNum);
            fitnrssList[0] = individualsList[0].GetFitness();
            double minFitnessIndividualValue = fitnrssList[0];
            int minFitnessIndividualInd = 0;
            maxFitnessIndividualValue = fitnrssList[0];
            maxFitnessIndividualInd = 0;
            double fit;
            for (int i = 1; i < populationSize; i++)
            {
                individualsList[i].FitnessEval(testImageList, testImageListMask, testImageSize, testImageNum, testNum);
                /*if ((i % 7) == 0)
                {
                    individualsList[i].AnnealingChromosome();
                    individualsList[i].FitnessEval(testImageList, testImageListMask, testImageSize, testImageNum, testNum);
                }*/
                fit = individualsList[i].GetFitness(); 
                if (maxFitnessIndividualValue < fit)
                {
                    maxFitnessIndividualValue = fit;
                    maxFitnessIndividualInd = i;
                }
                if (minFitnessIndividualValue > fit)
                {
                    minFitnessIndividualValue = fit;
                    minFitnessIndividualInd = i;
                }
            }
            if (maxFitnessIndividual != null)
            {
                //замена особи с мин фит в текущей популяции на особь с макс фит в предыдущей
                maxFitnessIndividual.FitnessEval(testImageList, testImageListMask, testImageSize, testImageNum, testNum);
                individualsList[minFitnessIndividualInd] = maxFitnessIndividual;
                if (maxFitnessIndividual.GetFitness() < individualsList[maxFitnessIndividualInd].GetFitness())
                {
                    maxFitnessIndividual = new CChromosome(individualsList[maxFitnessIndividualInd]);
                    maxFitnessIndividualValueList[currentGeneration] = maxFitnessIndividualValue;
                }
                else
                {
                    maxFitnessIndividual = new CChromosome(maxFitnessIndividual);
                    maxFitnessIndividualValueList[currentGeneration] = maxFitnessIndividualValueList[currentGeneration-1];
                }
                fitnrssList[0] = individualsList[0].GetFitness();
                for (int i = 1; i < populationSize; i++)
                {
                    fitnrssList[i] = fitnrssList[i - 1] + individualsList[i].GetFitness();
                }

            }
            else
            {
                maxFitnessIndividual = new CChromosome(individualsList[maxFitnessIndividualInd]);
                maxFitnessIndividualValueList[currentGeneration] = maxFitnessIndividualValue;
                fitnrssList[0] = individualsList[0].GetFitness();
                for (int i = 1; i < populationSize; i++)
                {
                    fitnrssList[i] = fitnrssList[i - 1] + individualsList[i].GetFitness();
                }
            }
            for (int iii = 0; iii < populationSize; iii++)
            {
                if (!individualsList[iii].GetIntegrity())
                    Debug.Assert(false);
            }
            averageFitnessIndividualValueList[currentGeneration] = fitnrssList[populationSize - 1] / populationSize;
            if (currentGeneration == (generationNum - 1)) statusString = "";
        }
        public double GetBestFitness()
        {
            return maxFitnessIndividualValue;
        }
        public void SetFitnessType(int type)
        {
            for (int i = 0; i < populationSize; i++)
            {
                individualsList[i].SetFitnessType(type);
            }
        }
        public string GetPopulationStatusString()
        {
            return statusString;
        }
        public double GetMaxFitnessIndividualValue(int index)
        {
            if ((index >= 0) && (index <= currentGeneration))
            {
                return maxFitnessIndividualValueList[index];
            }
            return -1;
        }
        public double GetAverageFitnessIndividualValue(int index)
        {
            if ((index >= 0) && (index <= currentGeneration))
            {
                return averageFitnessIndividualValueList[index];
            }
            return -1;
        }
        public int GetGenerationNum()
        {
            return generationNum;
        }
        private byte GetCrossoverType(int CurrentGeneration)
        {
            Random rand = new Random();
            if (rand.NextDouble() > ((generationNum - CurrentGeneration) / generationNum))
                return 1;
            else
                return 0;
        }
        private byte GetMutationType(int CurrentGeneration)
        {
            Random rand = new Random();
            if (rand.NextDouble() > ((generationNum - CurrentGeneration) / generationNum))
               /* if (libType == 1)
                {
                    if (counter < 50)
                        return 1;
                    else
                        return 3;
                }
                else*/
                    return 1;
            else
                    return 0;
        }
        private void IndividualFitnessEval(int IndividualIndex)
        {
            individualsList[IndividualIndex].FitnessEval(testImageList, testImageListMask, testImageSize, testImageNum, testNum);
        }
        private void SetFitnessListIntegrity()
        {
            fitnrssList[0] = individualsList[0].GetFitness();
            for (int i = 1; i < populationSize; i++)
            {
                fitnrssList[i] = fitnrssList[i - 1] + individualsList[i].GetFitness();
            }
        }

        private bool LoadTestImage()
        {
            Bitmap image;
            // FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            // DialogResult result = folderBrowserDialog.ShowDialog();
            try
            {
                //  if (result == DialogResult.OK)
                {
                    string folderName = @"d:\image_param\images"; ;//folderBrowserDialog.SelectedPath;
                    for (int i = 0; i < testImageNum; i++)
                    {
                        image = new Bitmap(folderName + "\\" + (counter / stat_period).ToString() + ".jpg");
                        testImageSize[0, i] = image.Height;
                        testImageSize[1, i] = image.Width;
                        testImageList[i] = new byte[testImageSize[0, i], testImageSize[1, i]];
                        for (int k = 0; k < testImageSize[0, i]; k++)
                            for (int j = 0; j < testImageSize[1, i]; j++)
                            {
                                testImageList[i][k, j] = image.GetPixel(j, k).G;
                            }
                        image = new Bitmap(folderName + "\\" + (counter / stat_period).ToString() + "mask.jpg");
                        testImageListMask[i] = new byte[testImageSize[0, i], testImageSize[1, i]];
                        for (int k = 0; k < testImageSize[0, i]; k++)
                            for (int j = 0; j < testImageSize[1, i]; j++)
                            {
                                testImageListMask[i][k, j] = (image.GetPixel(j, k).G > 150) ? (byte)1 : (byte)0;
                            }
                    }
                    return true;
                }
                /*   else
                   {
                       MessageBox.Show("Select the directory with test pictures");
                        return false;
                   }*/
            }
            catch (Exception ex)
            {
                Debug.Assert(false, "image not found" + ex.ToString());
                return false;
            }
        }

        int stat_period = 1;
        private int counter;
        private int libType;
        private int principleOfParentalChoice;
        private int setPoolNum;
        private double[] fitnrssList;
        private double [] rankingTable;
        private int crossoverType;
        private double a;//коэффициент ранжирования при отборе рродителей
        private int[] fitnessSort;
        private CChromosome[] individualsList;
        private CChromosome[] individualsPool;
        private byte[][,] testImageList;
        private byte[][,] testImageListMask;
        private int[,] testImageSize;
        private int populationSize;
        private int generationNum;
        private int testImageNum;
        private int testNum;
        private int maxFitnessIndividualInd;
        private CChromosome maxFitnessIndividual;
        private CChromosome firstParentIndividual;
        private CChromosome secondParentIndividual;
        private double maxFitnessIndividualValue;
        private double[] maxFitnessIndividualValueList;
        private double[] averageFitnessIndividualValueList;
        private int currentGeneration;
        private string statusString;
    }
}
