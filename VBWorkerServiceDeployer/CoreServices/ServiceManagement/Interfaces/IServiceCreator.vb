Namespace CoreServices.ServiceManagement.Interfaces

    ''' <summary>
    ''' Defines the contract for creating services.
    ''' </summary>
    ''' <remarks>
    ''' This interface specifies the method for creating services using the Service Control Manager (SCM).
    ''' The implementation of this interface should handle the creation of services by interacting with the SCM.
    ''' </remarks>
    ''' <seealso cref="ServiceCreator"/>
    Public Interface IServiceCreator

        ''' <summary>
        ''' Creates the service.
        ''' </summary>
        ''' <param name="serviceControlManager">The handle to the Service Control Manager.</param>
        ''' <returns>An <see cref="IntPtr"/> representing the handle to the newly created service.</returns>
        ''' <remarks>
        ''' This method should wrap the <see cref="NativeMethods.CreateService"/> function from the Windows API.
        ''' <see href="https://learn.microsoft.com/en-us/windows/win32/api/winsvc/nf-winsvc-createservicew"/>
        ''' </remarks>
        Function Create(serviceControlManager As IntPtr) As IntPtr
    End Interface
End Namespace
