Namespace CoreServices.ServiceManagement.Interfaces

    ''' <summary>
    ''' Defines the contract for stopping a service.
    ''' </summary>
    Public Interface IServiceStopper

        ''' <summary>
        ''' Stops the specified service.
        ''' </summary>
        ''' <param name="serviceHandle">The handle to the service.</param>
        Sub StopService(serviceHandle As IntPtr)
    End Interface
End Namespace
