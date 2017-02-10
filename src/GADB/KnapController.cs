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


        private HashSet<string> hgenotypes = null;
        private List<GADataSet.KnapSolutionsRow> sols = null;
        private GADataSet.GARow gaRow = null;

        public GADataSet.GARow GaRow
        {
            get
            {
                return gaRow;
            }

            set
            {
                gaRow = value;
            }
        }


        private string[] variableNames;
        private DataRow[] conditions = null;

        private int SIZE = 6;

        private int PROBLEMID = 0; //important!!!

        private DataRow[] problemData = null;

        /// <summary>
        /// Finds the fine for the given solution row, based on the conditions MAX, MIN and FINE TARIF
        /// </summary>
        /// <param name="r"></param>
        /// <param name="conditions"></param>
        /// <param name="variableNames">array of variableNames of problem (columns of KnapData)</param>
        private void findFines(ref DataRow r)
        {
         
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
                    fine += 0; //not to be fined
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
        private void fillBasic(ref GADataSet.KnapSolutionsRow r, ref GADataSet.KnapStringsRow s, ref IChromosome c)
        {
            r.Knap(ref c);

        
            s.TotalValue = 0;
            s.TotalWeight = 0;
            s.TotalVolume = 0;
            s.Fine = 0; //initialize the FINE
            s.Okays = string.Empty; //initialize the isOKStringArray //for info


            for (int i = 0; i < variableNames.Length; i++)
            {
                double dummy = Aid.SetBasic(r.GenesAsInts, problemData, variableNames[i]);
                s.SetField("Total" + variableNames[i], dummy); //first
            }

            r.ProblemID = PROBLEMID;

            DataRow row = s;
    
            findFines(ref row);
        
            r.Fitness = s.TotalValue;
            r.Fitness /= (1 + s.Fine); //max vol, max value * (1+fine)
        }

        /// <summary>
        /// POST CALCULATION TO DECODE
        /// </summary>
        /// <param name="r"></param>
        private void fillStrings(ref GADataSet.KnapSolutionsRow r, ref GADataSet.KnapStringsRow s)
        {
            r.Genotype = Aid.SetStrings(r.GenesAsInts);

            for (int i = 0; i < variableNames.Length; i++)
            {
                string dummy = Aid.DecodeStrings(r.GenesAsInts, problemData, variableNames[i]);
                string field = variableNames[i] + "String";
                s.SetField(field, dummy); //first
            }
        }

        // //// / / / / / //////// //////////////////////////// AQUI TEMPLATE
        /// <summary>
        /// INITIALIZER
        /// </summary>
        /// <param name="dt"></param>
        public KnapController(ref GADataSet.ProblemsRow p, int size)
        {
            if (p == null) throw new Exception("No Problem ID given");
            //DETERMINE CONDITIONS from PROBLEM ID
            conditions = p.GetKnapConditionsRows();
            if (conditions == null)
            {
                throw new Exception("No Problem Conditions given");
            }

            //fill arrays of values, wieghts and volumes
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




      
        /// <summary>
        /// To perform print process
        /// </summary>
        /// <param name="GaRow">Genetic Algorithm ROW</param>
        /// <param name="callBack">FUNCTION TO CALL BACK TO UPDATE FORM/CONTROL</param>
        public override void PostScript( )
        {
            //LIST OF NON REPEATED VALUES
            hgenotypes = new HashSet<string>();
            //NORMAL LIST TO ACCOMPANY, BECAUSE  A LIST IS INDEXED
            //AND A HASHSET IS NOT
            sols = new List<GADataSet.KnapSolutionsRow>();


            BackgroundWorker w = new BackgroundWorker();
            w.DoWork += W_DoWork;
          
            w.WorkerReportsProgress = true;
            w.ProgressChanged += W_ProgressChanged;

            w.RunWorkerAsync();
            

           
        }

        private void W_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

            try
            {

          


                GeneticAlgorithm ga = GA;
            IChromosome bestChromosome = GA.Population.BestChromosome;

            gaRow.Fill(ref ga); //report GA stuff


            //    CallBack.Invoke();

             //    Application.DoEvents();
                GADataSet ds = gaRow.Table.DataSet as GADataSet;
            GADataSet.KnapSolutionsRow currentSolution = null;
            currentSolution = ds.KnapSolutions.NewKnapSolutionsRow();
            GADataSet.KnapStringsRow currentString = null;
            currentString = ds.KnapStrings.NewKnapStringsRow();

               

            fillBasic(ref currentSolution, ref currentString, ref bestChromosome);
            FillGAData(ref currentSolution, ref gaRow);
            fillStrings(ref currentSolution, ref currentString);


            //IF NOT PRESENT IN THE LIST IS A NEW CHROMOSOME
            string genotype = currentSolution.Genotype;
            if (hgenotypes.Add(genotype)) //add to hashShet
            {
                ds.KnapSolutions.AddKnapSolutionsRow(currentSolution);
                currentString.GAID = currentSolution.GAID;
                currentString.ProblemID = currentSolution.ProblemID;
                ds.KnapStrings.AddKnapStringsRow(currentString);
                sols.Add(currentSolution);//add to indexed list
            }
            else
            {
                int i = sols.FindIndex(o => o.Genotype.Equals(genotype));
                sols[i].Frequency++;
                // currentSolution = null;
            }


            CallBack.Invoke();


            currentString.SolutionID = currentSolution.ID;

            }
            catch (Exception ex)
            {

                string text = ex.StackTrace;
                string yo = ex.Message;
            }


        }

      //  int i = 0;

        private void W_DoWork(object sender, DoWorkEventArgs e)
        {
         
            GA.GenerationRan += delegate
            {

                System.ComponentModel.BackgroundWorker w = sender as System.ComponentModel.BackgroundWorker;
                w.ReportProgress(0);


            };

            GA.Start();
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


  
    }
}