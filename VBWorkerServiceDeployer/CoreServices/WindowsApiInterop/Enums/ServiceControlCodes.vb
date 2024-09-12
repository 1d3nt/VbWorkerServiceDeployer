Namespace CoreServices.WindowsApiInterop.Enums

    ''' <summary>
    ''' Defines control codes for the <see cref="NativeMethods.ControlService"/> function, used to send control commands to a service.
    ''' </summary>
    ''' <remarks>
    ''' The <see cref="ServiceControlCodes"/> enumeration specifies the different control codes that can be sent to a service to request specific actions or status updates.
    ''' </remarks>
    ''' <list type="bullet">
    ''' <item>
    ''' <description><see cref="Stop"/>: Notifies the service to stop. In C++: <code>SERVICE_CONTROL_STOP</code></description>
    ''' </item>
    ''' <item>
    ''' <description><see cref="Pause"/>: Notifies the service to pause. In C++: <code>SERVICE_CONTROL_PAUSE</code></description>
    ''' </item>
    ''' <item>
    ''' <description><see cref="Continue"/>: Notifies a paused service that it should resume. In C++: <code>SERVICE_CONTROL_CONTINUE</code></description>
    ''' </item>
    ''' <item>
    ''' <description><see cref="Interrogate"/>: Notifies a service that it should report its current status information. In C++: <code>SERVICE_CONTROL_INTERROGATE</code></description>
    ''' </item>
    ''' <item>
    ''' <description><see cref="ParamChange"/>: Notifies a service that its startup parameters have changed. In C++: <code>SERVICE_CONTROL_PARAMCHANGE</code></description>
    ''' </item>
    ''' <item>
    ''' <description><see cref="NetBindAdd"/>: Notifies a network service that there is a new component for binding. This control code is deprecated. In C++: <code>SERVICE_CONTROL_NETBINDADD</code></description>
    ''' </item>
    ''' <item>
    ''' <description><see cref="NetBindRemove"/>: Notifies a network service that a component for binding has been removed. This control code is deprecated. In C++: <code>SERVICE_CONTROL_NETBINDREMOVE</code></description>
    ''' </item>
    ''' <item>
    ''' <description><see cref="NetBindEnable"/>: Notifies a network service that a disabled binding has been enabled. This control code is deprecated. In C++: <code>SERVICE_CONTROL_NETBINDENABLE</code></description>
    ''' </item>
    ''' <item>
    ''' <description><see cref="NetBindDisable"/>: Notifies a network service that a binding has been disabled. This control code is deprecated. In C++: <code>SERVICE_CONTROL_NETBINDDISABLE</code></description>
    ''' </item>
    ''' </list>
    Public Enum ServiceControlCodes As UInteger

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
    NetBindDisable = &HA
    End Enum
End Namespace
