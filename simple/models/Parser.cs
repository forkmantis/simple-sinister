using System;

namespace simple.models
{
    public class Parser
    {
        public PracticeSession Parse(string input)
        {
            var practiceSession = new PracticeSession() {
                Date = DateTime.Parse("2020-06-12")
            };

            return practiceSession;
        }
    }
}
