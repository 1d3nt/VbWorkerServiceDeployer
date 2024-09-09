Namespace Utilities.Interfaces

    ''' <summary>
    ''' Defines methods for handling Win32 errors.
    ''' </summary>
    ''' <remarks>
    ''' This interface provides a contract for handling Win32 errors in a standardized way. 
    ''' Implementations of this interface should define how to process and respond to errors 
    ''' encountered during Win32 API operations, particularly in relation to service control management.
    ''' </remarks>
    Public Interface IErrorHandlingService

        ''' <summary>
        ''' Handles Win32 errors by checking the validity of the service control manager handle 
        ''' and throwing an exception with a detailed error message if the handle is invalid.
        ''' </summary>
        ''' <param name="serviceControlManager">
        ''' A handle to the service control manager. This handle is checked for validity, and if invalid, 
        ''' an exception is thrown with a detailed error message based on the last Win32 error code.
        ''' </param>
        ''' <remarks>
        ''' Implementations of this method should retrieve the last Win32 error code when the 
        ''' service control manager handle is invalid and throw an <see cref="InvalidOperationException"/> 
        ''' with a descriptive error message. This allows for consistent error handling and reporting 
        ''' in service control management operations.
        ''' </remarks>
        Sub HandleWin32Error(serviceControlManager As IntPtr)
    End Interface
End Namespace
