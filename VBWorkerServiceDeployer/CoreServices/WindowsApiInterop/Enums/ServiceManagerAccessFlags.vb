Namespace CoreServices.WindowsApiInterop.Enums

    ''' <summary>
    ''' Specifies the access rights for the service control manager (SCM).
    ''' These flags are used to define the desired access when calling <see cref="NativeMethods.OpenSCManager"/>.
    ''' </summary>
    ''' <remarks>
    ''' The <see cref="ServiceManagerAccessFlags"/> enumeration specifies the different access rights that can be requested when interacting with the service control manager.
    ''' 
    ''' The following bullet points map the <see cref="ServiceManagerAccessFlags"/> enum values to their C++ equivalents:
    ''' <list type="bullet">
    '''     <item><description><see cref="Connect"/> corresponds to the constant <c>SC_MANAGER_CONNECT</c> in C++.</description></item>
    '''     <item><description><see cref="CreateService"/> corresponds to the constant <c>SC_MANAGER_CREATE_SERVICE</c> in C++.</description></item>
    '''     <item><description><see cref="EnumerateService"/> corresponds to the constant <c>SC_MANAGER_ENUMERATE_SERVICE</c> in C++.</description></item>
    '''     <item><description><see cref="Lock"/> corresponds to the constant <c>SC_MANAGER_LOCK</c> in C++.</description></item>
    '''     <item><description><see cref="QueryLockStatus"/> corresponds to the constant <c>SC_MANAGER_QUERY_LOCK_STATUS</c> in C++.</description></item>
    '''     <item><description><see cref="ModifyBootConfig"/> corresponds to the constant <c>SC_MANAGER_MODIFY_BOOT_CONFIG</c> in C++.</description></item>
    '''     <item><description><see cref="AllAccess"/> corresponds to the constant <c>SC_MANAGER_ALL_ACCESS</c> in C++.</description></item>
    ''' </list>
    ''' 
    ''' Note: Although this enum maps to specific access rights used with the service control manager, there is no direct C++ enumeration 
    ''' that matches these values. The enum members are used to specify the required access rights in Windows API functions such as 
    ''' <see cref="NativeMethods.OpenSCManager"/>. Some members are marked with <see cref="UsedImplicitlyAttribute"/> because they are 
    ''' not directly referenced in the current code, but are retained for completeness and potential future use.
    ''' 
    ''' For more information about security and access control models, refer to:
    ''' <see href="https://learn.microsoft.com/en-us/windows/win32/services/service-security-and-access-rights">Service Security and Access Rights</see>.
    ''' </remarks>
    <Flags>
    Public Enum ServiceManagerAccessFlags As UInteger

        ''' <summary>
        ''' Required to connect to the service control manager.
        ''' Corresponds to <c>SC_MANAGER_CONNECT</c> in C++.
        ''' </summary>
        Connect = &H1

        ''' <summary>
        ''' Required to call the CreateService function to create a service object and add it to the database.
        ''' Corresponds to <c>SC_MANAGER_CREATE_SERVICE</c> in C++.
        ''' </summary>
        CreateService = &H2

        ''' <summary>
        ''' Required to call the EnumServicesStatusEx function to list the services that are in the database.
        ''' Corresponds to <c>SC_MANAGER_ENUMERATE_SERVICE</c> in C++.
        ''' </summary>
        EnumerateService = &H4

        ''' <summary>
        ''' Required to call the LockServiceDatabase function to acquire a lock on the database.
        ''' Corresponds to <c>SC_MANAGER_LOCK</c> in C++.
        ''' </summary>
        ''' <remarks>
        ''' This member is marked with <see cref="UsedImplicitlyAttribute"/> because it is not directly referenced in the current code, 
        ''' but is included for completeness and potential future use.
        ''' </remarks>
        <UsedImplicitly>
        Lock = &H8

        ''' <summary>
        ''' Required to call the QueryServiceLockStatus function to retrieve the lock status information for the database.
        ''' Corresponds to <c>SC_MANAGER_QUERY_LOCK_STATUS</c> in C++.
        ''' </summary>
        ''' <remarks>
        ''' This member is marked with <see cref="UsedImplicitlyAttribute"/> because it is not directly referenced in the current code, 
        ''' but is included for completeness and potential future use.
        ''' </remarks>
        <UsedImplicitly>
        QueryLockStatus = &H10

        ''' <summary>
        ''' Required to modify the boot configuration of the system.
        ''' Corresponds to <c>SC_MANAGER_MODIFY_BOOT_CONFIG</c> in C++.
        ''' </summary>
        ''' <remarks>
        ''' This member is marked with <see cref="UsedImplicitlyAttribute"/> because it is not directly referenced in the current code, 
        ''' but is included for completeness and potential future use.
        ''' </remarks>
        <UsedImplicitly>
        ModifyBootConfig = &H20

        ''' <summary>
        ''' Combines all the access rights required for service management operations.
        ''' Corresponds to <c>SC_MANAGER_ALL_ACCESS</c> in C++.
        ''' </summary>
        ''' <remarks>
        ''' This member is marked with <see cref="UsedImplicitlyAttribute"/> because it is not directly referenced in the current code, 
        ''' but is included for completeness and potential future use.
        ''' </remarks>
        <UsedImplicitly>
        AllAccess = &HF003F
    End Enum
End Namespace
