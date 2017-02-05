using GeneticSharp.Domain.Chromosomes;
using GeneticSharp.Domain.Randomizations;

namespace GeneticSharp.Extensions.Knapsack
{
    /// <summary>
    /// Ghostwriter chromosome.
    /// </summary>
    public sealed class KnapsackChromosome : ChromosomeBase
    {
        #region Fields

        private int m_values;
        //  private IList<double> m_weights;
        // private  int m_size;

        //private IList<string> m_words;

        #endregion Fields

        #region Constructors

        /// <summary>
        ///
        /// </summary>
        /// <param name="size"></param>
        /// <param name="values"></param>
        public KnapsackChromosome(int size, int values) : base(size)
        {
            m_values = values; // do I need the values? nope I think, only indexes

            for (int i = 0; i < size; i++)
            {
                ReplaceGene(i, GenerateGene(i));
            }
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Generates the gene for the specified index.
        /// </summary>
        /// <returns>The gene.</returns>
        /// <param name="geneIndex">Gene index.</param>
        public override Gene GenerateGene(int geneIndex)
        {
            //makes 1 gene with a random index from 0 to m_values as MAX
            int randIndex = RandomizationProvider.Current.GetInt(0, this.Length);
            int extra = randIndex - m_values;
            if (extra >= 0) randIndex = -1;

            return new Gene(randIndex);
        }

        /// <summary>
        /// Creates a new chromosome using the same structure of this.
        /// </summary>
        /// <returns>The new chromosome.</returns>
        public override IChromosome CreateNew()
        {
            return new KnapsackChromosome(this.Length, m_values);
        }

        /// <summary>
        /// Creates a clone.
        /// </summary>
        /// <returns>The chromosome clone.</returns>
        public override IChromosome Clone()
        {
            return base.Clone();
        }

        /// <summary>
        /// Gets the text.
        /// </summary>
        /// <returns>The text.</returns>

        #endregion Methods
    }
}