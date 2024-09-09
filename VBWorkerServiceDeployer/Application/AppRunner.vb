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
        ''' The <see cref="Run"/> method retrieves the <see cref="IUserInputChecker"/> from the service provider,
        ''' uses it to get the friendly user account type, and prints it to the console. The method then waits 
        ''' for the user to press Enter before terminating.
        ''' </remarks>
        Friend Sub Run()
            Dim userInputChecker = _serviceProvider.GetService(Of IUserInputChecker)()
            Dim serviceInstaller = _serviceProvider.GetService(Of IServiceInstaller)()
            Dim shouldProceed = userInputChecker.ShouldProceed()
            If shouldProceed Then
                Try
                    Dim installationSuccess = serviceInstaller.InstallService()
                    Console.WriteLine($"Service installation success: {installationSuccess}")
                Catch ex As Exception
                    Console.WriteLine($"Service installation failed: {ex.Message}")
                End Try
            End If
            Console.ReadLine()
        End Sub
    End Class
End Namespace


