using System;
using System.Collections.Generic;
using System.Linq;
using GeneticSharp.Domain.Chromosomes;

namespace GeneticSharp.Extensions.Knapsack
{
    public class Knap
    {
        public Knap(IChromosome c)
        {
            chromosome = c;
        }

        private IChromosome chromosome = null;

        public int ChromoLenght
        {
            get { return chromosome.Length; }
        }

        public IList<Gene> Genes
        {
            get { return chromosome.GetGenes(); }
        }

        public double Fitness = 0;      //auxiliar en el cálculo de valor o fitness de la solución
        public double ValueTotal = 0;   //valor total acumulado de esta solución
        public double WeightTotal = 0;    //peso total acumulado de esta solución
        public double Fine = 0; //valor de penalizacion si solucion no es valida
        public double VolumenTotal = 0;

        private string VolumenString = string.Empty;
        private string WeightString = string.Empty;
        private string ValueString = string.Empty;

        /// <summary>
        /// Decode Chromosome as string of values
        /// </summary>
        /// <param name="values">values to decompose the Chromosome string into</param>
        /// <returns></returns>
        public string DecodeStrings(IEnumerable<object> values)
        {
            string text = string.Empty;
            for (int i = 0; i < Genes.Count; i++)
            {
                Gene g = Genes[i];
                int index = int.Parse(g.Value.ToString());
                //si está presente, entonces sumo el valor y el peso al contenedor
                if (index != -1)
                {
                    text += values.ElementAt(index).ToString();
                }
                else
                {
                    text += "*";
                }
                text += "  ";
            }

            return text;
        }

        /// <summary>
        /// Algo for finding fitness
        /// </summary>
        /// <param name="PESO_MAX"></param>
        /// <param name="VOL_MAX"></param>
        /// <param name="TARIFA"></param>
        /// <returns></returns>
        public double FindFitness(double PESO_MAX, double VOL_MAX, double TARIFA)
        {
            if (WeightTotal <= PESO_MAX && VolumenTotal <= VOL_MAX)
            {
                Fine = 0;
            }
            else
            {
                Fine = 0;
                if (WeightTotal > PESO_MAX)
                {
                    Fine = (int)(WeightTotal - PESO_MAX);
                    Fine *= TARIFA;
                }

                if (VolumenTotal > VOL_MAX)
                {
                    double Voldeficit = VolumenTotal - VOL_MAX;
                    if (Fine == 0) Fine = 1;
                    Fine *= Voldeficit * TARIFA;
                }
            }
            //ahora calculo el fitness, o valor neto, en función del ValorTotal y la Penalizacion
            Fitness = ValueTotal / (1 + Fine);

            return Fitness;
        }

        /// <summary>
        /// Assign values for TotalWeight, TotalValue and totalVolume
        /// </summary>
        /// <param name="m_values"></param>
        /// <param name="m_weights"></param>
        /// <param name="m_volumes"></param>
        public void SetBasic(IList<double> m_values, IList<double> m_weights, IList<double> m_volumes)
        {
            for (int i = 0; i < Genes.Count; i++)
            {
                Gene g = Genes.ElementAt(i);
                int index = int.Parse(g.Value.ToString());
                //si está presente, entonces sumo el valor y el peso al contenedor
                if (index != -1)
                {
                    ValueTotal = ValueTotal + m_values[index];
                    WeightTotal = WeightTotal + m_weights[index];
                    VolumenTotal = VolumenTotal + m_volumes[index];
                }
            }
        }

        /// <summary>
        /// PRINT BASIC TOTAL VALUES FOR CHROMOSOME
        /// </summary>
        public void PrintBasic()
        {
            Console.WriteLine();
            Console.WriteLine("Value: {0}", ValueTotal);
            Console.WriteLine("Weight: {0}", WeightTotal);
            Console.WriteLine("Volumen: {0}", VolumenTotal);
            Console.WriteLine("Fine: {0}", Fine);
            Console.WriteLine("Fitness: {0}", Fitness);
        }

        /// <summary>
        /// PRINT THE CONVERSION BETWEEN GENOTYPE AND VALUES
        /// </summary>
        public void PrintStrings()
        {
            Console.WriteLine("Lenght: {0}", ChromoLenght);

            Console.WriteLine("Values:\t\t\t {0}", ValueString);
            Console.WriteLine("Weights:\t\t {0}", WeightString);
            Console.WriteLine("Volumes:\t\t {0}", VolumenString);
        }

    }
}