Namespace Utilities.Interfaces

    ''' <summary>
    ''' Provides methods to prompt the user.
    ''' </summary>
    Public Interface IUserPrompter

        ''' <summary>
        ''' Prompts the user with a message.
        ''' </summary>
        ''' <param name="message">The message to display to the user.</param>
        Sub Prompt(message As String)
    End Interface
End Namespace
