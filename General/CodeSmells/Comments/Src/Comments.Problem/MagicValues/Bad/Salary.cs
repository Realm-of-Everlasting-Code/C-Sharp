namespace Comments.Problem.MagicValues.Bad
{
    /// <summary>
    /// Problem: Sometimes we use magic values and comments to explain them.
    /// </summary>
    public class Salary
    {
        public decimal CalculateNet(decimal bruto)
        {
            // -TaxFree *Insurance * Income tax .
            return 100 + (bruto - 100m) * 0.95m * 0.90m;
        }
    }
}
