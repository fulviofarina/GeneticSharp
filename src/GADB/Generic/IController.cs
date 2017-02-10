using System;
using GeneticSharp.Domain;
using GeneticSharp.Domain.Chromosomes;
using GeneticSharp.Domain.Fitnesses;

namespace GADB
{
    public interface IController
    {
        void DoStatistics<T>(object problema);
        Action CallBack { get; set; }
        GeneticAlgorithm GA { get; set; }

        /// <summary>
        /// Creates the fitness.
        /// </summary>
        /// <returns>The fitness.</returns>
        IFitness CreateFitness();

        /// <summary>
        /// Creates the chromosome.
        /// </summary>
        /// <returns>The chromosome.</returns>
        IChromosome CreateChromosome();

        Probabilities Probabilities { set; get; }
        /// <summary>
        /// Creates the mutation.
        /// </summary>
        /// <returns>The mutation.</returns>

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        void Initialize();

        /// <summary>
        /// Configure the Genetic Algorithm.
        /// </summary>
        /// <param name="ga">The genetic algorithm.</param>
        void ConfigGA();

        void PostScript();
    }
}