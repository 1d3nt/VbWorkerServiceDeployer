Namespace CoreServices.ServiceManagement

    ''' <summary>
    ''' Handles the stopping of a Windows service in a controlled and safe manner.
    ''' This class is responsible for sending the stop control code to the service and ensuring the service stops gracefully.
    ''' If the service fails to stop, it utilizes error handling services to report and manage the failure.
    ''' </summary>
    ''' <remarks>
    ''' The stopping process is initiated by sending the <see cref="ServiceControlCodes.Stop"/> control signal to the service.
    ''' If the service fails to stop, the <see cref="IErrorHandlingService"/> is used to handle Win32 errors.
    ''' The class ensures that any necessary clean-up actions are performed if stopping the service does not succeed.
    ''' 
    ''' It is important that the service handle passed to this class is valid and that proper permission is available to control the service.
    ''' The handle must be obtained using the appropriate Win32 functions like <c>OpenService</c>.
    ''' 
    ''' This class ensures a clean shutdown of the service and may throw exceptions depending on the implementation if stopping the service fails.
    ''' </remarks>
    ''' <seealso cref="IServiceStopper"/>
    Friend Class ServiceStopper
        Implements IServiceStopper

        ''' <summary>
        ''' The error handling service.
        ''' </summary>
        Private ReadOnly _errorHandlingService As IErrorHandlingService

        ''' <summary>
        ''' Initializes a new instance of the <see cref="ServiceStopper"/> class.
        ''' </summary>
        ''' <param name="errorHandlingService">An instance of <see cref="IErrorHandlingService"/> used for handling errors.</param>
        Public Sub New(errorHandlingService As IErrorHandlingService)
            _errorHandlingService = errorHandlingService
        End Sub

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
        Friend Sub StopService(serviceHandle As IntPtr) Implements IServiceStopper.StopService
            Dim serviceStatus As New ServiceStatus()
            If Not NativeMethods.ControlService(serviceHandle, ServiceControlCodes.Stop, serviceStatus) Then
                _errorHandlingService.HandleWin32Error(serviceHandle)
            End If
        End Sub
    End Class
End Namespace
