Namespace CoreServices.ServiceManagement

    ''' <summary>
    ''' Handles checking the status of a service.
    ''' </summary>
    Public Class ServiceStatusChecker
        Implements IServiceStatusChecker

        ''' <summary>
        ''' The time in milliseconds to wait between status checks.
        ''' </summary>
        Private Const DelayMilliseconds As Integer = 1000

        ''' <summary>
        ''' The timeout period in milliseconds.
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
        Public Sub New(errorHandlingService As IErrorHandlingService)
            _errorHandlingService = errorHandlingService
        End Sub

        ''' <summary>
        ''' Waits until the specified service has stopped.
        ''' </summary>
        ''' <param name="serviceHandle">The handle to the service.</param>
        ''' <returns>A task that represents the asynchronous operation. The task result is <c>True</c> if the service stopped within the timeout period; otherwise, <c>False</c>.</returns>
        Public Async Function WaitForServiceToStopAsync(serviceHandle As IntPtr) As Task(Of Boolean) Implements IServiceStatusChecker.WaitForServiceToStopAsync
            Dim serviceStatus As New ServiceStatus
            Dim startTime As DateTime = DateTime.Now

            Do
                Await AsynchronousProcessor.SimulateDelayedResponse(DelayMilliseconds)
                If Not NativeMethods.QueryServiceStatus(serviceHandle, serviceStatus) Then
                    _errorHandlingService.HandleWin32Error(serviceHandle)
                    Return False
                End If

                If IsServiceStopped(serviceStatus) Then
                    Return True
                End If
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
        ''' The function compares the <see cref="ServiceStatus.dwCurrentState"/> property to the <c>ServiceStopped</c> constant,
        ''' which represents the stopped state of a service. The value for a stopped service is typically 1.
        ''' </remarks>
        Private Shared Function IsServiceStopped(serviceStatus As ServiceStatus) As Boolean
            Const serviceStopped = 1
            Return serviceStatus.dwCurrentState = serviceStopped
        End Function
    End Class
End Namespace
