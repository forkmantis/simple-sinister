using System.Collections.Generic;
using System.Linq;

namespace simple.models
{
    public class PracticeExercise
    {
        public List<WorkPerformed> WorkPerformed { get; protected set; }
        public int WorkCapacity 
        {
            get { return WorkPerformed.Sum(x => x.Reps * x.Sets * x.Weight); }
        }

        public PracticeExercise()
        {
            WorkPerformed = new List<WorkPerformed>();
        }
    }
}
