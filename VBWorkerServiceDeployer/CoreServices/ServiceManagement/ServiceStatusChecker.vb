Namespace CoreServices.ServiceManagement

    ''' <summary>
    ''' Handles checking the status of a service.
    ''' </summary>
    ''' <seealso cref="IServiceStatusChecker"/>
    Public Class ServiceStatusChecker
        Implements IServiceStatusChecker

        ''' <summary>
        ''' The time in milliseconds to wait between status checks.
        ''' Defaults to 1000ms, providing a balance between responsiveness and system load.
        ''' </summary>
        Private Const DelayMilliseconds As Integer = 1000

        ''' <summary>
        ''' The timeout period in milliseconds.
        ''' Defaults to 30000ms (30 seconds), which is typically sufficient for most services to stop.
        ''' </summary>
        Private Const Timeout As Integer = 30000

        ''' <summary>
        ''' The error handling service.
        ''' </summary>
        Private ReadOnly _errorHandlingService As IErrorHandlingService

        ''' <summary>
        ''' Initializes a new instance of the <see cref="ServiceStatusChecker"/> class.
        ''' </summary>
        ''' <param name="errorHandlingService">An instance of <see cref="IErrorHandlingService"/> used for handling errors.</param>
        ''' <seealso cref="IServiceStatusChecker"/>
        Public Sub New(errorHandlingService As IErrorHandlingService)
            _errorHandlingService = errorHandlingService
        End Sub

        ''' <summary>
        ''' Waits until the specified service has stopped.
        ''' </summary>
        ''' <param name="serviceHandle">The handle to the service.</param>
        ''' <returns>A task that represents the asynchronous operation. The task result is <c>True</c> if the service stopped within the timeout period; otherwise, <c>False</c>.</returns>
        ''' <remarks>
        ''' This method uses asynchronous waiting via <see cref="AsynchronousProcessor.SimulateDelayedResponse"/> to avoid blocking the main thread.
        ''' </remarks>
        Friend Async Function WaitForServiceToStopAsync(serviceHandle As IntPtr) As Task(Of Boolean) Implements IServiceStatusChecker.WaitForServiceToStopAsync
            Dim serviceStatus As New ServiceStatus
            Dim startTime As DateTime = DateTime.Now
            Do
                Try
                    If Not NativeMethods.QueryServiceStatus(serviceHandle, serviceStatus) Then
                        _errorHandlingService.HandleWin32Error(serviceHandle)
                    End If
                Catch ex As InvalidOperationException
                    Throw
                End Try
                If IsServiceStopped(serviceStatus) Then
                    Return True
                End If
                Await AsynchronousProcessor.SimulateDelayedResponse(DelayMilliseconds)
            Loop While (DateTime.Now - startTime).TotalMilliseconds < Timeout
            Return IsServiceStopped(serviceStatus)
        End Function

        ''' <summary>
        ''' Determines whether the specified service status indicates that the service has stopped.
        ''' </summary>
        ''' <param name="serviceStatus">
        ''' An instance of the <see cref="ServiceStatus"/> structure that contains the current status of the service.
        ''' </param>
        ''' <returns>
        ''' <c>True</c> if the <paramref name="serviceStatus"/> indicates that the service is stopped; otherwise, <c>False</c>.
        ''' </returns>
        ''' <remarks>
        ''' The function compares the <see cref="ServiceStatus.dwCurrentState"/> property to the constant value representing the stopped state, 
        ''' typically 1 (<c>ServiceStopped</c>).
        ''' </remarks>
        Private Shared Function IsServiceStopped(serviceStatus As ServiceStatus) As Boolean
            Const serviceStopped = 1
            Return serviceStatus.dwCurrentState = serviceStopped
        End Function
    End Class
End Namespace
