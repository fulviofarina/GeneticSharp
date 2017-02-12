using System;
using System.Collections.Generic;
using System.Linq;
using GeneticSharp.Domain;
using GeneticSharp.Domain.Chromosomes;

namespace GADB
{
    partial class GADataSet
    {
        partial class StringsDataTable
        {
        }
        partial class StringsRow
        {
            public void Initialize()
            {
                TotalC = 0;
                TotalA = 0;
                TotalB = 0;
                AString = string.Empty;
                BString = string.Empty;
                CString = string.Empty;
                Fine = 0; //initialize the FINE
                Okays = string.Empty; //initialize the isOKStringArray //for info
            }
        }
        public partial class GARow
        {
            public void FillGADataToSolution(ref SolutionsRow r)
            {
                r.GAID = ID;
                r.TimeSpan = TimeStamp;
                r.Generations = GenerationCurrent;
            }
            public void Initialize(ref GeneticAlgorithm ga)
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

        partial class SolutionsDataTable
        {
        }

        partial class SolutionsRow
        {
            private GADataSet.DataDataTable dataAxuliar = new GADataSet.DataDataTable();
            public void Initialize(ref IChromosome c)
            {
                chromosome = c;
                Fitness = 0;
                Frequency = 1;
                DateTime = DateTime.Now;
            }

            private IChromosome chromosome = null;

            public IList<Gene> Genes
            {
                get { return chromosome.GetGenes(); }
            }

            IList<int> genesAsInts;
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
                set
                {
                    genesAsInts = value;
                }
            }

            public DataDataTable DataAxuliar
            {
                get
                {
                    return dataAxuliar;
                }

                set
                {
                    dataAxuliar = value;
                }
            }
        }

        partial class DataDataTable
        {
        }
    }
}