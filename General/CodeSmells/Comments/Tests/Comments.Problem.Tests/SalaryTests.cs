using FluentAssertions;
using Xunit;
using bad= Comments.Problem.Bad;
using good = Comments.Problem.Good;

namespace Comments.Problem.Tests
{
    public class SalaryTests
    {
        [Fact]
        public void Bad_Calculate_Salary_Should_Return_Expected()
        {
            var calculator = new bad.Salary();
            
            var salary = calculator.Calculate(100);

            salary.Should().Be(98);
        }

        [Fact]
        public void Good_Calculate_Salary_Should_Return_Expected()
        {
            var calculator = new good.Salary();

            var salary = calculator.Calculate(100);

            salary.Should().Be(98);
        }
    }
}
