using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace Comments.Problem.Tests
{
    public class Sorting
    {
        [Theory]
        [MemberData(nameof(SortingInputAndResults))]
        public void Good_Unsorted_MergeSort_Returns_Sorted(List<int> unsorted, List<int> expectedSorted)
        {
            var sorted = Algorithm_Without_Explanation.Good.Sorting.MergeSort(unsorted);
            
            sorted.Should().BeEquivalentTo(expectedSorted);
        }

        [Theory]
        [MemberData(nameof(SortingInputAndResults))]
        public void Bad_Unsorted_MergeSort_Returns_Sorted(List<int> unsorted, List<int> expectedSorted)
        {
            var sorted = Algorithm_Without_Explanation.Bad.Sorting.MergeSort(unsorted);

            sorted.Should().BeEquivalentTo(expectedSorted);
        }

        public static IEnumerable<object[]> SortingInputAndResults = new []
        {
            new object[]
            {
                new List<int>(),
                new List<int>()
            },
            new object[]
            {
                new List<int> {1},
                new List<int> {1}
            },
            new object[]
            {
                new List<int> {1, 2},
                new List<int> {1, 2}
            },
            new object[]
            {
                new List<int> {2, 1},
                new List<int> {2, 1}
            },
            new object[]
            {
                new List<int> {2, 1, 3},
                new List<int> {1, 2, 3}
            },
        };
    }
}
