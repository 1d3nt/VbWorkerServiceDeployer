Namespace CoreServices.ServiceManagement.Interfaces

    ''' <summary>
    ''' Defines the contract for deleting a service.
    ''' </summary>
    Public Interface IServiceDeleter

        ''' <summary>
        ''' Deletes the specified service.
        ''' </summary>
        ''' <param name="serviceHandle">The handle to the service.</param>
        Sub DeleteService(serviceHandle As IntPtr)
    End Interface
End Namespace
