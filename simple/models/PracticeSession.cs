using System;

namespace simple.models
{
    public class PracticeSession
    {
        public DateTime Date { get; set; }
        public string Title { get; set; }
        public PracticeExercise Swings { get; set; }
        public PracticeExercise GetUps { get; set; }
    }
}
