namespace monkey
{
    class Program
    {
        static void Main(string[] args)
        {
            var x = new Lexer("== let x = \"name\";");
            var y = x.NextToken();
            System.Console.WriteLine(y.Literal);
            System.Console.WriteLine(y.Type);
        }
    }
}
