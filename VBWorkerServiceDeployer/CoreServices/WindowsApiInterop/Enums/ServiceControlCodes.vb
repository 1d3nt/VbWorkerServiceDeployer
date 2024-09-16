Namespace CoreServices.WindowsApiInterop.Enums

    ''' <summary>
    ''' Defines control codes for the <see cref="NativeMethods.ControlService"/> function, used to send control commands to a service.
    ''' </summary>
    ''' <remarks>
    ''' The <see cref="ServiceControlCodes"/> enumeration specifies the different control codes that can be sent to a service to request specific actions or status updates.
    ''' 
    ''' Although there is no direct C++ enumeration that matches these values, similar control codes are used in Windows API functions.
    ''' For example, in C++ code, you might use these constants with API functions such as <c>SERVICE_CONTROL_STOP</c> or <c>SERVICE_CONTROL_PAUSE</c>.
    ''' 
    ''' The following bullet points map the <see cref="ServiceControlCodes"/> enum values to their C++ equivalents:
    ''' <list type="bullet">
    '''     <item><description><see cref="Stop"/> corresponds to the constant <c>SERVICE_CONTROL_STOP</c> in C++.</description></item>
    '''     <item><description><see cref="Pause"/> corresponds to the constant <c>SERVICE_CONTROL_PAUSE</c> in C++.</description></item>
    '''     <item><description><see cref="Continue"/> corresponds to the constant <c>SERVICE_CONTROL_CONTINUE</c> in C++.</description></item>
    '''     <item><description><see cref="Interrogate"/> corresponds to the constant <c>SERVICE_CONTROL_INTERROGATE</c> in C++.</description></item>
    '''     <item><description><see cref="ParamChange"/> corresponds to the constant <c>SERVICE_CONTROL_PARAMCHANGE</c> in C++.</description></item>
    '''     <item><description><see cref="NetBindAdd"/> corresponds to the constant <c>SERVICE_CONTROL_NETBINDADD</c> in C++.</description></item>
    '''     <item><description><see cref="NetBindRemove"/> corresponds to the constant <c>SERVICE_CONTROL_NETBINDREMOVE</c> in C++.</description></item>
    '''     <item><description><see cref="NetBindEnable"/> corresponds to the constant <c>SERVICE_CONTROL_NETBINDENABLE</c> in C++.</description></item>
    '''     <item><description><see cref="NetBindDisable"/> corresponds to the constant <c>SERVICE_CONTROL_NETBINDDISABLE</c> in C++.</description></item>
    ''' </list>
    ''' 
    ''' Note: Although some values may not be used in the current implementation, they are included for completeness and potential future needs.
    ''' 
    ''' For more information about control codes for services, refer to:
    ''' <see href="https://learn.microsoft.com/en-us/windows/win32/api/winsvc/nf-winsvc-controlservice">ControlService function</see>.
    ''' </remarks>
    Friend Enum ServiceControlCodes As UInteger

        ''' <summary>
        ''' Notifies the service to stop.
        ''' </summary>
        ''' <remarks>
        ''' The service is requested to stop its operations. The handle must have the <code>SERVICE_STOP</code> access right.
        ''' </remarks>
        ''' <example>
        ''' In C++: <code>SERVICE_CONTROL_STOP</code>
        ''' </example>
        [Stop] = &H1

        ''' <summary>
        ''' Notifies the service to pause.
        ''' </summary>
        ''' <remarks>
        ''' The service is requested to pause its operations. The handle must have the <code>SERVICE_PAUSE_CONTINUE</code> access right.
        ''' </remarks>
        ''' <example>
        ''' In C++: <code>SERVICE_CONTROL_PAUSE</code>
        ''' </example>
        Pause = &H2

        ''' <summary>
        ''' Notifies a paused service that it should resume.
        ''' </summary>
        ''' <remarks>
        ''' The service is requested to resume its operations after a pause. The handle must have the <code>SERVICE_PAUSE_CONTINUE</code> access right.
        ''' </remarks>
        ''' <example>
        ''' In C++: <code>SERVICE_CONTROL_CONTINUE</code>
        ''' </example>
        [Continue] = &H3

        ''' <summary>
        ''' Notifies a service that it should report its current status information.
        ''' </summary>
        ''' <remarks>
        ''' The service is requested to report its current status to the service control manager. The handle must have the <code>SERVICE_INTERROGATE</code> access right.
        ''' </remarks>
        ''' <example>
        ''' In C++: <code>SERVICE_CONTROL_INTERROGATE</code>
        ''' </example>
        Interrogate = &H4

        ''' <summary>
        ''' Notifies a service that its startup parameters have changed.
        ''' </summary>
        ''' <remarks>
        ''' The service is requested to reload or handle changes to its startup parameters. The handle must have the <code>SERVICE_PAUSE_CONTINUE</code> access right.
        ''' </remarks>
        ''' <example>
        ''' In C++: <code>SERVICE_CONTROL_PARAMCHANGE</code>
        ''' </example>
        <UsedImplicitly>
        ParamChange = &H6

        ''' <summary>
        ''' Notifies a network service that there is a new component for binding. This control code is deprecated.
        ''' </summary>
        ''' <remarks>
        ''' The service is notified of a new binding component. This control code is deprecated; use Plug and Play functionality instead.
        ''' </remarks>
        ''' <example>
        ''' In C++: <code>SERVICE_CONTROL_NETBINDADD</code>
        ''' </example>
        <UsedImplicitly>
        NetBindAdd = &H7

        ''' <summary>
        ''' Notifies a network service that a component for binding has been removed. This control code is deprecated.
        ''' </summary>
        ''' <remarks>
        ''' The service is notified of a removed binding component. This control code is deprecated; use Plug and Play functionality instead.
        ''' </remarks>
        ''' <example>
        ''' In C++: <code>SERVICE_CONTROL_NETBINDREMOVE</code>
        ''' </example>
        <UsedImplicitly>
        NetBindRemove = &H8

        ''' <summary>
        ''' Notifies a network service that a disabled binding has been enabled. This control code is deprecated.
        ''' </summary>
        ''' <remarks>
        ''' The service is notified of an enabled binding. This control code is deprecated; use Plug and Play functionality instead.
        ''' </remarks>
        ''' <example>
        ''' In C++: <code>SERVICE_CONTROL_NETBINDENABLE</code>
        ''' </example>
        <UsedImplicitly>
        NetBindEnable = &H9

        ''' <summary>
        ''' Notifies a network service that a binding has been disabled. This control code is deprecated.
        ''' </summary>
        ''' <remarks>
        ''' The service is notified of a disabled binding. This control code is deprecated; use Plug and Play functionality instead.
        ''' </remarks>
        ''' <example>
        ''' In C++: <code>SERVICE_CONTROL_NETBINDDISABLE</code>
        ''' </example>
        <UsedImplicitly>
        NetBindDisable = &HA
    End Enum
End Namespace
