﻿using System;
using System.Collections.Generic;
using System.Linq;
using GeneticSharp.Domain;
using GeneticSharp.Domain.Chromosomes;

namespace GADB
{
    partial class GADataSet
    {


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
                          //  Okays = string.Empty; //initialize the isOKStringArray //for info
            }
        }

        public partial class GARow
        {
            public void AverageGA(ref IEnumerable<GADataSet.GARow> subs)
            {
                this.GenerationCurrent = Convert.ToInt32(subs.Average(o => o.GenerationCurrent));
                this.GenerationTotal = Convert.ToInt32(subs.Sum(o => o.GenerationTotal));
                this.MutationProb = subs.Average(o => o.MutationProb);
                this.CrossProbability = subs.Average(o => o.CrossProbability);
                this.TimeStamp = subs.Average(o => o.TimeStamp);
            }

            public void FillGADataToSolution(ref SolutionsRow r)
            {
                r.GAID = ID;
                r.TimeSpan = TimeStamp;
                r.Generations = GenerationCurrent;
            }

            public void Update(ref GeneticAlgorithm ga)
            {
                double? fitnessVal = ga.Population.BestChromosome.Fitness;

                if (fitnessVal == null) fitnessVal = 0;

                Fitness = (double)fitnessVal;

                //TimeSpan te = ga.TimeEvolving;
                TimeStamp = ga.TimeEvolving.TotalSeconds;

                GenerationCurrent = ga.Population.CurrentGeneration.Number;
                GenerationTotal = ga.Population.GenerationsNumber;


            }
            public void ConfigTypes(ref Configuration config)
            {

                this.TermID = config.TerminationID;
                this.MutaID = config.MutationID;
                this.CrossID = config.CrossoverID;
                this.SelectID = config.SelectionID;
                this.ReinsID = config.ReinsertionID;


            }
            public void ConfigTypesNames(ref GeneticAlgorithm ga)
            {

                Termination = ga.Termination.GetType().Name;


                string aux = ga.Population.GenerationStrategy.ToString();
                int lastPoint = aux.LastIndexOf('.');
                GenerationStrategy = aux.Substring(lastPoint+1);

                aux = ga.Mutation.ToString();
                lastPoint = aux.LastIndexOf('.');
                Mutation = aux.Substring(lastPoint+1);

                aux = ga.Selection.ToString();
                lastPoint = aux.LastIndexOf('.');
                Selection = aux.Substring(lastPoint+1);
                if (ga.Reinsertion != null)
                {
                    aux = ga.Reinsertion.ToString();
                    lastPoint = aux.LastIndexOf('.');
                    Reinsertion = aux.Substring(lastPoint+1);
                }
                else Reinsertion = string.Empty;
                aux = ga.Crossover.ToString();
                lastPoint = aux.LastIndexOf('.');
                Crossover = aux.Substring(lastPoint+1);

            }
            /// <summary>
            ///  mejorar esto para no tener que pasar los nombres
            ///  si los ids que uso coinciden usar la funciona anterior
            /// </summary>
            /// <param name="ga"></param>
            public void Initialize(ref GeneticAlgorithm ga)
            {
               
                Fitness = 0;

                //TimeSpan te = ga.TimeEvolving;
                TimeStamp =0;

                CrossProbability = ga.CrossoverProbability;
                CrossChromeMinLenght = ga.Crossover.MinChromosomeLength;

             
              
                PopMax = ga.Population.MaxSize;
                PopMin = ga.Population.MinSize;
           
                MutationProb = ga.MutationProbability;

                CrossParents = ga.Crossover.ParentsNumber;
                CrossChildren = ga.Crossover.ChildrenNumber;

            }
        }


        partial class SolutionsRow
        {
            public bool ShouldDelete = false;

            private GADataSet.DataDataTable dataAxuliar;// = new GADataSet.DataDataTable();

            public void Initialize(Gene[] genes)
            {
                TimeSpan = 0;
                Generations = 0;
                Genotype = string.Empty;
                Counter = 1;
                Fitness = 0;
                Frequency = 1;
                DateTime = DateTime.Now;
                ShouldDelete = false;
                dataAxuliar = new GADataSet.DataDataTable();
              //  _genes = null;
                _genes = genes;
            }

          
            public IList<int> GenesAsInts
            {
                get
                {
                    Func<Gene, int> selector = o =>
                    {
                        return int.Parse(o.Value.ToString());
                    };

                    return _genes.Select(selector).ToList();
                }
            }

            //  IList<int> genesAsInts;
            public IList<double> GenesAsDoubles
            {
                get
                {
                    Func<Gene, double> selector = o =>
                    {
                        return double.Parse(o.Value.ToString());
                    };

                    return _genes.Select(selector).ToList();
                }
            }

            private Gene[] _genes;

            public DataDataTable DataAxuliar
            {
                get
                {
                    return dataAxuliar;
                }

              
            }

            public Gene[] Genes
            {
                get
                {
                    return _genes;
                }
            }
        }

    }
}