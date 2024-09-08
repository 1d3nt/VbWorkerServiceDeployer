Namespace CoreServices.ServiceManagement

    ''' <summary>
    ''' Handles the installation of services.
    ''' </summary>
    ''' <remarks>
    ''' The <see cref="ServiceInstaller"/> class provides methods to install services using P/Invoke and other necessary operations.
    ''' </remarks>
    Public Class ServiceInstaller
        Implements IServiceInstaller

        ''' <summary>
        ''' Represents the local machine name used in P/Invoke calls to specify the local system.
        ''' </summary>
        ''' <remarks>
        ''' This constant is used in P/Invoke calls such as <see cref="NativeMethods.OpenSCManager"/> where 
        ''' the first argument specifies the target machine. A value of "." refers to the local machine.
        ''' </remarks>
        Private Const LocalMachineName As String = "."

        ''' <summary>
        ''' Represents the default service control manager database.
        ''' </summary>
        ''' <remarks>
        ''' This constant is used in P/Invoke calls where the service control manager database 
        ''' is not specified, allowing the system to use the default database.
        ''' </remarks>
        Private Const DefaultScmDatabase As String = Nothing

        ''' <summary>
        ''' The service path provider used for retrieving service paths and names.
        ''' </summary>
        Private ReadOnly _servicePathProvider As IServicePathProvider

        ''' <summary>
        ''' Provides utility methods for handling Win32 errors.
        ''' </summary>
        Private ReadOnly _win32ErrorHelper As IWin32ErrorHelper

        ''' <summary>
        ''' Initializes a new instance of the <see cref="ServiceInstaller"/> class.
        ''' </summary>
        ''' <param name="servicePathProvider">
        ''' An instance of <see cref="IServicePathProvider"/> used to obtain service paths and names.
        ''' </param>
        ''' <param name="win32ErrorHelper">
        ''' An instance of <see cref="IWin32ErrorHelper"/> used to retrieve Win32 error codes.
        ''' </param>
        ''' <remarks>
        ''' The constructor takes instances of <see cref="IServicePathProvider"/> and <see cref="IWin32ErrorHelper"/> 
        ''' as parameters and assigns them to the corresponding fields. The <see cref="_servicePathProvider"/> field 
        ''' is used to obtain service paths and names, while the <see cref="_win32ErrorHelper"/> field is used for handling 
        ''' Win32 error codes.
        ''' </remarks>
        Public Sub New(servicePathProvider As IServicePathProvider, win32ErrorHelper As IWin32ErrorHelper)
            _servicePathProvider = servicePathProvider
            _win32ErrorHelper = win32ErrorHelper
        End Sub

        ''' <summary>
        ''' Installs the service.
        ''' </summary>
        ''' <returns>
        ''' <c>True</c> if the service was installed successfully; otherwise, <c>False</c>.
        ''' </returns>
        ''' <remarks>
        ''' The <see cref="IServiceInstaller.InstallService"/> method should implement the logic required 
        ''' to install a service, including any necessary configuration and setup steps. The method is 
        ''' expected to return <c>True</c> upon successful installation of the service, indicating that 
        ''' the service has been correctly set up and registered. If the installation fails or encounters 
        ''' issues, the method should return <c>False</c> to signal that the process was not completed 
        ''' successfully. This allows the caller to handle any errors or take appropriate actions based 
        ''' on the success or failure of the service installation.
        ''' </remarks>
        Public Function InstallService() As Boolean Implements IServiceInstaller.InstallService
            Dim serviceControlManager As IntPtr = NativeMethods.NullHandleValue
            Try
                serviceControlManager = NativeMethods.OpenSCManager(LocalMachineName, DefaultScmDatabase, ServiceManagerAccessFlags.CreateService)
                If Equals(serviceControlManager, NativeMethods.NullHandleValue) Then
                    Throw New InvalidOperationException($"Failed to open Service Control Manager. Error code: {_win32ErrorHelper.GetLastWin32Error()}")
                End If
                Dim service = TryCreateService(_servicePathProvider.GetServicePath(), _servicePathProvider.GetServiceName(), serviceControlManager)
                If Equals(service, NativeMethods.NullHandleValue) Then
                    Throw New InvalidOperationException($"Failed to create service. Error code: {_win32ErrorHelper.GetLastWin32Error()}")
                End If
                Return True
            Catch ex As Exception
                Console.WriteLine($"Error installing service: {ex.Message}")
                Return False
            Finally
                HandleManager.CloseServiceHandleIfNotNull(serviceControlManager)
            End Try
        End Function


        ''' <summary>
        ''' Creates a service object and installs it in the service control manager database 
        ''' by creating a key with the service name under the following registry key: 
        ''' HKEY_LOCAL_MACHINE\System\CurrentControlSet\Services.
        ''' </summary>
        ''' <param name="servicePath">Specifies the full path to the service executable.</param>
        ''' <param name="serviceName">Specifies the name to be used for the Service key in the registry.</param>
        ''' <param name="serviceControlManager">Handle to the service control manager database returned by <see cref="NativeMethods.OpenSCManager" />.</param>
        ''' <returns>
        ''' Returns a handle to the newly created service if successful. If it fails, returns IntPtr.Zero.
        ''' Call GetLastError for extended error information.
        ''' </returns>
        Private Shared Function TryCreateService(servicePath As String, serviceName As String, serviceControlManager As IntPtr) As IntPtr
            Return NativeMethods.CreateService(serviceControlManager, serviceName, serviceName, DesiredAccess.All, ServiceType.Win32OwnProcess, StartType.Automatic, ServiceErrorControlFlags.ServiceErrorNormal,
                                               servicePath, lpLoadOrderGroup:=Nothing, lpdwTagId:=0, lpDependencies:=Nothing, lpServiceStartName:=Nothing, lpPassword:=Nothing)
        End Function
    End Class
End Namespace
