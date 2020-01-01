namespace Comments.Problem.Magic_Values.Good
{
    /// <summary>
    /// Solution to <see cref="Bad.Salary"/>
    /// Instead of magic numbers and comments prefer to use named constants.
    /// </summary>
    public class Salary
    {
        public decimal CalculateNet(decimal bruto)
        {
            const decimal taxFree = 100;
            const decimal insurance = 0.95m;
            const decimal incomeTax = 0.90m;
            return taxFree + (bruto - taxFree) * insurance * incomeTax;
        }
    }
}
