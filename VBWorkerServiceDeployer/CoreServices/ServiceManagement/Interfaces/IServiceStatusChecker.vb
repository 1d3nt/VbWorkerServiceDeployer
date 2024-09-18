Namespace CoreServices.ServiceManagement.Interfaces

    ''' <summary>
    ''' Defines the contract for checking the status of a service.
    ''' </summary>
    Public Interface IServiceStatusChecker

        ''' <summary>
        ''' Waits until the specified service has stopped.
        ''' </summary>
        ''' <param name="serviceHandle">The handle to the service.</param>
        ''' <returns>A task that represents the asynchronous operation. The task result is <c>True</c> if the service stopped within the timeout period; otherwise, <c>False</c>.</returns>
        ''' <remarks>
        ''' This method uses asynchronous waiting via <see cref="AsynchronousProcessor.SimulateDelayedResponse"/> to avoid blocking the main thread.
        ''' </remarks>
        Function WaitForServiceToStopAsync(serviceHandle As IntPtr) As Task(Of Boolean)
    End Interface
End Namespace
