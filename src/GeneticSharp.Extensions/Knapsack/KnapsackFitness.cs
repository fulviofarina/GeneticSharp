using System;
using GeneticSharp.Domain.Chromosomes;
using GeneticSharp.Domain.Fitnesses;

namespace GeneticSharp.Extensions.Knapsack
{
    /// <summary>
    /// Ghostwriter fitness.
    /// </summary>
    public class KnapsackFitness : IFitness
    {
        public Func<KnapsackChromosome, double> FitnessFuncToPass { get; set; }

        /// <summary>
        /// Performs the evaluation against the specified chromosome.
        /// </summary>
        /// <param name="chromosome">The chromosome to be evaluated.</param>
        /// <returns>The fitness of the chromosome.</returns>
        public double Evaluate(IChromosome chromosome)
        {
            KnapsackChromosome c = chromosome as KnapsackChromosome;

            return FitnessFuncToPass(c);
        }
    }
}