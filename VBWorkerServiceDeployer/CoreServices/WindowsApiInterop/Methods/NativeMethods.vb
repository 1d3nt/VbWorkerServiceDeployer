Namespace CoreServices.WindowsApiInterop.Methods

    ''' <summary>
    ''' Provides methods for interacting with native Windows APIs. 
    ''' This class contains P/Invoke declarations for various functions used for process and token management.
    ''' </summary>
    ''' <remarks>
    ''' The <see cref="NativeMethods"/> class uses the <c>DllImport</c> attribute to define methods that are imported 
    ''' from unmanaged DLLs. These methods are used to interact with the Windows operating system at a low level.
    ''' 
    ''' The <c>SuppressUnmanagedCodeSecurity</c> attribute is applied to this class to improve performance when
    ''' calling unmanaged code. This attribute disables code access security checks for unmanaged code, which
    ''' can reduce overhead in performance-critical applications. Use this attribute with caution, as it bypasses
    ''' some of the security measures provided by the .NET runtime.
    ''' </remarks>
    <Security.SuppressUnmanagedCodeSecurity>
    Friend NotInheritable Class NativeMethods

        ''' <summary>
        ''' Represents a null handle value used in P/Invoke calls.
        ''' </summary>
        ''' <remarks>
        ''' This field is used to represent a null handle (IntPtr.Zero) in P/Invoke calls to unmanaged code.
        ''' </remarks>
        Friend Shared ReadOnly NullHandleValue As IntPtr = IntPtr.Zero

        ''' <summary>
        ''' Closes an open object handle.
        ''' </summary>
        ''' <param name="hObject">
        ''' A valid handle to an open object. This handle is typically obtained from functions like <c>CreateFile</c>,
        ''' <c>OpenProcess</c>, or <c>OpenThread</c>. This parameter is passed with the <c>[In]</c> attribute.
        ''' </param>
        ''' <returns>
        ''' If the function succeeds, the return value is nonzero (<c>True</c>). If the function fails, the return value is
        ''' zero (<c>False</c>). To get extended error information, call <see cref="Marshal.GetLastWin32Error"/>.
        ''' </returns>
        ''' <remarks>
        ''' The <c>CloseHandle</c> function is used to close an open handle to an object. It is crucial to call this function
        ''' to free system resources when a handle is no longer needed.
        ''' 
        ''' For more details, refer to the <see href="https://learn.microsoft.com/en-us/windows/desktop/api/handleapi/nf-handleapi-closehandle">CloseHandle</see> documentation.
        ''' 
        ''' The function signature in C++ is:
        ''' <code>
        ''' BOOL CloseHandle(
        '''   [in] HANDLE hObject
        ''' );
        ''' </code>
        ''' </remarks>
        <DllImport(ExternDll.Kernel32, SetLastError:=True)>
        Friend Shared Function CloseHandle(
            <[In]> hObject As IntPtr
        ) As <MarshalAs(UnmanagedType.Bool)> Boolean
        End Function

        ''' <summary>
        ''' Opens a handle to the service control manager (SCM) on the local computer or a specified remote computer.
        ''' </summary>
        ''' <param name="lpMachineName">
        ''' The name of the remote computer. If this parameter is <c>Nothing</c>, the function connects to the local computer.
        ''' This parameter is passed with the <c>[In]</c> and <c>[Optional]</c> attributes.
        ''' </param>
        ''' <param name="lpDatabaseName">
        ''' The name of the database to be opened. If this parameter is <c>Nothing</c>, the function opens the default database.
        ''' This parameter is passed with the <c>[In]</c> and <c>[Optional]</c> attributes.
        ''' </param>
        ''' <param name="dwDesiredAccess">
        ''' The access to the SCM database. This parameter can be a combination of values from the <see cref="ServiceManagerAccessFlags"/> enumeration.
        ''' This parameter is passed with the <c>[In]</c> attribute.
        ''' </param>
        ''' <returns>
        ''' If the function succeeds, it returns a handle to the SCM database. If the function fails, it returns <c>IntPtr.Zero</c>. 
        ''' To get extended error information, call <see cref="Marshal.GetLastWin32Error"/>.
        ''' </returns>
        ''' <remarks>
        ''' For additional information, refer to the <see href="https://learn.microsoft.com/en-us/windows/win32/api/winsvc/nf-winsvc-openscmanagerw">OpenSCManager</see> documentation.
        ''' 
        ''' The function signature in C++ is:
        ''' <code>
        ''' SC_HANDLE OpenSCManagerW(
        '''   [in, optional] LPCWSTR lpMachineName,
        '''   [in, optional] LPCWSTR lpDatabaseName,
        '''   [in]           DWORD   dwDesiredAccess
        ''' );
        ''' </code>
        ''' </remarks>
        <DllImport(ExternDll.Advapi32, SetLastError:=True, CharSet:=CharSet.Unicode)>
        Friend Shared Function OpenSCManager(
            <[In], [Optional], MarshalAs(UnmanagedType.LPWStr)> lpMachineName As String,
            <[In], [Optional], MarshalAs(UnmanagedType.LPWStr)> lpDatabaseName As String,
            <[In]> dwDesiredAccess As ServiceManagerAccessFlags
        ) As IntPtr
        End Function

        ''' <summary>
        ''' Closes a handle to a service control manager or service object.
        ''' </summary>
        ''' <param name="hScObject">
        ''' A handle to the service control manager object or the service object to close. Handles to service control manager objects are 
        ''' returned by the <see cref="OpenSCManager"/> function, and handles to service objects are returned by either the <see cref="OpenService"/> 
        ''' or <see cref="CreateService"/> function.
        ''' </param>
        ''' <returns>
        ''' If the function succeeds, the return value is nonzero. If the function fails, the return value is zero. To get extended error information, 
        ''' call <see cref="Marshal.GetLastWin32Error"/>.
        ''' </returns>
        ''' <remarks>
        ''' For more details, refer to the <see href="https://learn.microsoft.com/en-us/windows/win32/api/winsvc/nf-winsvc-closeservicehandle">CloseServiceHandle</see> documentation.
        ''' 
        ''' The function signature in C++ is:
        ''' <code>
        ''' BOOL CloseServiceHandle(
        '''   [in] SC_HANDLE hSCObject
        ''' );
        ''' </code>
        ''' </remarks>
        <DllImport(ExternDll.Advapi32, SetLastError:=True)>
        Friend Shared Function CloseServiceHandle(
            hScObject As IntPtr
        ) As <MarshalAs(UnmanagedType.Bool)> Boolean
        End Function

        ''' <summary>
        ''' Creates a service object and adds it to the specified service control manager database.
        ''' </summary>
        ''' <param name="hScManager">
        ''' A handle to the service control manager database. This handle is returned by the <c>OpenSCManager</c> function and must have the 
        ''' <see cref="ServiceManagerAccessFlags.CreateService"/> access right.
        ''' </param>
        ''' <param name="lpServiceName">
        ''' The name of the service to install. The maximum string length is 256 characters. The service control manager database preserves 
        ''' the case of the characters, but service name comparisons are always case-insensitive. Forward-slash (/) and backslash (\) are 
        ''' not valid service name characters.
        ''' </param>
        ''' <param name="lpDisplayName">
        ''' The display name to be used by user interface programs to identify the service. This string has a maximum length of 256 characters. 
        ''' The name is case-preserved in the service control manager. Display name comparisons are always case-insensitive.
        ''' </param>
        ''' <param name="dwDesiredAccess">
        ''' The access to the service. Before granting the requested access, the system checks the access token of the calling process. For a list 
        ''' of values, see <see cref="ServiceAccessFlags"/> for Service Security and Access Rights.
        ''' </param>
        ''' <param name="dwServiceType">
        ''' The service type. This parameter can be one of the values defined in <see cref="ServiceType"/>. 
        ''' </param>
        ''' <param name="dwStartType">
        ''' The service start options. This parameter can be one of the values defined in <see cref="ServiceStartType"/>.
        ''' </param>
        ''' <param name="dwErrorControl">
        ''' The severity of the error, and action taken, if this service fails to start. This parameter can be one of the values defined in <see cref="ErrorControlLevel"/>.
        ''' </param>
        ''' <param name="lpBinaryPathName">
        ''' The fully qualified path to the service binary file. If the path contains a space, it must be quoted so that it is correctly interpreted.
        ''' </param>
        ''' <param name="lpLoadOrderGroup">
        ''' The names of the load ordering group of which this service is a member. Specify <c>Nothing</c> or an empty string if the service does not belong to a group.
        ''' </param>
        ''' <param name="lpdwTagId">
        ''' A pointer to a variable that receives a tag value that is unique in the group specified in the <c>lpLoadOrderGroup</c> parameter. 
        ''' Specify <c>Nothing</c> if you are not changing the existing tag.
        ''' </param>
        ''' <param name="lpDependencies">
        ''' A pointer to a double null-terminated array of null-separated names of services or load ordering groups that the system must start before 
        ''' this service. Specify <c>Nothing</c> or an empty string if the service has no dependencies.
        ''' </param>
        ''' <param name="lpServiceStartName">
        ''' The name of the account under which the service should run. If the service type is <see cref="ServiceType.SERVICE_WIN32_OWN_PROCESS"/>, use an account name in the 
        ''' form <c>DomainName\UserName</c>.
        ''' </param>
        ''' <param name="lpPassword">
        ''' The password to the account name specified by the <c>lpServiceStartName</c> parameter.
        ''' </param>
        ''' <returns>
        ''' If the function succeeds, the return value is a handle to the service.
        ''' </returns>
        ''' <remarks>
        ''' For more details, see <see href="https://docs.microsoft.com/en-us/windows/desktop/api/winsvc/nf-winsvc-createservicea">CreateServiceA</see>.
        ''' 
        ''' The C++ function signature is as follows:
        ''' <code>
        ''' SC_HANDLE CreateServiceA(
        '''   [in]            SC_HANDLE hSCManager,
        '''   [in]            LPCSTR    lpServiceName,
        '''   [in, optional]  LPCSTR    lpDisplayName,
        '''   [in]            DWORD     dwDesiredAccess,
        '''   [in]            DWORD     dwServiceType,
        '''   [in]            DWORD     dwStartType,
        '''   [in]            DWORD     dwErrorControl,
        '''   [in, optional]  LPCSTR    lpBinaryPathName,
        '''   [in, optional]  LPCSTR    lpLoadOrderGroup,
        '''   [out, optional] LPDWORD   lpdwTagId,
        '''   [in, optional]  LPCSTR    lpDependencies,
        '''   [in, optional]  LPCSTR    lpServiceStartName,
        '''   [in, optional]  LPCSTR    lpPassword
        ''' );
        ''' </code>
        ''' </remarks>
        <DllImport(ExternDll.Advapi32, SetLastError:=True, CharSet:=CharSet.Unicode)>
        Friend Shared Function CreateService(
            <[In]> hScManager As IntPtr,
            <[In]> lpServiceName As String,
            <[In], [Optional]> lpDisplayName As String,
            <[In]> dwDesiredAccess As DesiredAccess,
            <[In]> dwServiceType As ServiceType,
            <[In]> dwStartType As StartType,
            <[In]> dwErrorControl As ServiceErrorControlFlags,
            <[In], [Optional]> lpBinaryPathName As String,
            <[In], [Optional]> lpLoadOrderGroup As String,
            <[Out], [Optional]> lpdwTagId As UInteger,
            <[In], [Optional]> lpDependencies As String,
            <[In], [Optional]> lpServiceStartName As String,
            <[In], [Optional]> lpPassword As String
        ) As IntPtr
        End Function
    End Class
End Namespace
