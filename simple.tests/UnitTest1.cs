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
            var parser = new Parser();
            string foo = "2020-05-03 wod: Pavel Timeless Simple LR 10x10 @ 45#;";

            var expected = new PracticeSession() {
                Date = DateTime.Parse("2020-06-12")
            };

            var output = parser.Parse(foo);

            Assert.Equal(expected.Date, output.Date);
        }
    }
}
