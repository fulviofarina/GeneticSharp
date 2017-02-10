using System;
using System.Collections.Generic;
using System.Data;
using GeneticSharp.Domain;
using GeneticSharp.Domain.Chromosomes;
using GeneticSharp.Domain.Crossovers;
using GeneticSharp.Domain.Fitnesses;
using GeneticSharp.Domain.Mutations;
using GeneticSharp.Domain.Populations;
using GeneticSharp.Domain.Selections;
using GeneticSharp.Domain.Terminations;
using GeneticSharp.Infrastructure.Threading;

namespace GADB
{
    public abstract class ControllerBase : IController
    {
        private GADataSet.GARow gARow = null;

        public GADataSet.GARow GARow
        {
            get
            {
                return gARow;
            }

            set
            {
                gARow = value;
            }
        }

        private Action callBack = null;
        public Action CallBack
        {
            get
            {
                return callBack;
            }

            set
            {
                callBack = value;
            }
        }
        private Action finalCallBack = null;
        public Action FinalCallBack
        {
            get
            {
                return finalCallBack;
            }

            set
            {
                finalCallBack = value;
            }
        }
        public int PROBLEMID = 0; //important!!!
        private DataRow[] problemData = null;
        private string[] variableNames;

        public void FillStrings<T>(ref GADataSet.SolutionsRow r, ref T s)
        {
            r.Genotype = Aid.SetStrings(r.GenesAsInts);

            for (int i = 0; i < variableNames.Length; i++)
            {
                string dummy = Aid.DecodeStrings(r.GenesAsInts, problemData, variableNames[i]);
                string field = variableNames[i] + "String";
                DataRow row = s as DataRow;
                row.SetField(field, dummy); //first
            }
        }
        public void FillGAData(ref GADataSet.SolutionsRow r)
        {
            r.GAID = gARow.ID;
            r.TimeSpan = gARow.TimeStamp;
            r.Generations = gARow.GenerationCurrent;
        }

        private Probabilities probabilities;

        /// <summary>
        /// Gets the Genetic Algorithm.
        /// </summary>
        /// <value>The Genetic Algorithm.</value>
        ///
        public GeneticAlgorithm GA { get; set; }

        public Probabilities Probabilities
        {
            get
            {
                return probabilities;
            }

            set
            {
                probabilities = value;
            }
        }

        public DataRow[] ProblemData
        {
            get
            {
                return problemData;
            }

            set
            {
                problemData = value;
            }
        }

        public string[] VariableNames
        {
            get
            {
                return variableNames;
            }

            set
            {
                variableNames = value;
            }
        }

        public HashSet<string> HashListOfGenotypes
        {
            get
            {
                return hashListOfGenotypes;
            }

            set
            {
                hashListOfGenotypes = value;
            }
        }

        public List<GADataSet.SolutionsRow> ListOfSolutions
        {
            get
            {
                return listOfSolutions;
            }

            set
            {
                listOfSolutions = value;
            }
        }

        private HashSet<string> hashListOfGenotypes = null;
        private List<GADataSet.SolutionsRow> listOfSolutions = null;

        public virtual void DoStatistics<T>(object problema)
        {
        }

        /// <summary>
        /// Creates the chromosome.
        /// </summary>
        /// <returns>
        /// The chromosome.
        /// </returns>
        public abstract IChromosome CreateChromosome();

        /// <summary>
        /// Creates the fitness.
        /// </summary>
        /// <returns>
        /// The fitness.
        /// </returns>
        public abstract IFitness CreateFitness();

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        public virtual void Initialize()
        {
        }

        /// <summary>
        /// Configure the Genetic Algorithm.
        /// </summary>
        /// <param name="ga">The genetic algorithm.</param>

        public virtual void ConfigGA()
        {
            Initialize(); //IMPORTANT

            ISelection selection = new EliteSelection();
            ICrossover crossover = new UniformCrossover();
            IMutation mutation = new UniformMutation();

            IChromosome adam = CreateChromosome();

            IPopulation population = new Population(probabilities.minPop, probabilities.maxPop, adam);
            population.GenerationStrategy = new PerformanceGenerationStrategy();

            IFitness fitness = CreateFitness();
            GeneticAlgorithm ga;
            ga = new GeneticAlgorithm(population, fitness, selection, crossover, mutation);
            ga.Termination = new FitnessStagnationTermination(probabilities.maxPop);

            ga.MutationProbability = probabilities.mutationProb;
            ga.CrossoverProbability = probabilities.crossProb;

            ga.TaskExecutor = new SmartThreadPoolTaskExecutor()
            {
                MinThreads = 10,
                MaxThreads = 50
            };

            GA = ga;
        }

        public virtual void PostScript()
        {
        }
    }
}