using Comments.Problem.Magic_Values.Bad;
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
            var calculator = new Salary();
            
            var net = calculator.CalculateNet(bruto);

            net.Should().Be(expectedNet);
        }

        [Theory]
        [InlineData(untaxedSalary, untaxedSalary)]
        [InlineData(101, 100.855)]
        public void Good_Calculate_Salary_Returns_Net(decimal bruto, decimal expectedNet)
        {
            var calculator = new Magic_Values.Good.Salary();

            var net = calculator.CalculateNet(bruto);

            net.Should().Be(expectedNet);
        }
    }
}
