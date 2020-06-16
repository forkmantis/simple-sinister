using FluentAssertions;
using Newtonsoft.Json;
using System;
using Xunit;
using simple.models;

namespace simple.tests
{
    public class ParserShould
    {
        [Theory]
        [InlineData("2020-05-03 wod: Pavel Timeless Simple LR 10x10 @ 45#;")]
        [InlineData("2020-05-03 wod: Pavel Timeless Simple LR 10 x 10 @ 45#;")]
        [InlineData("2020-05-03 wod: Pavel Timeless Simple LR 10x10@45#;")]
        public void Parse_Valid_Single_Set_Without_Notes(string input)
        {
            // Arrange
            var parser = new Parser();

            var expected = new PracticeSession() {
                Date = DateTime.Parse("2020-05-03"), 
                Title = "Pavel Timeless Simple", 
                Handedness = "LR"
            };
            expected.Swings.WorkPerformed.Add(new WorkPerformed() {Sets = 10, Reps = 10, Weight = 45});
            expected.GetUps.WorkPerformed.Add(new WorkPerformed() {Sets = 10, Reps = 1, Weight = 45});

            Console.WriteLine(JsonConvert.SerializeObject(expected, Formatting.Indented));

            // Act
            var output = parser.Parse(input);

            // Assert
            output.Should().BeEquivalentTo(expected);
        }

        [Theory]
        [InlineData("2020-05-04 wod: Pavel Timeless Simple T 10x10 @ 53#; notes: I didn't get much sleep the night before;")]
        public void Parse_Valid_Single_Set_With_Notes(string input)
        {
            // Arrange
            var parser = new Parser();

            var expected = new PracticeSession() {
                Date = DateTime.Parse("2020-05-04"), 
                Title = "Pavel Timeless Simple", 
                Handedness = "T",
                Notes =  "I didn't get much sleep the night before"
            };
            expected.Swings.WorkPerformed.Add(new WorkPerformed() {Sets = 10, Reps = 10, Weight = 53});
            expected.GetUps.WorkPerformed.Add(new WorkPerformed() {Sets = 10, Reps = 1, Weight = 53});

            // Act
            var output = parser.Parse(input);

            // Assert
            output.Should().BeEquivalentTo(expected);
        }
    }
}
