Namespace CoreServices.WindowsApiInterop.Structs

    ''' <summary>
    ''' Defines the service status information for a service.
    ''' </summary>
    ''' <remarks>
    ''' The <see cref="ServiceStatus"/> structure contains information about the current state of a service and is used by the service control manager 
    ''' and the service to communicate service status information.
    ''' 
    ''' This structure corresponds to the <see cref="ServiceStatus"/> structure in the Windows API:
    ''' 
    ''' <list type="bullet">
    ''' <item><description><see cref="ServiceStatus.dwServiceType"/>: The type of service. In C++: <code>DWORD dwServiceType;</code></description></item>
    ''' <item><description><see cref="ServiceStatus.dwCurrentState"/>: The current state of the service. In C++: <code>DWORD dwCurrentState;</code></description></item>
    ''' <item><description><see cref="ServiceStatus.dwControlsAccepted"/>: The types of control codes that the service can accept. In C++: <code>DWORD dwControlsAccepted;</code></description></item>
    ''' <item><description><see cref="ServiceStatus.dwWin32ExitCode"/>: The Win32 error code if the service stops. In C++: <code>DWORD dwWin32ExitCode;</code></description></item>
    ''' <item><description><see cref="ServiceStatus.dwServiceSpecificExitCode"/>: The service-specific error code if the service stops. In C++: <code>DWORD dwServiceSpecificExitCode;</code></description></item>
    ''' <item><description><see cref="ServiceStatus.dwCheckPoint"/>: Indicates the progress of the service's operation. In C++: <code>DWORD dwCheckPoint;</code></description></item>
    ''' <item><description><see cref="ServiceStatus.dwWaitHint"/>: Specifies the estimated time required to complete the requested operation, in milliseconds. In C++: <code>DWORD dwWaitHint;</code></description></item>
    ''' </list>
    ''' 
    ''' The <see cref="ServiceStatus"/> structure uses <c>LayoutKind.Sequential</c> to ensure that the fields are laid out
    ''' in the same order as defined in the structure. This ensures compatibility with the unmanaged API.
    ''' 
    ''' <example>
    ''' In C++:
    ''' <code>
    ''' typedef struct _SERVICE_STATUS {
    '''     DWORD dwServiceType;
    '''     DWORD dwCurrentState;
    '''     DWORD dwControlsAccepted;
    '''     DWORD dwWin32ExitCode;
    '''     DWORD dwServiceSpecificExitCode;
    '''     DWORD dwCheckPoint;
    '''     DWORD dwWaitHint;
    ''' } SERVICE_STATUS, *LPSERVICE_STATUS;
    ''' </code>
    ''' </example>
    ''' 
    ''' For additional details on the <see cref="ServiceStatus"/> structure, refer to:
    ''' <see href="https://learn.microsoft.com/en-us/windows/win32/api/winsvc/ns-winsvc-service_status">SERVICE_STATUS Structure</see>.
    ''' </remarks>

    <StructLayout(LayoutKind.Sequential)>
    Friend Structure ServiceStatus

        ''' <summary>
        ''' The type of service. This member can be a combination of the following values:
        ''' <list type="bullet">
        ''' <item><description><see cref="ServiceType.Win32OwnProcess"/>: The service runs in its own process.</description></item>
        ''' <item><description><see cref="ServiceType.Win32ShareProcess"/>: The service shares a process with other services.</description></item>
        ''' <item><description><see cref="ServiceType.Interactive"/>: The service can interact with the desktop.</description></item>
        ''' </list>
        ''' </summary>
        ''' <remarks>
        ''' The <code>dwServiceType</code> member specifies the type of service and is a combination of the values from the <see cref="ServiceType"/> enumeration.
        ''' </remarks>
        ''' <example>
        ''' In C++: <code>DWORD dwServiceType;</code>
        ''' </example>
        Friend dwServiceType As UInteger

        ''' <summary>
        ''' The current state of the service. This member can be one of the following values:
        ''' <list type="bullet">
        ''' <item><description><c>ServiceState.Stopped</c>: The service is not running.</description></item>
        ''' <item><description><c>ServiceState.StartPending</c>: The service is starting.</description></item>
        ''' <item><description><c>ServiceState.StopPending</c>: The service is stopping.</description></item>
        ''' <item><description><c>ServiceState.Run</c>: The service is running.</description></item>
        ''' <item><description><c>ServiceState.PausePending</c>: The service is pausing.</description></item>
        ''' <item><description><c>ServiceState.Paused</c>: The service is paused.</description></item>
        ''' </list>
        ''' </summary>
        ''' <remarks>
        ''' The <c>dwCurrentState</c> member specifies the current state of the service and is a value from the <c>ServiceState</c> enumeration.
        ''' </remarks>
        ''' <example>
        ''' In C++: <code>DWORD dwCurrentState;</code>
        ''' </example>
        Friend dwCurrentState As UInteger

        ''' <summary>
        ''' The types of control code that the service can accept. This member can be a combination of the following values:
        ''' <list type="bullet">
        ''' <item><description><c>ServiceControlFlags.Stop</c>: The service accepts stop control codes.</description></item>
        ''' <item><description><c>ServiceControlFlags.PauseContinue</c>: The service accepts pause and continue control codes.</description></item>
        ''' <item><description><c>ServiceControlFlags.Interrogate</c>: The service accepts interrogate control codes.</description></item>
        ''' </list>
        ''' </summary>
        ''' <remarks>
        ''' The <c>dwControlsAccepted</c> member specifies the types of control codes that the service can accept and is a combination of the values from the <c>ServiceControlFlags</c> enumeration.
        ''' </remarks>
        ''' <example>
        ''' In C++: <code>DWORD dwControlsAccepted;</code>
        ''' </example>
        Friend dwControlsAccepted As UInteger

        ''' <summary>
        ''' The service-specific error code that is returned when the service stops. This code is specific to the service and is defined by the service itself.
        ''' </summary>
        ''' <remarks>
        ''' The <code>dwWin32ExitCode</code> member specifies the Win32 error code that is returned when the service stops.
        ''' </remarks>
        ''' <example>
        ''' In C++: <code>DWORD dwWin32ExitCode;</code>
        ''' </example>
        Friend dwWin32ExitCode As UInteger

        ''' <summary>
        ''' The service-specific error code that is returned when the service stops. This code is specific to the service and is defined by the service itself.
        ''' </summary>
        ''' <remarks>
        ''' The <code>dwServiceSpecificExitCode</code> member specifies the service-specific error code that is returned when the service stops.
        ''' </remarks>
        ''' <example>
        ''' In C++: <code>DWORD dwServiceSpecificExitCode;</code>
        ''' </example>
        Friend dwServiceSpecificExitCode As UInteger

        ''' <summary>
        ''' The service's progress toward completing its start, stop, pause, or continue operation. This member is used by the service to report progress.
        ''' </summary>
        ''' <remarks>
        ''' The <code>dwCheckPoint</code> member indicates the progress of the service's operation.
        ''' </remarks>
        ''' <example>
        ''' In C++: <code>DWORD dwCheckPoint;</code>
        ''' </example>
        Friend dwCheckPoint As UInteger

        ''' <summary>
        ''' The estimated time required to complete the requested service control operation, in milliseconds. This value is used by the service control manager to determine when to check the service status.
        ''' </summary>
        ''' <remarks>
        ''' The <code>dwWaitHint</code> member specifies the estimated time, in milliseconds, that is required to complete the requested operation.
        ''' </remarks>
        ''' <example>
        ''' In C++: <code>DWORD dwWaitHint;</code>
        ''' </example>
        Friend dwWaitHint As UInteger
    End Structure
End Namespace
