Namespace CoreServices.ServiceManagement.Interfaces

    ''' <summary>
    ''' Defines the contract for stopping a service.
    ''' </summary>
    ''' <remarks>
    ''' This interface defines the behavior for stopping a Windows service. Implementers of this interface must ensure 
    ''' that appropriate error handling is performed, as stopping a service may encounter permission or state-related issues.
    ''' </remarks>
    ''' <seealso cref="ServiceStopper"/>
    Public Interface IServiceStopper

        ''' <summary>
        ''' Stops the specified service.
        ''' </summary>
        ''' <param name="serviceHandle">The handle to the service.</param>
        ''' <remarks>
        ''' The <paramref name="serviceHandle"/> is an open handle to the service. Implementers of this method should ensure that
        ''' the service is gracefully stopped and any necessary clean-up actions are performed. If stopping the service fails, the 
        ''' error should be properly handled, and an exception may be thrown depending on the implementation.
        ''' 
        ''' It is recommended that this method uses the <see cref="IErrorHandlingService"/> to capture and handle any errors that occur
        ''' during the stop process.
        ''' </remarks>
        Sub StopService(serviceHandle As IntPtr)
    End Interface
End Namespace
