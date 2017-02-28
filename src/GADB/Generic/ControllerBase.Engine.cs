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

        /// <summary>
        /// Main postcript function to store best results
        /// </summary>
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
            //  if (currentSolution.Fitness <= 0.001) return;

        //    

            //define filter function by genotype
            Func<GADataSet.SolutionsRow, GADataSet.StringsRow, bool> funcion;
            funcion = Aid.FilterByGenotype(ref hashListOfGenotypes, ref listOfSolutions, ref listOfStrings);
           //execute filter function by genotype
            funcion(currentSolution, currentString);

            //the listOfSolutions contains the list of rows that need to be added
            //these rows are flagged ShouldDelete = false
            if (!currentSolution.ShouldDelete)
            {

                ds.Solutions.AddSolutionsRow(currentSolution);

                GARow.FillGADataToSolution(ref currentSolution);

                ds.Strings.AddStringsRow(currentString);
                currentString.GAID = currentSolution.GAID;
                currentString.ProblemID = currentSolution.ProblemID;
                //decode
                FillStrings(ref currentSolution, ref currentString);

              //  GNUPLOT(ref currentSolution);

            }


        }

        private static void GNUPLOT(ref GADataSet.SolutionsRow s)
        {
            string script = "set grid\n";
            script += "set title 'Trajectories'\n";
            script += "set xlabel 'X'\n";
            script += "set ylabel 'Y'\n";




            GADataSet.DataRow[] data = s.ProblemsRow.GetKnapDataRows();
            double min = data.Min(o => o.A);
            double max = data.Max(o => o.A);

            script += "set xrange[" + (min - 1) + ":" + (max + 1) + "]\n";
            min = data.Min(o => o.B);
            max = data.Max(o => o.B);
            script += "set yrange[" + (min - 1) + ":" + (max + 1) + "]\n";

            script += "set terminal gif animate delay 100\n";
            script += "set output FILENAME\n";

            //get genotype string
            string[] a = s.Genotype.Split(' ');

            //clean nulls
            a = a.Where(o => !string.IsNullOrEmpty(o)).ToArray();

            //make a data .txt file with A,B,C points
            for (int i = 0; i < a.Length; i++)
            {
                // if (string.IsNullOrEmpty(a[i])) continue;
                string aa = data.ElementAt(Convert.ToInt32(a[i]) - 1).A + "\t";
                aa += data.ElementAt(Convert.ToInt32(a[i]) - 1).B + "\t";
                aa += data.ElementAt(Convert.ToInt32(a[i]) - 1).C;
                // string fileindex = i;
                script += "plot '" + i + ".txt' using 1:2:3 with points palette pointsize 2 pointtype 5\n";
                System.IO.File.WriteAllText(i + ".txt", aa);
            }

            //make gnuplot script file
            string scriptFile = Guid.NewGuid().ToString().Substring(0, 6);
            System.IO.File.WriteAllText(scriptFile + ".gp", script);


            //execute gnuplot
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.FileName = "gnuplot";
            p.StartInfo.Arguments = "-e \"FILENAME='" + scriptFile + ".gif'\" " + scriptFile + ".gp";
            p.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            p.Start();
            p.WaitForExit();

            //add image to Chromosome
            s.Chromosome = System.IO.File.ReadAllBytes(scriptFile + ".gif");
        }
    }
}