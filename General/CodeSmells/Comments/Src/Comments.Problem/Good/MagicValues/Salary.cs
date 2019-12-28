namespace Comments.Problem.Good.MagicValues
{
    /// <summary>
    /// Solution to <see cref="Bad.MagicValues.Salary"/>
    /// Instead of magic numbers and comments prefer to use named constants.
    /// </summary>
    public class Salary
    {
        public decimal Calculate(decimal main)
        {
            const decimal taxFree = 100;
            const decimal insurance = 0.95m;
            const decimal incomeTax = 0.90m;
            return taxFree + (main - taxFree) * insurance * incomeTax;
        }
    }
}
