namespace Triangle.Compiler.SyntacticAnalyzer
{
    /// <summary>
    /// Types of token in the source language
    /// </summary>
    public enum TokenKind
    {
        // non-terminals
        IntLiteral, Identifier, Operator,

        // reserved words - terminals
        Begin, Const, Do, Else, End, If, In, Let, Then, Var, While,

        // punctuation - terminals (Becomes is for assignment (:=) , Is is for constants (~))
        Colon, Semicolon, Becomes, Is, LeftBracket, RightBracket,

        // special tokens
        EndOfText, Error,

        // other
        CharLiteral, Skip, Comma
    }
}