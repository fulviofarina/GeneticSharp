using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace GADB
{
    public static class Aid
    {


        /// <summary>
        /// FUNCTION TO PERFORM AVERAGE AND HISTOGRAM
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="problema"></param>
        public static void DoStatistics<T>(T problema)
        {
            GADataSet.ProblemsRow currentProblem = problema as GADataSet.ProblemsRow;

            IEnumerable<GADataSet.GARow> gasrows = currentProblem.GetGARows();

            int min = gasrows.Min(o => o.ChromosomeLength);
            int max = gasrows.Max(o => o.ChromosomeLength);

            HashSet<string> hash = new HashSet<string>();
            List<GADataSet.SolutionsRow> list = new List<GADataSet.SolutionsRow>();

            // int counter = 1;
            Func<GADataSet.SolutionsRow, bool> funcion;

            funcion = o =>
            {
                string genotype = o.Genotype;
                if (hash.Add(genotype)) //add to hashShet
                {
                    list.Add(o);//add to indexed list
                }
                else
                {
                    int i = list.FindIndex(r => r.Genotype.Equals(genotype));
                    list[i].Frequency += o.Frequency;
                }
                return true;
            };

            //iterate min max chromosome lenght for all genetic algorithms
            for (int j = min; j <= max; j++)
            {
                gasrows = currentProblem.GetGARows();

                IEnumerable<GADataSet.GARow> subs = gasrows.Where(o => o.ChromosomeLength == j).ToList();

                GADataSet.GARow subFirst = subs.FirstOrDefault();
                subFirst.GenerationCurrent = Convert.ToInt32(subs.Average(o => o.GenerationCurrent));
                subFirst.GenerationTotal = Convert.ToInt32(subs.Average(o => o.GenerationTotal));
                subFirst.MutationProb = subs.Average(o => o.MutationProb);
                subFirst.CrossProbability = subs.Average(o => o.CrossProbability);
                subFirst.TimeStamp = subs.Average(o => o.TimeStamp);

                //select GARow childrens
                IEnumerable<GADataSet.SolutionsRow> knaprows = subs.SelectMany(o => o.GetSolutionsRows());

                hash.Clear(); //clear
                list.Clear();//clear

                knaprows = knaprows.Where(funcion).ToList(); //evaluate the filter function

                int count = knaprows.Count();
              

                for (int d = 0; d < count; d++)
                {
                    GADataSet.SolutionsRow s = knaprows.ElementAt(d);
                 
                    if (!list.Contains(s)) s.Delete();
                    else s.GAID = subFirst.ID;
                }

                double bestFitness = list.Max(o=> o.Fitness);
                subFirst.Fitness = bestFitness;
             

                count = subs.Count();
                for (int d = 1; d < count; d++)
                {
                    subs.ElementAt(d).Delete();
                }
            }
        }

        public static double SetBasic(IList<int> Genes, DataRow[] values, string field)
        {
            double TotalValue = 0;

            for (int i = 0; i < Genes.Count; i++)
            {
                int index = Genes.ElementAt(i);
                if (index != -1)
                {
                    TotalValue += values[index - 1].Field<double>(field);
                }
            }

            return TotalValue;
        }

        /// <summary>
        /// USED BY DRONE CONTROLLER
        /// </summary>
        /// <param name="conditions"></param>
        /// <param name="Genes"></param>
        /// <param name="indexAt"></param>
        /// <param name="values"></param>
        /// <param name="field"></param>
        /// <returns></returns>
        public static double SetDifferences(DataRow conditions, IList<int> Genes, int indexAt, DataRow[] values, string field)
        {
            double difference = 0;
           
          
            //geneValue is index of Item in Table
            int geneValue = Genes.ElementAt(indexAt); //get first item

            //first item
            if (indexAt == 0)
            {
                //use value from MIN condition on A, B or C as start point
                double xo = conditions.Field<double>("Min" + field);
                difference = values[geneValue - 1].Field<double>(field)-xo;
            }
            //last item
            else if (indexAt  == Genes.Count-1)
            {
                //use value from MAX condition on A, B or C as end-point
                double xf = conditions.Field<double>("Max" + field);
                geneValue = Genes.ElementAt(indexAt-1); //get first item
                difference = values[geneValue - 1].Field<double>(field)-xf;
            }
            else
            {
                // when comparing items in the middle...
                int nextGeneValue = Genes.ElementAt(indexAt -1); //get second item

                //if not junk...
                if (geneValue != -1 && nextGeneValue != -1)
                {
               
                    difference = values[geneValue - 1].Field<double>(field); //value at index
                    difference -= values[nextGeneValue - 1].Field<double>(field); //value at next
                }
                
            }
            
        //    }

            return difference;
        }

        public static string SetStrings(IList<int> Genes)
        {
            // (IList<double> m_values, IList<double> m_weights, IList<double> m_volumes)
            //  IList<Gene> genes = Genes;

            string text = string.Empty;
            for (int i = 0; i < Genes.Count; i++)
            {
                int index = Genes.ElementAt(i);
                //  int index = int.Parse(g.Value.ToString());
                //si está presente, entonces sumo el valor y el peso al contenedor
                if (index != -1)
                {
                    text += (index).ToString();
                }
                else
                {
                    text += "*";
                }
                text += "  ";
            }

            return text;
        }

        public static string DecodeStrings(IList<int> Genes, DataRow[] values, string field)
        {
            string text = string.Empty;

            string ask = "*";
            string space = "  ";

            for (int i = 0; i < Genes.Count; i++)
            {
                int index = Genes[i];
                //si está presente, entonces sumo el valor y el peso al contenedor
                if (index != -1)
                {
                    text += values[index - 1].Field<double>(field).ToString();
                }
                else
                {
                    text += ask;
                }
                text += space;
            }

            return text;
        }
    }
}