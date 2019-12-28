using System;
using System.Collections.Generic;

namespace Comments.Problem.Bad.TooManyComments
{
    /// <summary>
    /// Problem: Enterprise code written with code blocks with comments rather than separated functions.
    /// </summary>
    public class BoozeDistributor
    {
        private readonly List<string> _boozeOrders = new List<string>() {"Order#1,Shampagne,1,Tom,2010-10-10,Lithuania Vilnius Seskines 6", "Order#2,Beer,10,Jay,2001-10-01,Lithuania Kaunas Studentu 12", "Order#3,Vodka,2,Sarah, 1994-05-25,Germany Hamburg XStreet 1"};
        
        // Order status can be either unchedked, sent and canceled.
        // Default status is uncheked.
        public IDictionary<string, string> LastBatchStatuses { get; } = new Dictionary<string, string>();

        // Distributes booze
        public void Distribute()
        {
            foreach (var orderData in _boozeOrders)
            {
                // Split order parts 
                var orderParts = orderData.Split(',');

                // Parse order
                var orderName = orderParts[0];
                var merchName = orderParts[1];
                var amount = double.Parse(orderParts[2]);

                // Parse person
                var personName = orderParts[3];
                var personBday = DateTime.Parse(orderParts[4]);
                var personAddress = orderParts[5];

                LastBatchStatuses.Add(orderName, "Unchecked");

                // Can drink alcohol?
                Console.WriteLine("Checking data...");
                if ((DateTime.Now - personBday).TotalDays / 365 >= 18)
                {
                    // Send booze
                    Console.WriteLine($"Person {personName} can drink booze.");
                    Console.WriteLine($"Sending booze {merchName}x{amount} to {personAddress}.");
                    Console.WriteLine($"Order {orderName} complete.");
                    // Newline
                    Console.WriteLine();

                    LastBatchStatuses[orderName] = "Sent";
                }
                else
                {
                    // Cancel order
                    Console.WriteLine($"Person {personName} cann't drink booze.");
                    Console.WriteLine($"Order {orderName} canceled.");
                    // Newline
                    Console.WriteLine();

                    LastBatchStatuses[orderName] = "Canceled";
                }
            }
        }
    }
}
