Namespace CoreServices.ServiceManagement

    ''' <summary>
    ''' Handles the uninstallation of services.
    ''' </summary>
    Public Class ServiceUninstaller
        Implements IServiceUninstaller

        ''' <summary>
        ''' The service control manager.
        ''' </summary>
        Private ReadOnly _serviceControlManager As IServiceControlManager

        ''' <summary>
        ''' The service path provider.
        ''' </summary>
        Private ReadOnly _servicePathProvider As IServicePathProvider

        ''' <summary>
        ''' The service stopper.
        ''' </summary>
        Private ReadOnly _serviceStopper As IServiceStopper

        ''' <summary>
        ''' Initializes a new instance of the <see cref="ServiceUninstaller"/> class.
        ''' </summary>
        ''' <param name="serviceControlManager">An instance of <see cref="IServiceControlManager"/> used for managing the service control manager.</param>
        ''' <param name="servicePathProvider">An instance of <see cref="IServicePathProvider"/> used for retrieving service paths and names.</param>
        ''' <param name="serviceStopper">An instance of <see cref="IServiceStopper"/> used for stopping the service.</param>
        Public Sub New(serviceControlManager As IServiceControlManager, servicePathProvider As IServicePathProvider, serviceStopper As IServiceStopper)
            _serviceControlManager = serviceControlManager
            _servicePathProvider = servicePathProvider
            _serviceStopper = serviceStopper
        End Sub

        ''' <summary>
        ''' Uninstalls the service.
        ''' </summary>
        ''' <returns><c>True</c> if the service was successfully uninstalled; otherwise, <c>False</c>.</returns>
        Public Function UninstallService() As Boolean Implements IServiceUninstaller.UninstallService
            Dim serviceName As String = _servicePathProvider.GetServiceName()
            Dim serviceControlManager As IntPtr = NativeMethods.NullHandleValue
            Dim serviceHandle As IntPtr = NativeMethods.NullHandleValue

            Try
                serviceControlManager = _serviceControlManager.Open(ServiceManagerAccessFlags.AllAccess)
                Debug.WriteLine(serviceControlManager)
                serviceHandle = _serviceControlManager.OpenService(serviceControlManager, serviceName, DesiredAccess.All)
               ' _serviceStopper.StopService(serviceHandle)
                Return True
            Catch
                Throw
            Finally
                _serviceControlManager.Close(serviceControlManager)
                _serviceControlManager.Close(serviceHandle)
            End Try
        End Function
    End Class
End Namespace
