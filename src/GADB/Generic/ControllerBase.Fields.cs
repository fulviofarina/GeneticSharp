using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
    public abstract partial class ControllerBase : IController
    {
        private DataRow[] conditions = null;
        public DataRow[] Conditions
        {
            get
            {
                return conditions;
            }

            set
            {
                conditions = value;
            }
        }

        public int SIZE = 6;

        private GADataSet.GARow gARow = null;
        public GADataSet.GARow GARow
        {
            get
            {
                return gARow;
            }

            set
            {
                gARow = value;
            }
        }
        private Action callBack = null;
        public Action CallBack
        {
            get
            {
                return callBack;
            }

            set
            {
                callBack = value;
            }
        }
        private Action finalCallBack = null;
        public Action FinalCallBack
        {
            get
            {
                return finalCallBack;
            }

            set
            {
                finalCallBack = value;
            }
        }

        public int PROBLEMID = 0; //important!!!
        private DataRow[] problemData = null;
        private string[] variableNames;

        private Probabilities probabilities;

        /// <summary>
        /// Gets the Genetic Algorithm.
        /// </summary>
        /// <value>The Genetic Algorithm.</value>
        ///
        public GeneticAlgorithm GA { get; set; }

        public Probabilities Probabilities
        {
            get
            {
                return probabilities;
            }

            set
            {
                probabilities = value;
            }
        }

        public DataRow[] ProblemData
        {
            get
            {
                return problemData;
            }

            set
            {
                problemData = value;
            }
        }

        public string[] VariableNames
        {
            get
            {
                return variableNames;
            }

            set
            {
                variableNames = value;
            }
        }

        public HashSet<string> HashListOfGenotypes
        {
            get
            {
                return hashListOfGenotypes;
            }

            set
            {
                hashListOfGenotypes = value;
            }
        }

        public List<GADataSet.SolutionsRow> ListOfSolutions
        {
            get
            {
                return listOfSolutions;
            }

            set
            {
                listOfSolutions = value;
            }
        }

       

        private HashSet<string> hashListOfGenotypes = null;
        private List<GADataSet.SolutionsRow> listOfSolutions = null;




    }
}