namespace Comments.Problem.Comments_Instead_of_SRP.Good
{
    /// <summary>
    /// For a defined set of values prefer to use a set of constants or better- enum.
    /// </summary>
    public enum OrderStatus
    {
        Unchecked,
        Sent,
        Canceled,
    }
}
