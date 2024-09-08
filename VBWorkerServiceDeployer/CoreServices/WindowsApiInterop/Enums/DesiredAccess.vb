﻿Namespace CoreServices.WindowsApiInterop.Enums

    ''' <summary>
    ''' Specifies the desired access rights for a service.
    ''' These flags are used to define the access level when calling service-related functions.
    ''' </summary>
    ''' <remarks>
    ''' The following bullet points map the <see cref="DesiredAccess"/> enum values to their C++ equivalents:
    ''' <list type="bullet">
    '''     <item><description><see cref="None"/> corresponds to the constant <c>0</c> in C++.</description></item>
    '''     <item><description><see cref="QueryStatus"/> corresponds to the constant <c>SERVICE_QUERY_STATUS</c> in C++.</description></item>
    '''     <item><description><see cref="Start"/> corresponds to the constant <c>SERVICE_START</c> in C++.</description></item>
    '''     <item><description><see cref="Stop"/> corresponds to the constant <c>SERVICE_STOP</c> in C++.</description></item>
    '''     <item><description><see cref="PauseContinue"/> corresponds to the constant <c>SERVICE_PAUSE_CONTINUE</c> in C++.</description></item>
    '''     <item><description><see cref="ChangeConfig"/> corresponds to the constant <c>SERVICE_CHANGE_CONFIG</c> in C++.</description></item>
    '''     <item><description><see cref="EnumerateDependents"/> corresponds to the constant <c>SERVICE_ENUMERATE_DEPENDENTS</c> in C++.</description></item>
    '''     <item><description><see cref="None"/> corresponds to the constant <c>0</c> in C++.</description></item>
    '''     <item><description><see cref="All"/> corresponds to a combination of all relevant service access rights.</description></item>
    ''' </list>
    ''' <para>
    ''' Note: Although some values may not be used in the current implementation, they are included for completeness and potential future needs.
    ''' </para>
    ''' For more information about access rights, refer to:
    ''' <see href="https://learn.microsoft.com/en-us/windows/win32/services/service-security-and-access-rights">Service Security and Access Rights</see>.
    ''' </remarks>
    <Flags>
    Public Enum DesiredAccess As UInteger

        ''' <summary>
        ''' No access rights specified.
        ''' Corresponds to <c>0</c> in C++.
        ''' </summary>
        None = 0

        ''' <summary>
        ''' Allows querying the service status.
        ''' Corresponds to <c>SERVICE_QUERY_STATUS</c> in C++.
        ''' </summary>
        QueryStatus = &H4

        ''' <summary>
        ''' Allows starting the service.
        ''' Corresponds to <c>SERVICE_START</c> in C++.
        ''' </summary>
        Start = &H10

        ''' <summary>
        ''' Allows stopping the service.
        ''' Corresponds to <c>SERVICE_STOP</c> in C++.
        ''' </summary>
        [Stop] = &H20

        ''' <summary>
        ''' Allows pausing and continuing the service.
        ''' Corresponds to <c>SERVICE_PAUSE_CONTINUE</c> in C++.
        ''' </summary>
        PauseContinue = &H40

        ''' <summary>
        ''' Allows changing the service configuration.
        ''' Corresponds to <c>SERVICE_CHANGE_CONFIG</c> in C++.
        ''' </summary>
        ChangeConfig = &H2

        ''' <summary>
        ''' Allows enumerating the services that are dependent on this service.
        ''' Corresponds to <c>SERVICE_ENUMERATE_DEPENDENTS</c> in C++.
        ''' </summary>
        EnumerateDependents = &H8

        ''' <summary>
        ''' Combines all available access rights.
        ''' This value includes all the rights defined by other enumeration values.
        ''' </summary>
        All = QueryStatus Or Start Or [Stop] Or PauseContinue Or ChangeConfig Or EnumerateDependents
    End Enum
End Namespace
