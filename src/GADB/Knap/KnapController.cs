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

        public override void FillStrings<T>(ref GADataSet.SolutionsRow r, ref T s)
        {
         

            for (int i = 0; i < VariableNames.Length; i++)
            {
                string dummy = Aid.DecodeStrings(r.GenesAsInts, ProblemData, VariableNames[i]);
                string field = VariableNames[i] + "String";
                DataRow row = s as DataRow;
                row.SetField(field, dummy); //first
            }
        }


        /// <summary>
        /// Finds the fine for the given solution row, based on the conditions MAX, MIN and FINE TARIF
        /// </summary>
        /// <param name="r"></param>
        /// <param name="conditions"></param>
        /// <param name="variableNames">array of variableNames of problem (columns of KnapData)</param>
        private string findFines(ref DataRow r)
        {

            string actualStr = string.Empty;

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

              //  actualStr = r.Field<string>("Okays");
                for (int i = 0; i < VariableNames.Length; i++)
                {
                    actualStr += varOk[i].ToString()[0] + " ";
                }
               // r.SetField("Okays", actualStr);
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


            return actualStr;

        }
     
        /// <summary>
        /// BASIC CALCULATION NECESSARY FOR FITNESS
        /// </summary>
        /// <param name="r"></param>
        /// <param name="c"></param>
        public override void FillBasic(ref GADataSet.SolutionsRow r, ref GADataSet.StringsRow s)
        {
            

            for (int i = 0; i < VariableNames.Length; i++)
            {
                double dummy = Aid.SetBasic(r.GenesAsInts, ProblemData, VariableNames[i]);
                s.SetField("Total" + VariableNames[i], dummy); //first
            }

           

            DataRow row = s;
            r.Okays =  findFines(ref row);

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


    }
}