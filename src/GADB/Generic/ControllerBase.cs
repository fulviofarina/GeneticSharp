using System;
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
        public void FillGAData(ref GADataSet.KnapSolutionsRow r, ref GADataSet.GARow ga)
        {
            r.GAID = ga.ID;
            r.TimeSpan = ga.TimeStamp;
            r.Generations = ga.GenerationCurrent;
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
                MinThreads = 25,
                MaxThreads = 70
            };

            GA = ga;
        }

        public virtual void PostScript(ref object param, ref Action callback)
        {
        }
    }
}