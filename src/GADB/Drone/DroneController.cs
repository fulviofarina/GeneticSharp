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
            s.AString = String.Join(" ", r.DataAxuliar.Select(d => DecimalTxt(d.A)));
            s.BString = String.Join(" ", r.DataAxuliar.Select(d => DecimalTxt(d.B)));

       
            s.CString = String.Join(" ", r.DataAxuliar.Select(d => DecimalTxt(d.C)));


            r.DataAxuliar.WriteXml(r.ID.ToString() + ".txt",true);

            



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
       public override void FillBasic(ref GADataSet.SolutionsRow r, ref GADataSet.StringsRow s)
        {

           

            HashSet<int>   nonRepeated = new HashSet<int>();

            r.GenesAsInts.Where(o => nonRepeated.Add(o)).ToList();

            string e = string.Empty ;
            s.Fine = 0;
            DataRow cond = Conditions.FirstOrDefault();

            if (nonRepeated.Count == ProblemData.Count())
            {
                try
                {
                    List<int> fullList = nonRepeated.ToList();
                    fullList.Add(0); //adds origin to the end
                    for (int j = 0; j < fullList.Count; j++)
                    {
                        GADataSet.DataRow d = r.DataAxuliar.NewDataRow();
                        r.DataAxuliar.AddDataRow(d);

           

                        for (int i = 0; i < VariableNames.Length; i++)
                        {
                            //Field A, B or C
                            string varField = VariableNames[i];
                            double var = Aid.SetDifferences(cond, fullList, j, ProblemData, varField);
                            d.SetField<double>(varField, var); //set Distance Differences for A or B
                        }
                        
                    }

                    fullList.Clear();
                    fullList = null;
                   

                    foreach (GADataSet.DataRow item in r.DataAxuliar)
                    {
                        double a2 = Math.Pow(item.A, 2);
                        double b2 = Math.Pow(item.B, 2);
                        item.C = Math.Sqrt(a2 + b2);
                    }
                    s.TotalC = r.DataAxuliar.Sum(i => i.C);


                }
                catch (SystemException ex)
                {
                     e = ex.StackTrace;
                }
               

            }
            else s.Fine = cond.Field<double>("CFine"); //a million

            nonRepeated.Clear();
            nonRepeated = null;
         
          
            s.Fine = s.TotalC + s.Fine;
            if (s.Fine != 0)   r.Fitness =100 / s.Fine; //max vol, max value * (1+fine)
        }

        private decimal  DecimalTxt(double varPower)
        {
         

          
            decimal deci1 = Decimal.Round(Convert.ToDecimal(varPower), 1);
        
            return deci1;
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