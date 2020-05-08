using System;
using System.Collections.Generic;
using System.Linq;

namespace Comments.Problem.Algorithm_Without_Explanation.Good
{
    /// <summary>
    /// Solution to <see cref="Bad.Sorting"/>
    /// In most cases the complexity is what developers create.
    /// The answer still lies in dividing and simplifying the complexity.
    /// If done right, each part is trivial enough and does not require comments.
    /// </summary>
    public class Sorting
    {
        public static List<int> MergeSort(List<int> unsorted)
        {
            var canSplit = unsorted.Count > 1;
            if (!canSplit) return unsorted;

            var (left, right) = SplitInHalf(unsorted);
            left = MergeSort(left);
            right = MergeSort(right);

            return Merge(left, right);
        }

        private static List<int> Merge(List<int> left, List<int> right)
        {
            var result = new List<int>();

            bool EitherSideHasElements() => left.Any() || right.Any();
            while (EitherSideHasElements())
            {
                MoveBiggerElementToResult(left, right, result);
            }
            return result;
        }

        private static void MoveBiggerElementToResult(List<int> left, List<int> right, List<int> result)
        {
            var bothSidesHaveElements = left.Any() && right.Any();
            if (bothSidesHaveElements)
            {
                MoveFirstBiggerElementToResult(left, right, result);
            }
            else
            {
                MoveRemainingElementToResult(left, right, result);
            }
        }

        private static void MoveFirstBiggerElementToResult(List<int> left, List<int> right, List<int> result)
        {
            var biggerHalf = left[0] <= right[0]
                             ? left
                             : right;

            result.Add(biggerHalf[0]);
            biggerHalf.Remove(biggerHalf[0]);
        }

        private static void MoveRemainingElementToResult(List<int> left, List<int> right, List<int> result)
        {
            var halfWithElements = right.Any()
                                   ? right
                                   : left;

            result.Add(halfWithElements[0]);
            halfWithElements.Remove(halfWithElements[0]);
        }

        private static (List<int>, List<int>) SplitInHalf(List<int> numbers)
        {
            var left = new List<int>();
            var right = new List<int>();

            var middle = numbers.Count / 2;
            for (var i = 0; i < middle; i++)
            {
                left.Add(numbers[i]);
            }

            for (var i = middle; i<numbers.Count; i++)
            {
                right.Add(numbers[i]);
            }

            return (left, right);
        }
    }
}
