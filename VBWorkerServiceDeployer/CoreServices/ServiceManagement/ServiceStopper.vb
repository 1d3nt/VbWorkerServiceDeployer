Namespace CoreServices.ServiceManagement

    ''' <summary>
    ''' Handles stopping a service.
    ''' </summary>
    Public Class ServiceStopper
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
        Public Sub StopService(serviceHandle As IntPtr) Implements IServiceStopper.StopService
            Dim serviceStatus As New ServiceStatus()
            If Not NativeMethods.ControlService(serviceHandle, ServiceControlCodes.Stop, serviceStatus) Then
                _errorHandlingService.HandleWin32Error(serviceHandle)
            End If
        End Sub
    End Class
End Namespace
