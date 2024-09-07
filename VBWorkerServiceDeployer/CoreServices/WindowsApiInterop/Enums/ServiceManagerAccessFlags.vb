Namespace CoreServices.WindowsApiInterop.Enums

    ''' <summary>
    ''' Specifies the access rights for the service control manager (SCM).
    ''' These flags are used to define the desired access when calling <see cref="NativeMethods.OpenSCManager"/>.
    ''' </summary>
    ''' <remarks>
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
    ''' <para>
    ''' Note: Although many of these access rights may not be used in the current application, they have been migrated from another project 
    ''' and are kept here for completeness and potential future use. Members marked with <see cref="UsedImplicitlyAttribute"/> are not currently utilized 
    ''' but are retained for reference and potential future needs based on the project's objectives.
    ''' </para>
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
        Lock = &H8

        ''' <summary>
        ''' Required to call the QueryServiceLockStatus function to retrieve the lock status information for the database.
        ''' Corresponds to <c>SC_MANAGER_QUERY_LOCK_STATUS</c> in C++.
        ''' </summary>
        QueryLockStatus = &H10

        ''' <summary>
        ''' Required to modify the boot configuration of the system.
        ''' Corresponds to <c>SC_MANAGER_MODIFY_BOOT_CONFIG</c> in C++.
        ''' </summary>
        ModifyBootConfig = &H20

        ''' <summary>
        ''' Combines all the access rights required for service management operations.
        ''' Corresponds to <c>SC_MANAGER_ALL_ACCESS</c> in C++.
        ''' </summary>
        AllAccess = &HF003F
    End Enum
End Namespace
