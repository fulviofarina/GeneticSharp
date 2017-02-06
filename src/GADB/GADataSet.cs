﻿using System;
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
                ChromosomeLenght = c.Length;
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

            /// <summary>
            /// Algo for finding fitness
            /// </summary>
            /// <param name="PESO_MAX"></param>
            /// <param name="VOL_MAX"></param>
            /// <param name="TARIFA"></param>
            /// <returns></returns>
            public void FindFitness(double PESO_MAX, double VOL_MAX, double TARIFA, double norm)
            {
                if (TotalWeight <= PESO_MAX && TotalVolume <= VOL_MAX)
                {
                    Fine = 0;
                }
                else
                {
                    Fine = 0;
                    if (TotalWeight > PESO_MAX)
                    {
                        Fine = TotalWeight - PESO_MAX; //excess weight
                        
                    }
                    if (TotalVolume > VOL_MAX)
                    {
                        Fine += (TotalVolume - VOL_MAX)*3; //excess volume
                    }
                    Fine *= TARIFA; //aply TARIF
                }
                //ahora calculo el fitness, o valor neto, en función del ValorTotal y la Penalizacion
                Fitness = TotalValue;
                Fitness /= norm * (1 + Fine); //max vol, max value * (1+fine)
            }
        }

        partial class KnapDataDataTable
        {
        }
    }
}