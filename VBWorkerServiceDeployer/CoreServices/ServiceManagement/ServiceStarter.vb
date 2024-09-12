Namespace CoreServices.ServiceManagement

    ''' <summary>
    ''' Handles starting a service.
    ''' </summary>
    Public Class ServiceStarter
        Implements IServiceStarter

        ''' <summary>
        ''' Represents the number of service arguments to pass to the <see cref="NativeMethods.StartService"/> method when there are no arguments.
        ''' </summary>
        ''' <remarks>
        ''' This constant is used to specify that there are no arguments being passed to the service when calling the <see cref="NativeMethods.StartService"/> method.
        ''' </remarks>
        Private Const NoServiceArguments As Integer = 0

        ''' <summary>
        ''' Represents the absence of arguments for the <see cref="NativeMethods.StartService"/> method.
        ''' </summary>
        ''' <remarks>
        ''' This read-only field is used to indicate that there are no arguments to pass to the service.
        ''' It is equivalent to passing <c>Nothing</c> in VB.NET.
        ''' </remarks>
        Private Shared ReadOnly NoArguments As String() = Nothing

        ''' <summary>
        ''' The error handling service.
        ''' </summary>
        Private ReadOnly _errorHandlingService As IErrorHandlingService

        ''' <summary>
        ''' Initializes a new instance of the <see cref="ServiceStarter"/> class.
        ''' </summary>
        ''' <param name="errorHandlingService">An instance of <see cref="IErrorHandlingService"/> used for handling errors.</param>
        Public Sub New(errorHandlingService As IErrorHandlingService)
            _errorHandlingService = errorHandlingService
        End Sub

        ''' <summary>
        ''' Starts the specified service.
        ''' </summary>
        ''' <param name="serviceHandle">The handle to the service.</param>
        Public Sub StartService(serviceHandle As IntPtr) Implements IServiceStarter.StartService
            If Not NativeMethods.StartService(serviceHandle, NoServiceArguments, NoArguments) Then
                _errorHandlingService.HandleWin32Error(serviceHandle)
            End If
        End Sub
    End Class
End Namespace
