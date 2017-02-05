using System.Collections.Generic;
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
    public abstract class SampleControllerBase : ISampleController
    {
      

        public IList<IChromosome> Chromosomes;
        /// <summary>
        /// Gets the Genetic Algorithm.
        /// </summary>
        /// <value>The Genetic Algorithm.</value>
        protected GeneticAlgorithm GA { get; private set; }

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
            Chromosomes = new List<IChromosome>();
        }

        /// <summary>
        /// Configure the Genetic Algorithm.
        /// </summary>
        /// <param name="ga">The genetic algorithm.</param>
      
        public virtual void ConfigGA(ref GeneticAlgorithm ga, int minPop, int maxPop, float mutationProb, float crossProb)
        {

           

         
            Initialize(); //IMPORTANT

            ISelection selection = CreateSelection();
            ICrossover crossover = CreateCrossover();
            IMutation mutation = CreateMutation();


            IChromosome adam = CreateChromosome();

            IPopulation population = new Population(minPop, maxPop, adam);
            population.GenerationStrategy = new PerformanceGenerationStrategy();


            IFitness fitness = CreateFitness();


            ga = new GeneticAlgorithm(population, fitness, selection, crossover, mutation);
            ga.Termination = CreateTermination(maxPop);


            ga.MutationProbability = mutationProb;
            ga.CrossoverProbability = crossProb;

            ga.TaskExecutor = new SmartThreadPoolTaskExecutor()
            {
                MinThreads = 25,
                MaxThreads = 50
            };

            GA = ga;
        }


        /// <summary>
        /// Draws the sample.
        /// </summary>
        /// <param name="bestChromosome">The current best chromosome</param>
        public virtual void Add(IChromosome bestChromosome)
        {
            Chromosomes.Add(bestChromosome);
        }
        /// <summary>
        /// Draws the sample.
        /// </summary>
        /// <param name="bestChromosome">The current best chromosome</param>
        public virtual void Draw(IChromosome bestChromosome)
        {

        }
     

        /// <summary>
        /// Creates the termination.
        /// </summary>
        /// <returns>
        /// The termination.
        /// </returns>
        public virtual ITermination CreateTermination(int expectedNumber)
        {
            return new FitnessStagnationTermination(expectedNumber);
        }

        /// <summary>
        /// Creates the crossover.
        /// </summary>
        /// <returns>The crossover.</returns>
        public virtual ICrossover CreateCrossover()
        {
            return new UniformCrossover();
        }

        /// <summary>
        /// Creates the mutation.
        /// </summary>
        /// <returns>The mutation.</returns>
        public virtual IMutation CreateMutation()
        {
            return new UniformMutation(true);
        }

        /// <summary>
        /// Creates the selection.
        /// </summary>
        /// <returns>The selection.</returns>
        public virtual ISelection CreateSelection()
        {
            return new EliteSelection();
        }
    }
}