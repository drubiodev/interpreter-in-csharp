namespace monkey
{
    public class Token
    {
        public TokenType Type { get; set; }
        public string Literal { get; set; }

        public TokenType Keywords(string key)
        {
            switch (key)
            {
                case "fn":
                    return TokenType.FUNCTION;
                case "let":
                    return TokenType.LET;
                default:
                    return TokenType.IDENT;

            }
        }

        public TokenType LookupIndent(string literal)
        {
            return Keywords(literal);

        }
    }
}