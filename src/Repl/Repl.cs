using System;

namespace monkey
{
    public static class Repl
    {
        const string _PROMPT = ">> ";

        public static void Start()
        {
            Console.Write(_PROMPT);
            var line = Console.ReadLine();
            var lexer = new Lexer(line);

            for (var token = lexer.NextToken();token.Type != TokenType.EOF;token = lexer.NextToken())
            {
                Console.WriteLine($"Type: {token.Type},Literal: {token.Literal}");
            }
        }
    }
}
