Namespace CoreServices.WindowsApiInterop.Enums

    ''' <summary>
    ''' Defines the severity of the error if the service fails to start during boot.
    ''' </summary>
    ''' <remarks>
    ''' The <see cref="ServiceErrorControlFlags"/> enumeration specifies how the operating system handles errors that occur when a service fails to start during the boot process.
    ''' </remarks>
    ''' <list type="bullet">
    ''' <item>
    ''' <description><see cref="ServiceErrorIgnore"/>: The startup program logs the error but continues the startup operation.</description>
    ''' </item>
    ''' <item>
    ''' <description><see cref="ServiceErrorNormal"/>: The startup program logs the error, displays a message, and continues the startup operation.</description>
    ''' </item>
    ''' <item>
    ''' <description><see cref="ServiceErrorSevere"/>: The startup program logs the error. If the last-known good configuration is being loaded, the startup program will try to start the service.</description>
    ''' </item>
    ''' <item>
    ''' <description><see cref="ServiceErrorCritical"/>: The startup program logs the error, displays a message, and the service is marked as failed. The startup program will not continue.</description>
    ''' </item>
    ''' </list>
    Public Enum ServiceErrorControlFlags As UInteger

        ''' <summary>
        ''' The startup program logs the error but continues the startup operation.
        ''' </summary>
        ''' <remarks>
        ''' The error is logged, but the system continues the startup process without taking additional action.
        ''' </remarks>
        ''' <example>
        ''' In C++: <code>ERROR_CONTROL_IGNORE</code>
        ''' </example>
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
        ''' </remarks>
        ''' <example>
        ''' In C++: <code>ERROR_CONTROL_SEVERE</code>
        ''' </example>
        ServiceErrorSevere = 2

        ''' <summary>
        ''' The startup program logs the error, displays a message, and the service is marked as failed. The startup program will not continue.
        ''' </summary>
        ''' <remarks>
        ''' The error is logged, a message is displayed, and the service is marked as failed. The system will stop the startup process.
        ''' </remarks>
        ''' <example>
        ''' In C++: <code>ERROR_CONTROL_CRITICAL</code>
        ''' </example>
        ServiceErrorCritical = 3
    End Enum
End Namespace
