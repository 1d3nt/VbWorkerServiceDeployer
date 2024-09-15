Namespace Utilities.ErrorHandling.Interfaces

    ''' <summary>
    ''' Defines methods for handling Win32 errors.
    ''' </summary>
    ''' <remarks>
    ''' This interface provides a contract for handling Win32 errors in a standardized way. 
    ''' Implementations of this interface should define how to process and respond to errors 
    ''' encountered during Win32 API operations, particularly in relation to service control management.
    ''' </remarks>
    ''' <seealso cref="ErrorhandlingService"/>
    Public Interface IErrorHandlingService

        ''' <summary>
        ''' Handles Win32 errors by checking if the service control manager handle is invalid, 
        ''' retrieves the last Win32 error code, and throws an <see cref="InvalidOperationException"/> 
        ''' with a detailed error message.
        ''' </summary>
        ''' <param name="serviceControlManager">
        ''' A handle to the service control manager. If this handle is invalid, the method retrieves the 
        ''' last Win32 error code and provides a detailed error description.
        ''' </param>
        ''' <remarks>
        ''' This method is used to manage and interpret errors related to the service control manager. 
        ''' It retrieves the last Win32 error code using <see cref="IWin32ErrorHelper"/> and translates it 
        ''' into a human-readable error description using <see cref="IWin32ErrorUtility"/>. An 
        ''' <see cref="InvalidOperationException"/> is thrown if the service control manager handle is invalid.
        ''' </remarks>
        ''' <exception cref="InvalidOperationException">
        ''' Thrown when the service control manager handle is invalid, providing the error code and description.
        ''' </exception>
        Sub HandleWin32Error(serviceControlManager As IntPtr)
    End Interface
End Namespace
