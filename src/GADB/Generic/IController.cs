using System;
using GeneticSharp.Domain;
using GeneticSharp.Domain.Chromosomes;
using GeneticSharp.Domain.Fitnesses;

namespace GADB
{
    public interface IController
    {
         GADataSet.GARow GARow
        {
            get;

            set;
        }
        void SetControllerFor(ref GADataSet.ProblemsRow p, int size);
      
        Action CallBack { get; set; }
        Action FinalCallBack { get; set; }
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

        void ConfigGA();

        void PostScript(bool bkgWork);
    }
}