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
    public abstract partial class ControllerBase : IController
    {

        public abstract void FillBasic(ref GADataSet.SolutionsRow r, ref GADataSet.StringsRow s, ref IChromosome c);
        /// <summary>
        /// 
        /// Fills the Strings Table based on the variableNames
        /// </summary>
        /// <typeparam name="T">DataRow of StringsTable</typeparam>
        /// <param name="r">Solutions row</param>
        /// <param name="s">DataRow of stringsTable, e.g. KnapStrings</param>
        public virtual void FillStrings<T>(ref GADataSet.SolutionsRow r, ref T s)
        {
            r.Genotype = Aid.SetStrings(r.GenesAsInts);

            for (int i = 0; i < variableNames.Length; i++)
            {
                string dummy = Aid.DecodeStrings(r.GenesAsInts, problemData, variableNames[i]);
                string field = variableNames[i] + "String";
                DataRow row = s as DataRow;
                row.SetField(field, dummy); //first
            }
        }

        public void FillGAData(ref GADataSet.SolutionsRow r)
        {
            r.GAID = gARow.ID;
            r.TimeSpan = gARow.TimeStamp;
            r.Generations = gARow.GenerationCurrent;
        }

        public void SetControllerFor(ref GADataSet.ProblemsRow p, int size)
        {
            if (p == null) throw new Exception("No Problem ID given");
            //DETERMINE CONDITIONS from PROBLEM ID
            conditions = p.GetConditionsRows();
            if (conditions == null)
            {
                throw new Exception("No Problem Conditions given");
            }

            ProblemData = p.GetKnapDataRows();

            if (ProblemData.Length == 0)
            {
                throw new Exception("No Problem Variables and Values given");
            }

            SIZE = size;

            PROBLEMID = p.ProblemID;

            VariableNames = ProblemData.FirstOrDefault()
                .Table.Columns.OfType<DataColumn>()
                .Where(o => !o.ColumnName.Contains("ID"))
                .Select(o => o.ColumnName).ToArray();
        }


        private void WorkerProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            try
            {
                GeneticAlgorithm ga = GA;
                IChromosome bestChromosome = GA.Population.BestChromosome;

                GARow.Fill(ref ga); //report GA stuff

                GADataSet ds = GARow.Table.DataSet as GADataSet;
                GADataSet.SolutionsRow currentSolution = null;
                currentSolution = ds.Solutions.NewSolutionsRow();
                GADataSet.StringsRow currentString = null;
                currentString = ds.Strings.NewStringsRow();

                FillBasic(ref currentSolution, ref currentString, ref bestChromosome);

                FillGAData(ref currentSolution);
                //   DataRow r = currentString;
                FillStrings(ref currentSolution, ref currentString);

                //IF NOT PRESENT IN THE LIST IS A NEW CHROMOSOME
                string genotype = currentSolution.Genotype;
                if (HashListOfGenotypes.Add(genotype)) //add to hashShet
                {
                    ds.Solutions.AddSolutionsRow(currentSolution);
                    currentString.GAID = currentSolution.GAID;
                    currentString.ProblemID = currentSolution.ProblemID;
                    ds.Strings.AddStringsRow(currentString);
                    ListOfSolutions.Add(currentSolution);//add to indexed list
                }
                else
                {
                    int i = ListOfSolutions.FindIndex(o => o.Genotype.Equals(genotype));
                    ListOfSolutions[i].Frequency++;
                    // currentSolution = null;
                }

                CallBack.Invoke();

                currentString.SolutionID = currentSolution.ID;
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        /// <summary>
        /// Generic RunWorker Completed for the background worker
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            FinalCallBack.Invoke();
        }
        /// <summary>
        /// Generic Do Work for the background worker
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WorkerDoWork(object sender, DoWorkEventArgs e)
        {
            GA.GenerationRan += delegate
            {
                BackgroundWorker w = sender as BackgroundWorker;
                w.ReportProgress(0);
            };

            GA.Start();
        }



        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="problema"></param>
        public virtual void DoStatistics<T>(object problema)
        {
        }

        /// <summary>
        /// Creates the chromosome.
        /// </summary>
        /// <returns>
        /// The chromosome.
        /// </returns>
        public abstract IChromosome CreateChromosome();

        /// <summary>
        /// Creates the fitness. Must be overrided
        /// </summary>
        /// <returns>
        /// The fitness
        /// </returns>
        public virtual IFitness CreateFitness()
        {
            AFitness f = new AFitness();

            f.FitnessFuncToPass = c =>
            {
                GADataSet.SolutionsDataTable dt = new GADataSet.SolutionsDataTable();
                GADataSet.SolutionsRow nap = dt.NewSolutionsRow();
                GADataSet.StringsDataTable nstrings = new GADataSet.StringsDataTable();
                GADataSet.StringsRow n = nstrings.NewStringsRow();

                FillBasic(ref nap, ref n, ref c); //basic calculation

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
        /// Initializes this instance of the Controller
        /// </summary>
        public virtual void Initialize()
        {
        }

        /// <summary>
        /// Configure the Genetic Algorithm
        /// </summary>
        public virtual void ConfigGA()
        {
            Initialize(); //IMPORTANT

            ISelection selection = new EliteSelection();
            ICrossover crossover = new UniformCrossover();
            IMutation mutation = new UniformMutation();

            IChromosome adam = CreateChromosome();

            IPopulation population = new Population(probabilities.minPop, probabilities.maxPop, adam);
            population.GenerationStrategy = new PerformanceGenerationStrategy();

            IFitness fitness = CreateFitness();
            GeneticAlgorithm ga;
            ga = new GeneticAlgorithm(population, fitness, selection, crossover, mutation);
            ga.Termination = new FitnessStagnationTermination(probabilities.maxPop);

            ga.MutationProbability = probabilities.mutationProb;
            ga.CrossoverProbability = probabilities.crossProb;

            ga.TaskExecutor = new SmartThreadPoolTaskExecutor()
            {
                MinThreads = 10,
                MaxThreads = 50
            };

            GA = ga;
        }

        /// <summary>
        /// Does Post processing stuff after configuration
        /// Like stablishing the background worker
        /// </summary>
        public virtual void PostScript()
        {
            //LIST OF NON REPEATED VALUES
            HashListOfGenotypes = new HashSet<string>();
            //NORMAL LIST TO ACCOMPANY, BECAUSE  A LIST IS INDEXED
            //AND A HASHSET IS NOT
            ListOfSolutions = new List<GADataSet.SolutionsRow>();

            BackgroundWorker w = new BackgroundWorker();
            w.DoWork += WorkerDoWork;

            w.WorkerReportsProgress = true;
            w.ProgressChanged += WorkerProgressChanged;

            w.RunWorkerCompleted += WorkerRunWorkerCompleted;

            w.RunWorkerAsync();
        }
       // public abstract void WorkerProgressChanged(object sender, ProgressChangedEventArgs e);
      

    }
}