using System;
using System.Collections.Generic;
using System.ComponentModel;

using GeneticSharp.Domain;
using GeneticSharp.Domain.Chromosomes;
using GeneticSharp.Domain.Fitnesses;
using GeneticSharp.Extensions.Knapsack;
using GeneticSharp.Infrastructure.Threading;

namespace GeneticSharp.Runner.ConsoleApp.Samples
{
    [DisplayName("Knapsack")]
    public class KnapsackSampleController : SampleControllerBase
    {

       


        private List<double> m_values;
        private List<double> m_weights;
        private List<double> m_volumes;

        private int SIZE = 8;
        private double PESO_MAX = 10; //en kilos
        private double TARIFA = 10; //10 bolos
        private double VOL_MAX = 20;


       

        /// <summary>
        /// Function to PASS to Fitness Evaluation
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        private double GetFitness(IChromosome c)
        {
            Knap nap = new Knap(c); //create object

            nap.SetBasic(m_values, m_weights, m_volumes); //first

            nap.FindFitness(PESO_MAX, VOL_MAX, TARIFA);//find fitness

            return nap.Fitness;
        }

        public override void Draw(IChromosome bestChromosome)
        {


            Knap nap = new Knap(bestChromosome);

            nap.SetStrings(m_values, m_weights, m_volumes);
            nap.PrintStrings(); //print decodification of genes

            nap.SetBasic(m_values, m_weights, m_volumes); //set final values

            nap.FindFitness(PESO_MAX, VOL_MAX, TARIFA);

            nap.PrintBasic(); //print basic total values
        }

        public KnapsackSampleController()
        {
            m_values = new List<double>();
            m_weights = new List<double>();
            m_volumes = new List<double>();

            double[] pesos = { 1, 1, 1, 2, 2, 4 };
            double[] values = { 4, 4, 5, 10, 20, 30 };
            double[] volumes = { 2, 2, 3, 3, 8, 8 };

            m_values.AddRange(values);
            m_weights.AddRange(pesos);
            m_volumes.AddRange(volumes);

           



        }

        // // /// // // // // // //

        public override void ConfigGA(GeneticAlgorithm ga)
        {
            base.ConfigGA(ga);
            ga.TaskExecutor = new SmartThreadPoolTaskExecutor()
            {
                MinThreads = 25,
                MaxThreads = 50
            };
        }

        public override IFitness CreateFitness()
        {
            var f = new KnapsackFitness();

            f.FitnessFuncToPass = GetFitness; //link to internal method

            return f;
        }

        public override IChromosome CreateChromosome()
        {
            return new KnapsackChromosome(SIZE, m_values.Count);
        }

        // // // / / / / // / / / / // / / / //

        /// <summary>
        /// NOT USED HERE
        /// </summary>
        /// <param name="s"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        private int LevenshteinDistance(string s, string t)
        {
            // degenerate cases
            if (s == t)
            {
                return 0;
            }

            if (s.Length == 0)
            {
                return t.Length;
            }

            if (t.Length == 0)
            {
                return s.Length;
            }

            // create two work vectors of integer distances
            int[] v0 = new int[t.Length + 1];
            int[] v1 = new int[t.Length + 1];

            // initialize v0 (the previous row of distances)
            // this row is A[0][i]: edit distance for an empty s
            // the distance is just the number of characters to delete from t
            for (int i = 0; i < v0.Length; i++)
            {
                v0[i] = i;
            }

            for (int i = 0; i < s.Length; i++)
            {
                // calculate v1 (current row distances) from the previous row v0

                // first element of v1 is A[i+1][0]
                //   edit distance is delete (i+1) chars from s to match empty t
                v1[0] = i + 1;

                // use formula to fill in the rest of the row
                for (int j = 0; j < t.Length; j++)
                {
                    var cost = (s[i] == t[j]) ? 0 : 1;
                    v1[j + 1] = Math.Min(Math.Min(v1[j] + 1, v0[j + 1] + 1), v0[j] + cost);
                }

                // copy v1 (current row) to v0 (previous row) for next iteration
                for (int j = 0; j < v0.Length; j++)
                {
                    v0[j] = v1[j];
                }
            }

            return v1[t.Length];
        }
    }
}