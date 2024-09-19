Namespace CoreServices.WindowsApiInterop.Enums

    ''' <summary>
    ''' Defines the severity of the error if the service fails to start during boot.
    ''' </summary>
    ''' <remarks>
    ''' The <see cref="ServiceErrorControlFlags"/> enumeration specifies how the operating system handles errors that occur when a service fails to start during the boot process.
    ''' 
    ''' Although there is no direct C++ enumeration that matches these values, similar error control flags are used in Windows API functions.
    ''' For example, in C++ code, you might use these constants with API functions such as <c>CreateServiceA</c>.
    ''' 
    ''' The following bullet points map the <see cref="ServiceErrorControlFlags"/> enum values to their C++ equivalents:
    ''' <list type="bullet">
    '''     <item><description><see cref="ServiceErrorIgnore"/> corresponds to the constant <c>ERROR_CONTROL_IGNORE</c> in C++.</description></item>
    '''     <item><description><see cref="ServiceErrorNormal"/> corresponds to the constant <c>ERROR_CONTROL_NORMAL</c> in C++.</description></item>
    '''     <item><description><see cref="ServiceErrorSevere"/> corresponds to the constant <c>ERROR_CONTROL_SEVERE</c> in C++.</description></item>
    '''     <item><description><see cref="ServiceErrorCritical"/> corresponds to the constant <c>ERROR_CONTROL_CRITICAL</c> in C++.</description></item>
    ''' </list>
    ''' 
    ''' Note: Although some values may not be used in the current implementation, they are included for completeness and potential future needs.
    ''' 
    ''' For more information about the service creation and error control flags, refer to:
    ''' <see href="https://learn.microsoft.com/en-us/windows/win32/api/winsvc/nf-winsvc-createservicea">CreateServiceA function</see>.
    ''' </remarks>
    Friend Enum ServiceErrorControlFlags As UInteger

        ''' <summary>
        ''' The startup program logs the error but continues the startup operation.
        ''' </summary>
        ''' <remarks>
        ''' The error is logged, but the system continues the startup process without taking additional action.
        ''' This member is marked with <see cref="UsedImplicitlyAttribute"/> because it is not directly referenced in the current code, 
        ''' but is included for completeness and potential future use.
        ''' </remarks>
        ''' <example>
        ''' In C++: <code>ERROR_CONTROL_IGNORE</code>
        ''' </example>
        <UsedImplicitly>
        ServiceErrorIgnore = 0

        ''' <summary>
        ''' The startup program logs the error, displays a message, and continues the startup operation.
        ''' </summary>
        ''' <remarks>
        ''' The error is logged, a message is displayed, and the system continues the startup process.
        ''' </remarks>
        ''' <example>
        ''' In C++: <code>ERROR_CONTROL_NORMAL</code>
        ''' </example>
        ServiceErrorNormal = 1

        ''' <summary>
        ''' The startup program logs the error. If the last-known good configuration is being loaded, the startup program will try to start the service.
        ''' </summary>
        ''' <remarks>
        ''' The error is logged. If the system is loading a last-known good configuration, the system will attempt to start the service.
        ''' This member is marked with <see cref="UsedImplicitlyAttribute"/> because it is not directly referenced in the current code, 
        ''' but is included for completeness and potential future use.
        ''' </remarks>
        ''' <example>
        ''' In C++: <code>ERROR_CONTROL_SEVERE</code>
        ''' </example>
        <UsedImplicitly>
        ServiceErrorSevere = 2

        ''' <summary>
        ''' The startup program logs the error, displays a message, and the service is marked as failed. The startup program will not continue.
        ''' </summary>
        ''' <remarks>
        ''' The error is logged, a message is displayed, and the service is marked as failed. The system will stop the startup process.
        ''' This member is marked with <see cref="UsedImplicitlyAttribute"/> because it is not directly referenced in the current code, 
        ''' but is included for completeness and potential future use.
        ''' </remarks>
        ''' <example>
        ''' In C++: <code>ERROR_CONTROL_CRITICAL</code>
        ''' </example>
        <UsedImplicitly>
        ServiceErrorCritical = 3
    End Enum
End Namespace
