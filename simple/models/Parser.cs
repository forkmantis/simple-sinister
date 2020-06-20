using System;
using System.Text.RegularExpressions;

namespace simple.models
{
    public class Parser
    {
        public PracticeSession Parse(string input)
        {
            Regex outerRegex = new Regex(@"([0-9]{4}-[0-9]{2}-[0-9]{2}) *wod: *(Pavel.*) (LR|T) ([^;]+);? ?(notes: *([^;]+);)?$");
            Match match = outerRegex.Match(input);

            var date = match.Groups[1].Value;
            var title = match.Groups[2].Value;
            var handedness = match.Groups[3].Value;
            var workingSets = match.Groups[4].Value;
            var notes = match.Groups[6].Value;

            var practiceSession = new PracticeSession() {
                Date = DateTime.Parse(date), 
                Title = title, 
                Handedness = handedness, 
                Notes = notes
            };

            foreach (string workingSet in workingSets.Split(','))
            {
                Regex innerRegex = new Regex(@" *([0-9]{1,2}) *x *([0-9]{1,2}) *@ *([0-9]{1,3})");
                Match innerMatch = innerRegex.Match(workingSet);

                var sets = Int32.Parse(innerMatch.Groups[1].Value);
                var swingReps = Int32.Parse(innerMatch.Groups[2].Value);
                var getUpReps = swingReps / 10;
                var weight = Int32.Parse(innerMatch.Groups[3].Value);

                practiceSession.Swings.WorkPerformed.Add(new WorkPerformed() { Sets = sets, Reps = swingReps, Weight = weight});
                practiceSession.GetUps.WorkPerformed.Add(new WorkPerformed() { Sets = sets, Reps = getUpReps, Weight = weight});
            }

            return practiceSession;
        }
    }
}
