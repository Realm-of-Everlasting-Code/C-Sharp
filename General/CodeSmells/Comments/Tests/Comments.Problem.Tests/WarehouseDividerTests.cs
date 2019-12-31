using System.Collections.Generic;
using System.Linq;
using Comments.Problem.TooManyComments.Good;
using FluentAssertions;
using Xunit;

namespace Comments.Problem.Tests
{
    public class WarehouseDividerTests
    {
        [Fact]
        public void Good_Test()
        {
            var distributor = new BoozeDistributor();
            
            distributor.Distribute();

            var orders = distributor.LastOrdersBatch;
            orders.Count(o => o.Status == OrderStatus.Canceled).Should().Be(1);
            orders.Count(o => o.Status == OrderStatus.Sent).Should().Be(2);
            orders.Count(o => o.Status == OrderStatus.Unchecked).Should().Be(0);
        }

        [Fact]
        public void Bad_Test()
        {
            var distributor = new TooManyComments.Bad.BoozeDistributor();

            distributor.Distribute();

            var statuses = distributor.LastOrdersBatch.Values;
            statuses.Count(s => s == "Canceled").Should().Be(1);
            statuses.Count(s => s == "Sent").Should().Be(2);
            statuses.Count(s => s == "Unchecked").Should().Be(0);
        }
    }
}
