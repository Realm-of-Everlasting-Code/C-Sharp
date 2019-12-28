using System;
using System.Collections.Generic;
using System.Linq;

namespace Comments.Problem.Good.TooManyComments
{
    /// <summary>
    /// Problem: Enterprise code written with code blocks with comments rather than separated functions.
    /// Solution: Instead of commented code write functions. Instead of nested logic extract it into objects and their methods.
    /// </summary>
    public class BoozeDistributor
    {
        private readonly List<string> _boozeOrders = new List<string>() { "Order#1,Shampagne,1,Tom,2010-10-10,Lithuania Vilnius Seskines 6", "Order#2,Beer,10,Jay,2001-10-01,Lithuania Kaunas Studentu 12", "Order#3,Vodka,2,Sarah, 1994-05-25,Germany Hamburg XStreet 1" };
        // Compared to previous solution, this would not be as efficient, because we store more info than we need
        // (not just order name and the status). But if performance is not crucial, this can be left as is.
        // If performance is crucial, keep this as a dictionary of before (string,OrderStats).
        public List<Order> LastOrdersBatch { get; private set; }

        // Like this, we have a high level overview of what the function does.
        // We no longer are forced look through the whole function when we care only about a part of it.
        // As a developer, minimizing the scope you need to care about at the time is essential!
        // Code speaks for itself!
        public int Distribute()
        {
            LastOrdersBatch = ParseOrders();
            foreach (var order in LastOrdersBatch)
            {
                var isDrinkingAge = order.Person.Age >= 18;
                if (isDrinkingAge)
                {
                    SendOrder(order);
                }
                else
                {
                    CancelOrder(order);
                }
            }

            return 0;
        }

        // Functions should read like a book:
        // From highest level going down;
        // From first used function to last used function. 
        private List<Order> ParseOrders()
        {
            // The remark on split is not needed- code speaks for itself.
            return _boozeOrders.Select(o => o.Split(','))
                .Select(
                    o => new Order(
                        o[0],
                        o[1],
                        double.Parse(o[2]),
                        new Person(
                            o[3],
                            DateTime.Parse(o[4]),
                            o[5]
                        )
                    )
                ).ToList();
        }

        private static void CancelOrder(Order order)
        {
            var person = order.Person;

            Console.WriteLine($"Person {person.Name} cann't drink booze.");
            Console.WriteLine($"Order {order.Name} canceled.");
            // The remark on newline is not needed- code speaks for itself.
            Console.WriteLine();

            order.Status = OrderStatus.Canceled;
        }

        private static void SendOrder(Order order)
        {
            var person = order.Person;

            Console.WriteLine($"Person {person.Name} can drink booze.");
            Console.WriteLine($"Sending booze {order.Merch}x{order.Amount} to {person.Address}.");
            Console.WriteLine($"Order {order.Name} complete.");
            Console.WriteLine();

            order.Status = OrderStatus.Sent;
        }
    }
}
