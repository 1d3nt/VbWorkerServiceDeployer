Namespace Utilities

    ''' <summary>
    ''' Provides methods to prompt the user via the console.
    ''' </summary>
    ''' <remarks>
    ''' The <see cref="UserPrompter"/> class implements the <see cref="IUserPrompter"/> interface and is used to interact with the user 
    ''' by displaying messages on the console. This can be useful for providing feedback, requesting input, or guiding the user 
    ''' through a process.
    ''' </remarks>
    ''' <seealso cref="IUserPrompter"/>
    Friend Class UserPrompter
        Implements IUserPrompter

        ''' <summary>
        ''' Prompts the user with a message.
        ''' </summary>
        ''' <param name="message">The message to display to the user.</param>
        ''' <remarks>
        ''' This method writes the specified message to the console, allowing the user to see and respond to it.
        ''' It can be used for simple user interactions where a message needs to be displayed without requiring user input.
        ''' </remarks>
        Friend Sub Prompt(message As String) Implements IUserPrompter.Prompt
            Console.WriteLine(message)
        End Sub
    End Class
End Namespace
