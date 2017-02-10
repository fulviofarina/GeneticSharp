using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace GADB
{
    public static class Aid
    {

       


        public static double SetBasic(IList<int> Genes, DataRow[] values, string field)
        {
            double TotalValue = 0;

            for (int i = 0; i < Genes.Count; i++)
            {
                int index = Genes.ElementAt(i);
                //  int index = int.Parse(g.Value.ToString());
                //si está presente, entonces sumo el valor y el peso al contenedor
                if (index != -1)
                {
                    TotalValue += values[index-1].Field<double>(field);
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
                    text += values[index-1].Field<double>(field).ToString();
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