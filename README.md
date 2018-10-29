# Scanner and Parser Coursework

* [Scanner](#Scanner)
* [Parser](#Parser)
* [Testing](#Testing)

## Scanner

| | | | | | |
| - | - | - | - | - | - |
| Location.cs | Scanner.cs | SourceFile.cs | SourcePosition.cs | Token.cs | TokenKind.cs

The scanner will read the source file line by line and examine each character individually. If this encompassed by the given “ScanWhiteSpace()” to be a newline character (\n), space( ) or tab (\t) character then it is skipped, if it is a exclamation mark (!) however the entire line is skipped as we know it to be a comment.
From here the character is passed into the main part of the code the “ScanToken()” method which will check the character against all known parts of the grammar to detect if it can be turned into a token and if not an error will be returned.  In addition to accepting operators we have to parse for characters and digits along with an assortment of other ASCII characters. To handle operators a function “IsOperator()” was provided and this was used a template to build a similar function for determining graphics, “IsGraphic()”, using a switch statement to check against the characters defined in the grammar.
Particular care was taken here to include as much of the code in the switch statement as it will be more performant to the code, however this switch statement is placed after the if else statement and thus the effect is nulled and remains only for readability.
Terminals are built and accepted if the current character is matched to the first character of the grammar. Location is tracked here from the first character of the token and the last and stored in a location class which is passed through.


## Parser

| | | | | | | | |
| - | - | - | - | - | - | - | - |
| Parser - Commands.cs | Parser - Common.cs | Parser - Declarations.cs | Parser - Expressions.cs | Parser - Parameters.cs | Parser - Programs.cs | Parser - Terminals.cs | Parser - TypeDenoters.cs |

The parser was designed and implemented in an array of partial classes to improve the legibility of the code. Given more time a similar approach could have been used for the scanner to break up the `ScanToken()` method to be more legible. The parser handles the tokens passed from the scanner in a recursive descent method. Our `Compiler.cs` file calls the `ParseProgram()` method which starts everything as we expect our source code to be enveloped in a begin `<command>` end as specified in the grammar. From this we can break down into the command and follow our switch statements to recursively parse out all our tokens we received from the scanner. If no errors are found and the syntax is valid it will successfully descend and navigate through all of the tokens and build successfully. If a token is found in the wrong place or a grammatically incorrect token is found we will throw an error which describes the error and points to the location in the code were our error has occurred. At present our error reporting is rudimentary as it does not attempt to tell the user what is wrong with the token found to be erroneous. At the point of finding an error our parser will stop as any continued parsing would be pointless as we have already uncovered an error.

## Testing

Running against an extremely simple test file ( testGood.file ) we can see that the code is able to complete and give us a model output.

![reference 1](images/testGood.png "reference 1")

Running against a file we expect it to fail on ( testBad.file ) we can see how it handles errors.

![reference 2](images/testBad.png "reference 2")

When running against the verify.tri we see that it successfully catches the incorrect grammar for an invalid char Literal for the language used in the labs. And for all similar code it catches everything as expected.

![reference 3](images/testVerify.png "reference 3")