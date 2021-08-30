namespace monkey
{
    public enum TokenType
    {
        ILLEGAL, // not valid
        EOF, // end of line
        IDENT, // indent
        INT, // int 1,2,3,4
        ASSIGN, // = 
        PLUS, // +
        MINUS, // -
        BANG, // !
        ASTERISK, // *
        SLASH, // /
        LT, // <
        GT, // >
        COMMA, // ,
        SEMICOLON, // ;
        LPAREN, // (
        RPAREN, // )
        LBRACE, // {
        RBRACE, // }
        FUNCTION, // fn
        LET, // let
        TRUE, // true
        FALSE, // false
        IF, // if
        ELSE, // else
        RETURN // return
    }
}