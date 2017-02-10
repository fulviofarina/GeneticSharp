using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GADB
{
    public class Probabilities
    {
        public Probabilities(int MinPop, int MaxPop, float MutationProb, float CrossProb)
        {
            mutationProb = MutationProb;
            crossProb = CrossProb;
            minPop = MinPop;
            maxPop = MaxPop;

        }
        public float mutationProb, crossProb;
        public int minPop, maxPop;
    }
}
