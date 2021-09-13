namespace monkey.Ast
{
    public class Program
    {
        IStatement[] Statements { get; set; }

        public string TokenLiteral()
        {
            if (this.Statements.Length > 0)
            {
                return this.Statements[0].TokenLiteral();
            }
            else
            {
                return "";
            }
        }
    }

    public class LetStatement
    {
        public Token Token { get; set; }
        public Identifier Name { get; set; }
        public IExpression Value { get; set; }

        public void StatementNode() { }
        public string TokenLiteral() { return this.Token.Literal; }
    }

    public class Identifier
    {
        Token Token { get; set; }
        public string Value { get; set; }

        public void ExpressionNode() { }
        public string TokenLiteral() { return this.Token.Literal; }
    }

    public interface INode
    {
        string TokenLiteral();
    }

    public interface IStatement : INode
    {
        void StatementNode();
    }

    public interface IExpression : INode
    {
        void ExpressionNode();
    }
}
