Namespace CoreServices.ServiceManagement.Interfaces

    ''' <summary>
    ''' Defines the contract for uninstalling a service.
    ''' </summary>
    ''' <remarks>
    ''' The <see cref="IServiceUninstaller"/> interface provides a method for uninstalling a service.
    ''' Implementing classes should provide the actual logic for uninstalling the service.
    ''' </remarks>
    Public Interface IServiceUninstaller

        ''' <summary>
        ''' Uninstalls the service.
        ''' </summary>
        ''' <returns><c>True</c> if the service was successfully uninstalled; otherwise, <c>False</c>.</returns>
        ''' <remarks>
        ''' This method attempts to uninstall the service. Implementing classes should handle any necessary steps
        ''' to remove the service from the system.
        ''' </remarks>
        Function UninstallServiceAsync() As Task(Of Boolean)
    End Interface
End Namespace
