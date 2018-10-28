/* @Author: Shaw Eastwood <1504614@rgu.ac.uk>
 * @Date:   10-Oct-172017
 */

// Types of token in the source language
namespace Triangle.Compiler.SyntacticAnalyzer {
    public enum TokenKind {

        // non-terminals
        IntLiteral, Identifier, Operator,

        // reserved words - terminals
        Begin, Const, Do, Else, End, If, In, Let, Then, Var, While, Skip,

        // punctuation - terminals (Becomes is for assignment (:=) , Is is for constants (~))
        Colon, Semicolon, Becomes, Is, LeftBracket, RightBracket,

        // special tokens
        EndOfText, Error,

        // other
        CharLiteral, Comma
    }
}