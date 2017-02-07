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
        private  GADataSet.KnapConditionsRow[] conditions = null;
        private int SIZE = 6;
     
        private  double NORMA;

        private int PROBLEMID = 0; //important!!!

       
        private void findFines(ref GADataSet.KnapSolutionsRow r,  ref GADataSet.KnapConditionsRow conditions)
        {

                

            bool weightOk = (r.TotalWeight <= conditions.MaxWeight);
            weightOk = weightOk && ( r.TotalWeight >= conditions.MinWeight);

            bool volOk = (r.TotalVolume <= conditions.MaxVolume);
            volOk = volOk && (r.TotalVolume >= conditions.MinVolume);

            bool valueOk = (r.TotalValue <= conditions.MaxValue);
            valueOk = valueOk && (r.TotalValue >= conditions.MinValue);

            //FIRST LETER T OR F
            r.Okays += weightOk.ToString()[0] + " ";
            r.Okays += volOk.ToString()[0] + " ";
            r.Okays +=  valueOk.ToString()[0] + " * ";


            if (weightOk && volOk && valueOk)
            {
                r.Fine += 0;
            }
            else
            {
              //  r.Fine += 0;
                if (!weightOk)
                {
                    r.Fine += (r.TotalWeight - conditions.MaxWeight) * conditions.WeightFine; //excess weight
                
                }
                if (!volOk)
                {
                    r.Fine += (r.TotalVolume - conditions.MaxVolume) * conditions.VolumeFine; //excess volume NEVER!
                }
                //this does not matter since ValueFine can be 0
                if (!valueOk)
                {
                    r.Fine += (r.TotalValue - conditions.MaxValue) * conditions.ValueFine; //excess volume NEVER!
                }

            }
           
         
        }


        /// <summary>
        /// BASIC CALCULATION NECESSARY FOR FITNESS
        /// </summary>
        /// <param name="r"></param>
        /// <param name="c"></param>
        public void FillBasic(ref GADataSet.KnapSolutionsRow r ,ref IChromosome c)
        {
            r.Knap(ref c);

            r.TotalValue = Aid.SetBasic(r.GenesAsInts, m_values); //first
            r.TotalWeight = Aid.SetBasic(r.GenesAsInts, m_weights); //first
            r.TotalVolume = Aid.SetBasic(r.GenesAsInts, m_volumes); //first

            r.ProblemID = PROBLEMID;

            r.Fine = 0; //initialize the FINE
            r.Okays = string.Empty;
            for (int i = 0; i< conditions.Length; i++)
            {
                GADataSet.KnapConditionsRow cond = conditions[i];
              
                findFines(ref r, ref cond); //
                r.Fitness = r.TotalValue;
                r.Fitness /= NORMA * (1 + r.Fine); //max vol, max value * (1+fine)
            }


        }

        /// <summary>
        /// POST CALCULATION TO DECODE
        /// </summary>
        /// <param name="r"></param>
        public void FillStrings(ref GADataSet.KnapSolutionsRow r)
        {
            r.Genotype = Aid.SetStrings(r.GenesAsInts);

            r.ValueString = Aid.DecodeStrings<double>(r.GenesAsInts, m_values);
            r.WeightString = Aid.DecodeStrings<double>(r.GenesAsInts, m_weights);
            r.VolumeString = Aid.DecodeStrings<double>(r.GenesAsInts, m_volumes);
        }


        public void FillGAData(ref GADataSet.KnapSolutionsRow r,  ref GADataSet.GARow ga)
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


            if (p == null) throw new Exception("No Problem ID given");
            //DETERMINE CONDITIONS from PROBLEM ID
            conditions = p.GetKnapConditionsRows();
            if (conditions == null )
            {
                throw new Exception("No Problem Conditions given");
            }


            m_values = new List<double>();
            m_weights = new List<double>();
            m_volumes = new List<double>();

            //fill arrays of values, wieghts and volumes
            List<GADataSet.KnapDataRow> list =  p.GetKnapDataRows().ToList();

            if (list.Count == 0)
            {
                throw new Exception("No Problem Variables and Values given");
            }
            m_values = list.Select(o => o.Value).ToList();
            m_weights = list.Select(o => o.Weight).ToList();
            m_volumes = list.Select(o => o.Volume).ToList();

           

            //determine norm to normalize on fitness
            NORMA = m_values.Max() * m_values.Count;

            SIZE = size;

            PROBLEMID = p.ProblemID;

        }

        public override IFitness CreateFitness()
        {
            var f = new AFitness();


            Func<IChromosome, double> fitnessEval = c =>
             {

                 GADataSet.KnapSolutionsDataTable dt = new GADataSet.KnapSolutionsDataTable();
                 GADataSet.KnapSolutionsRow nap = dt.NewKnapSolutionsRow();


                 FillBasic(ref nap, ref c); //basic calculation

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