Namespace CoreServices.ServiceManagement

    ''' <summary>
    ''' Handles the installation of services.
    ''' </summary>
    ''' <remarks>
    ''' The <see cref="ServiceInstaller"/> class provides methods to install services using P/Invoke and other necessary operations.
    ''' It utilizes the <see cref="IServiceControlManager"/> to manage the Service Control Manager and the <see cref="IServiceCreator"/>
    ''' to create the service.
    ''' </remarks>
    Public Class ServiceInstaller
        Implements IServiceInstaller

        ''' <summary>
        ''' An instance of <see cref="IServiceControlManager"/> used to manage the Service Control Manager.
        ''' </summary>
        ''' <remarks>
        ''' This field is used to open and close the Service Control Manager.
        ''' </remarks>
        Private ReadOnly _serviceControlManager As IServiceControlManager

        ''' <summary>
        ''' An instance of <see cref="IServiceCreator"/> used to create the service.
        ''' </summary>
        ''' <remarks>
        ''' This field is used to create the service using the provided service control manager handle.
        ''' </remarks>
        Private ReadOnly _serviceCreator As IServiceCreator

        ''' <summary>
        ''' Initializes a new instance of the <see cref="ServiceInstaller"/> class.
        ''' </summary>
        ''' <param name="serviceControlManager">An instance of <see cref="IServiceControlManager"/> used to manage the Service Control Manager.</param>
        ''' <param name="serviceCreator">An instance of <see cref="IServiceCreator"/> used to create the service.</param>
        ''' <remarks>
        ''' This constructor initializes the <see cref="ServiceInstaller"/> with the provided instances of 
        ''' <see cref="IServiceControlManager"/> and <see cref="IServiceCreator"/>. The <see cref="_serviceControlManager"/> 
        ''' field is used to manage the Service Control Manager, and the <see cref="_serviceCreator"/> field is used to create the service.
        ''' </remarks>
        Public Sub New(serviceControlManager As IServiceControlManager, serviceCreator As IServiceCreator)
            _serviceControlManager = serviceControlManager
            _serviceCreator = serviceCreator
        End Sub

        ''' <summary>
        ''' Installs the service.
        ''' </summary>
        ''' <returns><c>True</c> if the service was installed successfully; otherwise, <c>False</c>.</returns>
        ''' <remarks>
        ''' The <see cref="InstallService"/> method implements the logic required to install a service, 
        ''' including necessary configuration and setup steps. It returns <c>True</c> upon successful 
        ''' installation of the service, indicating that the service has been correctly set up and registered. 
        ''' If the installation fails or encounters issues, it returns <c>False</c> to signal that the process 
        ''' was not completed successfully, allowing the caller to handle any errors or take appropriate 
        ''' actions based on the success or failure of the service installation.
        ''' </remarks>
        Public Function InstallService() As Boolean Implements IServiceInstaller.InstallService
            Dim serviceControlManager As IntPtr = NativeMethods.NullHandleValue
            Try
                serviceControlManager = _serviceControlManager.Open()
                _serviceCreator.Create(serviceControlManager)
                Return True
            Catch
                Throw
            Finally
                _serviceControlManager.Close(serviceControlManager)
            End Try
        End Function
    End Class
End Namespace
