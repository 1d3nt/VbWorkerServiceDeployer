Namespace CoreServices.ServiceManagement

    ''' <summary>
    ''' Handles the installation of services.
    ''' </summary>
    ''' <remarks>
    ''' This class implements the <see cref="IServiceInstaller"/> interface and provides the logic required
    ''' to install a service, including creating and starting the service. It uses the <see cref="IServiceControlManager"/>
    ''' to interact with the Service Control Manager, the <see cref="IServiceCreator"/> to create the service,
    ''' and the <see cref="IServiceStarter"/> to start the service once it has been created.
    ''' </remarks>
    ''' <seealso cref="IServiceInstaller"/>
    Friend Class ServiceInstaller
        Implements IServiceInstaller

        ''' <summary>
        ''' An instance of <see cref="IServiceControlManager"/> used to manage the Service Control Manager.
        ''' </summary>
        Private ReadOnly _serviceControlManager As IServiceControlManager

        ''' <summary>
        ''' An instance of <see cref="IServiceCreator"/> used to create the service.
        ''' </summary>
        Private ReadOnly _serviceCreator As IServiceCreator

        ''' <summary>
        ''' An instance of <see cref="IServiceStarter"/> used to start the service.
        ''' </summary>
        Private ReadOnly _serviceStarter As IServiceStarter

        ''' <summary>
        ''' Initializes a new instance of the <see cref="ServiceInstaller"/> class.
        ''' </summary>
        ''' <param name="serviceControlManager">An instance of <see cref="IServiceControlManager"/> used to manage the Service Control Manager.</param>
        ''' <param name="serviceCreator">An instance of <see cref="IServiceCreator"/> used to create the service.</param>
        ''' <param name="serviceStarter">An instance of <see cref="IServiceStarter"/> used to start the service.</param>
        ''' <remarks>
        ''' This constructor initializes the fields used for service management, creation, and starting the service.
        ''' </remarks>
        Public Sub New(serviceControlManager As IServiceControlManager, serviceCreator As IServiceCreator, serviceStarter As IServiceStarter)
            _serviceControlManager = serviceControlManager
            _serviceCreator = serviceCreator
            _serviceStarter = serviceStarter
        End Sub

        ''' <summary>
        ''' Installs the service.
        ''' </summary>
        ''' <returns><c>True</c> if the service was installed successfully; otherwise, <c>False</c>.</returns>
        ''' <remarks>
        ''' This method performs the service installation process, which includes opening a connection to the
        ''' Service Control Manager, creating the service using <see cref="IServiceCreator"/>, and starting the service
        ''' using <see cref="IServiceStarter"/>. It returns <c>True</c> if the service installation completes successfully.
        ''' </remarks>
        Friend Function InstallService() As Boolean Implements IServiceInstaller.InstallService
            Dim serviceControlManager As IntPtr = NativeMethods.NullHandleValue
            Dim serviceHandle As IntPtr = NativeMethods.NullHandleValue
            Try
                serviceControlManager = _serviceControlManager.Open(ServiceManagerAccessFlags.CreateService)
                serviceHandle = _serviceCreator.Create(serviceControlManager)
                _serviceStarter.StartService(serviceHandle)
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
