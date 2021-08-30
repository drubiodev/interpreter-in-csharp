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
                case "true":
                    return TokenType.TRUE;
                case "false":
                    return TokenType.FALSE;
                case "if":
                    return TokenType.IF;
                case "else":
                    return TokenType.ELSE;
                case "return":
                    return TokenType.RETURN;
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