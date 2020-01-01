namespace Comments.Problem.TooManyComments.Good
{
    /// <summary>
    /// We work with orders and people, so we might as well make concepts for each.
    /// </summary>
    public class Order
    {
        public string Name { get; }
        public string Merch { get; }
        public double Amount { get; }
        public Person Person { get; }
        public OrderStatus Status { get; set; }

        public Order(string name, string merch, double amount, Person person)
        {
            Name = name;
            Merch = merch;
            Amount = amount;
            Person = person;
            Status = OrderStatus.Unchecked;
        }
    }
}
