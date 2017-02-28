using System.Collections.Generic;
using GeneticSharp.Domain.Chromosomes;
using GeneticSharp.Domain.Randomizations;

namespace GADB
{
    public sealed class DroneChromosome : ChromosomeBase
    {
        private int numberOfGenes;
       // private HashSet<int> nonRepeated;
        private int maxEmpty=0;
        /// <summary>
        ///
        /// </summary>
        /// <param name="sizeOfChromosome"></param>
        /// <param name="numOfGenes"></param>
        public DroneChromosome(int sizeOfChromosome, int numOfGenes, int maxJunk) : base(sizeOfChromosome)
        {
           // nonRepeated = new HashSet<int>();

            numberOfGenes = numOfGenes; // do I need the values? nope I think, only indexes

            maxEmpty=maxJunk ;
/*
            int geneCounter = 0;
            while (geneCounter<sizeOfChromosome)
            {
                Gene g = GenerateGene(geneCounter);
                int val = (int)g.Value;
          
                        ReplaceGene(geneCounter, g);
                        geneCounter++;
              
            }
       */
            var citiesIndexes = RandomizationProvider.Current.GetUniqueInts(numberOfGenes, 1, numberOfGenes+1);

            for (int i = 0; i < numberOfGenes; i++)
            {
                int valor = citiesIndexes[i];
             //   if (valor > numberOfGenes) valor = -1;
                Gene g = new Gene(valor);
                ReplaceGene(i, g);
            }
       

    }

        public override Gene GenerateGene(int geneIndex)
        {
            int valor = RandomizationProvider.Current.GetInt(1, numberOfGenes + 1);
         //   if (valor > numberOfGenes) valor = -1;
            return new Gene(valor);
        }


        /// <summary>
        /// THIS WORKS THE BEST, HIGH PROB OF JUNK GENE
        /// </summary>
        /// <param name="geneIndex"></param>
        /// <returns></returns>
        public Gene GenerateGeneC(int geneIndex)
        {
            int randIndex = 0;
            int initial = 0;

            randIndex = RandomizationProvider.Current.GetInt(initial, numberOfGenes + maxEmpty);

            if (randIndex > numberOfGenes || randIndex == 0) randIndex = -1;

            return new Gene(randIndex);
        }

        /// <summary>
        /// OPTION B
        /// </summary>
        /// <param name="geneIndex"></param>
        /// <returns></returns>
        public Gene GenerateGeneB(int geneIndex)
        {
            int randIndex = 0;
            int initial = 0;

            randIndex = RandomizationProvider.Current.GetInt(initial, numberOfGenes);

            if (randIndex == 0) randIndex = -1;

            return new Gene(randIndex);
        }

        /// <summary>
        /// OPTION A
        /// </summary>
        /// <param name="geneIndex"></param>
        /// <returns></returns>
        public  Gene GenerateGeneA(int geneIndex)
        {
            int randIndex = 0;
            int initial = 0;

            //makes 1 gene with a random index from 0 to m_values as MAX
            initial = 1;

            randIndex = RandomizationProvider.Current.GetInt(initial, numberOfGenes+1);

            if (randIndex > numberOfGenes) randIndex = -1;

            return new Gene(randIndex);
        }

        /// <summary>
        /// Creates a new chromosome using the same structure of this.
        /// </summary>
        /// <returns>The new chromosome.</returns>
        public override IChromosome CreateNew()
        {
            return new DroneChromosome(this.Length, this.numberOfGenes, this.maxEmpty);
        }

        /// <summary>
        /// Creates a clone.
        /// </summary>
        /// <returns>The chromosome clone.</returns>
        public override IChromosome Clone()
        {
            return base.Clone();
        }
    }
}