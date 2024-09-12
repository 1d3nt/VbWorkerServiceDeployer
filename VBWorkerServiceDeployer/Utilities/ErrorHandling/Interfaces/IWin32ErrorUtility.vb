Namespace Utilities.ErrorHandling.Interfaces

    ''' <summary>
    ''' Defines methods for working with Win32 error codes and retrieving their friendly descriptions.
    ''' </summary>
    ''' <remarks>
    ''' This interface provides a contract for retrieving human-readable error descriptions 
    ''' for Win32 error codes. Implementations of this interface should provide a dictionary 
    ''' lookup or similar mechanism to map error codes to descriptions.
    ''' </remarks>
    Public Interface IWin32ErrorUtility

        ''' <summary>
        ''' Retrieves the friendly error message for a given Win32 error code.
        ''' </summary>
        ''' <param name="errorCode">The <see cref="Win32ErrorCode"/> value for which to retrieve the error message.</param>
        ''' <returns>
        ''' A string representing the friendly error message. If the error code is not found, "Unknown error code" is returned.
        ''' </returns>
        ''' <remarks>
        ''' This method is responsible for converting Win32 error codes into human-readable messages
        ''' to make error handling more informative and easier to understand.
        ''' </remarks>
        Function GetErrorDescription(errorCode As Win32ErrorCode) As String

        ''' <summary>
        ''' Converts an integer error code to a <see cref="Win32ErrorCode"/>.
        ''' </summary>
        ''' <param name="errorCode">The integer error code to convert.</param>
        ''' <returns>
        ''' The corresponding <see cref="Win32ErrorCode"/>. If the integer code is not a defined value, returns <see cref="Win32ErrorCode.Unknown"/>.
        ''' </returns>
        ''' <remarks>
        ''' This method is used to map an integer error code to the <see cref="Win32ErrorCode"/> enumeration.
        ''' </remarks>
        Function ToWin32ErrorCode(errorCode As Integer) As Win32ErrorCode
    End Interface
End Namespace
