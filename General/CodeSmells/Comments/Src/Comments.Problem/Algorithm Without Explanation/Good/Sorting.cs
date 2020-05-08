using System.Collections.Generic;
using System.Linq;

namespace Comments.Problem.Algorithm_Without_Explanation.Good
{
    /// <summary>
    /// Solution to <see cref="Bad.Sorting"/>
    /// In algorithms or other complex functions, splitting code made not make as much sense.
    /// It's really hard to express yourself with self documenting code when implementing algorithms.
    /// In those cases code is not enough and a comment is needed to explain the logic better.
    /// </summary>
    public class Sorting
    {
        /// <summary>
        /// Sorts a given list of numbers using merge sort algorithm.
        /// Algorithm: split collection into 2 parts left or right from the middle.
        /// Recursively repeat the step until there is nothing left to split.
        /// Then merge both sides presuming that both of them are sorted.
        /// </summary>
        /// <param name="unsorted">Unsorted set of integers.</param>
        /// <returns>Sorted list of integers</returns>
        public static List<int> MergeSort(List<int> unsorted)
        {
            // Exit condition- stops going deeper.
            var canSplit = unsorted.Count > 1;
            if (!canSplit) return unsorted;

            // Split collection into 2 parts left and right of the middle point.
            var left = new List<int>();
            var right = new List<int>();

            var middle = unsorted.Count / 2;
            // Left side. Might be equal to right or +1.
            for (var i = 0; i < middle; i++)
            {
                left.Add(unsorted[i]);
            }
            // Right side.
            for (var i = middle; i < unsorted.Count; i++)
            {
                right.Add(unsorted[i]);
            }

            // Split unsorted sides until 1 item is left (create many branches).
            left = MergeSort(left);
            right = MergeSort(right);
            // Merge the branches 1 depth at the time until result emerges.
            return Merge(left, right);
        }

        /// <summary>
        /// Merge left and right sides split in middle.
        /// </summary>
        /// <param name="left">Sorted list left of middle.</param>
        /// <param name="right">Sorted list right of middle.</param>
        /// <returns>Merged and sorted list of integers</returns>
        private static List<int> Merge(List<int> left, List<int> right)
        {
            var result = new List<int>();

            while (left.Any() || right.Any())
            {
                if (left.Any() && right.Any())
                {
                    MergeFirstElement(left, right, result);
                }
                // To cover the case when one side has no more elements but the other one still has.
                // Don't mix this with the previous note that one side might have +1 elements compared to other.
                // Merge might have a scenario where all the big elements are on the left side or the right side.
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
        
        private static List<int> MergeFirstElement(List<int> left, List<int> right, List<int> result)
        {
           var biggerHalf =  left.First() <= right.First() 
                                      ? left 
                                      : right;
                    
                    result.Add(biggerHalf.First());
                    biggerHalf.Remove(biggerHalf .First());
        }
    }
}
