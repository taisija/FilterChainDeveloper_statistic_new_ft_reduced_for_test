using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
//using Microsoft.Office.Interop.Excel;

namespace FilterChainDeveloper
{
    class CChromosome
    {
        public static void SetLibraryCapacity(int capacity)
        {
            //fitnessThreshold = 0;
            middleDeltaFetness = 0;
            segmentsNum = capacity;
            segmentOfChromosome = new List<CNode>[segmentsNum];
            segmentsIncrease = new double[segmentsNum];
            //segmentsIncreaseSort = new int [segmentsNum];
        }


        public static void SetCounter(int c)
        {
            if (c >= 0 && c < segmentsNum)
                counter = c;
        }
        /*

        public static List<CNode> GetMinSegment(int num)
        {
            if (counter > num)
            {
                return segmentOfChromosome[num];
            }
            return null;
        }

        public void SetFitnessIncreaseSpeed()
        {
            double a = (fitnessList[individualLen - 1] - fitnessList[0])/individualLen;
            if (a > middleDeltaFetness) middleDeltaFetness = a;
        }

        public void LibrarySort()
        {
            if (counter == segmentsNum)
            {
                int j;
                double tmp;
                List<CNode> temp;
                for (int i = 0; i < segmentsNum; i++)
                {
                    tmp = segmentsIncrease[i];
                    temp = segmentOfChromosome[i];
                    for (j = i - 1; j >= 0 && segmentsIncrease[j] > tmp; j--)
                    {
                        segmentsIncrease[j + 1] = segmentsIncrease[j];
                        segmentOfChromosome[j + 1] = segmentOfChromosome[j];
                    }
                    segmentsIncrease[j + 1] = tmp;
                    segmentOfChromosome[j + 1] = temp;
                }
            }
        }

        public int SearchMinSegments()
        {
             int k = 0;
             for (int i = 0; i < (individualLen - 1); i++)
             {
                 if ((fitnessList[i] - fitnessList[i]) > middleDeltaFetness)
                 {
                     while ((fitnessList[i] - fitnessList[i+1]) > middleDeltaFetness)
                     {
                         i++;
                     }
                     k++;
                 }
             }
             return k;
        }

        public List<CNode> GetFirstMinSegment()
        {
            List<CNode> list = new List<CNode>();
            IEnumerator<CNode> iter = nodeList.GetEnumerator();
            int k = 0;
            for (int i = 0; i < (individualLen-1); i++)
            {
                if ((fitnessList[i] - fitnessList[i+1]) > middleDeltaFetness)
                {
                    while (iter.MoveNext() && k < i)
                    {
                        while (iter.Current == null) iter.MoveNext();
                        k++;
                    }
                    while ((i < (individualLen - 1)) && ((fitnessList[i] - fitnessList[i+1]) > middleDeltaFetness))
                    {
                        list.Add(iter.Current);
                        iter.MoveNext(); 
                        i++;
                    }
                    firstSegmentIncrease = (fitnessList[k] - fitnessList[i])/(i+1-k);
                    return list;
                }
            }
            return null;
        }

        public List<CNode> GetFirstMaxSegment()
        {
            List<CNode> list = new List<CNode>();
            IEnumerator<CNode> iter = nodeList.GetEnumerator();
            int k = 0;
            for (int i = 0; i < (individualLen - 1); i++)
            {
                if ((fitnessList[i + 1] - fitnessList[i]) > middleDeltaFetness)
                {
                    while (iter.MoveNext() && k < i)
                    {
                        while (iter.Current == null) iter.MoveNext();
                        k++;
                    }
                    while ((i < (individualLen - 1)) && ((fitnessList[i + 1] - fitnessList[i]) > middleDeltaFetness))
                    {
                        list.Add(iter.Current);
                        iter.MoveNext();
                        i++;
                    }
                    firstSegmentIncrease = (fitnessList[i] - fitnessList[k]) / (i + 1 - k);
                    return list;
                }
            }
            return null;
        }

        public void SaveToLibrary(List<CNode> newSegment)
        {
            if (counter < segmentsNum)
            {
                segmentOfChromosome[counter] = newSegment;
                segmentsIncrease[counter] = firstSegmentIncrease;
                counter++;
            }
            else
            {
                if (firstSegmentIncrease > segmentsIncrease[0])
                {
                    segmentsIncrease[0] = firstSegmentIncrease;
                    segmentOfChromosome[0] = newSegment;
                    LibrarySort();
                }
            }
        }*//*
        public CChromosome(Random _random)
        {
            random = _random;
            individualLen = random.Next(minIndividualLen, maxIndividualLen);
            nodeList = new List<CNode>();
            try
            {
                for (int i = 0; i < individualLen; i++)
                {
                    nodeList.Add(CNodesFactory.INSTANCE.NewNode());
                }
            }
            catch(Exception ex)
            {
                Debug.Assert(true, ex.ToString());
            }
            sizeList = new int[maxTestImageNum][];
            fitnessList = new double[individualLen];
            imageList = new double[maxTestImageNum][,];
            imageMed = new int[maxTestImageNum];
            for (int i = 0; i < maxTestImageNum; i++)
            {
                imageList[i] = null;
                imageMed[i] = 0;
            }
        }*/
        public CChromosome(DataLoader DL, int num)
        {
            individualLen = DL.DataLen[num];
            nodeList = new List<CNode>();
            try
            {
                for (int i = 0; i < individualLen; i++)
                {
                    nodeList.Add(CNodesFactory.INSTANCE.NewNode(DL.LoadingData[num][i]));
                }
            }
            catch (Exception ex)
            {
                Debug.Assert(true, ex.ToString());
            }
            sizeList = new int[maxTestImageNum][];
            fitnessList = new double[individualLen];
            imageList = new double[maxTestImageNum][,];
            imageMed = new int[maxTestImageNum];
            for (int i = 0; i < maxTestImageNum; i++)
            {
                imageList[i] = null;
                imageMed[i] = 0;
            }
        }
        public CChromosome(CChromosome sourceChromosome)
        {
            individualLen = sourceChromosome.individualLen;
            IEnumerator<CNode> iter = sourceChromosome.nodeList.GetEnumerator();
            nodeList = new List<CNode>();
            try
            {
                for (int i = 0; iter.MoveNext() && (i < individualLen); i++)
                {
                    nodeList.Add(iter.Current.Clone());
                }
            }
            catch (Exception ex)
            {
                Debug.Assert(true, ex.ToString());
            }
            fitnessList = new double[individualLen];
            for (int i = 0; i < individualLen; i++)
            {
                fitnessList[i] = sourceChromosome.fitnessList[i];
            }
            crossPoint1 = sourceChromosome.crossPoint1;
            crossPoint2 = sourceChromosome.crossPoint2;
            imageList = new double[maxTestImageNum][,];
            for (int i = 0; i < maxTestImageNum; i++)
            {
                imageList[i] = sourceChromosome.imageList[i];
            }
            sizeList = new int[maxTestImageNum][];
            imageMed = new int[maxTestImageNum];
            for (int i = 0; i < maxTestImageNum; i++)
            {
                if (sourceChromosome.sizeList[i]!=null)
                {
                    sizeList[i] = new int [2];
                    sizeList[i][0] = sourceChromosome.sizeList[i][0];
                    sizeList[i][1] = sourceChromosome.sizeList[i][1];
                    imageMed[i] = sourceChromosome.imageMed[i];
                }
            }
            fitnessType = sourceChromosome.fitnessType;
            random = sourceChromosome.random;
        }
        public void Mutation(byte mutationType)
        {
            int mutationPoint;
            int num = 0;
            Random random = new Random();
            switch (mutationType)
            {
                case 0:
                    mutationPoint = random.Next(minIndividualLen, nodeList.Count-1);
                    nodeList.RemoveRange(mutationPoint, 1);
                    nodeList.Insert(mutationPoint, CNodesFactory.INSTANCE.NewNode());
                    break;
                case 1:
                    if (counter > 0)
                    {
                        num = random.Next(0, counter);
                        IEnumerator<CNode> iter = segmentOfChromosome[num].GetEnumerator();
                        while (iter.Current == null) iter.MoveNext();
                        mutationPoint = GetMinFitnessNodeInd();
                        nodeList.RemoveRange(mutationPoint, 1);
                        for (int i = 0; i < segmentOfChromosome[num].Count; i++)
                        {
                            nodeList.Insert(mutationPoint + i, iter.Current);
                            iter.MoveNext();
                        }
                        individualLen += segmentOfChromosome[num].Count - 1;
                        fitnessList = new double[individualLen];
                        break;
                    }                    
                    mutationPoint = GetMinFitnessNodeInd();
                    nodeList.RemoveRange(mutationPoint, 1);
                    nodeList.Insert(mutationPoint, CNodesFactory.INSTANCE.NewNode());
                    break;
                case 3:
                    if (counter > 0)
                    {
                        num = random.Next(0, counter);
                        IEnumerator<CNode> iter = segmentOfChromosome[num].GetEnumerator();
                        while (iter.Current == null) iter.MoveNext();
                        mutationPoint = GetMaxFitnessNodeInd();
                        nodeList.RemoveRange(mutationPoint, 1);
                        for (int i = 0; i < segmentOfChromosome[num].Count; i++)
                        {
                            nodeList.Insert(mutationPoint + i, iter.Current);
                            iter.MoveNext();
                        }
                        individualLen += segmentOfChromosome[num].Count - 1;
                        fitnessList = new double[individualLen];
                        break;
                    }
                    mutationPoint = GetMaxFitnessNodeInd();
                    nodeList.RemoveRange(mutationPoint, 1);
                    nodeList.Insert(mutationPoint, CNodesFactory.INSTANCE.NewNode());
                    break;
                default:
                    mutationPoint = GetMinFitnessNodeInd();
                    nodeList.RemoveRange(mutationPoint, 1);
                    nodeList.Insert(mutationPoint, CNodesFactory.INSTANCE.NewNode());
                    break;
            }
        }
        public void Crossover(List<CNode> part)
        {
            nodeList.RemoveRange(crossPoint2, crossPoint1 - crossPoint2);
            nodeList.InsertRange(crossPoint2, part);
            individualLen = nodeList.Count;
            fitnessList = new double[individualLen];
            crossPoint1 = 0;
            crossPoint2 = 0;
        }
        public bool GetIntegrity()
        {
            return (individualLen == nodeList.Count);
        }
        public List<CNode> GetSubsequence(byte crossoverType)
        {
            crossType = crossoverType;
            int a;
            List<CNode> part = new List<CNode>();
            switch(crossoverType)
            {
                case 0:
                    Random rand  = new Random();
                    crossPoint1 = rand.Next(1, individualLen - 1);
                    crossPoint2 = 0;
                    break;
                case 1:
                    crossPoint1 = GetMinFitnessNodeInd();
                    crossPoint2 = 0;
                    break;
                default:
                    crossPoint1 = GetMinFitnessNodeInd();
                    crossPoint2 = GetSecondFitnessNodeInd(crossPoint1);
                    if (crossPoint1 < crossPoint2)
                    {
                        a = crossPoint1;
                        crossPoint1 = crossPoint2;
                        crossPoint2 = a;
                    }
                    break;
            }
            IEnumerator<CNode> iter = nodeList.GetEnumerator();
            int i = 0;
            while (i < crossPoint2)
            {
                iter.MoveNext();
                i++;
            }
            for (int j = i; iter.MoveNext() && (j < crossPoint1); j++)
            {
                part.Add(iter.Current);
            }
            return part; 
        }
        public void FitnessEval(byte[][,] ImageList, byte[][,] ImageMaskList, int[,] ImageSizeList, int ImageNum, int TestNum)
        {
            int num, size;
            IEnumerator<CNode> iter = nodeList.GetEnumerator();
         /*   if (nodeList.Count < 3)
            {
                int d = 0;
            }*/
            double filterSum = 0;
            double med;
            for (int i = 0; i < maxTestImageNum; i++)
            {
                imageList[i] = null;
            }
            for (int l = 0; l < individualLen; l++)
            {
                fitnessList[l] = 0;
            }
            //double numen, denomin;
            for (int i = 0; i < TestNum; i++)
            {
                //выбираем картинку
                num = i;//random.Next(0, ImageNum-1);
                //начинаем с первого фильтра
                /*if (iter.Current != null)
                {*/
                    iter.Reset();
                //}
                //обнуляем буффер для фильтрации
                currentImage = new double[ImageSizeList[0, num], ImageSizeList[1, num]];
                newImage = new double[ImageSizeList[0, num], ImageSizeList[1, num]];
                sizeList[i] = new int[2];
                sizeList[i][0] = imageSizeX = ImageSizeList[1, num];
                sizeList[i][1] = imageSizeY = ImageSizeList[0, num];
                
              /*  for (int y = 0; y < ImageSizeList[0, num];y ++ )
                    for (int x = 0; x < ImageSizeList[1, num]; x++)
                    {
                        curImage[y, x] = 0;
                        newImage[y, x] = 0;
                    }*/
                //для каждого узла особи вычисляем фитнесс
                int k = 0;
               // var tn = DateTime.Now;
                //string str = "";
                    while (iter.MoveNext() && (k < individualLen))
                    {
                        while (iter.Current == null) iter.MoveNext();
                        filterSum = 0;
                        //fitnessList[k] = 0;
                        size = iter.Current.GetFilterLength();
                        filterSum = iter.Current.GetFilterSum();
                        //по изображению
                        /*    max = 0;
                            min = 255;*/
                        double numen = 0, denomin = 1;
                        double numen_b = 0, denomin_b = 1;

                        if (k == 0)
                        {
                            //   tn = DateTime.Now;
                            med = iter.Current.ApplyFilter(ImageList[num], currentImage, ImageSizeList[1, num], ImageSizeList[0, num]);
                            //   str += (DateTime.Now - tn).ToString()+ " ";
                            for (int yy = 0; yy < ImageSizeList[0, num]; yy++)
                                for (int xx = 0; xx < ImageSizeList[1, num]; xx++)
                                {
                                    numen += ((ImageMaskList[num][yy, xx] > 0) && (currentImage[yy, xx] > med)) ? 1 : 0;
                                    // numen += ((ImageMaskList[num][yy, xx] == 0) && (currentImage[yy, xx] <= med)) ? 1 : 0;
                                    denomin += ((ImageMaskList[num][yy, xx] > 0) || (currentImage[yy, xx] > med)) ? 1 : 0;

                                    numen_b += ((ImageMaskList[num][yy, xx] == 0) && (currentImage[yy, xx] < med)) ? 1 : 0;
                                    denomin_b += ((ImageMaskList[num][yy, xx] == 0) || (currentImage[yy, xx] < med)) ? 1 : 0;
                                }
                            //-------------------
                            //denomin = ImageSizeList[1, num] * ImageSizeList[0, num];
                            //----------------------
                            //fitnessList[k] += (numen / denomin) * (maxIndividualLen - (double)k + minIndividualLen) / maxIndividualLen;
                            fitnessList[k] += GetFitnessToList(numen, denomin, k+1);
                            //fitnessList[k] += (GetFitnessToList(numen_b, denomin_b, k + 1) + GetFitnessToList(numen, denomin, k + 1)) / 2;
                            k++;
                            imageList[i] = currentImage;
                            imageMed[i] = (int)med;
                        }
                        else
                        {
                            //  tn = DateTime.Now;
                            med = iter.Current.ApplyFilter(currentImage, newImage, ImageSizeList[1, num], ImageSizeList[0, num]);
                            //  str += (DateTime.Now - tn).ToString() + " ";
                            for (int yy = 0; yy < ImageSizeList[0, num]; yy++)
                                for (int xx = 0; xx < ImageSizeList[1, num]; xx++)
                                {
                                    numen += ((ImageMaskList[num][yy, xx] > 0) && (newImage[yy, xx] > med)) ? 1 : 0;
                                    //numen += ((ImageMaskList[num][yy, xx] == 0) && (currentImage[yy, xx] <= med)) ? 1 : 0;
                                    denomin += ((ImageMaskList[num][yy, xx] > 0) || (newImage[yy, xx] > med)) ? 1 : 0;
                                    numen_b += ((ImageMaskList[num][yy, xx] == 0) && (currentImage[yy, xx] < med)) ? 1 : 0;
                                    denomin_b += ((ImageMaskList[num][yy, xx] == 0) || (currentImage[yy, xx] < med)) ? 1 : 0;
                                }
                            //-------------------
                            //denomin = ImageSizeList[1, num] * ImageSizeList[0, num];
                            //----------------------
                            //fitnessList[k] += (numen / denomin) * (maxIndividualLen - (double)k + minIndividualLen) / maxIndividualLen;
                            fitnessList[k] += GetFitnessToList(numen, denomin, k+1);
                            //fitnessList[k] += (GetFitnessToList(numen_b, denomin_b, k + 1) + GetFitnessToList(numen, denomin, k + 1)) / 2;
                            k++;
                            imageList[i] = newImage;
                            imageMed[i] = (int)med;
                            if (iter.MoveNext())
                            {
                                filterSum = 0;
                                //fitnessList[k] = 0;
                                size = iter.Current.GetFilterLength();
                                filterSum = iter.Current.GetFilterSum();
                                //по изображению
                                numen = 0;
                                denomin = 1;
                                numen_b = 0;
                                denomin_b = 1;
                                //  tn = DateTime.Now;
                                med = iter.Current.ApplyFilter(newImage, currentImage, ImageSizeList[1, num], ImageSizeList[0, num]);
                                //  str += (DateTime.Now - tn).ToString() + " ";
                                for (int yy = 0; yy < ImageSizeList[0, num]; yy++)
                                    for (int xx = 0; xx < ImageSizeList[1, num]; xx++)
                                    {
                                        numen += ((ImageMaskList[num][yy, xx] > 0) && (currentImage[yy, xx] > med)) ? 1 : 0;
                                        //numen += ((ImageMaskList[num][yy, xx] == 0) && (currentImage[yy, xx] <= med)) ? 1 : 0;
                                        denomin += ((ImageMaskList[num][yy, xx] > 0) || (currentImage[yy, xx] > med)) ? 1 : 0;
                                        numen_b += ((ImageMaskList[num][yy, xx] == 0) && (currentImage[yy, xx] < med)) ? 1 : 0;
                                        denomin_b += ((ImageMaskList[num][yy, xx] == 0) || (currentImage[yy, xx] < med)) ? 1 : 0;
                                    }
                                //-------------------
                                //denomin = ImageSizeList[1, num] * ImageSizeList[0, num];
                                //----------------------
                                //fitnessList[k] += (numen / denomin) * (maxIndividualLen - (double)k + minIndividualLen) / maxIndividualLen;
                                fitnessList[k] += GetFitnessToList(numen, denomin, k+1);
                                //fitnessList[k] += (GetFitnessToList(numen_b, denomin_b, k + 1) + GetFitnessToList(numen, denomin, k + 1))/2;
                                k++;
                                imageList[i] = currentImage;
                                imageMed[i] = (int)med;
                            }
                        }
                    }
            }
            for (int k = 0; k < individualLen; k++)
            {
                fitnessList[k] /= TestNum;
            }
            saveImageFlag = false;
        }
        public void SaveFilterList(int generationNumber, int index, int c)
        {
            //Create a new subfolder under the current active folder
            string activeDir = @"d:\test";
            //Create a new subfolder under the current active folder
            string newPath = System.IO.Path.Combine(activeDir, c.ToString());
            // Create the subfolder
            StreamWriter f = new StreamWriter(newPath + "\\" + c.ToString() + "_.txt", true);
            f.WriteLine(fitnessList[individualLen - 1]);
            f.Close();

            try
            {
                using (TextWriter writer = File.CreateText(newPath + "\\" + generationNumber.ToString() + "_" + index.ToString() + ".txt"))
                {
                    int len = 0;
                    int i;
                    IEnumerator<CNode> iter = nodeList.GetEnumerator();
                    while (iter.MoveNext())
                    {
                        len = iter.Current.GetFilterLength();
                        writer.WriteLine(len.ToString() + " " + iter.Current.GetFilterDenominatorSum().ToString());
                        for (i = 0; i < len; i++)
                        {
                            for (int j = 0; j < len; j++)
                                writer.Write(iter.Current.GetFilterValue(i, j).ToString() + " ");
                            writer.WriteLine();
                        }
                        while (i < iter.Current.GetMaxFilterLength())
                        {
                            writer.WriteLine("");
                            i++;
                        }
                    }
                    writer.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void SaveFilterFitness(int generationNumber, int index, int c)
        {
            //Create a new subfolder under the current active folder
            string activeDir = @"d:\test";
            //Create a new subfolder under the current active folder
            string newPath = System.IO.Path.Combine(activeDir, c.ToString());
            // Create the subfolder
            StreamWriter f = new StreamWriter(newPath + "\\" + c.ToString() + ".txt", true);
            f.WriteLine(fitnessList[individualLen - 1]);
            f.Close();
            try
            {
                using (TextWriter writer = File.CreateText(newPath + "\\" + generationNumber.ToString() + ".txt"))
                {
                    writer.WriteLine(fitnessList[individualLen - 1]);
                    writer.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void SetSaveImageFlag()
        {
            saveImageFlag = true; 
        }
        public void SaveFilteredImages(int generationNumber, int index, int c)
        {
            //Create a new subfolder under the current active folder
            string newPath = @"d:\test\" + c.ToString();
            try
            {
                Bitmap image;
                int i = 0;
                while (imageList[i] != null)
                {
                    image = new Bitmap(sizeList[i][0], sizeList[i][1]);
                    for (int k = 0; k < sizeList[i][1]; k++)
                        for (int j = 0; j < sizeList[i][0]; j++)
                        {
                            image.SetPixel(j, k, System.Drawing.Color.FromArgb(((imageList[i][k, j] > imageMed[i]) ? 254 : 0), ((imageList[i][k, j] > imageMed[i]) ? 254 : 0), ((imageList[i][k, j] > imageMed[i]) ? 254 : 0)));
                        }
                    image.Save(newPath + "\\" + generationNumber.ToString() + "_" + index.ToString() + "_" + i.ToString() + ".jpg");
                    i++;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        public double GetFitness()
        {
            return fitnessList[individualLen - 1];
        }
        private double GetFitnessToList(double Numen, double Denomin, int len)
        {
            switch (fitnessType)
            {
                case 1:
                    return ((Numen / Denomin) * ((len < maxIndividualLen) ? ((maxIndividualLen - (double)len + minIndividualLen) / maxIndividualLen) : 0.001));
                case 2:
                    return ((Numen / Denomin) * (((len<2)||(len>15))?0.001:((len<2)?0.5:((len<10)?1:0.5))));
            }
            return ((Numen / Denomin) * ((len < maxIndividualLen)?((maxIndividualLen - (double)len + minIndividualLen) / maxIndividualLen):0.001));
        }

        public void SetFitnessType(int FitnessType)
        {
            fitnessType = FitnessType;
        }

        private byte GetMinFitnessNodeInd()
        {
            double min = 1;
            byte num = 0;
            for(byte i = 0; i < individualLen; i++)
                if (fitnessList[i] <= min) 
                {
                    num = i;
                    min = fitnessList[i];
                }
            return num;
        }

        public bool AnnealingChromosome()
        {
            double max = 0;
            byte num = 0;
            double []fl;
            for (byte i = 0; i < individualLen; i++)
                if (fitnessList[i] >= max)
                {
                    num = i;
                    max = fitnessList[i];
                }
            if (num < (individualLen - 1))
            {
                nodeList.RemoveRange(num, individualLen - num - 1);
                individualLen = num+1;
                fl = fitnessList;
                fitnessList = new double[individualLen];
                for (byte i = 0; i < individualLen; i++)
                {
                    fitnessList[i] = fl[i];
                }
                return true;
            }
            return false;
        }

        private byte GetSecondFitnessNodeInd(int firstMinInd)
        {
            double min = 1;
            byte num = 0;
            for (byte i = 0; i < individualLen; i++)
                if (fitnessList[i] <= min && i != firstMinInd)
                {
                    num = i;
                    min = fitnessList[i];
                }
            return num;
        }

        private byte GetMaxFitnessNodeInd()
        {
            double max = 0;
            byte num = 0;
            for (byte i = 0; i < individualLen; i++)
                if (fitnessList[i] >= max)
                {
                    num = i;
                    max = fitnessList[i];
                }
            return num;
        }

        public int GetIndividualLength()
        {
            return individualLen;
        }

        public int[] GetIndexesOfAllNodes()
        {
            int[] indexes = new int[individualLen];
            int i = 0;
            IEnumerator<CNode> iter = nodeList.GetEnumerator();
            while (iter.MoveNext() && i < individualLen)
            {
                indexes[i] = iter.Current.GetFilterIndex();
                i++;
            }
            return indexes;
        }
        //library
        private static List<CNode>[] segmentOfChromosome;
        private static double[] segmentsIncrease;
        //private static int[] segmentsIncreaseSort;
        private static int segmentsNum;
        //private static double fitnessThreshold;
        private static double middleDeltaFetness;
        private static int counter;
        private double firstSegmentIncrease;

        //-------
        private int crossType;
        private double[,] currentImage;
        private double[,] newImage;
        private double[][,] imageList;
        private int[] imageMed;
        private int[][] sizeList;
        private int imageSizeX;
        private int imageSizeY;
        private double[] fitnessList;
        private bool saveImageFlag = false;
        private List<CNode> nodeList;
        private int individualLen;
        private int maxIndividualLen = 30;
        private int minIndividualLen = 2;
        private int crossPoint1;
        private int crossPoint2;
        private int fitnessType = 1;
        private int maxTestImageNum = 10;
        private Random random;
    }
}
