Namespace CoreServices.ServiceManagement.Interfaces

    ''' <summary>
    ''' Defines the contract for starting a service.
    ''' </summary>
    ''' <remarks>
    ''' This interface provides the necessary method for starting a service in the system. 
    ''' It is intended to abstract the service start functionality and ensure that 
    ''' any class implementing this interface can handle the startup of system services 
    ''' with the provided service handle. 
    ''' </remarks>
    ''' <seealso cref="ServiceStarter"/>
    Public Interface IServiceStarter

        ''' <summary>
        ''' Starts the specified service.
        ''' </summary>
        ''' <param name="serviceHandle">The handle to the service that needs to be started.</param>
        ''' <remarks>
        ''' The <paramref name="serviceHandle"/> represents a handle to an existing Windows service. 
        ''' The implementation of this method should ensure that the service is successfully started 
        ''' using the provided handle. The handle must be obtained through the appropriate means, such as 
        ''' by opening the service using Windows API functions like <c>OpenService</c>.
        ''' <para>
        ''' It is important that the service handle is valid and that the caller has the necessary privileges 
        ''' to start the service.
        ''' </para>
        ''' </remarks>
        ''' <seealso cref="ServiceStarter.StartService"/>
        Sub StartService(serviceHandle As IntPtr)
    End Interface
End Namespace
