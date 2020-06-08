using System;
using System.Text.RegularExpressions;

namespace simple.models
{
    public class Parser
    {
        public PracticeSession Parse(string input)
        {
            Regex regex = new Regex(@"([0-9]{4}-[0-9]{2}-[0-9]{2})");
            Match match = regex.Match(input);

            var date = match.Groups[0].Value;

            var practiceSession = new PracticeSession() {
                Date = DateTime.Parse(date)
            };

            return practiceSession;
        }
    }
}
