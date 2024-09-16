Namespace CoreServices.ServiceManagement.Interfaces

    ''' <summary>
    ''' Defines the contract for managing the Service Control Manager.
    ''' </summary>
    ''' <remarks>
    ''' This interface specifies the methods for interacting with the Service Control Manager (SCM).
    ''' It includes methods to open handles to the SCM and services, and to close these handles.
    ''' These methods use P/Invoke to call Windows API functions.
    ''' </remarks>
    ''' <seealso cref="ServiceControlManager"/>
    Public Interface IServiceControlManager

        ''' <summary>
        ''' Opens the Service Control Manager with the specified access rights.
        ''' </summary>
        ''' <param name="desiredAccess">The desired access level for the Service Control Manager.</param>
        ''' <returns>An <see cref="IntPtr"/> representing the handle to the Service Control Manager.</returns>
        ''' <remarks>
        ''' This method wraps the <see cref="NativeMethods.OpenSCManager"/> function from the Windows API.
        ''' <see href="https://learn.microsoft.com/en-us/windows/win32/api/winsvc/nf-winsvc-openscmanagerw"/>
        ''' </remarks>
        Function Open(desiredAccess As ServiceManagerAccessFlags) As IntPtr

        ''' <summary>
        ''' Opens a handle to the specified service.
        ''' </summary>
        ''' <param name="scmHandle">The handle to the Service Control Manager.</param>
        ''' <param name="serviceName">The name of the service to open.</param>
        ''' <param name="desiredAccess">The desired access level for the service.</param>
        ''' <returns>An <see cref="IntPtr"/> representing the handle to the service.</returns>
        ''' <remarks>
        ''' This method wraps the <see cref="NativeMethods.OpenService"/> function from the Windows API.
        ''' <see href="https://learn.microsoft.com/en-us/windows/win32/api/winsvc/nf-winsvc-openservicew"/>
        ''' </remarks>
        Function OpenService(scmHandle As IntPtr, serviceName As String, desiredAccess As DesiredAccess) As IntPtr

        ''' <summary>
        ''' Closes the Service Control Manager handle if it is not null.
        ''' </summary>
        ''' <param name="serviceControlManager">The handle to the Service Control Manager.</param>
        ''' <remarks>
        ''' This method wraps the <see cref="NativeMethods.CloseServiceHandle"/> function from the Windows API.
        ''' <see href="https://learn.microsoft.com/en-us/windows/win32/api/winsvc/nf-winsvc-closeservicehandle"/>
        ''' </remarks>
        Sub Close(serviceControlManager As IntPtr)
    End Interface
End Namespace
