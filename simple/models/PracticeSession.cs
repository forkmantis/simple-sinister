using System;

namespace simple.models
{
    public class PracticeSession
    {
        public DateTime Date { get; set; }
        public string Title { get; set; }
        public string Handedness { get; set; }
        public string Notes { get; set; }
        public PracticeExercise Swings { get; set; }
        public PracticeExercise GetUps { get; set; }

        public PracticeSession()
        {
            Notes = String.Empty;
            Swings = new PracticeExercise();
            GetUps = new PracticeExercise();
        }
    }
}
