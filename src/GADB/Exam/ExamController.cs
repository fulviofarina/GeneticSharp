using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using GeneticSharp.Domain;
using GeneticSharp.Domain.Chromosomes;

namespace GADB
{
    public partial class ExamController : ControllerBase
    {

        public override void FillStrings<T>(ref GADataSet.SolutionsRow r, ref T stringRow)
        {
          //  r.Genotype = Aid.SetStrings(r.GenesAsInts);

            GADataSet.StringsRow s = stringRow as GADataSet.StringsRow;
          //  s.AString = String.Join(" ", r.DataAxuliar.Select(d => Aid.DecimalTxt(d.A)));
        //    s.BString = String.Join(" ", r.DataAxuliar.Select(d => Aid.DecimalTxt(d.B)));

       
          //  s.CString = String.Join(" ", r.DataAxuliar.Select(d => Aid.DecimalTxt(d.C)));


         //   r.DataAxuliar.WriteXml(r.ID.ToString() + ".txt",true);

            



        }

        /// <summary>
        /// Finds the fine for the given solution row, based on the conditions MAX, MIN and FINE TARIF
        /// </summary>
        /// <param name="r"></param>
        /// <param name="conditions"></param>
        /// <param name="variableNames">array of variableNames of problem (columns of KnapData)</param>
        private void findFines(ref DataRow r)
        {

            /*

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

            */
        }

        public delegate double y (double[] a, double x);



        /// <summary>
        /// BASIC CALCULATION NECESSARY FOR FITNESS
        /// </summary>
        /// <param name="r"></param>
        /// <param name="c"></param>
        public override void FillBasic(ref GADataSet.SolutionsRow r)
        {



            y[] func=  new y[5];

            func[0] = y1;
            func[1] = y2;
            func[2] = y3;
            func[3] = y4;
            func[4] = y5;




            // int badRoute = 1;

            // HashSet<int> nonRepeated = new HashSet<int>();

            //  r.GenesAsInts.Where(o => nonRepeated.Add(o)).ToList();

            //  string e = string.Empty;
            double Fine = 0;

            double[] ai = r.GenesAsDoubles.ToArray();

            double[] yi =new double[ai.Length];
            double[] di = new double[ai.Length];

            for (int i = 0; i < di.Length; i++) di[i] = yi[i]=0;
            for (int i = 1; i < ai.Length; i++) ai[i] *=5;

            foreach (DataRow d in this.ProblemData)
            {
               double x = d.Field<double>("A");
                double yexp = d.Field<double>("B");

              //  for (int i = 1; i < ai.Length; i++)
                {
                    //  yi[0] = y1(ai, x);
                    //  yi[1] = y2(ai, x);
                    //  yi[2] = y3(ai, x);
                    //  yi[3] = y4(ai, x);
                    //  yi[4] = y5(ai, x);
                    int index = Convert.ToInt32(ai[0]);
                     yi[0] = func[index](ai,x);
                      di[0] += Math.Pow(yexp - yi[0],2);
                   // di[1] += Math.Pow(yexp - yi[1], 2);
                  //  di[2] += Math.Pow(yexp - yi[2], 2);
                   // di[3] += Math.Pow(yexp - yi[3], 2);
                   // di[4] += Math.Pow(yexp - yi[4], 2);
                }


            }

            /*
            int goodEq = 0;
            double last = 10000;
            for (int i = 0; i < di.Length; i++)
            {
                if (di[i] < last)
                {
                    last = di[i];
                    goodEq = i;
                    s.Fine = Math.Sqrt(di[i]);

                    r.Okays = i + " " + Decimal.Round(Convert.ToDecimal(s.Fine), 2);
                  

                }
            }
            */
            Fine = Math.Sqrt(di[0]);
            r.Okays = ai[0] + " " + Decimal.Round(Convert.ToDecimal(Fine), 3);
            r.Fitness = 1/ (1+ Fine); //max vol, max value * (1+fine)



            r.Genotype = Aid.SetStrings(r.GenesAsDoubles, 4);



            //  r.Fitness /= badRoute;

        }

        double y1 (double[] a, double x)
        {
            return  a[1]*Math.Sin(a[2]*x+a[3]) + a[4];
        }
        double y2(double[] a, double x)
        {
            return a[1] * Math.Cos(a[2] * x + a[3]) + a[4];
        }
        double y3(double[] a, double x)
        {
            return a[1] * Math.Exp(a[2] * x + a[3]) + a[4];
        }
        double y4(double[] a, double x)
        {
            return a[1] +(a[2] * x );
        }
        double y5(double[] a, double x)
        {
            return a[1] + (a[2] * x)+ (a[3] * Math.Pow(x,2))+ (a[4] * Math.Pow(x,3));
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
        public ExamController() : base()
        {
          
        }

        /// <summary>
        /// NATURAL FUNCTION, COMPULSORY
        /// </summary>
        /// <returns></returns>
        public override IChromosome CreateChromosome()
        {
            //no junk? last argument
            ExamChromosome c = new ExamChromosome(SIZE, 5);
            return c;
        }



   
    }
}