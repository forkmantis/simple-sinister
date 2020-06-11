using System;
using System.Text.RegularExpressions;

namespace simple.models
{
    public class Parser
    {
        public PracticeSession Parse(string input)
        {
            Regex outerRegex = new Regex(@"([0-9]{4}-[0-9]{2}-[0-9]{2}) *wod: *(Pavel.*) (LR|T) ([^;]+);? ?(notes:.*)?$");
            Match match = outerRegex.Match(input);

            var date = match.Groups[1].Value;
            var title = match.Groups[2].Value;
            var handedness = match.Groups[3].Value;
            var workingSets = match.Groups[4].Value;
            var notes = match.Groups[5].Value;

            Regex innerRegex = new Regex(@" *([0-9]{1,2}) *x *([0-9]{1,2}) *@ *([0-9]{1,3})");
            Match innerMatch = innerRegex.Match(workingSets);
            
            var sets = Int32.Parse(innerMatch.Groups[1].Value);
            var reps = Int32.Parse(innerMatch.Groups[2].Value);
            var weight = Int32.Parse(innerMatch.Groups[3].Value);

            var practiceSession = new PracticeSession(DateTime.Parse(date), title, handedness, notes);
            practiceSession.Swings.WorkPerformed.Add(new WorkPerformed(sets, reps, weight));

            return practiceSession;
        }
    }
}
