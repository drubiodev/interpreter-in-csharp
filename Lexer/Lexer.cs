using System;

namespace monkey
{
    public class Lexer
    {
        public string Input { get; set; }
        public int Position { get; set; }
        public int ReadPosition { get; set; }
        public Nullable<char> Ch { get; set; }

        public Lexer(string input)
        {
            this.Input = input;
            this.ReadChar();
        }

        public void ReadChar()
        {
            if (this.ReadPosition >= this.Input.Length)
            {
                this.Ch = null;
            }
            else
            {
                this.Ch = this.Input[this.ReadPosition];
            }

            this.Position = this.ReadPosition;
            this.ReadPosition += 1;
        }

        public Token NewToken(TokenType tokenType, Nullable<char> ch)
        {
            return new Token { Type = tokenType, Literal = ch.ToString() };
        }

        public bool IsLetter(char ch)
        {
            return 'a' <= ch && ch <= 'z' || 'A' <= ch && ch <= 'Z' || ch == '_';
        }

        public string ReadIdentifier()
        {
            int position = this.Position;

            while (this.Ch.HasValue && IsLetter(this.Ch.Value))
            {
                ReadChar();
            }
            return this.Input.Substring(position, this.Position);
        }

        public Token NextToken()
        {
            var token = new Token();

            SkipWhiteSpace();

            switch (this.Ch)
            {
                case '=':
                    token = NewToken(TokenType.ASSIGN, this.Ch);
                    break;
                case ';':
                    token = NewToken(TokenType.SEMICOLON, this.Ch);
                    break;
                case '(':
                    token = NewToken(TokenType.LPAREN, this.Ch);
                    break;
                case ')':
                    token = NewToken(TokenType.RPAREN, this.Ch);
                    break;
                case ',':
                    token = NewToken(TokenType.COMMA, this.Ch);
                    break;
                case '+':
                    token = NewToken(TokenType.PLUS, this.Ch);
                    break;
                case '{':
                    token = NewToken(TokenType.LBRACE, this.Ch);
                    break;
                case '}':
                    token = NewToken(TokenType.RBRACE, this.Ch);
                    break;
                case null:
                    token.Literal = "";
                    token.Type = TokenType.EOF;
                    break;
                default:
                    if (this.Ch.HasValue && IsLetter(this.Ch.Value))
                    {
                        token.Literal = ReadIdentifier();
                        token.Type = token.LookupIndent(token.Literal);
                        return token;
                    }
                    else if (IsDigit())
                    {
                        token.Literal = ReadNumber();
                        token.Type = TokenType.INT;
                    }
                    else
                    {
                        token = NewToken(TokenType.ILLEGAL, this.Ch);
                    }
                    break;
            }

            this.ReadChar();
            return token;
        }

        public void SkipWhiteSpace()
        {
            while (this.Ch == ' ' || this.Ch == '\t' || this.Ch == '\n' || this.Ch == '\r')
            {
                ReadChar();
            }
        }

        public bool IsDigit()
        {
            if (this.Ch.HasValue)
            {
                return Char.IsDigit(this.Ch.Value);
            }

            return false;
        }

        public string ReadNumber()
        {
            int position = this.Position;

            while (IsDigit())
            {
                ReadChar();
            }
            return this.Input.Substring(position, this.Position);
        }
    }
}