using GeneticSharp.Domain.Chromosomes;
using GeneticSharp.Domain.Randomizations;

namespace GADB
{
    
    public sealed class AChromosome : ChromosomeBase
    {

        private int numberOfGenes;

      

        /// <summary>
        ///
        /// </summary>
        /// <param name="sizeOfChromosome"></param>
        /// <param name="numOfGenes"></param>
        public AChromosome(int sizeOfChromosome, int numOfGenes) : base(sizeOfChromosome)
        {
            numberOfGenes = numOfGenes; // do I need the values? nope I think, only indexes

            for (int i = 0; i < sizeOfChromosome; i++)
            {
                ReplaceGene(i, GenerateGene(i));
            }
        }

      

        /// <summary>
        /// Generates the gene for the specified index.
        /// </summary>
        /// <returns>The gene.</returns>
        /// <param name="geneIndex">Gene index.</param>
        public override Gene GenerateGene(int geneIndex)
        {
            //makes 1 gene with a random index from 0 to m_values as MAX
            int randIndex = RandomizationProvider.Current.GetInt(0, this.Length);
            int extra = randIndex - numberOfGenes;
            if (extra >= 0) randIndex = -2;

            return new Gene(randIndex+1);
        }

        /// <summary>
        /// Creates a new chromosome using the same structure of this.
        /// </summary>
        /// <returns>The new chromosome.</returns>
        public override IChromosome CreateNew()
        {
            return new AChromosome(this.Length, numberOfGenes);
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