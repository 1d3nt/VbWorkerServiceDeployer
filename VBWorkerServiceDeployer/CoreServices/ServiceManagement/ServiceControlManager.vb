﻿Namespace CoreServices.ServiceManagement

    ''' <summary>
    ''' Handles opening and closing the Service Control Manager.
    ''' </summary>
    Public Class ServiceControlManager
        Implements IServiceControlManager

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
        ''' The error handling service.
        ''' </summary>
        Private ReadOnly _errorHandlingService As IErrorHandlingService

        ''' <summary>
        ''' Initializes a new instance of the <see cref="ServiceControlManager"/> class.
        ''' </summary>
        ''' <param name="errorHandlingService">
        ''' An instance of <see cref="IErrorHandlingService"/> used for handling errors.
        ''' </param>
        Public Sub New(errorHandlingService As IErrorHandlingService)
            _errorHandlingService = errorHandlingService
        End Sub

        ''' <summary>
        ''' Opens the Service Control Manager with the specified access rights.
        ''' </summary>
        ''' <param name="desiredAccess">The desired access level for the Service Control Manager.</param>
        ''' <returns>An IntPtr representing the handle to the Service Control Manager.</returns>
        Public Function Open(desiredAccess As ServiceManagerAccessFlags) As IntPtr Implements IServiceControlManager.Open
            Dim serviceControlManager = NativeMethods.OpenSCManager(LocalMachineName, DefaultScmDatabase, desiredAccess)
            _errorHandlingService.HandleWin32Error(serviceControlManager)
            Return serviceControlManager
        End Function

        ''' <summary>
        ''' Opens a handle to the specified service.
        ''' </summary>
        ''' <param name="scmHandle">The handle to the Service Control Manager.</param>
        ''' <param name="serviceName">The name of the service to open.</param>
        ''' <param name="desiredAccess">The desired access level for the service.</param>
        ''' <returns>An IntPtr representing the handle to the service.</returns>
        Public Function OpenService(scmHandle As IntPtr, serviceName As String, desiredAccess As DesiredAccess) As IntPtr Implements IServiceControlManager.OpenService
            Dim serviceHandle = NativeMethods.OpenService(scmHandle, serviceName, desiredAccess)
            _errorHandlingService.HandleWin32Error(serviceHandle)
            Return serviceHandle
        End Function

        ''' <summary>
        ''' Closes the Service Control Manager handle if it is not null.
        ''' </summary>
        ''' <param name="serviceControlManager">The handle to the Service Control Manager.</param>
        Public Sub Close(serviceControlManager As IntPtr) Implements IServiceControlManager.Close
            HandleManager.CloseServiceHandleIfNotNull(serviceControlManager)
        End Sub
    End Class
End Namespace