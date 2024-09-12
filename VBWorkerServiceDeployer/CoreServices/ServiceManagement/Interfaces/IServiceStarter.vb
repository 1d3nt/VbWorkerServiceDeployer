Namespace CoreServices.ServiceManagement.Interfaces

    ''' <summary>
    ''' Defines the contract for starting a service.
    ''' </summary>
    Public Interface IServiceStarter

        ''' <summary>
        ''' Starts the specified service.
        ''' </summary>
        ''' <param name="serviceHandle">The handle to the service.</param>
        Sub StartService(serviceHandle As IntPtr)
    End Interface
End Namespace
