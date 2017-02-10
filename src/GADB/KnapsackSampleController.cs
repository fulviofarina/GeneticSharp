using System;
using System.Collections.Generic;
using System.ComponentModel;
using GADB;
using GeneticSharp.Domain;
using GeneticSharp.Domain.Chromosomes;
using GeneticSharp.Domain.Fitnesses;
using System.Data;
using System.Linq;
using System.Collections;

namespace GADB
{
    [DisplayName("Knapsack")]
    public class KnapsackSampleController : SampleControllerBase
    {

     
        private string[] variableNames;
        private  DataRow[] conditions = null;

        private int SIZE = 6;

        private int methodNumber=0;

        private  double NORMA;

        private int PROBLEMID = 0; //important!!!


       private DataRow[] problemData = null;

        /// <summary>
        /// Finds the fine for the given solution row, based on the conditions MAX, MIN and FINE TARIF
        /// </summary>
        /// <param name="r"></param>
        /// <param name="conditions"></param>
        /// <param name="variableNames">array of variableNames of problem (columns of KnapData)</param>
        public void FindFines(ref DataRow r)
        {
            r.SetField("Fine", 0); //initialize the FINE
            r.SetField("Okays", string.Empty); //initialize the isOKStringArray //for info

            for (int j = 0; j < conditions.Length; j++)
            {

                //find if all parameters are ok
                bool[] varOk = new bool[variableNames.Length];
                bool ANDS_OK = true;
                for (int i = 0; i < variableNames.Length; i++)
                {
                    varOk[i] = false;
                    string totalVarStr = "Total" + variableNames[i];
                    string maxVarStr = "Max" + variableNames[i];
                    string minVarStr = "Min" + variableNames[i];

                    //is the variable within the window given by the condition?
                    double a = r.Field<double>(totalVarStr);
                    double b = conditions[j].Field<double>(maxVarStr);
                    varOk[i] = (a <= b);

                    a = r.Field<double>(totalVarStr);
                    b = conditions[j].Field<double>(minVarStr);

                    varOk[i] = varOk[i] && (a >= b);
                   
                    ANDS_OK = ANDS_OK && varOk[i];
                }

                //FIRST LETER T OR F
              
                string actualStr = r.Field<string>("Okays");
                for (int i = 0; i < variableNames.Length; i++)
                {
                    actualStr += varOk[i].ToString()[0] + " ";
                }
                r.SetField("Okays", actualStr);
                //NOW ASSIGN THE PENALTY / FINE
                double fine = r.Field<double>("Fine");

                if (ANDS_OK)
                {
                    fine += 0;
                }
                else
                {
                    for (int i = 0; i < variableNames.Length; i++)
                    {
                        if (!varOk[i])
                        {
                            //auxiliars
                            string str = "Total" + variableNames[i];
                            string maxCondstr = "Max" + variableNames[i];
                            string fineCondstr = variableNames[i] + "Fine";

                            //difference value less MAX_VALUE
                            double auxiliarDifference = r.Field<double>(str) - conditions[j].Field<double>(maxCondstr);
                            //take TARIF
                            double tariff = conditions[j].Field<double>(fineCondstr);

                            //FINE i-esim = difference * tariff
                            fine += (auxiliarDifference) * tariff; //excess weight
                        }
                    }


                }

                r.SetField("Fine", fine);
            }

        }


        /// <summary>
        /// BASIC CALCULATION NECESSARY FOR FITNESS
        /// </summary>
        /// <param name="r"></param>
        /// <param name="c"></param>
        private void fillBasic(ref GADataSet.KnapSolutionsRow r ,ref IChromosome c)
        {
            r.Knap(ref c);


            for (int i = 0; i < variableNames.Length; i++)
            {
                double dummy = Aid.SetBasic(r.GenesAsInts, problemData, variableNames[i]);
                r.SetField("Total"+variableNames[i], dummy); //first
            }

               r.ProblemID = PROBLEMID;

      
                DataRow row = r;
                FindFines(ref row);

                r.Fitness = r.TotalValue;
                r.Fitness /= (1 + r.Fine); //max vol, max value * (1+fine)
       
        }

        /// <summary>
        /// POST CALCULATION TO DECODE
        /// </summary>
        /// <param name="r"></param>
        private void fillStrings(ref GADataSet.KnapSolutionsRow r)
        {
            r.Genotype = Aid.SetStrings(r.GenesAsInts);

            for (int i = 0; i < variableNames.Length; i++)
            {
                string dummy = Aid.DecodeStrings(r.GenesAsInts, problemData, variableNames[i]);
                string field = variableNames[i] + "String";
                r.SetField(field, dummy); //first
            }
        
        }





        // //// / / / / / //////// //////////////////////////// AQUI TEMPLATE
        /// <summary>
        /// INITIALIZER 
        /// </summary>
        /// <param name="dt"></param>
        public KnapsackSampleController(ref GADataSet.ProblemsRow p, int size, int methodNum)
        {


            if (p == null) throw new Exception("No Problem ID given");
            //DETERMINE CONDITIONS from PROBLEM ID
            conditions = p.GetKnapConditionsRows();
            if (conditions == null)
            {
                throw new Exception("No Problem Conditions given");
            }

          //  List<List<double>> listsOfValues;

         
            //fill arrays of values, wieghts and volumes
             problemData = p.GetKnapDataRows();

            if (problemData.Length == 0)
            {
                throw new Exception("No Problem Variables and Values given");
            }




            //determine norm to normalize on fitness

         

            SIZE = size;

            PROBLEMID = p.ProblemID;

            methodNumber = methodNum;


            variableNames = problemData.FirstOrDefault()
                .Table.Columns.OfType<DataColumn>()
                .Where(o => !o.ColumnName.Contains("ID"))
                .Select(o=> o.ColumnName).ToArray();

     


        



        }

        public override void PostScript(ref object GaRow, ref Action callBack)
        {

            Action a = callBack;

            // Application.DoEvents();
            ///DEFAULT TEMPLATE for handler
            EventHandler generationRan = null;
            //LIST OF NON REPEATED VALUES
            HashSet<string> hgenotypes = new HashSet<string>();
            //NORMAL LIST TO ACCOMPANY, BECAUSE  A LIST IS INDEXED
            //AND A HASHSET IS NOT
            List<GADataSet.KnapSolutionsRow> sols = new List<GADataSet.KnapSolutionsRow>();

            GADataSet.GARow gaRow = GaRow as GADataSet.GARow;

            generationRan = delegate
            {

                GeneticAlgorithm ga = GA;
                IChromosome bestChromosome = GA.Population.BestChromosome;

                gaRow.Fill(ref ga); //report GA stuff

                // Application.DoEvents();

                GADataSet.KnapSolutionsRow currentSolution = null;
                currentSolution = (gaRow.Table.DataSet as GADataSet).KnapSolutions.NewKnapSolutionsRow();

                fillBasic(ref currentSolution, ref bestChromosome);
                FillGAData(ref currentSolution, ref gaRow);
                fillStrings(ref currentSolution);

                //IF NOT PRESENT IN THE LIST IS A NEW CHROMOSOME
                string genotype = currentSolution.Genotype;
                if (hgenotypes.Add(genotype)) //add to hashShet
                {
                    (gaRow.Table.DataSet as GADataSet).KnapSolutions.AddKnapSolutionsRow(currentSolution);

                    sols.Add(currentSolution);//add to indexed list
                }
                else
                {
                    int i = sols.FindIndex(o => o.Genotype.Equals(genotype));
                    sols[i].Frequency++;
                    // currentSolution = null;
                }


                a.Invoke();


            };


            GA.GenerationRan += generationRan;



        }
        public  override void DoStatistics<T>(object problema)
        {


            GADataSet.ProblemsRow currentProblem = problema as GADataSet.ProblemsRow;

            IEnumerable<GADataSet.GARow> gasrows = currentProblem.GetGARows();

            int min = gasrows.Min(o => o.ChromosomeLength);
            int max = gasrows.Max(o => o.ChromosomeLength);

            HashSet<string> hash = new HashSet<string>();
            List<GADataSet.KnapSolutionsRow> list = new List<GADataSet.KnapSolutionsRow>();

            // int counter = 1;
            Func<GADataSet.KnapSolutionsRow, bool> funcion;

            funcion = o =>
            {
                string genotype = o.Genotype;
                if (hash.Add(genotype)) //add to hashShet
                {
                    list.Add(o);//add to indexed list
                }
                else
                {
                    int i = list.FindIndex(r => r.Genotype.Equals(genotype));
                    list[i].Frequency += o.Frequency;
                    //   list[i].TimeSpan += o.TimeSpan;
                    //  list[i].Fitness += o.Fitness;
                    //  list[i].TotalValue += o.TotalValue;
                    //  list[i].TotalWeight += o.TotalWeight;
                    //  list[i].TotalVolume += o.TotalVolume;
                    //  counter++;
                }
                return true;
            };


            //iterate min max chromosome lenght for all genetic algorithms
            for (int j = min; j <= max; j++)
            {

                gasrows = currentProblem.GetGARows();

                IEnumerable<GADataSet.GARow> subs = gasrows.Where(o => o.ChromosomeLength == j).ToList();

                GADataSet.GARow subFirst = subs.FirstOrDefault();
                subFirst.GenerationCurrent = Convert.ToInt32(subs.Average(o => o.GenerationCurrent));
                subFirst.GenerationTotal = Convert.ToInt32(subs.Average(o => o.GenerationTotal));
                subFirst.MutationProb = subs.Average(o => o.MutationProb);
                subFirst.CrossProbability = subs.Average(o => o.CrossProbability);
                subFirst.TimeStamp = subs.Average(o => o.TimeStamp);

                //select GARow childrens
                IEnumerable<GADataSet.KnapSolutionsRow> knaprows = subs.SelectMany(o => o.GetKnapSolutionsRows());

                hash.Clear(); //clear
                list.Clear();//clear
                             //   counter = currentProblem.Iters;

                knaprows = knaprows.Where(funcion).ToList(); //evaluate the filter function


                int count = knaprows.Count();
                for (int d = 0; d < count; d++)
                {
                    if (!list.Contains(knaprows.ElementAt(d))) knaprows.ElementAt(d).Delete();

                }
                count = list.Count;
                for (int d = 0; d < count; d++)
                {

                    //  list.ElementAt(d).Frequency /= counter;
                    //  list.ElementAt(d).TimeSpan /= counter;
                    // list.ElementAt(d).Fitness /= counter;
                    // list.ElementAt(d).TotalValue /= counter;
                    //  list.ElementAt(d).TotalWeight /= counter;
                    //  list.ElementAt(d).TotalVolume /= counter;
                }
                count = subs.Count();
                for (int d = 1; d < count; d++)
                {
                    subs.ElementAt(d).Delete();
                }
            }

        }

      
        public override IFitness CreateFitness()
        {
            AFitness f = new AFitness();

            f.FitnessFuncToPass =  c =>
            {

                GADataSet.KnapSolutionsDataTable dt = new GADataSet.KnapSolutionsDataTable();
                GADataSet.KnapSolutionsRow nap = dt.NewKnapSolutionsRow();


                fillBasic(ref nap, ref c); //basic calculation

                double fit = nap.Fitness;

                nap = null;
                dt.Dispose();
                dt = null;

                return fit;

            };

            return f;
        }

        public override IChromosome CreateChromosome()
        {

            AChromosome c = new AChromosome(SIZE, problemData.Length);
            return c;
        }
    }
}