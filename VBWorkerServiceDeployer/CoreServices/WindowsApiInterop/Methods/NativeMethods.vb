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
    End Class
End Namespace
