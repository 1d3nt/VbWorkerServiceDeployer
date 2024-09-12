Namespace Utilities

    ''' <summary>
    ''' Provides methods to prompt the user via the console.
    ''' </summary>
    Public Class UserPrompter
        Implements IUserPrompter

        ''' <summary>
        ''' Prompts the user with a message.
        ''' </summary>
        ''' <param name="message">The message to display to the user.</param>
        Public Sub Prompt(message As String) Implements IUserPrompter.Prompt
            Console.WriteLine(message)
        End Sub
    End Class
End Namespace
