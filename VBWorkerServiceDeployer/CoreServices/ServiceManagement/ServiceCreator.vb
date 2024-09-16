Namespace CoreServices.ServiceManagement

    ''' <summary>
    ''' Handles creating the service.
    ''' </summary>
    ''' <remarks>
    ''' This class implements the <see cref="IServiceCreator"/> interface and provides the method
    ''' for creating services using the Service Control Manager (SCM). It utilizes the <see cref="IServicePathProvider"/>
    ''' to obtain service paths and names, and <see cref="IErrorHandlingService"/> to handle any errors that occur during
    ''' the creation process.
    ''' </remarks>
    ''' <seealso cref="IServiceCreator"/>
    Friend Class ServiceCreator
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
        ''' <param name="servicePathProvider">
        ''' An instance of <see cref="IServicePathProvider"/> used to obtain service paths and names.
        ''' </param>
        ''' <param name="errorHandlingService">
        ''' An instance of <see cref="IErrorHandlingService"/> used for handling errors.
        ''' </param>
        ''' <remarks>
        ''' The constructor initializes the <see cref="_servicePathProvider"/> and <see cref="_errorHandlingService"/>
        ''' fields, which are used to provide service paths and handle any errors that occur during service creation.
        ''' </remarks>
        Public Sub New(servicePathProvider As IServicePathProvider, errorHandlingService As IErrorHandlingService)
            _servicePathProvider = servicePathProvider
            _errorHandlingService = errorHandlingService
        End Sub

        ''' <summary>
        ''' Creates the service using the Service Control Manager (SCM).
        ''' </summary>
        ''' <param name="serviceControlManager">
        ''' The handle to the Service Control Manager.
        ''' </param>
        ''' <returns>
        ''' An <see cref="IntPtr"/> representing the handle to the newly created service.
        ''' </returns>
        ''' <remarks>
        ''' This method uses the <see cref="IServicePathProvider"/> to obtain the service name and path,
        ''' and configures the service with default parameters. It also handles any errors that occur during
        ''' the creation process using the <see cref="IErrorHandlingService"/>.
        ''' </remarks>
        Friend Function Create(serviceControlManager As IntPtr) As IntPtr Implements IServiceCreator.Create
            Dim serviceName As String = _servicePathProvider.GetServiceName()
            Dim servicePath As String = _servicePathProvider.GetServicePath()
            Dim service As IntPtr = CreateService(serviceControlManager, serviceName, servicePath)
            HandleErrors(serviceControlManager)
            Return service
        End Function

        ''' <summary>
        ''' Creates the service with the specified name and path.
        ''' </summary>
        ''' <param name="serviceControlManager">The handle to the Service Control Manager.</param>
        ''' <param name="serviceName">The name of the service.</param>
        ''' <param name="servicePath">The path to the service executable.</param>
        ''' <returns>
        ''' An <see cref="IntPtr"/> representing the handle to the newly created service.
        ''' </returns>
        ''' <remarks>
        ''' This method wraps the <see cref="NativeMethods.CreateService"/> function from the Windows API.
        ''' <see href="https://learn.microsoft.com/en-us/windows/win32/api/winsvc/nf-winsvc-createservicew"/>
        ''' </remarks>
        Private Shared Function CreateService(serviceControlManager As IntPtr, serviceName As String, servicePath As String) As IntPtr
            Return NativeMethods.CreateService(
                serviceControlManager,
                serviceName,
                serviceName,
                DesiredAccess.All,
                ServiceType.Win32OwnProcess,
                StartType.Automatic,
                ServiceErrorControlFlags.ServiceErrorNormal,
                servicePath,
                lpLoadOrderGroup:=Nothing,
                lpdwTagId:=0,
                lpDependencies:=Nothing,
                lpServiceStartName:=Nothing,
                lpPassword:=Nothing
            )
        End Function

        ''' <summary>
        ''' Handles any errors that occur during the service creation process.
        ''' </summary>
        ''' <param name="serviceControlManager">The handle to the Service Control Manager.</param>
        ''' <remarks>
        ''' This method uses the <see cref="IErrorHandlingService"/> to handle any Win32 errors that might
        ''' occur during the service creation process.
        ''' </remarks>
        Private Sub HandleErrors(serviceControlManager As IntPtr)
            _errorHandlingService.HandleWin32Error(serviceControlManager)
        End Sub
    End Class
End Namespace
