using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using GeneticSharp.Domain;
using GeneticSharp.Domain.Chromosomes;

namespace GADB
{
    public partial class DroneController : ControllerBase
    {

        public override void FillStrings<T>(ref GADataSet.SolutionsRow r, ref T stringRow)
        {
          //  r.Genotype = Aid.SetStrings(r.GenesAsInts);

            GADataSet.StringsRow s = stringRow as GADataSet.StringsRow;
            s.AString = String.Join(" ", r.DataAxuliar.Select(d => Aid.DecimalTxt(d.A)));
            s.BString = String.Join(" ", r.DataAxuliar.Select(d => Aid.DecimalTxt(d.B)));

       
            s.CString = String.Join(" ", r.DataAxuliar.Select(d => Aid.DecimalTxt(d.C)));


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

        /// <summary>
        /// BASIC CALCULATION NECESSARY FOR FITNESS
        /// </summary>
        /// <param name="r"></param>
        /// <param name="c"></param>
        public override void FillBasic(ref GADataSet.SolutionsRow r)
        {

            int badRoute = 1;

            HashSet<int> nonRepeated = new HashSet<int>();

            r.GenesAsInts.Where(o => nonRepeated.Add(o)).ToList();

          //  string e = string.Empty;
            double Fine = 0;
            DataRow cond = Conditions.FirstOrDefault();

            //if non-repeated list counts to number of variables.. OK!
            if (nonRepeated.Count == ProblemData.Count())
            {
                try
                {
                    List<int> fullList = nonRepeated.ToList();
                    fullList.Add(0); //adds origin to the end

                    //create rows for subtable Data auxiliar
                    for (int j = 0; j < fullList.Count; j++)
                    {
                        GADataSet.DataRow d = r.DataAxuliar.NewDataRow();
                        r.DataAxuliar.AddDataRow(d);
                        //auxiliar data row
                        for (int i = 0; i < VariableNames.Length; i++)
                        {
                            //Field A, B or C
                            string varField = VariableNames[i];
                            double var = Aid.SetDifferences(cond, fullList, j, ProblemData, varField);
                            d.SetField<double>(varField, var); //set Distance Differences for A or B
                        }

                    }

                  


                    foreach (GADataSet.DataRow item in r.DataAxuliar)
                    {
                        double a2 = Math.Pow(item.A, 2); //x^2
                        double b2 = Math.Pow(item.B, 2); //y^2
                        item.C = Math.Sqrt(a2 + b2); //distance = sqrt (x^2,y^2)
                    }
                    //put total distance parcourred 
                   double totalDistance = r.DataAxuliar.Sum(i => i.C);

                    Fine = totalDistance / (r.DataAxuliar.Count * 10);

                 
                    fullList.Insert(0, 0);

                    foreach (GADataSet.ConditionsRow c in Conditions)
                    {
                        string prohibited = c.MinC.ToString() + c.MaxC.ToString();
                        string genotype = String.Join("", fullList.Select(o => o));
                        if (genotype.Contains(prohibited))
                        {
                            badRoute++;
                        }
                    }

                 //   if (s.Fine > 1 && badRoute>1) s.Fine = 0.80;
                    if (Fine > 1) Fine = 0.90;

                  

                    fullList.Clear();
                    fullList = null;

                }
                catch (SystemException ex)
                {
                   // e = ex.StackTrace;
                }


            }
            else Fine = cond.Field<double>("CFine"); //a million

            nonRepeated.Clear();
            nonRepeated = null;

            r.Okays = badRoute.ToString() + " " +  Decimal.Round(Convert.ToDecimal(Fine),3);


            r.Fitness = 1 - Fine; //max vol, max value * (1+fine)

            r.Fitness /= badRoute;


            r.Genotype = Aid.SetStrings(r.GenesAsInts);



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
        public DroneController() : base()
        {
          
        }

        /// <summary>
        /// NATURAL FUNCTION, COMPULSORY
        /// </summary>
        /// <returns></returns>
        public override IChromosome CreateChromosome()
        {
            //no junk? last argument
            DroneChromosome c = new DroneChromosome(SIZE, ProblemData.Length, 0);
            return c;
        }



   
    }
}