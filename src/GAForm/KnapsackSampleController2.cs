using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using GeneticSharp.Domain;
using GeneticSharp.Domain.Chromosomes;
using GeneticSharp.Domain.Fitnesses;
using GeneticSharp.Extensions.Knapsack;
using GeneticSharp.Infrastructure.Threading;
using GADB;
using System;

namespace GAForm
{
  
    [DisplayName("Knapsack2")]
    public class KnapsackSampleController2 : SampleControllerBase
    {
     

        private GADataSet.KnapSolutionsDataTable m_solutions;

        private List<double> m_values;
        private List<double> m_weights;
        private List<double> m_volumes;

        private int SIZE = 6;
        private double PESO_MAX = 10; //en kilos
        private double TARIFA = 10; //10 bolos
        private double VOL_MAX = 20;

        public IList<GADataSet.KnapSolutionsRow> Rows;

        /// <summary>
        /// Function to PASS to Fitness Evaluation
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        private double GetFitness(IChromosome c)
        {
            GADataSet.KnapSolutionsRow nap = m_solutions.NewKnapSolutionsRow();

            nap.Knap(ref c);


        

            nap.TotalValue = Aid.SetBasic(nap.GenesAsInts, m_values); //first
            nap.TotalWeight = Aid.SetBasic(nap.GenesAsInts, m_weights); //first
            nap.TotalVolume = Aid.SetBasic(nap.GenesAsInts, m_volumes); //first

            nap.FindFitness(PESO_MAX, VOL_MAX, TARIFA);//find fitness

            double fit = nap.Fitness;

            nap = null;

            return fit;
        }

        public void FillRows()
        {
            m_solutions.Clear();

            for (int i = 0; i < Chromosomes.Count; i++)
            {
                GADataSet.KnapSolutionsRow r = this.m_solutions.NewKnapSolutionsRow();
                IChromosome c = Chromosomes[i];
                FillRow(ref r, ref c);

                this.m_solutions.AddKnapSolutionsRow(r);
            }

            Chromosomes.Clear();
        }

        public void FillRow(ref GADataSet.KnapSolutionsRow r, ref IChromosome c)
        {
            r.Knap(ref c);

            r.TotalValue = Aid.SetBasic(r.GenesAsInts, m_values); //first
            r.TotalWeight = Aid.SetBasic(r.GenesAsInts, m_weights); //first
            r.TotalVolume = Aid.SetBasic(r.GenesAsInts, m_volumes); //first

            r.FindFitness(PESO_MAX, VOL_MAX, TARIFA);

            r.Genotype = Aid.SetStrings(r.GenesAsInts);

            r.ValueString = Aid.DecodeStrings<double>(r.GenesAsInts, m_values);
            r.WeightString = Aid.DecodeStrings<double>(r.GenesAsInts, m_weights);
            r.VolumeString = Aid.DecodeStrings<double>(r.GenesAsInts, m_volumes);
          
        }

        public KnapsackSampleController2(ref GADataSet dt)
        {
            m_values = new List<double>();
            m_weights = new List<double>();
            m_volumes = new List<double>();

            double[] pesos = { 1, 1, 1, 2, 2, 4 };
            double[] values = { 4, 4, 5, 10, 20, 30 };
            double[] volumes = { 2, 2, 3, 3, 8, 8 };

            m_values.AddRange(values);
            m_weights.AddRange(pesos);
            m_volumes.AddRange(volumes);

            m_solutions = dt.KnapSolutions;

          
        }



       

        public override IFitness CreateFitness()
        {
            var f = new KnapsackFitness();

            f.FitnessFuncToPass = GetFitness; //link to internal method

            return f;
        }

        public override IChromosome CreateChromosome()
        {
            return new KnapsackChromosome(SIZE, m_values.Count);
        }
    }
}