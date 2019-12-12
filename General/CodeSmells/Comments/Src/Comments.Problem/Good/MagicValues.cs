using Comments.Problem.Bad;

namespace Comments.Problem.Good
{
    /// <summary>
    /// Solution to <see cref="Bad.Salary"/>
    /// Instead of magic numbers and comments prefer to use named constants.
    /// </summary>
    public class Salary
    {
        public double Calculate(float main)
        {
            // coeficient * multiplier * taxes - mandatory pay.
            return 1 * 0.99 * main - 1;
        }
    }
}
