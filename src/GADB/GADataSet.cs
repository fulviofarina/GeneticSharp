using System;
using System.Collections.Generic;
using System.Linq;
using GeneticSharp.Domain;
using GeneticSharp.Domain.Chromosomes;

namespace GADB
{
    partial class GADataSet
    {
        public partial class GARow
        {
            public void Fill(ref GeneticAlgorithm ga)
            {

                double? fitnessVal = ga.Population.BestChromosome.Fitness;

                if (fitnessVal == null) fitnessVal = 0;

                Fitness = (double)fitnessVal;

                //TimeSpan te = ga.TimeEvolving;
                TimeStamp = ga.TimeEvolving.TotalSeconds;


                CrossProbability = ga.CrossoverProbability;
                CrossChromeMinLenght = ga.Crossover.MinChromosomeLength;

                Termination = ga.Termination.GetType().Name;
                GenerationCurrent = ga.Population.CurrentGeneration.Number;
                PopMax = ga.Population.MaxSize;
                PopMin = ga.Population.MinSize;
                GenerationStrategy = ga.Population.GenerationStrategy.ToString();
                GenerationTotal = ga.Population.GenerationsNumber;
                MutationProb = ga.MutationProbability;

                CrossParents = ga.Crossover.ParentsNumber;
                CrossChildren = ga.Crossover.ChildrenNumber;
            }
        }

        partial class KnapSolutionsDataTable
        {
        }

        partial class KnapSolutionsRow
        {
            public void Knap(ref IChromosome c)
            {
                chromosome = c;
                TotalValue = 0;
                TotalVolume = 0;
                TotalWeight = 0;
                Fine = 0;
                Fitness = 0;
                Frequency = 1;
                //  ChromosomeLength = c.Length;
                DateTime = DateTime.Now;
            }

            private IChromosome chromosome = null;

            public IList<Gene> Genes
            {
                get { return chromosome.GetGenes(); }
            }

            public IList<int> GenesAsInts
            {
                get
                {
                    Func<Gene, int> selector = o =>
                {
                    return int.Parse(o.Value.ToString());
                };

                    return Genes.Select(selector).ToList();
                }
            }


        }

        partial class KnapDataDataTable
        {
        }
    }
}