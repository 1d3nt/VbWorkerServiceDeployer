Namespace CoreServices.ServiceManagement.Interfaces

    ''' <summary>
    ''' Defines the contract for managing the Service Control Manager.
    ''' </summary>
    Public Interface IServiceControlManager

        ''' <summary>
        ''' Opens the Service Control Manager.
        ''' </summary>
        ''' <returns>An IntPtr representing the handle to the Service Control Manager.</returns>
        Function Open() As IntPtr

        ''' <summary>
        ''' Closes the Service Control Manager handle if it is not null.
        ''' </summary>
        ''' <param name="serviceControlManager">The handle to the Service Control Manager.</param>
        Sub Close(serviceControlManager As IntPtr)
    End Interface
End Namespace
