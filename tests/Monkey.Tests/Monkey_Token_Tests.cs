using monkey;
using Xunit;

namespace Monkey.Tests
{
    public class Monkey_Token_Tests
    {
        [Fact]
        public void TestNextToken()
        {
            var lexer = new Lexer("== let x = \"name\";");
            var eq = lexer.NextToken();
            var let = lexer.NextToken();
            Assert.True(eq.Type == TokenType.EQ);
            Assert.True(let.Type == TokenType.LET);
        }
    }
}
