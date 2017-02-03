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

