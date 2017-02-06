using System;
using System.Collections.Generic;
using System.ComponentModel;
using GADB;
using GeneticSharp.Domain;
using GeneticSharp.Domain.Chromosomes;
using GeneticSharp.Domain.Fitnesses;
using System.Data;
using System.Linq;

namespace GADB
{
    [DisplayName("Knapsack")]
    public class KnapsackSampleController : SampleControllerBase
    {
        private GADataSet.KnapSolutionsDataTable m_solutions;

        private List<double> m_values;
        private List<double> m_weights;
        private List<double> m_volumes;

        private int SIZE = 6;


        private double PESO_MAX = 10; //en kilos
        private double TARIFA = 10; //10 bolos
        private double VOL_MAX = 20;
        private  double NORMA;

        public void FillRows(int GAID)
        {
           // m_solutions.Clear();

            for (int i = 0; i < Chromosomes.Count; i++)
            {
                GADataSet.KnapSolutionsRow r = this.m_solutions.NewKnapSolutionsRow();
                IChromosome c = Chromosomes[i];
                FillRow(ref r, ref c, GAID);

                this.m_solutions.AddKnapSolutionsRow(r);
            }

            Chromosomes.Clear();
        }

        public void FillRow(ref GADataSet.KnapSolutionsRow r ,ref IChromosome c, int GAID)
        {
           

            r.Knap(ref c);

            r.TotalValue = Aid.SetBasic(r.GenesAsInts, m_values); //first
            r.TotalWeight = Aid.SetBasic(r.GenesAsInts, m_weights); //first
            r.TotalVolume = Aid.SetBasic(r.GenesAsInts, m_volumes); //first

            r.FindFitness(PESO_MAX, VOL_MAX, TARIFA,NORMA);

            r.Genotype = Aid.SetStrings(r.GenesAsInts);

            r.ValueString = Aid.DecodeStrings<double>(r.GenesAsInts, m_values);
            r.WeightString = Aid.DecodeStrings<double>(r.GenesAsInts, m_weights);
            r.VolumeString = Aid.DecodeStrings<double>(r.GenesAsInts, m_volumes);


            r.GAID = GAID;
        }

        // //// / / / / / //////// //////////////////////////// AQUI TEMPLATE


     
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dt"></param>
        public KnapsackSampleController(ref GADataSet.KnapSolutionsDataTable dataset, ref GADataSet.ProblemsRow p, int size)
        {


            if (p == null) throw new Exception("No problem ID given");

            if (dataset == null) throw new Exception("No Solutions DataTable given");

            m_values = new List<double>();
            m_weights = new List<double>();
            m_volumes = new List<double>();

            //fill arrays of values, wieghts and volumes
            List<GADataSet.KnapDataRow> list =  p.GetKnapDataRows().ToList();
            m_values = list.Select(o => o.Value).ToList();
            m_weights = list.Select(o => o.Weight).ToList();
            m_volumes = list.Select(o => o.Volume).ToList();

            m_solutions = dataset; //link to solutions table

            //determine norm to normalize on fitness
            NORMA = m_values.Max() * m_values.Count;
            //NORMA *= m_volumes.Max() * m_volumes.Count;



            //DETERMINE CONDITIONS from PROBLEM ID
           GADataSet.KnapConditionsRow conditions  =p.GetKnapConditionsRows().FirstOrDefault();

            if (conditions != null)
            {
                PESO_MAX = conditions.TotalWeight;
                VOL_MAX = conditions.TotalVolume;
                TARIFA = conditions.Fine;
            }
            else throw new Exception("No conditions given");


            SIZE = size;

        }

        public override IFitness CreateFitness()
        {
            var f = new AFitness();


            Func<IChromosome, double> fitnessEval = c =>
             {

                 GADataSet.KnapSolutionsDataTable dt = new GADataSet.KnapSolutionsDataTable();
                 GADataSet.KnapSolutionsRow nap = dt.NewKnapSolutionsRow();


                 nap.Knap(ref c);

                nap.TotalValue = Aid.SetBasic(nap.GenesAsInts, m_values); //first
                nap.TotalWeight = Aid.SetBasic(nap.GenesAsInts, m_weights); //first
                nap.TotalVolume = Aid.SetBasic(nap.GenesAsInts, m_volumes); //first

                

                nap.FindFitness(PESO_MAX, VOL_MAX, TARIFA, NORMA);//find fitness

                double fit = nap.Fitness;

                 nap = null;
                 dt.Dispose();
                 dt = null;

                 return fit;

             };


            f.FitnessFuncToPass = fitnessEval; //link to internal method

            return f;
        }

        public override IChromosome CreateChromosome()
        {
            return new AChromosome(SIZE, m_values.Count);
        }
    }
}