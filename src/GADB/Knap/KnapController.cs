using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using GeneticSharp.Domain;
using GeneticSharp.Domain.Chromosomes;

namespace GADB
{
    public partial class KnapController : ControllerBase
    {
       

        /// <summary>
        /// Finds the fine for the given solution row, based on the conditions MAX, MIN and FINE TARIF
        /// </summary>
        /// <param name="r"></param>
        /// <param name="conditions"></param>
        /// <param name="variableNames">array of variableNames of problem (columns of KnapData)</param>
        private void findFines(ref DataRow r)
        {
            for (int j = 0; j < Conditions.Length; j++)
            {
                //find if all parameters are ok
                bool[] varOk = new bool[VariableNames.Length];
                bool ANDS_OK = true;
                for (int i = 0; i < VariableNames.Length; i++)
                {
                    varOk[i] = false;
                    string totalVarStr = "Total" + VariableNames[i];
                    string maxVarStr = "Max" + VariableNames[i];
                    string minVarStr = "Min" + VariableNames[i];
                    //is the variable within the window given by the condition?
                    double a = r.Field<double>(totalVarStr);
                    double b = Conditions[j].Field<double>(maxVarStr);
                    varOk[i] = (a <= b);
                    a = r.Field<double>(totalVarStr);
                    b = Conditions[j].Field<double>(minVarStr);
                    varOk[i] = varOk[i] && (a >= b);

                    ANDS_OK = ANDS_OK && varOk[i];
                }

                //FIRST LETER T OR F

                string actualStr = r.Field<string>("Okays");
                for (int i = 0; i < VariableNames.Length; i++)
                {
                    actualStr += varOk[i].ToString()[0] + " ";
                }
                r.SetField("Okays", actualStr);
                //NOW ASSIGN THE PENALTY / FINE
                double fine = r.Field<double>("Fine");

                if (ANDS_OK)
                {
                    fine += 0; //not to be fined
                }
                else
                {
                    for (int i = 0; i < VariableNames.Length; i++)
                    {
                        if (!varOk[i])
                        {
                            //auxiliars
                            string str = "Total" + VariableNames[i];
                            string maxCondstr = "Max" + VariableNames[i];
                            string fineCondstr = VariableNames[i] + "Fine";

                            //difference value less MAX_VALUE
                            double auxiliarDifference = r.Field<double>(str) - Conditions[j].Field<double>(maxCondstr);
                            //take TARIF
                            double tariff = Conditions[j].Field<double>(fineCondstr);

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
       public override void FillBasic(ref GADataSet.SolutionsRow r, ref GADataSet.StringsRow s, ref IChromosome c)
        {
            r.Knap(ref c);

            s.TotalC = 0;
            s.TotalA = 0;
            s.TotalB = 0;
            s.Fine = 0; //initialize the FINE
            s.Okays = string.Empty; //initialize the isOKStringArray //for info

            for (int i = 0; i < VariableNames.Length; i++)
            {
                double dummy = Aid.SetBasic(r.GenesAsInts, ProblemData, VariableNames[i]);
                s.SetField("Total" + VariableNames[i], dummy); //first
            }

            r.ProblemID = PROBLEMID;

            DataRow row = s;

            findFines(ref row);

            r.Fitness = s.TotalC;
            r.Fitness /= (1 + s.Fine); //max vol, max value * (1+fine)
        }

        /// <summary>
        /// POST CALCULATION TO DECODE
        /// </summary>
        /// <param name="r"></param>

        // //// / / / / / //////// //////////////////////////// AQUI TEMPLATE
        /// <summary>
        /// INITIALIZER
        /// </summary>
        /// <param name="dt"></param>
        public KnapController() : base()
        {
          
        }

        /// <summary>
        /// NATURAL FUNCTION, COMPULSORY
        /// </summary>
        /// <returns></returns>
        public override IChromosome CreateChromosome()
        {
            KnapChromosome c = new KnapChromosome(SIZE, ProblemData.Length);
            return c;
        }



        /// <summary>
        /// FUNCTION TO PERFORM AVERAGE AND HISTOGRAM
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="problema"></param>
        public override void DoStatistics<T>(object problema)
        {
            GADataSet.ProblemsRow currentProblem = problema as GADataSet.ProblemsRow;

            IEnumerable<GADataSet.GARow> gasrows = currentProblem.GetGARows();

            int min = gasrows.Min(o => o.ChromosomeLength);
            int max = gasrows.Max(o => o.ChromosomeLength);

            HashSet<string> hash = new HashSet<string>();
            List<GADataSet.SolutionsRow> list = new List<GADataSet.SolutionsRow>();

            // int counter = 1;
            Func<GADataSet.SolutionsRow, bool> funcion;

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
                IEnumerable<GADataSet.SolutionsRow> knaprows = subs.SelectMany(o => o.GetSolutionsRows());

                hash.Clear(); //clear
                list.Clear();//clear

                knaprows = knaprows.Where(funcion).ToList(); //evaluate the filter function

                int count = knaprows.Count();
                for (int d = 0; d < count; d++)
                {
                    if (!list.Contains(knaprows.ElementAt(d))) knaprows.ElementAt(d).Delete();
                }

                count = subs.Count();
                for (int d = 1; d < count; d++)
                {
                    subs.ElementAt(d).Delete();
                }
            }
        }
    }
}