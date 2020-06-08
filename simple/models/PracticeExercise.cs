using System.Collections.Generic;

namespace simple.models
{
    public class PracticeExercise
    {
        public List<WorkPerformed> WorkPerformed { get; protected set; }
        public int WorkCapacity { get; protected set; }

        public PracticeExercise()
        {
            WorkPerformed = new List<WorkPerformed>();
        }
    }
}
