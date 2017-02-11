namespace GADB
{
    /// <summary>
    /// AUXILIAR CLASS TO STORE TEMPORARILY THE PREFERENCES
    /// </summary>
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