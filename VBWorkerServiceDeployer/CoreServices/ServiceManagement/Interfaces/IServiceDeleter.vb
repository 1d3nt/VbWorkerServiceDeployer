Namespace CoreServices.ServiceManagement.Interfaces

    ''' <summary>
    ''' Defines the contract for deleting a service.
    ''' </summary>
    ''' <remarks>
    ''' This interface provides the method required for deleting a service using its handle.
    ''' Implementations should handle the deletion process and any necessary error handling.
    ''' </remarks>
    ''' <seealso cref="ServiceDeleter"/>
    Public Interface IServiceDeleter

        ''' <summary>
        ''' Deletes the specified service.
        ''' </summary>
        ''' <param name="serviceHandle">
        ''' The handle to the service to be deleted. This handle is obtained through
        ''' the <see cref="IServiceControlManager"/> interface or similar mechanisms.
        ''' </param>
        ''' <remarks>
        ''' This method should wrap the <see cref="NativeMethods.DeleteService"/> function from the Windows API.
        ''' <see href="https://learn.microsoft.com/en-us/windows/win32/api/winsvc/nf-winsvc-deleteservice"/>
        ''' </remarks>
        Sub DeleteService(serviceHandle As IntPtr)
    End Interface
End Namespace
