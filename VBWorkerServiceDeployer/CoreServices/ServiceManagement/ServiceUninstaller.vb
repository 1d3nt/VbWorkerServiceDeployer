Namespace CoreServices.ServiceManagement

    ''' <summary>
    ''' Handles the uninstallation of services.
    ''' </summary>
    ''' <seealso cref="IServiceUninstaller"/>
    ''' <remarks>
    ''' The <see cref="ServiceUninstaller"/> class implements the <see cref="IServiceUninstaller"/> interface to provide
    ''' the logic required for uninstalling a service. This class relies on several dependencies to manage the
    ''' uninstallation process, including stopping the service, checking its status, and deleting it.
    ''' </remarks>
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
        ''' The service status checker.
        ''' </summary>
        Private ReadOnly _serviceStatusChecker As IServiceStatusChecker

        ''' <summary>
        ''' The service deleter.
        ''' </summary>
        Private ReadOnly _serviceDeleter As IServiceDeleter

        ''' <summary>
        ''' Initializes a new instance of the <see cref="ServiceUninstaller"/> class.
        ''' </summary>
        ''' <param name="serviceControlManager">An instance of <see cref="IServiceControlManager"/> used for managing the service control manager.</param>
        ''' <param name="servicePathProvider">An instance of <see cref="IServicePathProvider"/> used for retrieving service paths and names.</param>
        ''' <param name="serviceStopper">An instance of <see cref="IServiceStopper"/> used for stopping the service.</param>
        ''' <param name="serviceStatusChecker">An instance of <see cref="IServiceStatusChecker"/> used for checking the status of the service.</param>
        ''' <param name="serviceDeleter">An instance of <see cref="IServiceDeleter"/> used for deleting the service.</param>
        Public Sub New(serviceControlManager As IServiceControlManager, servicePathProvider As IServicePathProvider, serviceStopper As IServiceStopper, serviceStatusChecker As IServiceStatusChecker, serviceDeleter As IServiceDeleter)
            _serviceControlManager = serviceControlManager
            _servicePathProvider = servicePathProvider
            _serviceStopper = serviceStopper
            _serviceStatusChecker = serviceStatusChecker
            _serviceDeleter = serviceDeleter
        End Sub

        ''' <summary>
        ''' Uninstalls the service.
        ''' </summary>
        ''' <returns><c>True</c> if the service was successfully uninstalled; otherwise, <c>False</c>.</returns>
        ''' <remarks>
        ''' This method uses <see cref="DesiredAccess.All"/> for opening the service handle. Although <see cref="DesiredAccess.Stop"/> and
        ''' <see cref="DesiredAccess.Delete"/> might seem sufficient, <see cref="DesiredAccess.All"/> ensures all necessary permissions are granted.
        ''' It was found that using <see cref="DesiredAccess.All"/> is required for the delete operation to succeed, even though
        ''' it grants broader access than stopping alone.
        ''' </remarks>
        Friend Async Function UninstallServiceAsync() As Task(Of Boolean) Implements IServiceUninstaller.UninstallServiceAsync
            Dim serviceName As String = _servicePathProvider.GetServiceName()
            Dim serviceControlManager As IntPtr = NativeMethods.NullHandleValue
            Dim serviceHandle As IntPtr = NativeMethods.NullHandleValue

            Try
                serviceControlManager = _serviceControlManager.Open(ServiceManagerAccessFlags.Connect Or ServiceManagerAccessFlags.EnumerateService)
                serviceHandle = _serviceControlManager.OpenService(serviceControlManager, serviceName, DesiredAccess.All)
                If Not Await StopAndDeleteServiceAsync(serviceHandle) Then
                    Return False
                End If
                Return True
            Catch
                Throw
            Finally
                _serviceControlManager.Close(serviceControlManager)
                _serviceControlManager.Close(serviceHandle)
            End Try
        End Function

        ''' <summary>
        ''' Stops the service and deletes it if stopped successfully.
        ''' </summary>
        ''' <param name="serviceHandle">The handle to the service.</param>
        ''' <returns><c>True</c> if the service was stopped and deleted successfully; otherwise, <c>False</c>.</returns>
        ''' <remarks>
        ''' This method first attempts to stop the service using <see cref="IServiceStopper.StopService"/>. It then waits for the service
        ''' to stop using <see cref="IServiceStatusChecker.WaitForServiceToStopAsync"/> before proceeding to delete it using
        ''' <see cref="IServiceDeleter.DeleteService"/>.
        ''' </remarks>
        Private Async Function StopAndDeleteServiceAsync(serviceHandle As IntPtr) As Task(Of Boolean)
            Try
                _serviceStopper.StopService(serviceHandle)
                Dim serviceStopped As Boolean = Await _serviceStatusChecker.WaitForServiceToStopAsync(serviceHandle)
                If Not serviceStopped Then
                    Return False
                End If
                _serviceDeleter.DeleteService(serviceHandle)
                Return True
            Catch ex As Exception
                Throw
            End Try
        End Function
    End Class
End Namespace
