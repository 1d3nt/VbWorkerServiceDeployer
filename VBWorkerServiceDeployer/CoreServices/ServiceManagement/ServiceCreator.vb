Namespace CoreServices.ServiceManagement

    ''' <summary>
    ''' Handles creating the service.
    ''' </summary>
    Public Class ServiceCreator
        Implements IServiceCreator

        ''' <summary>
        ''' The service path provider used for retrieving service paths and names.
        ''' </summary>
        Private ReadOnly _servicePathProvider As IServicePathProvider

        ''' <summary>
        ''' The error handling service.
        ''' </summary>
        Private ReadOnly _errorHandlingService As IErrorHandlingService

        ''' <summary>
        ''' Initializes a new instance of the <see cref="ServiceCreator"/> class.
        ''' </summary>
        ''' <param name="servicePathProvider">An instance of <see cref="IServicePathProvider"/> used to obtain service paths and names.</param>
        ''' <param name="errorHandlingService">An instance of <see cref="IErrorHandlingService"/> used for handling errors.</param>
        Public Sub New(servicePathProvider As IServicePathProvider, errorHandlingService As IErrorHandlingService)
            _servicePathProvider = servicePathProvider
            _errorHandlingService = errorHandlingService
        End Sub

        ''' <summary>
        ''' Creates the service.
        ''' </summary>
        ''' <param name="serviceControlManager">The handle to the Service Control Manager.</param>
        ''' <returns>An IntPtr representing the handle to the newly created service.</returns>
        Public Function Create(serviceControlManager As IntPtr) As IntPtr Implements IServiceCreator.Create
            Dim service = NativeMethods.CreateService(serviceControlManager, _servicePathProvider.GetServiceName(), _servicePathProvider.GetServiceName(), DesiredAccess.All, ServiceType.Win32OwnProcess, StartType.Automatic, ServiceErrorControlFlags.ServiceErrorNormal,
                                                      _servicePathProvider.GetServicePath(), lpLoadOrderGroup:=Nothing, lpdwTagId:=0, lpDependencies:=Nothing, lpServiceStartName:=Nothing, lpPassword:=Nothing)
            _errorHandlingService.HandleWin32Error(serviceControlManager)
            Return service
        End Function
    End Class
End Namespace
