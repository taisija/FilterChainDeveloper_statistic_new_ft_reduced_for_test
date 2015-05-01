using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace FilterChainDeveloper
{
    class CNode
    {
        public CNode()
        {
            /*Random random = new Random();
            filterInd = random.Next(0, filterNum);
            SetFilterValue();*/
        }
        public CNode(double[][,] Filters, int FilterNum, int[] FiltersSizes, int [] FiltersDenom)
        {
            //Random random = new Random();
            filterInd = FilterNum;//random.Next(0, NumOfFilters);
            filterLen = FiltersSizes[filterInd];
            filterDenominatorSum = FiltersDenom[filterInd];
            filter = Filters[filterInd];
            SetFilterSum();
        }
        public CNode(CNode sourceNode)
        {
            filterInd = sourceNode.filterInd;
            filterLen = sourceNode.filterLen;
            filterSum = sourceNode.filterSum;
            filterDenominatorSum = sourceNode.filterDenominatorSum;
            filter = new double[filterLen, filterLen];
            for (int i = 0; i < filterLen; i++)
                for (int j = 0; j < filterLen; j++)
                {
                    filter[i, j] = sourceNode.filter[i, j];
                }
        }
        public virtual CNode Clone()
        {
            CNode newNode = new CNode();
            newNode.filterInd = filterInd;
            newNode.filterLen = filterLen;
            newNode.filterSum = filterSum;
            newNode.filterDenominatorSum = filterDenominatorSum;
            newNode.filter = new double[filterLen, filterLen];
            for (int i = 0; i < filterLen; i++)
                for (int j = 0; j < filterLen; j++)
                {
                    newNode.filter[i, j] = filter[i, j];
                }
            return newNode;
        }
        public virtual double ApplyFilter(double[,] CurImage, double[,] NewImage, int Width, int Height)
        {
            //по изображению
            double max = 0;
            double min = 255;
            int lHeight = Height - 2;
            int lWidth = Width - 2;
            int llHeight = Height - 1;
            int llWidth = Width - 1;
            if (filterLen == 5)
            {
                for (int y = 2; y < lHeight; y++)
                    for (int x = 2; x < lWidth; x++)
                    {
                        NewImage[y, x] = 0;
                        NewImage[y, x] += CurImage[y - 2, x - 2] * filter[0, 0];
                        NewImage[y, x] += CurImage[y - 2, x - 1] * filter[0, 1];
                        NewImage[y, x] += CurImage[y - 2, x] * filter[0, 2];
                        NewImage[y, x] += CurImage[y - 2, x + 1] * filter[0, 3];
                        NewImage[y, x] += CurImage[y - 2, x + 2] * filter[0, 4];

                        NewImage[y, x] += CurImage[y - 1, x - 2] * filter[1, 0];
                        NewImage[y, x] += CurImage[y - 1, x - 1] * filter[1, 1];
                        NewImage[y, x] += CurImage[y - 1, x] * filter[1, 2];
                        NewImage[y, x] += CurImage[y - 1, x + 1] * filter[1, 3];
                        NewImage[y, x] += CurImage[y - 1, x + 2] * filter[1, 4];

                        NewImage[y, x] += CurImage[y, x - 2] * filter[2, 0];
                        NewImage[y, x] += CurImage[y, x - 1] * filter[2, 1];
                        NewImage[y, x] += CurImage[y, x] * filter[2, 2];
                        NewImage[y, x] += CurImage[y, x + 1] * filter[2, 3];
                        NewImage[y, x] += CurImage[y, x + 2] * filter[2, 4];

                        NewImage[y, x] += CurImage[y + 1, x - 2] * filter[4, 0];
                        NewImage[y, x] += CurImage[y + 1, x - 1] * filter[4, 1];
                        NewImage[y, x] += CurImage[y + 1, x] * filter[4, 2];
                        NewImage[y, x] += CurImage[y + 1, x + 1] * filter[4, 3];
                        NewImage[y, x] += CurImage[y + 1, x + 2] * filter[4, 4];

                        NewImage[y, x] += CurImage[y + 2, x - 2] * filter[4, 0];
                        NewImage[y, x] += CurImage[y + 2, x - 1] * filter[4, 1];
                        NewImage[y, x] += CurImage[y + 2, x] * filter[4, 2];
                        NewImage[y, x] += CurImage[y + 2, x + 1] * filter[4, 3];
                        NewImage[y, x] += CurImage[y + 2, x + 2] * filter[4, 4];
                  
                        if (NewImage[y, x] < 0)
                            NewImage[y, x] = 0;
                        if (NewImage[y, x] > 255)
                            NewImage[y, x] = 255;
                        NewImage[y, x] /= filterSum;
                        if (min > NewImage[y, x])
                            min = NewImage[y, x];
                        if (max < NewImage[y, x])
                            max = NewImage[y, x];
                    }
                for (int y = 0; y < Height; y++)
                {
                    NewImage[y, 0] = NewImage[y, 1] = NewImage[y, 2];
                    NewImage[y, (Width - 1)] = NewImage[y, (Width - 2)] = NewImage[y, (Width - 3)];
                }
                for (int x = 0; x < Width; x++)
                {
                    NewImage[0, x] = NewImage[1, x] = NewImage[2, x];
                    NewImage[(Height - 1), x] = NewImage[(Height - 2), x] = NewImage[(Height - 3), x];
                }
            }
            else
            {
                for (int y = 1; y < lHeight; y++)
                    for (int x = 1; x < lWidth; x++)
                    {
                        NewImage[y, x] = 0;
                        
                        NewImage[y, x] += CurImage[y - 1, x - 1] * filter[0, 0];
                        NewImage[y, x] += CurImage[y - 1, x] * filter[0, 1];
                        NewImage[y, x] += CurImage[y - 1, x + 1] * filter[0, 2];

                        NewImage[y, x] += CurImage[y, x - 1] * filter[1, 0];
                        NewImage[y, x] += CurImage[y, x] * filter[1, 1];
                        NewImage[y, x] += CurImage[y, x + 1] * filter[1, 2];

                        NewImage[y, x] += CurImage[y + 1, x - 1] * filter[2, 0];
                        NewImage[y, x] += CurImage[y + 1, x] * filter[2, 1];
                        NewImage[y, x] += CurImage[y + 1, x + 1] * filter[2, 2];

                        if (NewImage[y, x] < 0)
                            NewImage[y, x] = 0;
                        if (NewImage[y, x] > 255)
                            NewImage[y, x] = 255;
                        NewImage[y, x] /= filterSum;
                        if (min > NewImage[y, x])
                            min = NewImage[y, x];
                        if (max < NewImage[y, x])
                            max = NewImage[y, x];
                    }
                for (int y = 0; y < Height; y++)
                    {
                        NewImage[y, 0] = NewImage[y, 1];
                        NewImage[y, (Width - 1)] = NewImage[y, (Width - 2)];
                    }
                for (int x = 0; x < Width; x++)
                {
                    NewImage[0, x] = NewImage[1, x];
                    NewImage[(Height - 1), x] = NewImage[(Height - 2), x];
                }
            }
            return (max + min) / 2;
        }
        public virtual double ApplyFilter(byte[,] CurImage, double[,] NewImage, int Width, int Height)
        {
            //по изображению
            double max = 0;
            double min = 255;
            int lHeight = Height - 2;
            int lWidth = Width - 2;
            int llHeight = Height - 1;
            int llWidth = Width - 1;
            if (filterLen == 5)
            {
                for (int y = 2; y < lHeight; y++)
                    for (int x = 2; x < lWidth; x++)
                    {
                        NewImage[y, x] = 0;
                        NewImage[y, x] += CurImage[y - 2, x - 2] * filter[0, 0];
                        NewImage[y, x] += CurImage[y - 2, x - 1] * filter[0, 1];
                        NewImage[y, x] += CurImage[y - 2, x] * filter[0, 2];
                        NewImage[y, x] += CurImage[y - 2, x + 1] * filter[0, 3];
                        NewImage[y, x] += CurImage[y - 2, x + 2] * filter[0, 4];

                        NewImage[y, x] += CurImage[y - 1, x - 2] * filter[1, 0];
                        NewImage[y, x] += CurImage[y - 1, x - 1] * filter[1, 1];
                        NewImage[y, x] += CurImage[y - 1, x] * filter[1, 2];
                        NewImage[y, x] += CurImage[y - 1, x + 1] * filter[1, 3];
                        NewImage[y, x] += CurImage[y - 1, x + 2] * filter[1, 4];

                        NewImage[y, x] += CurImage[y, x - 2] * filter[2, 0];
                        NewImage[y, x] += CurImage[y, x - 1] * filter[2, 1];
                        NewImage[y, x] += CurImage[y, x] * filter[2, 2];
                        NewImage[y, x] += CurImage[y, x + 1] * filter[2, 3];
                        NewImage[y, x] += CurImage[y, x + 2] * filter[2, 4];

                        NewImage[y, x] += CurImage[y + 1, x - 2] * filter[4, 0];
                        NewImage[y, x] += CurImage[y + 1, x - 1] * filter[4, 1];
                        NewImage[y, x] += CurImage[y + 1, x] * filter[4, 2];
                        NewImage[y, x] += CurImage[y + 1, x + 1] * filter[4, 3];
                        NewImage[y, x] += CurImage[y + 1, x + 2] * filter[4, 4];

                        NewImage[y, x] += CurImage[y + 2, x - 2] * filter[4, 0];
                        NewImage[y, x] += CurImage[y + 2, x - 1] * filter[4, 1];
                        NewImage[y, x] += CurImage[y + 2, x] * filter[4, 2];
                        NewImage[y, x] += CurImage[y + 2, x + 1] * filter[4, 3];
                        NewImage[y, x] += CurImage[y + 2, x + 2] * filter[4, 4];

                        if (NewImage[y, x] < 0)
                            NewImage[y, x] = 0;
                        if (NewImage[y, x] > 255)
                            NewImage[y, x] = 255;
                        NewImage[y, x] /= filterSum;
                        if (min > NewImage[y, x])
                            min = NewImage[y, x];
                        if (max < NewImage[y, x])
                            max = NewImage[y, x];
                    }
                for (int y = 0; y < Height; y++)
                {
                    NewImage[y, 0] = NewImage[y, 1] = NewImage[y, 2];
                    NewImage[y, (Width - 1)] = NewImage[y, (Width - 2)] = NewImage[y, (Width - 3)];
                }
                for (int x = 0; x < Width; x++)
                {
                    NewImage[0, x] = NewImage[1, x] = NewImage[2, x];
                    NewImage[(Height - 1), x] = NewImage[(Height - 2), x] = NewImage[(Height - 3), x];
                }
            }
            else
            {
                for (int y = 1; y < lHeight; y++)
                    for (int x = 1; x < lWidth; x++)
                    {
                        NewImage[y, x] = 0;

                        NewImage[y, x] += CurImage[y - 1, x - 1] * filter[0, 0];
                        NewImage[y, x] += CurImage[y - 1, x] * filter[0, 1];
                        NewImage[y, x] += CurImage[y - 1, x + 1] * filter[0, 2];

                        NewImage[y, x] += CurImage[y, x - 1] * filter[1, 0];
                        NewImage[y, x] += CurImage[y, x] * filter[1, 1];
                        NewImage[y, x] += CurImage[y, x + 1] * filter[1, 2];

                        NewImage[y, x] += CurImage[y + 1, x - 1] * filter[2, 0];
                        NewImage[y, x] += CurImage[y + 1, x] * filter[2, 1];
                        NewImage[y, x] += CurImage[y + 1, x + 1] * filter[2, 2];

                        if (NewImage[y, x] < 0)
                            NewImage[y, x] = 0;
                        if (NewImage[y, x] > 255)
                            NewImage[y, x] = 255;
                        NewImage[y, x] /= filterSum;
                        if (min > NewImage[y, x])
                            min = NewImage[y, x];
                        if (max < NewImage[y, x])
                            max = NewImage[y, x];
                    }
                for (int y = 0; y < Height; y++)
                {
                    NewImage[y, 0] = NewImage[y, 1];
                    NewImage[y, (Width - 1)] = NewImage[y, (Width - 2)];
                }
                for (int x = 0; x < Width; x++)
                {
                    NewImage[0, x] = NewImage[1, x];
                    NewImage[(Height - 1), x] = NewImage[(Height - 2), x];
                }
            }
            return (max - min) / 2 + min;
        }
        public void Mutate()
        {
        }
    /*   private bool SetFilterValue()
        {
            try
            {
                using (TextReader reader = File.OpenText("filter.txt"))
                {
                    for (int i = 0; i < filterInd * (maxFilterLen + 1); i++) reader.ReadLine();
                    string text = reader.ReadLine();
                    string[] bits = text.Split(' ');
                    filterLen = int.Parse(bits[0]);
                    filterDenominatorSum = int.Parse(bits[1]);
                    filter = new double[filterLen, filterLen];
                    for (int i = 0; i < filterLen; i++)
                    {
                        text = reader.ReadLine();
                        string[] nbits = text.Split(' ');
                        for (int j = 0; j < filterLen; j++)
                        {
                            filter[i, j] = double.Parse(nbits[j]);
                        }
                    }
                    SetFilterSum();
                }
            }
            catch (Exception ex)
            {
                Debug.Assert(false, ex.ToString());
                return false;
            }
            return true;
        }*/
        public double GetFilterValue(int i, int j)
        {
            if (i < filterLen && j < filterLen && i >= 0 && j >= 0)
                return filter[i, j];
            else
            {
                Debug.Assert(false, "GetFilterValue() error: out of range");
                return 0;
            }
        }
        public int GetMaxFilterLength()
        {
            return maxFilterLen;
        }
        public int GetFilterLength()
        {
            return filterLen;
        }
        public double GetFilterSum()
        {
            return filterSum;
        }
        public int GetFilterDenominatorSum()
        {
            return filterDenominatorSum;
        }
        public int GetFilterIndex()
        {
            return filterInd;
        }
        private void SetFilterSum()
        {
            switch (filterDenominatorSum)
            {
                case 1:
                    //среднее по матрице
                    filterSum = filterLen * filterLen;
                    break;
                case 2:
                    //среднее по матрице (чётный фильтр)
                    filterSum = (filterLen - 1) * (filterLen - 1);
                    break;
                case 3:
                    //обычный усредняющий фильтр
                    for (int ii = 0; ii < filterLen; ii++)
                        for (int jj = 0; jj < filterLen; jj++)
                        {
                            filterSum += filter[ii, jj];
                        }
                    break;
                case 4:
                    //обычный усредняющий чётный фильтр
                    for (int ii = 0; ii < (filterLen - 1); ii++)
                        for (int jj = 0; jj < (filterLen - 1); jj++)
                        {
                            filterSum += filter[ii, jj];
                        }
                    break;
                default:
                    //фильтр повышения высоких частот
                    filterSum = 1;
                    break;
            }

        }
        protected double[,] filter;
       // protected int filterNum = 17;
        protected int filterInd;
        protected const int maxFilterLen = 5;
        protected int filterLen;
        protected double filterSum;
        protected int filterDenominatorSum;
    }
}
