Namespace Application

    ''' <summary>
    ''' Represents an application that uses dependency injection to obtain services and perform operations.
    ''' </summary>
    ''' <remarks>
    ''' The <see cref="AppRunner"/> class relies on dependency injection to obtain an <see cref="IServiceProvider"/> 
    ''' which is used to retrieve services throughout the application. The main functionality of the class is to
    Friend Class AppRunner

        ''' <summary>
        ''' The service provider used for retrieving services.
        ''' </summary>
        Private ReadOnly _serviceProvider As IServiceProvider

        ''' <summary>
        ''' Initializes a new instance of the <see cref="AppRunner"/> class.
        ''' </summary>
        ''' <param name="serviceProvider">
        ''' An instance of <see cref="IServiceProvider"/> used to resolve dependencies and obtain services.
        ''' </param>
        ''' <remarks>
        ''' The constructor takes an <see cref="IServiceProvider"/> as a parameter and assigns it to the
        ''' <see cref="_serviceProvider"/> field. This service provider is used throughout the class to obtain 
        ''' necessary services.
        ''' </remarks>
        Friend Sub New(serviceProvider As IServiceProvider)
            _serviceProvider = serviceProvider
        End Sub

        ''' <summary>
        ''' Runs the application.
        ''' </summary>
        ''' <remarks>
        ''' The <see cref="RunAsync"/> method retrieves the <see cref="IUserInputChecker"/> from the service provider,
        ''' uses it to get the friendly user account type, and prints it to the console. The method then waits 
        ''' for the user to press Enter before terminating.
        ''' </remarks>
        Friend Async Function RunAsync() As Task
            Dim userInputChecker = _serviceProvider.GetService(Of IUserInputChecker)()
            Dim shouldProceed = userInputChecker.ShouldProceed()

            If shouldProceed Then
                InstallService()
                Await DelayBeforeUninstall()
                UninstallService()
            End If

            Console.ReadLine()
        End Function

        ''' <summary>
        ''' Installs the service by using the <see cref="IServiceInstaller"/> retrieved from the service provider.
        ''' </summary>
        ''' <remarks>
        ''' This method attempts to install the service and handles any exceptions that occur during the installation process.
        ''' </remarks>
        Private Sub InstallService()
            Dim serviceInstaller = _serviceProvider.GetService(Of IServiceInstaller)()
            Try
                Dim installationSuccess = serviceInstaller.InstallService()
                Console.WriteLine($"Service installation success: {installationSuccess}")
            Catch ex As Exception
                Console.WriteLine($"Service installation failed: {ex.Message}")
            End Try
        End Sub

        ''' <summary>
        ''' Introduces a delay before proceeding to uninstall the service.
        ''' </summary>
        ''' <returns>A task that represents the asynchronous operation.</returns>
        Private Async Function DelayBeforeUninstall() As Task
            Const delayMilliseconds = 30000
            PromptUserAboutDelay(delayMilliseconds)
            Await AsynchronousProcessor.SimulateDelayedResponse(delayMilliseconds)
        End Function

        ''' <summary>
        ''' Prompts the user about the delay duration.
        ''' </summary>
        ''' <param name="delayMilliseconds">The delay duration in milliseconds.</param>
        Private Sub PromptUserAboutDelay(delayMilliseconds As Integer)
            Dim userPrompter = _serviceProvider.GetService(Of IUserPrompter)()
            userPrompter.Prompt($"The service will wait for {delayMilliseconds / 1000} seconds before proceeding to uninstall.")
        End Sub

        ''' <summary>
        ''' Uninstalls the service by using the <see cref="IServiceUninstaller"/> retrieved from the service provider.
        ''' </summary>
        ''' <remarks>
        ''' This method attempts to uninstall the service and handles any exceptions that occur during the uninstallation process.
        ''' </remarks>
        Private Async Sub UninstallService()
            Dim serviceUninstaller = _serviceProvider.GetService(Of IServiceUninstaller)()
            Try
                Dim uninstallationSuccess = Await serviceUninstaller.UninstallServiceAsync()
                Console.WriteLine($"Service uninstallation success: {uninstallationSuccess}")
            Catch ex As Exception
                Console.WriteLine($"Service uninstallation failed: {ex.Message}")
            End Try
        End Sub
    End Class
End Namespace


