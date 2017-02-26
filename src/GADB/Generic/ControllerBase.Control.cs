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
    /// THESE WORK BY DEFAULT BUT THE USER CAN OVERRIDE THEM
    /// </summary>
    public abstract partial class ControllerBase : IController
    {

     

        /// <summary>
        /// Creates the fitness. Must be overriden
        /// </summary>
        /// <returns>
        /// The fitness
        /// </returns>
        public virtual IFitness CreateFitness()
        {

            AFitness f = new AFitness();

            f.FitnessFuncToPass = c =>
            {
                GADataSet.SolutionsDataTable sols = new GADataSet.SolutionsDataTable();
                GADataSet.StringsDataTable strs = new GADataSet.StringsDataTable();
                GADataSet.SolutionsRow currentSolution = sols.NewSolutionsRow();
                GADataSet.StringsRow currentString = strs.NewStringsRow(); 
              
                initializeRows(ref currentSolution, ref currentString, ref c);

                FillBasic(ref currentSolution, ref currentString);

                double fit = currentSolution.Fitness; //STORE THE VALUE OF FITNESS
                sols.Dispose();
                strs.Dispose();
                
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
            //  selection = new RouletteWheelSelection();
            selection = new TournamentSelection();//es buenisimoooo
            //encontró mejores optimos en 3 iteraciones
            ICrossover crossover = new UniformCrossover();
          //  crossover = new PartiallyMappedCrossover();
            //crossover = new CycleCrossover();
            //crossover = new OrderedCrossover();
          //  crossover = new ThreeParentCrossover();
            IMutation mutation = new UniformMutation(true);

           // crossover = new CycleCrossover();
            IChromosome adam = CreateChromosome();
           

            IPopulation population = new Population(probabilities.minPop, probabilities.maxPop, adam);
            population.GenerationStrategy = new PerformanceGenerationStrategy();
            //population.GenerationStrategy = new TrackingGenerationStrategy();
            IFitness fitness = CreateFitness();
            GeneticAlgorithm ga;
            ga = new GeneticAlgorithm(population, fitness, selection, crossover, mutation);
            ga.Termination = new FitnessStagnationTermination(probabilities.maxPop);
         //   ga.Termination = new GenerationNumberTermination(probabilities.maxPop);
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

            listOfStrings = new List<GADataSet.StringsRow>();
            if (bkgWorker)
            {
                BackgroundWorker w = new BackgroundWorker();
                w.DoWork += workerDoWork;

                w.WorkerReportsProgress = true;
                w.ProgressChanged += workerProgressChanged;

                w.RunWorkerCompleted += workerRunWorkerCompleted;

                w.RunWorkerAsync();
            }
            else
            {
                GA.GenerationRan += delegate
                {
                    workerProgressChanged(null, null);

                };

                GA.Start();


                FinalCallBack();
            }

        }


        public virtual void SetControllerFor(ref GADataSet.ProblemsRow p, int size)
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




    }
}