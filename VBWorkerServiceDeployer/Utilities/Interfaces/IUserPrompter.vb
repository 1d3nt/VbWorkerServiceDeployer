Namespace Utilities.Interfaces

    ''' <summary>
    ''' Provides methods to prompt the user.
    ''' </summary>
    ''' <remarks>
    ''' This interface defines the contract for prompting the user with messages.
    ''' Implementations of this interface will provide the actual mechanism for 
    ''' displaying messages to the user.
    ''' </remarks>
    ''' <seealso cref="UserPrompter"/>
    Public Interface IUserPrompter

        ''' <summary>
        ''' Prompts the user with a message.
        ''' </summary>
        ''' <param name="message">The message to display to the user.</param>
        ''' <remarks>
        ''' This method writes the specified message to the console, allowing the user to see and respond to it.
        ''' It can be used for simple user interactions where a message needs to be displayed without requiring user input.
        ''' </remarks>
        Sub Prompt(message As String)
    End Interface
End Namespace
