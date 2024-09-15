Namespace Utilities.Interfaces

    ''' <summary>
    ''' Provides methods to read user input.
    ''' </summary>
    ''' <remarks>
    ''' This interface defines the contract for reading input from the user.
    ''' Implementations of this interface will provide the actual mechanism for 
    ''' reading input, typically from the console or another input source.
    ''' </remarks>
    ''' <seealso cref="UserInputReader"/>
    Public Interface IUserInputReader

        ''' <summary>
        ''' Reads a line of input.
        ''' </summary>
        ''' <returns>The input string.</returns>
        ''' <remarks>
        ''' This method is responsible for capturing user input as a string. 
        ''' It may be used to gather information or responses from the user.
        ''' </remarks>
        Function ReadInput() As String
    End Interface
End Namespace
