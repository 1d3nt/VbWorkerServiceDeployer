Namespace CoreServices.WindowsApiInterop.Enums

    ''' <summary>
    ''' Specifies the type of service.
    ''' These flags define the characteristics of the service when calling <see cref="NativeMethods.CreateService"/>.
    ''' </summary>
    ''' <remarks>
    ''' The <see cref="ServiceType"/> enumeration specifies the various types of services that can be created and managed through the Windows Service Control Manager.
    ''' 
    ''' The following bullet points map the <see cref="ServiceType"/> enum values to their C++ equivalents:
    ''' <list type="bullet">
    '''     <item><description><see cref="KernelDriver"/> corresponds to the constant <c>SERVICE_KERNEL_DRIVER</c> in C++.</description></item>
    '''     <item><description><see cref="FileSystemDriver"/> corresponds to the constant <c>SERVICE_FILE_SYSTEM_DRIVER</c> in C++.</description></item>
    '''     <item><description><see cref="Win32OwnProcess"/> corresponds to the constant <c>SERVICE_WIN32_OWN_PROCESS</c> in C++.</description></item>
    '''     <item><description><see cref="Win32ShareProcess"/> corresponds to the constant <c>SERVICE_WIN32_SHARE_PROCESS</c> in C++.</description></item>
    '''     <item><description><see cref="Interactive"/> corresponds to the constant <c>SERVICE_INTERACTIVE_PROCESS</c> in C++.</description></item>
    '''     <item><description><see cref="All"/> corresponds to a combination of all the constants listed below in C++.</description></item>
    ''' </list>
    ''' 
    ''' Note: The <see cref="Interactive"/> value allows the service to interact with the desktop. However, this is not recommended for services running on newer versions of Windows due to security concerns.
    ''' 
    ''' For more information about service types, refer to:
    ''' <see href="https://learn.microsoft.com/en-us/dotnet/api/system.serviceprocess.servicetype?view=net-8.0">ServiceType Enum</see>.
    ''' </remarks>
    Friend Enum ServiceType As UInteger

        ''' <summary>
        ''' The service is a kernel-mode driver.
        ''' Corresponds to <c>SERVICE_KERNEL_DRIVER</c> in C++.
        ''' </summary>
        KernelDriver = &H1

        ''' <summary>
        ''' The service is a file system driver.
        ''' Corresponds to <c>SERVICE_FILE_SYSTEM_DRIVER</c> in C++.
        ''' </summary>
        FileSystemDriver = &H2

        ''' <summary>
        ''' The service runs in its own process.
        ''' Corresponds to <c>SERVICE_WIN32_OWN_PROCESS</c> in C++.
        ''' </summary>
        Win32OwnProcess = &H10

        ''' <summary>
        ''' The service runs in the same process as other services.
        ''' Corresponds to <c>SERVICE_WIN32_SHARE_PROCESS</c> in C++.
        ''' </summary>
        Win32ShareProcess = &H20

        ''' <summary>
        ''' The service can interact with the desktop.
        ''' Corresponds to <c>SERVICE_INTERACTIVE_PROCESS</c> in C++.
        ''' </summary>
        Interactive = &H100

        ''' <summary>
        ''' Combines all available service types.
        ''' This value includes all the types defined by other enumeration values.
        ''' 
        ''' Corresponds to the combination of <c>SERVICE_KERNEL_DRIVER</c>, <c>SERVICE_FILE_SYSTEM_DRIVER</c>, 
        ''' <c>SERVICE_WIN32_OWN_PROCESS</c>, <c>SERVICE_WIN32_SHARE_PROCESS</c>, and <c>SERVICE_INTERACTIVE_PROCESS</c> in C++.
        ''' </summary>
        All = KernelDriver Or FileSystemDriver Or Win32OwnProcess Or Win32ShareProcess Or Interactive
    End Enum
End Namespace
