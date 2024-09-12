Namespace Utilities

    ''' <summary>
    ''' Provides methods to check user input for application setup decisions.
    ''' </summary>
    ''' <remarks>
    ''' This class implements the <see cref="IUserInputChecker"/> interface and is used to determine whether the user wants to proceed
    ''' based on their response.
    ''' </remarks>
    Public Class UserInputChecker
        Implements IUserInputChecker

        ''' <summary>
        ''' The input reader used to read user input.
        ''' </summary>
        ''' <remarks>
        ''' This field is initialized via dependency injection and is used to read user input from the console or other input sources.
        ''' </remarks>
        Private ReadOnly _inputReader As IUserInputReader

        ''' <summary>
        ''' The prompter used to display messages to the user.
        ''' </summary>
        ''' <remarks>
        ''' This field is initialized via dependency injection and is used to display messages to the user.
        ''' </remarks>
        Private ReadOnly _prompter As IUserPrompter

        ''' <summary>
        ''' Initializes a new instance of the <see cref="UserInputChecker"/> class.
        ''' </summary>
        ''' <param name="inputReader">The input reader to use for reading user input.</param>
        ''' <param name="prompter">The prompter to use for displaying messages to the user.</param>
        Public Sub New(inputReader As IUserInputReader, prompter As IUserPrompter)
            _inputReader = inputReader
            _prompter = prompter
        End Sub

        ''' <summary>
        ''' Prompts the user to decide whether to proceed with the application setup.
        ''' </summary>
        ''' <returns>
        ''' <c>True</c> if the user inputs 'Y' (case-insensitive) to indicate they want to proceed; otherwise, <c>False</c>.
        ''' </returns>
        Public Function ShouldProceed() As Boolean Implements IUserInputChecker.ShouldProceed
            PromptUser()
            Dim input As String = GetUserInput()
            Return IsConfirmation(input)
        End Function

        ''' <summary>
        ''' Prompts the user with a confirmation message.
        ''' </summary>
        Private Sub PromptUser()
            _prompter.Prompt("Please confirm whether you would like to proceed with the installation of the service by entering 'Y'")
        End Sub

        ''' <summary>
        ''' Reads the user's input.
        ''' </summary>
        ''' <returns>The input string from the user.</returns>
        Private Function GetUserInput() As String
            Return _inputReader.ReadInput()
        End Function

        ''' <summary>
        ''' Determines if the input indicates confirmation.
        ''' </summary>
        ''' <param name="input">The input string from the user.</param>
        ''' <returns>
        ''' <c>True</c> if the input is 'Y' (case-insensitive); otherwise, <c>False</c>.
        ''' </returns>
        Private Shared Function IsConfirmation(input As String) As Boolean
            Return String.Equals(input, "Y", StringComparison.OrdinalIgnoreCase)
        End Function
    End Class
End Namespace
