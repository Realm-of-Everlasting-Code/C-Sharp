using System;
using System.Collections.Generic;
using System.Text;

namespace Comments.Problem.Bad
{
    /// <summary>
    /// Problem: Sometimes we use magic values and comments to explain them.
    /// </summary>
    public class Salary
    {
        public double Calculate(float main)
        {
            // coeficient * taxes - mandatory pay.
            return 1 * 0.99 * main- 1;
        }
    }
}
