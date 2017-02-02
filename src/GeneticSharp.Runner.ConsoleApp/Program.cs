using System;
using System.IO;
using GeneticSharp.Domain;
using GeneticSharp.Domain.Populations;
using GeneticSharp.Infrastructure.Framework.Reflection;
using GeneticSharp.Infrastructure.Threading;
using GeneticSharp.Runner.ConsoleApp.Samples;
using GeneticSharp.Domain.Chromosomes;

using System.Collections.Generic;

namespace GeneticSharp.Runner.ConsoleApp
{
    public static class Msg
    {

        ////////////////////////////////
        public static void EvolvedMsg()
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine();
            Console.WriteLine("Evolved.");
            Console.ResetColor();
        }

        public static void ErrorMsg(ref Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine();
            Console.WriteLine("Error: {0}", ex.Message);
            Console.ResetColor();
            Console.ReadKey();
        }





        ////////////////////////MINE

        /// <summary>
        /// 
        /// </summary>
        public static void IntroMsg()
        {
            Console.SetError(TextWriter.Null);
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("GeneticSharp - ConsoleApp");
            Console.ResetColor();
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="selectedSampleName"></param>

        public static void DrawSampleName(string selectedSampleName)
        {
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("GeneticSharp - ConsoleApp");
            Console.WriteLine();
            Console.WriteLine(selectedSampleName);
            Console.ResetColor();
        }

        public static string SelectSample(ref IList<string> sampleNames)
        {
            Console.WriteLine("Select the sample:");


            for (int i = 0; i < sampleNames.Count; i++)
            {
                Console.WriteLine("{0}) {1}", i + 1, sampleNames[i]);
            }

            int sampleNumber = 0;
            string selectedSampleName = string.Empty;

            try
            {
                sampleNumber = Convert.ToInt32(Console.ReadLine());
                selectedSampleName = sampleNames[sampleNumber - 1];
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid option.");
            }

            return selectedSampleName;
        }

    }
}

namespace GeneticSharp.Runner.ConsoleApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //intro text
            Msg.IntroMsg();


            //get list of examples (menu)
            IList<string> sampleNames = TypeHelper.GetDisplayNamesByInterface<ISampleController>();

            //select an example
            string selectedSampleName = Msg.SelectSample(ref sampleNames);

        
            
            //an interface for the example to use?
            ISampleController sampleController = null;
            GeneticAlgorithm ga = null; //object engine


            ga = Create(selectedSampleName, ref sampleController); //creates the thing

            ConfigHandler(selectedSampleName, ref sampleController, ref ga);

            try
            {
                sampleController.ConfigGA(ga);
                ga.Start();
            }
            catch (Exception ex)
            {
                Msg.ErrorMsg(ref ex);
                return;
            }

            Msg.EvolvedMsg();

            Console.ReadKey();

            Main(args);

        }

   

        private static GeneticAlgorithm Create(string selectedSampleName, ref ISampleController sampleController)
        {
            //get sample controller associated to sample name
            sampleController = TypeHelper.CreateInstanceByName<ISampleController>(selectedSampleName);

            Msg.DrawSampleName(selectedSampleName); //text

            sampleController.Initialize(); //IMPORTANT

            Console.WriteLine("Starting...");

           Domain.Selections.ISelection selection = sampleController.CreateSelection();
           Domain.Crossovers.ICrossover crossover = sampleController.CreateCrossover();
            Domain.Mutations.IMutation mutation = sampleController.CreateMutation();
            Domain.Fitnesses.IFitness fitness = sampleController.CreateFitness();
            Domain.Populations.IPopulation  population = new Population(100, 200, sampleController.CreateChromosome());
            population.GenerationStrategy = new PerformanceGenerationStrategy();

            GeneticAlgorithm ga;
            ga = new GeneticAlgorithm(population, fitness, selection, crossover, mutation);
            ga.Termination = sampleController.CreateTermination();



            return ga;
           
        }

        private static void ConfigHandler(string selectedSampleName, ref ISampleController sampleController, ref GeneticAlgorithm geneticAlgo)
        {

            //REQUIRED CASTING to introduce them into the Lamda Expression
            ISampleController scontroller = sampleController;
            GeneticAlgorithm ga = geneticAlgo;


            EventHandler generationRan;

            generationRan = delegate
            {
                Msg.DrawSampleName(selectedSampleName);
                string terminationName = ga.Termination.GetType().Name;

                IChromosome bestChromosome = ga.Population.BestChromosome;
                Console.WriteLine("Termination: {0}", terminationName);

                int generationsNum = ga.Population.GenerationsNumber;
                Console.WriteLine("Generations: {0}", generationsNum);

                double? fitness = bestChromosome.Fitness;
                Console.WriteLine("Fitness: {0,10}", fitness);

                TimeSpan te = ga.TimeEvolving;
                Console.WriteLine("Time: {0}", te);

                scontroller.Draw(bestChromosome);
            };

            ga.GenerationRan += generationRan;
            
        }


      
    }
}
