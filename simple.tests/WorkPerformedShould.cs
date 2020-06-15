using System;
using Xunit;
using simple.models;
using FluentAssertions;

namespace simple.tests
{
    public class WorkPerformedShould
    {
        [Theory]
        [InlineData(10, 10, 35, 3500)]
        [InlineData(10, 1, 35, 350)]
        public void Calculate_Correct_WorkCapacity_With_Single_Set(int sets, int reps, int weight, int expected)
        {
            // Arrange
            var practiceExercise = new PracticeExercise();
            var workPerformed = new WorkPerformed(sets, reps, weight); 
 
            // Act
            practiceExercise.WorkPerformed.Add(workPerformed);

            // Assert
            practiceExercise.WorkCapacity.Should().Be(expected);
        }

        [Fact]
        public void Calculate_Correct_WorkCapacity_With_Double_Set()
        {
            // Arrange
            var practiceExercise = new PracticeExercise();
 
            // Act
            practiceExercise.WorkPerformed.Add(new WorkPerformed(2, 10, 53));
            practiceExercise.WorkPerformed.Add(new WorkPerformed(8, 10, 35));

            // Assert
            practiceExercise.WorkCapacity.Should().Be(3860);
        }
    }
}
