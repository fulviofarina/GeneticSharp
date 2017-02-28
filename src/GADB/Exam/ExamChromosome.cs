﻿using System.Collections.Generic;
using GeneticSharp.Domain.Chromosomes;
using GeneticSharp.Domain.Randomizations;

namespace GADB
{
    public sealed class ExamChromosome : ChromosomeBase
    {
        private int numberOfGenes;
       // private HashSet<int> nonRepeated;
        private int eqNumber=0;
        /// <summary>
        ///
        /// </summary>
        /// <param name="sizeOfChromosome"></param>
        /// <param name="numOfGenes"></param>
        public ExamChromosome( int numOfGenes, int numberEqs) : base(numOfGenes+1)
        {
           // nonRepeated = new HashSet<int>();

            numberOfGenes = numOfGenes; // do I need the values? nope I think, only indexes

            eqNumber = numberEqs;


            for (int i = 0; i < numberOfGenes+1; i++)
            {
                Gene g = GenerateGene(i);
                ReplaceGene(i, g);
            }
       

    }

        public override Gene GenerateGene(int geneIndex)
        {
            object o=0;
            if (geneIndex==0) o = RandomizationProvider.Current.GetInt(0, eqNumber);
            else o = RandomizationProvider.Current.GetDouble(-1, 1);
        
            return new Gene(o);
        }


       

        /// <summary>
        /// Creates a new chromosome using the same structure of this.
        /// </summary>
        /// <returns>The new chromosome.</returns>
        public override IChromosome CreateNew()
        {
            return new ExamChromosome(this.numberOfGenes, this.eqNumber);
        }

        /// <summary>
        /// Creates a clone.
        /// </summary>
        /// <returns>The chromosome clone.</returns>
        public override IChromosome Clone()
        {
            ExamChromosome c = base.Clone() as ExamChromosome;
            c.numberOfGenes = this.numberOfGenes;
            c.eqNumber = this.eqNumber;
            return c;
        }
    }
}