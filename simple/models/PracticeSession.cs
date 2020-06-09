using System;

namespace simple.models
{
    public class PracticeSession
    {
        public DateTime Date { get; private set; }
        public string Title { get; private set; }
        public string Handedness { get; private set; }
        public string Notes { get; private set; }
        public PracticeExercise Swings { get; private set; }
        public PracticeExercise GetUps { get; private set; }

        public PracticeSession(DateTime date, string title, string handedness, string notes)
        {
            Date = date;
            Title = title;
            Handedness = handedness;
            Notes = notes;
            Swings = new PracticeExercise();
            GetUps = new PracticeExercise();
        }
    }
}
