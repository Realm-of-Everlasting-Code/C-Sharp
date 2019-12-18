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
        public decimal Calculate(decimal main)
        {
            // -TaxFree *Insurance * Income tax .
            return 100 + (main- 100m) * 0.95m * 0.90m;
        }
    }
}
