Namespace Utilities

    ''' <summary>
    ''' Provides methods to read user input from the console.
    ''' </summary>
    ''' <remarks>
    ''' This class implements the <see cref="IUserInputReader"/> interface, providing functionality 
    ''' to read input from the console. It captures user input as a string, which can then be 
    ''' processed or used as needed in the application.
    ''' </remarks>
    ''' <seealso cref="IUserInputReader"/>
    Friend Class UserInputReader
        Implements IUserInputReader

        ''' <summary>
        ''' Reads a line of input from the console.
        ''' </summary>
        ''' <returns>The input string from the console.</returns>
        ''' <remarks>
        ''' This method reads a line of input provided by the user through the console.
        ''' It allows the application to receive and utilize user input dynamically.
        ''' </remarks>
        Friend Function ReadInput() As String Implements IUserInputReader.ReadInput
            Return Console.ReadLine()
        End Function
    End Class
End Namespace
