using FluentAssertions;
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

            var expected = new PracticeSession(DateTime.Parse("2020-05-03"), "Pavel Timeless Simple", "LR", String.Empty);
            expected.Swings.WorkPerformed.Add(new WorkPerformed(10, 10, 45));
            expected.GetUps.WorkPerformed.Add(new WorkPerformed(10, 1, 45));

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

            var expected = new PracticeSession(DateTime.Parse("2020-05-04"), "Pavel Timeless Simple", "T", "I didn't get much sleep the night before");
            expected.Swings.WorkPerformed.Add(new WorkPerformed(10, 10, 53));
            expected.GetUps.WorkPerformed.Add(new WorkPerformed(10, 1, 53));

            // Act
            var output = parser.Parse(input);

            // Assert
            output.Should().BeEquivalentTo(expected);
        }
    }
}
