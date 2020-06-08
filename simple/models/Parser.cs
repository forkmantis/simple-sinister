using System;
using System.Text.RegularExpressions;

namespace simple.models
{
    public class Parser
    {
        public PracticeSession Parse(string input)
        {
            Regex regex = new Regex(@"([0-9]{4}-[0-9]{2}-[0-9]{2}) *wod: *(Pavel.*) (LR|T)");
            Match match = regex.Match(input);

            var date = match.Groups[1].Value;
            var title = match.Groups[2].Value;
            var handedness = match.Groups[3].Value;

            var practiceSession = new PracticeSession(DateTime.Parse(date), title, handedness);

            return practiceSession;
        }
    }
}
