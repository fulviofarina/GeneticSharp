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

    /// <summary>
    /// the generic fiels, works great
    /// </summary>
    public abstract partial class ControllerBase : IController
    {
        public int SIZE = 6;
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
        private int PROBLEMID = 0; //important!!!
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
      
      

        private DataRow[] problemData = null;
        private string[] variableNames;
        private Probabilities probabilities;
        private Action finalCallBack = null;
        private HashSet<string> hashListOfGenotypes = null;
        private List<GADataSet.SolutionsRow> listOfSolutions = null;
        private GADataSet.GARow gARow = null;
        private DataRow[] conditions = null;
        private Action callBack = null;
    }
}