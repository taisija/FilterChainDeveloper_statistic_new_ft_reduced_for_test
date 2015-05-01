using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Windows.Forms;

namespace FilterChainDeveloper
{
    class CNodesFactory
    {
        public static CNodesFactory INSTANCE = new CNodesFactory();
         // some variables to store data from file
  
         private bool initialized;

         private CNodesFactory() 
         {
             random = new Random();
             histogram = new double[256];
         }

         public CNode NewNode() 
         {
            if (! initialized) 
            {
            // load data from file
                try
                {
                    using (TextReader reader = File.OpenText("john.txt"))
                    {
                        const int n = 256;
                        histogram = new double[n];

                        string text = reader.ReadLine();
                        histogram[0] = double.Parse(text);

                        for (int x = 1; x < n; x++)
                        {
                            text = reader.ReadLine();
                            histogram[x] = double.Parse(text)+histogram[x-1];
                        }
                    }
                    using (TextReader reader = File.OpenText("filter.txt"))
                    {
                        filters = new double [numOfFilters][,];
                        filtersSizes = new int[numOfFilters];
                        filtersDenom = new int[numOfFilters];
                        for (int n = 0; n < numOfFilters; n++)
                        {
                             string text = reader.ReadLine();
                             string[] bits = text.Split(' ');
                             filtersSizes[n] = int.Parse(bits[0]);
                             filtersDenom[n] = int.Parse(bits[1]);
                             filters[n] = new double[filtersSizes[n], filtersSizes[n]];
                             for (int i = 0; i < filtersSizes[n]; i++)
                             {
                                 text = reader.ReadLine();
                                 string[] nbits = text.Split(' ');
                                 for (int j = 0; j < filtersSizes[n]; j++)
                                 {
                                     filters[n][i, j] = double.Parse(nbits[j]);
                                 }
                             }
                             for (int i = filtersSizes[n]; i < maxFilterLen; i++)
                                 reader.ReadLine();
                        }
                    }
                    initialized = true;
                }
                catch (Exception ex)
                {
                    Debug.Assert(false, ex.ToString());
                    MessageBox.Show("filter.txt or john.txt not found in current directory");
                    return null;
                }
            }
            int ind = random.Next(0, numOfFilters);
            if (ind < numOfSimpleFilters) 
                return new CNode(filters, ind, filtersSizes, filtersDenom);
            else
                return new CNodeFunction(filters, ind, filtersSizes, filtersDenom, numOfSimpleFilters, histogram);
         }
         public CNode NewNode(int num)
         {
             if (!initialized)
             {
                 // load data from file
                 try
                 {
                     using (TextReader reader = File.OpenText("john.txt"))
                     {
                         const int n = 256;
                         histogram = new double[n];

                         string text = reader.ReadLine();
                         histogram[0] = double.Parse(text);

                         for (int x = 1; x < n; x++)
                         {
                             text = reader.ReadLine();
                             histogram[x] = double.Parse(text) + histogram[x - 1];
                         }
                     }
                     using (TextReader reader = File.OpenText("filter.txt"))
                     {
                         filters = new double[numOfFilters][,];
                         filtersSizes = new int[numOfFilters];
                         filtersDenom = new int[numOfFilters];
                         for (int n = 0; n < numOfFilters; n++)
                         {
                             string text = reader.ReadLine();
                             string[] bits = text.Split(' ');
                             filtersSizes[n] = int.Parse(bits[0]);
                             filtersDenom[n] = int.Parse(bits[1]);
                             filters[n] = new double[filtersSizes[n], filtersSizes[n]];
                             for (int i = 0; i < filtersSizes[n]; i++)
                             {
                                 text = reader.ReadLine();
                                 string[] nbits = text.Split(' ');
                                 for (int j = 0; j < filtersSizes[n]; j++)
                                 {
                                     filters[n][i, j] = double.Parse(nbits[j]);
                                 }
                             }
                             for (int i = filtersSizes[n]; i < maxFilterLen; i++)
                                 reader.ReadLine();
                         }
                     }
                     initialized = true;
                 }
                 catch (Exception ex)
                 {
                     Debug.Assert(false, ex.ToString());
                     MessageBox.Show("filter.txt or john.txt not found in current directory");
                     return null;
                 }
             }
             int ind = num;
             if (ind < numOfSimpleFilters)
                 return new CNode(filters, ind, filtersSizes, filtersDenom);
             else
                 return new CNodeFunction(filters, ind, filtersSizes, filtersDenom, numOfSimpleFilters, histogram);
         }
        private Random random;
        private double[][,] filters;
        private double[] histogram;
        private int numOfFilters = 13;
        private int numOfSimpleFilters = 2;
        private int[] filtersSizes;
        private int[] filtersDenom;
        private int maxFilterLen = 5;
        private int k = 0;
    }
}
