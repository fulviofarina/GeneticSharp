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

        /// <summary>
        /// Finds the fitness and Fine for the chromosome
        /// Function necessary during Fitness.Evaluation()
        /// Function necessary during PostScript printing
        /// Needs to be overriden
        /// </summary>
        /// <param name="r"></param>
        /// <param name="s"></param>
        /// <param name="c"></param>
        public abstract void FillBasic(ref GADataSet.SolutionsRow r, ref GADataSet.StringsRow s, ref IChromosome c);
        /// <summary>
        /// DECODES THE CHROMOSOME DATA CALCULATIONS INTO STRINGS OF TEXT
        /// Fills the Strings Table based on the variableNames
        /// Needs to be overriden
        /// </summary>
        /// <typeparam name="T">DataRow of StringsTable</typeparam>
        /// <param name="r">Solutions row</param>
        /// <param name="s">DataRow of stringsTable to fill, e.g. Strings</param>
        public abstract void FillStrings<T>(ref GADataSet.SolutionsRow r, ref T s);

        public abstract IChromosome CreateChromosome();

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="problema"></param>
     //   public virtual void DoStatistics<T>(T problema)
     //   {
      //  }
        /// <summary>
        /// Creates the chromosome.
        /// </summary>
        /// <returns>
        /// The chromosome.
        /// </returns>

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
                GADataSet set = new GADataSet();
                GADataSet.SolutionsRow nap;
                GADataSet.StringsRow n;
                createSolutionRow(ref c, ref set, out nap, out n);
                double fit = nap.Fitness; //STORE THE VALUE OF FITNESS
                set.Dispose();
                set = null;
                return fit;
            };

            return f;
        }
        /// <summary>
        /// Configure the Genetic Algorithm
        /// </summary>
        public virtual void ConfigGA()
        {
            //  Initialize(); //IMPORTANT

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
                MaxThreads = 70
            };

            GA = ga;
        }
        /// <summary>
        /// Does Post processing stuff after configuration
        /// Like stablishing the background worker
        /// </summary>
        public virtual void PostScript(bool bkgWorker)
        {
            //LIST OF NON REPEATED VALUES
            hashListOfGenotypes = new HashSet<string>();
            //NORMAL LIST TO ACCOMPANY, BECAUSE  A LIST IS INDEXED
            //AND A HASHSET IS NOT
            listOfSolutions = new List<GADataSet.SolutionsRow>();
            if (bkgWorker)
            {
                BackgroundWorker w = new BackgroundWorker();
                w.DoWork += WorkerDoWork;

                w.WorkerReportsProgress = true;
                w.ProgressChanged += WorkerProgressChanged;

                w.RunWorkerCompleted += WorkerRunWorkerCompleted;

                w.RunWorkerAsync();
            }
            else
            {
                GA.GenerationRan += delegate
                {
                    WorkerProgressChanged(null, null);
                };

                GA.Start();
            }

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

            problemData = p.GetKnapDataRows();

            if (problemData.Length == 0)
            {
                throw new Exception("No Problem Variables and Values given");
            }

            SIZE = size;

            PROBLEMID = p.ProblemID;

            variableNames = problemData.FirstOrDefault()
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


                //BASIC
                GADataSet ds = GARow.Table.DataSet as GADataSet;
                GADataSet.SolutionsRow currentSolution;
                GADataSet.StringsRow currentString;
                createSolutionRow(ref bestChromosome, ref ds, out currentSolution, out currentString);


                //fill GA data to row
                GARow.Initialize(ref ga); //report GA stuff
                GARow.FillGADataToSolution(ref currentSolution);

                //adt solutions and decoding to dataset
                addToDataSet(ref ds,ref  currentSolution, ref currentString);

                //callBack MEthod to Form or User Control
                CallBack.Invoke();

                //assign string ID... //this should be better
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
                w.ReportProgress(0); //should I put a percentage?
            };

            GA.Start();
        }

        /// <summary>
        /// Creates a solution row and a strings row
        /// </summary>
        /// <param name="bestChromosome"></param>
        /// <param name="ds"></param>
        /// <param name="currentSolution"></param>
        /// <param name="currentString"></param>
        private void createSolutionRow(ref IChromosome bestChromosome, ref GADataSet ds, out GADataSet.SolutionsRow currentSolution, out GADataSet.StringsRow currentString)
        {
            currentSolution = null;
            currentString = null;
            currentSolution = ds.Solutions.NewSolutionsRow();
            currentString = ds.Strings.NewStringsRow();
            initializeRows(ref currentSolution, ref currentString, ref bestChromosome);
            currentSolution.ProblemID = PROBLEMID;

            //this is the most important function to override, does the fitness calc
            FillBasic(ref currentSolution, ref currentString, ref bestChromosome);

        }

        /// <summary>
        /// Sets default values 0,0 0,0,0
        /// </summary>
        /// <param name="r"></param>
        /// <param name="s"></param>
        /// <param name="c"></param>
        private void initializeRows(ref GADataSet.SolutionsRow r, ref GADataSet.StringsRow s, ref IChromosome c)
        {
            r.Initialize(ref c);

            s.Initialize();
        }


        /// <summary>
        /// adds the rows to the given dataset
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="currentSolution"></param>
        /// <param name="currentString"></param>
        private void addToDataSet(ref GADataSet ds, ref GADataSet.SolutionsRow currentSolution, ref GADataSet.StringsRow currentString)
        {



            //decode
            FillStrings(ref currentSolution, ref currentString);
            //IF NOT PRESENT IN THE LIST IS A NEW CHROMOSOME
            string genotype = currentSolution.Genotype;
            if (hashListOfGenotypes.Add(genotype)) //add to hashShet
            {
                ds.Solutions.AddSolutionsRow(currentSolution);
                currentString.GAID = currentSolution.GAID;
                currentString.ProblemID = currentSolution.ProblemID;
                ds.Strings.AddStringsRow(currentString);
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