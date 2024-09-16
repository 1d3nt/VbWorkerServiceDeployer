Namespace CoreServices.WindowsApiInterop.Enums

    ''' <summary>
    ''' Specifies the start type of the service.
    ''' These flags define how the service should be started when calling <see cref="NativeMethods.CreateService"/>.
    ''' </summary>
    ''' <remarks>
    ''' The following bullet points map the <see cref="StartType"/> enum values to their C++ equivalents:
    ''' <list type="bullet">
    '''     <item><description><see cref="Boot"/> corresponds to the constant <c>SERVICE_BOOT_START</c> in C++.</description></item>
    '''     <item><description><see cref="System"/> corresponds to the constant <c>SERVICE_SYSTEM_START</c> in C++.</description></item>
    '''     <item><description><see cref="Automatic"/> corresponds to the constant <c>SERVICE_AUTO_START</c> in C++.</description></item>
    '''     <item><description><see cref="Manual"/> corresponds to the constant <c>SERVICE_DEMAND_START</c> in C++.</description></item>
    '''     <item><description><see cref="Disabled"/> corresponds to the constant <c>SERVICE_DISABLED</c> in C++.</description></item>
    ''' </list>
    ''' 
    ''' <para>
    ''' Note: The start type defines when the service is started and whether it starts automatically, manually, or if it is disabled.
    ''' </para>
    ''' 
    ''' <para>
    ''' Some members of this enum are marked with <see cref="UsedImplicitlyAttribute"/> as they are not currently used in the application but 
    ''' are kept for completeness and potential future use.
    ''' </para>
    ''' 
    ''' For more information about service start types, refer to:
    ''' <see href="https://learn.microsoft.com/en-us/windows/win32/services/service-start-type">Service Start Type</see>.
    ''' </remarks>
    Friend Enum StartType As UInteger

        ''' <summary>
        ''' A device driver started by the system loader.
        ''' This value is valid only for driver services.
        ''' Corresponds to <c>SERVICE_BOOT_START</c> in C++.
        ''' <para>Note: This member is marked with <see cref="UsedImplicitlyAttribute"/> as it is not currently used but kept for completeness.</para>
        ''' </summary>
        <UsedImplicitly>
        Boot = &H0

        ''' <summary>
        ''' The service is started by the operating system when the system starts.
        ''' This value is used by services that need to be started early in the boot process.
        ''' Corresponds to <c>SERVICE_SYSTEM_START</c> in C++.
        ''' <para>Note: This member is marked with <see cref="UsedImplicitlyAttribute"/> as it is not currently used but kept for completeness.</para>
        ''' </summary>
        <UsedImplicitly>
        System = &H1

        ''' <summary>
        ''' The service is started automatically by the service control manager during system startup.
        ''' Corresponds to <c>SERVICE_AUTO_START</c> in C++.
        ''' </summary>
        Automatic = &H2

        ''' <summary>
        ''' The service is started by the service control manager when a process calls the StartService function.
        ''' Corresponds to <c>SERVICE_DEMAND_START</c> in C++.
        ''' <para>Note: This member is marked with <see cref="UsedImplicitlyAttribute"/> as it is not currently used but kept for completeness.</para>
        ''' </summary>
        <UsedImplicitly>
        Manual = &H3

        ''' <summary>
        ''' The service is disabled and cannot be started.
        ''' Attempts to start the service result in the error code ERROR_SERVICE_DISABLED.
        ''' Corresponds to <c>SERVICE_DISABLED</c> in C++.
        ''' <para>Note: This member is marked with <see cref="UsedImplicitlyAttribute"/> as it is not currently used but kept for completeness.</para>
        ''' </summary>
        <UsedImplicitly>
        Disabled = &H4
    End Enum
End Namespace
