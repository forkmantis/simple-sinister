using System;
using Xunit;
using simple.models;
using FluentAssertions;

namespace simple.tests
{
    public class ParserShould
    {
        [Theory]
        [InlineData("2020-05-03 wod: Pavel Timeless Simple LR 10x10 @ 45#;")]
        [InlineData("2020-05-03 wod: Pavel Timeless Simple LR 10 x 10 @ 45#;")]
        [InlineData("2020-05-03 wod: Pavel Timeless Simple LR 10x10@45#;")]
        public void Parse_Valid_Single_Set(string input)
        {
            // Arrange
            var parser = new Parser();

            var expected = new PracticeSession(DateTime.Parse("2020-05-03"), "Pavel Timeless Simple", "LR", String.Empty);
            expected.Swings.WorkPerformed.Add(new WorkPerformed(10, 10, 45));

            // Act
            var output = parser.Parse(input);

            // Assert
            output.Should().BeEquivalentTo(expected);
        }
    }
}
