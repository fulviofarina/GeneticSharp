using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;

using GeneticSharp.Domain;
using GeneticSharp.Domain.Chromosomes;
using GeneticSharp.Domain.Fitnesses;
using GeneticSharp.Extensions.Knapsack;
using GeneticSharp.Infrastructure.Threading;
namespace GADB
{
    public static class Aid
    {
        public static double SetBasic(IList<int> Genes, IList<double> values)
        {
            double TotalValue = 0;

            for (int i = 0; i < Genes.Count; i++)
            {
                int index = Genes.ElementAt(i);
              //  int index = int.Parse(g.Value.ToString());
                //si está presente, entonces sumo el valor y el peso al contenedor
                if (index != -1)
                {
                    TotalValue += values[index];
                }
            }

            return TotalValue;
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
                    text += index.ToString();
                }
                else
                {
                    text += "*";
                }
                text += "  ";
            }

            return text;
        }

        public static string DecodeStrings<T>(IList<int> Genes, IEnumerable<T> values)
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
                    text += values.ElementAt(index).ToString();
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
