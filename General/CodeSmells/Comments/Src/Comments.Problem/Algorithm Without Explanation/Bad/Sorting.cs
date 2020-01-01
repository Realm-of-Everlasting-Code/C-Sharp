using System.Collections.Generic;
using System.Linq;

namespace Comments.Problem.Algorithm_Without_Explanation.Bad
{
    /// <summary>
    /// Problem: Complex logic not explained in comments.
    /// </summary>
    public class Sorting
    {
        public static List<int> MergeSort(List<int> unsorted)
        {
            if (unsorted.Count <= 1) return unsorted;

            var left = new List<int>();
            var right = new List<int>();

            var middle = unsorted.Count / 2;
            for (var i = 0; i < middle; i++)
            {
                left.Add(unsorted[i]);
            }
            for (var i = middle; i < unsorted.Count; i++)
            {
                right.Add(unsorted[i]);
            }

            left = MergeSort(left);
            right = MergeSort(right);
            return Merge(left, right);
        }

        private static List<int> Merge(List<int> left, List<int> right)
        {
            var result = new List<int>();

            while (left.Any() || right.Any())
            {
                if (left.Any() && right.Any())
                {
                    if (left.First() <= right.First())
                    {
                        result.Add(left.First());
                        left.Remove(left.First());
                    }
                    else
                    {
                        result.Add(right.First());
                        right.Remove(right.First());
                    }
                }
                else if (left.Any())
                {
                    result.Add(left.First());
                    left.Remove(left.First());
                }
                else if (right.Any())
                {
                    result.Add(right.First());
                    right.Remove(right.First());
                }
            }
            return result;
        }
    }
}
