namespace simple.models
{
    public class WorkPerformed
    {
        public int Sets { get; private set; }
        public int Reps { get; private set; }
        public int Weight { get; private set; }

        public WorkPerformed(int sets, int reps, int weight)
        {
            Sets = sets;
            Reps = reps;
            Weight = weight;
        }
    }
}
