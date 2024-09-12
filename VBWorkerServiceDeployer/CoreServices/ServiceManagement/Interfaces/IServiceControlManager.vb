Namespace CoreServices.ServiceManagement.Interfaces

    ''' <summary>
    ''' Defines the contract for managing the Service Control Manager.
    ''' </summary>
    Public Interface IServiceControlManager

        ''' <summary>
        ''' Opens the Service Control Manager with the specified access rights.
        ''' </summary>
        ''' <param name="desiredAccess">The desired access level for the Service Control Manager.</param>
        ''' <returns>An IntPtr representing the handle to the Service Control Manager.</returns>
        Function Open(desiredAccess As ServiceManagerAccessFlags) As IntPtr

        ''' <summary>
        ''' Opens a handle to the specified service.
        ''' </summary>
        ''' <param name="scmHandle">The handle to the Service Control Manager.</param>
        ''' <param name="serviceName">The name of the service to open.</param>
        ''' <param name="desiredAccess">The desired access level for the service.</param>
        ''' <returns>An IntPtr representing the handle to the service.</returns>
        Function OpenService(scmHandle As IntPtr, serviceName As String, desiredAccess As DesiredAccess) As IntPtr

        ''' <summary>
        ''' Closes the Service Control Manager handle if it is not null.
        ''' </summary>
        ''' <param name="serviceControlManager">The handle to the Service Control Manager.</param>
        Sub Close(serviceControlManager As IntPtr)
    End Interface
End Namespace
