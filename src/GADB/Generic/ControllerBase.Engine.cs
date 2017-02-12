using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
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

    /// <summary>
    /// The generic engine, works great
    /// </summary>
    public abstract partial class ControllerBase : IController
    {


        private void workerProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            try
            {
                fillAll();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void workerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            FinalCallBack.Invoke();
        }
        /// <summary>
        /// Generic Do Work for the background worker
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void workerDoWork(object sender, DoWorkEventArgs e)
        {
            GA.GenerationRan += delegate
            {
                BackgroundWorker w = sender as BackgroundWorker;
                w.ReportProgress(0); //should I put a percentage?
            };

            GA.Start();
        }

        private void fillAll()
        {

            IChromosome bestChromosome = GA.Population.BestChromosome;


            //BASIC
            GADataSet ds = GARow.Table.DataSet as GADataSet;

            GADataSet.SolutionsRow currentSolution;
            GADataSet.StringsRow currentString;
            currentSolution = ds.Solutions.NewSolutionsRow();
            currentString = ds.Strings.NewStringsRow();

            initializeRows(ref currentSolution, ref currentString, ref bestChromosome);


            //this is the most important function to override, does the fitness calc
            FillBasic(ref currentSolution, ref currentString);

            GeneticAlgorithm ga = GA;
            //fill GA data to row
            GARow.Initialize(ref ga); //report GA stuff

            //adt solutions and decoding to dataset
            addDistinctToDataSet(ref ds, ref currentSolution, ref currentString);

            //callBack MEthod to Form or User Control
            CallBack.Invoke();

            //assign string ID... //this should be better
            currentString.SolutionID = currentSolution.ID;
        }

        /// <summary>
        /// Generic RunWorker Completed for the background worker
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
      
      
        /// <summary>
        /// Sets default values 0,0 0,0,0
        /// </summary>
        /// <param name="r"></param>
        /// <param name="s"></param>
        /// <param name="c"></param>
        private void initializeRows(ref GADataSet.SolutionsRow r, ref GADataSet.StringsRow s, ref IChromosome c)
        {
            r.Initialize( c.GetGenes());
            r.ProblemID = PROBLEMID;
            s.Initialize();

          //  c.TagArray = new object[] { r.ItemArray, s.ItemArray }; //save the arrays of rows to later fill in
            //speeds up everything!
        }


        /// <summary>
        /// adds the rows to the given dataset
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="currentSolution"></param>
        /// <param name="currentString"></param>
        private void addDistinctToDataSet(ref GADataSet ds, ref GADataSet.SolutionsRow currentSolution, ref GADataSet.StringsRow currentString)
        {

          
            //better this
            if (currentSolution.Fitness <= 0.001) return;

          

            currentSolution.Genotype = Aid.SetStrings(currentSolution.GenesAsInts);

            //IF NOT PRESENT IN THE LIST IS A NEW CHROMOSOME
            string genotype = currentSolution.Genotype;
            if (hashListOfGenotypes.Add(genotype)) //add to hashShet
            {
              
                ds.Solutions.AddSolutionsRow(currentSolution);
                GARow.FillGADataToSolution(ref currentSolution);
                ds.Strings.AddStringsRow(currentString);
                currentString.GAID = currentSolution.GAID;
                currentString.ProblemID = currentSolution.ProblemID;
                //decode
                FillStrings(ref currentSolution, ref currentString);

                listOfSolutions.Add(currentSolution);//add to indexed list
            }
            else
            {
                int i = listOfSolutions.FindIndex(o => o.Genotype.Equals(genotype));
                listOfSolutions[i].Frequency++;

            }
        }



    }
}