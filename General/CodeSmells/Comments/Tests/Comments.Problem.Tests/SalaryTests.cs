using FluentAssertions;
using Xunit;

namespace Comments.Problem.Tests
{
    public class SalaryTests
    {
        private const int untaxedSalary = 100;

        [Theory]
        [InlineData(untaxedSalary, untaxedSalary)]
        [InlineData(101, 100.855)]
        public void Bad_Calculate_Salary_Returns_Net(decimal bruto, decimal expectedNet)
        {
            var calculator = new Bad.MagicValues.Salary();
            
            var net = calculator.Calculate(bruto);

            net.Should().Be(expectedNet);
        }

        [Theory]
        [InlineData(untaxedSalary, untaxedSalary)]
        [InlineData(101, 100.855)]
        public void Good_Calculate_Salary_Returns_Net(decimal bruto, decimal expectedNet)
        {
            var calculator = new Good.MagicValues.Salary();

            var net = calculator.Calculate(bruto);

            net.Should().Be(expectedNet);
        }
    }
}
