using System;
using Xunit;
using simple.models;
using FluentAssertions;

namespace simple.tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            // Arrange
            var parser = new Parser();
            string foo = "2020-05-03 wod: Pavel Timeless Simple LR 10x10 @ 45#;";

            var expected = new PracticeSession(DateTime.Parse("2020-05-03"), "Pavel Timeless Simple", "LR", String.Empty);
            expected.Swings.WorkPerformed.Add(new WorkPerformed(10, 10, 45));

            // Act
            var output = parser.Parse(foo);

            // Assert
            output.Should().BeEquivalentTo(expected);
        }
    }
}
