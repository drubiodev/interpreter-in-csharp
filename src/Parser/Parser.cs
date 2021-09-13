namespace monkey
{
    public class Parser
    {
        public Lexer Lexer { get; set; }
        public Token CurrentToken { get; set; }
        public Token PeekToken { get; set; }

        public Parser(Lexer lexer)
        {
            this.Lexer = lexer;

            // Read two tokens, so curent and peek are both set
            this.Lexer.NextToken();
            this.Lexer.NextToken();
        }

        public void NextToken()
        {
            this.CurrentToken = this.PeekToken;
            this.PeekToken = this.Lexer.NextToken();
        }

        public Ast.Program ParseProgram()
        {
            return null;
        }
    }
}
