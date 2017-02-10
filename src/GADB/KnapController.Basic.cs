using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using GeneticSharp.Domain;
using GeneticSharp.Domain.Chromosomes;
using GeneticSharp.Domain.Fitnesses;

namespace GADB
{
    [DisplayName("Knapsack")]
    public partial class KnapController : ControllerBase
    {
      

        /// <summary>
        /// NATURAL FUNCTION COMPULSORY
        /// </summary>
        /// <returns></returns>
        public override IFitness CreateFitness()
        {
            AFitness f = new AFitness();

            f.FitnessFuncToPass = c =>
           {
               GADataSet.KnapSolutionsDataTable dt = new GADataSet.KnapSolutionsDataTable();
               GADataSet.KnapSolutionsRow nap = dt.NewKnapSolutionsRow();
               GADataSet.KnapStringsDataTable nstrings = new GADataSet.KnapStringsDataTable();
               GADataSet.KnapStringsRow n = nstrings.NewKnapStringsRow();


               fillBasic(ref nap, ref n, ref c); //basic calculation

                double fit = nap.Fitness;

               nap = null;
               n = null;
               nstrings.Dispose();
               nstrings = null;
               dt.Dispose();
               dt = null;

               return fit;
           };

            return f;
        }

        /// <summary>
        /// NATURAL FUNCTION, COMPULSORY
        /// </summary>
        /// <returns></returns>
        public override IChromosome CreateChromosome()
        {
            AChromosome c = new AChromosome(SIZE, problemData.Length);
            return c;
        }
    }
}