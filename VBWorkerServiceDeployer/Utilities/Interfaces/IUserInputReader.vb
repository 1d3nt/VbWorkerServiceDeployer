Namespace Utilities.Interfaces

    ''' <summary>
    ''' Provides methods to read user input.
    ''' </summary>
    Public Interface IUserInputReader

        ''' <summary>
        ''' Reads a line of input.
        ''' </summary>
        ''' <returns>The input string.</returns>
        Function ReadInput() As String
    End Interface
End Namespace
