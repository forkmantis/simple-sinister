using FluentAssertions;
using Newtonsoft.Json;
using System.IO;
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
            PracticeSession expected = JsonConvert.DeserializeObject<PracticeSession>(
                File.ReadAllText("test-data/01-single-scheme-output.json")
            );

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
            PracticeSession expected = JsonConvert.DeserializeObject<PracticeSession>(
                File.ReadAllText("test-data/03-single-scheme-with-notes-output.json")
            );

            // Act
            var output = parser.Parse(input);

            // Assert
            output.Should().BeEquivalentTo(expected);
        }
    }
}
