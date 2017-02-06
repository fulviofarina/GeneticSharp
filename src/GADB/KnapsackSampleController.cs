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

        private List<double> m_values;
        private List<double> m_weights;
        private List<double> m_volumes;

        private int SIZE = 6;
        private double PESO_MAX = 10; //en kilos
        private double TARIFA = 10; //10 bolos
        private double VOL_MAX = 20;
        private  double NORMA;



        /// <summary>
        /// Algo for finding fitness
        /// </summary>
        /// <param name="PESO_MAX"></param>
        /// <param name="VOL_MAX"></param>
        /// <param name="TARIFA"></param>
        /// <returns></returns>
        public void FindFitness(ref GADataSet.KnapSolutionsRow r, double PESO_MAX, double VOL_MAX, double TARIFA, double norm)
        {

            float maxFINE = 10000000; //IN CASE EXCEEDS VOLUME, 1 MILLION PENALTY

            if (r.TotalWeight <= PESO_MAX && r.TotalVolume <= VOL_MAX)
            {
                r.Fine = 0;
            }
            else
            {
                r.Fine = 0;
                if (r.TotalWeight > PESO_MAX)
                {
                    r.Fine = r.TotalWeight - PESO_MAX; //excess weight

                }
                if (r.TotalVolume > VOL_MAX)
                {
                    r.Fine += (r.TotalVolume - VOL_MAX) * maxFINE; //excess volume NEVER!
                }
                r.Fine *= TARIFA; //aply TARIF
            }
            //ahora calculo el fitness, o valor neto, en función del ValorTotal y la Penalizacion
            r.Fitness = r.TotalValue;
            r.Fitness /= norm * (1 + r.Fine); //max vol, max value * (1+fine)
        }


        /// <summary>
        /// BASIC CALCULATION NECESSARY FOR FITNESS
        /// </summary>
        /// <param name="r"></param>
        /// <param name="c"></param>
        public void FillRow(ref GADataSet.KnapSolutionsRow r ,ref IChromosome c)
        {
            r.Knap(ref c);

            r.TotalValue = Aid.SetBasic(r.GenesAsInts, m_values); //first
            r.TotalWeight = Aid.SetBasic(r.GenesAsInts, m_weights); //first
            r.TotalVolume = Aid.SetBasic(r.GenesAsInts, m_volumes); //first

            FindFitness(ref r, PESO_MAX, VOL_MAX, TARIFA, NORMA);

         
        }

        /// <summary>
        /// POST CALCULATION TO DECODE
        /// </summary>
        /// <param name="r"></param>
        public void DecodeRow(ref GADataSet.KnapSolutionsRow r)
        {
            r.Genotype = Aid.SetStrings(r.GenesAsInts);

            r.ValueString = Aid.DecodeStrings<double>(r.GenesAsInts, m_values);
            r.WeightString = Aid.DecodeStrings<double>(r.GenesAsInts, m_weights);
            r.VolumeString = Aid.DecodeStrings<double>(r.GenesAsInts, m_volumes);
        }


        public void FillRow(ref GADataSet.KnapSolutionsRow r,  ref GADataSet.GARow ga)
        {

            r.GAID = ga.ID;
            r.TimeSpan = ga.TimeStamp;
            r.Generations = ga.GenerationCurrent;

        }

        // //// / / / / / //////// //////////////////////////// AQUI TEMPLATE



        /// <summary>
        /// INITIALIZER 
        /// </summary>
        /// <param name="dt"></param>
        public KnapsackSampleController( ref GADataSet.ProblemsRow p, int size)
        {


            if (p == null) throw new Exception("No problem ID given");

     
            m_values = new List<double>();
            m_weights = new List<double>();
            m_volumes = new List<double>();

            //fill arrays of values, wieghts and volumes
            List<GADataSet.KnapDataRow> list =  p.GetKnapDataRows().ToList();
            m_values = list.Select(o => o.Value).ToList();
            m_weights = list.Select(o => o.Weight).ToList();
            m_volumes = list.Select(o => o.Volume).ToList();

      

            //determine norm to normalize on fitness
            NORMA = m_values.Max() * m_values.Count;


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


                 FillRow(ref nap, ref c); //basic calculation

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