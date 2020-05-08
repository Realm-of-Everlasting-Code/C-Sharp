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

        private static List<int> Merge(List<int> left, List<int> right)
        {
            var result = new List<int>();
            
            var eitherSideHasElements = left.Any() || right.Any()
            while (isEitherSideWithElements)
            {
                var bothSidesHaveElements = left.Any() && right.Any();
                if (isBothSidesWithElements)
                {
                    MergeFirstElement(left, right, result);
                }
                else
                {
                    MergeRemainingElement(left, right, result);
                }
            }
            return result;
        }
        
        private static void MergeFirstElement(List<int> left, List<int> right, List<int> result)
        {
           var biggerHalf =  left.First() <= right.First() 
                                      ? left 
                                      : right;
                    
                    result.Add(biggerHalf.First());
                    biggerHalf.Remove(biggerHalf .First());
        }
        
        private static void MergeRemainingElement(List<int> left, List<int> right, List<int> result)
        {
            var halfWithElements = right.Any() ? right : left;
                    result.Add(halfWithElements.First());
                    halfWithElements.Remove(halfWithElements.First());
        }
    }
}
