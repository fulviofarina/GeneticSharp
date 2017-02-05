﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using HelperSharp;

namespace GeneticSharp.Domain.Chromosomes
{
    /// <summary>
    /// A base class for chromosomes.
    /// </summary>
    [DebuggerDisplay("Fitness:{Fitness}, Genes:{Length}, GenesAsInts:{GenesAsInts}")]
    [Serializable]
	public abstract class ChromosomeBase : IChromosome
    {
        #region Fields
        private Gene[] m_genes;
        private int m_length;
        #endregion

        #region Constructors        
        /// <summary>
        /// Initializes a new instance of the <see cref="ChromosomeBase"/> class.
        /// </summary>
        /// <param name="length">The length, in genes, of the chromosome.</param>
        protected ChromosomeBase(int length)
        {
            ValidateLength(length);

            m_length = length;
            m_genes = new Gene[length];
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the fitness of the chromosome in the current problem.
        /// </summary>
        public double? Fitness { get; set; }


       
        
        /// <summary>
        /// Gets the length, in genes, of the chromosome.
        /// </summary>
        public int Length
        {
            get
            {
                return m_length;
            }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Implements the operator ==.
        /// </summary>
        /// <param name="first">The first.</param>
        /// <param name="second">The second.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static bool operator ==(ChromosomeBase first, ChromosomeBase second)
        {
            if (Object.ReferenceEquals(first, second))
            {
                return true;
            }

            if (((object)first == null) || ((object)second == null))
            {
                return false;
            }

            return first.CompareTo(second) == 0;
        }

        /// <summary>
        /// Implements the operator !=.
        /// </summary>
        /// <param name="first">The first.</param>
        /// <param name="second">The second.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static bool operator !=(ChromosomeBase first, ChromosomeBase second)
        {
            return !(first == second);
        }

        /// <summary>
        /// Implements the operator &lt;.
        /// </summary>
        /// <param name="first">The first.</param>
        /// <param name="second">The second.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static bool operator <(ChromosomeBase first, ChromosomeBase second)
        {
            if (Object.ReferenceEquals(first, second))
            {
                return false;
            }
            else if ((object)first == null)
            {
                return true;
            }
            else if ((object)second == null)
            {
                return false;
            }

            return first.CompareTo(second) < 0;
        }

        /// <summary>
        /// Implements the operator &gt;.
        /// </summary>
        /// <param name="first">The first.</param>
        /// <param name="second">The second.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static bool operator >(ChromosomeBase first, ChromosomeBase second)
        {
            return !(first == second) && !(first < second);
        }

        /// <summary>
        /// Generates the gene for the specified index.
        /// </summary>
        /// <param name="geneIndex">Gene index.</param>
        /// <returns>The gene generated at the specified index.</returns>
        public abstract Gene GenerateGene(int geneIndex);

        /// <summary>
        /// Creates a new chromosome using the same structure of this.
        /// </summary>
        /// <returns>The new chromosome.</returns>
        public abstract IChromosome CreateNew();

        /// <summary>
        /// Creates a clone.
        /// </summary>
        /// <returns>The chromosome clone.</returns>
        public virtual IChromosome Clone()
        {
            var clone = CreateNew();
            clone.ReplaceGenes(0, GetGenes());
            clone.Fitness = Fitness;

            return clone;
        }

        /// <summary>
        /// Replaces the gene in the specified index.
        /// </summary>
        /// <param name="index">The gene index to replace.</param>
        /// <param name="gene">The new gene.</param>
        /// <exception cref="System.ArgumentOutOfRangeException">index;There is no Gene on index {0} to be replaced..With(index)</exception>
        public void ReplaceGene(int index, Gene gene)
        {
            if (index < 0 || index >= m_length)
            {
                throw new ArgumentOutOfRangeException("index", "There is no Gene on index {0} to be replaced.".With(index));
            }

            m_genes[index] = gene;
            Fitness = null;
        }

        /// <summary>
        /// Replaces the genes starting in the specified index.
        /// </summary>
        /// <param name="startIndex">Start index.</param>
        /// <param name="genes">The genes.</param>
        /// <remarks>
        /// The genes to be replaced can't be greater than the available space between the start index and the end of the chromosome.
        /// </remarks>
        public void ReplaceGenes(int startIndex, Gene[] genes)
        {
            ExceptionHelper.ThrowIfNull("genes", genes);

            if (genes.Length > 0)
            {
                if (startIndex < 0 || startIndex >= m_length)
                {
                    throw new ArgumentOutOfRangeException("index", "There is no Gene on index {0} to be replaced.".With(startIndex));
                }

                var genesToBeReplacedLength = genes.Length;

                var availableSpaceLength = m_length - startIndex;

                if (genesToBeReplacedLength > availableSpaceLength)
                {
                    throw new ArgumentException(
                        "genes", "The number of genes to be replaced is greater than available space, there is {0} genes between the index {1} and the end of chromosome, but there is {2} genes to be replaced.".With(availableSpaceLength, startIndex, genesToBeReplacedLength));
                }

                Array.Copy(genes, 0, m_genes, startIndex, genes.Length);

                Fitness = null;
            }
        }

        /// <summary>
        /// Resizes the chromosome to the new length.
        /// </summary>
        /// <param name="newLength">The new length.</param>
        public void Resize(int newLength)
        {
            ValidateLength(newLength);

            Array.Resize(ref m_genes, newLength);
            m_length = newLength;
        }

        /// <summary>
        /// Gets the gene in the specified index.
        /// </summary>
        /// <param name="index">The gene index.</param>
        /// <returns>
        /// The gene.
        /// </returns>
        public Gene GetGene(int index)
        {
            return m_genes[index];
        }

        /// <summary>
        /// Gets the genes.
        /// </summary>
        /// <returns>The genes.</returns>
        public Gene[] GetGenes()
        {
            return m_genes;
        }

        /// <summary>
        /// Compares the current object with another object of the same type.
        /// </summary>
        /// <returns>The to.</returns>
        /// <param name="other">The other chromosome.</param>
        public int CompareTo(IChromosome other)
        {
            if (other == null)
            {
                return -1;
            }

            var otherFitness = other.Fitness;

            if (Fitness == otherFitness)
            {
                return 0;
            }

            // TODO: chromosomes with same fitnesss are really equals?
            return Fitness > otherFitness ? 1 : -1;
        }

        /// <summary>
        /// Determines whether the specified <see cref="System.Object"/> is equal to the current <see cref="GeneticSharp.Domain.Chromosomes.ChromosomeBase"/>.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object"/> to compare with the current <see cref="GeneticSharp.Domain.Chromosomes.ChromosomeBase"/>.</param>
        /// <returns><c>true</c> if the specified <see cref="System.Object"/> is equal to the current
        /// <see cref="GeneticSharp.Domain.Chromosomes.ChromosomeBase"/>; otherwise, <c>false</c>.</returns>
        public override bool Equals(object obj)
        {
            var other = obj as IChromosome;

            if (other == null)
            {
                return false;
            }

            return CompareTo(other) == 0;
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
        /// </returns>
        public override int GetHashCode()
        {
            return Fitness.GetHashCode();
        }

        /// <summary>
        /// Creates the gene on specified index.
        /// <remarks>
        /// It's a shortcut to:  
        /// <code>
        /// ReplaceGene(index, GenerateGene(index));
        /// </code>
        /// </remarks>
        /// </summary>
        /// <param name="index">The gene index.</param>
        protected virtual void CreateGene(int index)
        {
            ReplaceGene(index, GenerateGene(index));
        }

        /// <summary>
        /// Creates all genes
        /// <remarks>
        /// It's a shortcut to: 
        /// <code>
        /// for (int i = 0; i &lt; Length; i++)
        /// {
        ///     ReplaceGene(i, GenerateGene(i));
        /// }
        /// </code>
        /// </remarks>
        /// </summary>        
        protected virtual void CreateGenes()
        {
            for (int i = 0; i < Length; i++)
            {
                ReplaceGene(i, GenerateGene(i));
            }
        }

        /// <summary>
        /// Validates the length.
        /// </summary>
        /// <param name="length">The length.</param>
        /// <exception cref="System.ArgumentException">The minimum length for a chromosome is 2 genes.</exception>
        private static void ValidateLength(int length)
        {
            if (length < 2)
            {
                throw new ArgumentException("The minimum length for a chromosome is 2 genes.");
            }
        }
        #endregion      
    }
}
