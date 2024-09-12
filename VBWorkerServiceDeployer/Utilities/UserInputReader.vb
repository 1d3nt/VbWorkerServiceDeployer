Namespace Utilities

    ''' <summary>
    ''' Provides methods to read user input from the console.
    ''' </summary>
    Public Class UserInputReader
        Implements IUserInputReader

        ''' <summary>
        ''' Reads a line of input from the console.
        ''' </summary>
        ''' <returns>The input string from the console.</returns>
        Public Function ReadInput() As String Implements IUserInputReader.ReadInput
            Return Console.ReadLine()
        End Function
    End Class
End Namespace
