namespace Test
{
    public class Query
    {
        public Book GetBook()
        {
           return new Book()
            {
                Title = "C# in depth",
                Author = new Author()
                {
                    Name = "John Wick",
                }
            };
        }
    }
}
