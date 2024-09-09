Namespace Utilities

    ''' <summary>
    ''' Provides utility methods for handling Win32 errors.
    ''' </summary>
    Public Class Win32ErrorUtility
        Implements IWin32ErrorUtility

        ''' <summary>
        ''' Dictionary to map Win32 error codes to their friendly descriptions.
        ''' </summary>
        Private Shared ReadOnly ErrorDescriptions As New Dictionary(Of Win32ErrorCode, String)() From {
            {Win32ErrorCode.Success, "The operation completed successfully."},
            {Win32ErrorCode.FileNotFound, "The system cannot find the file specified."},
            {Win32ErrorCode.PathNotFound, "The system cannot find the path specified."},
            {Win32ErrorCode.SharingViolation, "The process cannot access the file because it is being used by another process."},
            {Win32ErrorCode.NetNameDeleted, "The specified network name is no longer available."},
            {Win32ErrorCode.AccessDenied, "Access is denied."},
            {Win32ErrorCode.InvalidHandle, "The handle is invalid."},
            {Win32ErrorCode.NotEnoughMemory, "Not enough storage is available to process this command."},
            {Win32ErrorCode.InvalidParameter, "The parameter is incorrect."},
            {Win32ErrorCode.MessageNotFound, "The system cannot find the message text for message number 0x%1 in the message file for %2."},
            {Win32ErrorCode.BufferTooSmall, "The data area passed to a system call is too small."},
            {Win32ErrorCode.PrivilegeNotHeld, "A required privilege is not held by the client."},
            {Win32ErrorCode.ServiceDoesNotExist, "The specified service does not exist as an installed service."}
        }

        ''' <summary>
        ''' Retrieves the friendly error message for a given Win32 error code.
        ''' </summary>
        ''' <param name="errorCode">The <see cref="Win32ErrorCode"/> value for which to retrieve the error message.</param>
        ''' <returns>
        ''' A string representing the friendly error message. If the error code is not found, "Unknown error code" is returned.
        ''' </returns>
        ''' <remarks>
        ''' This method looks up the <paramref name="errorCode"/> in the <see cref="ErrorDescriptions"/> dictionary
        ''' to get a friendly description of the error.
        ''' </remarks>
        Public Function GetErrorDescription(errorCode As Win32ErrorCode) As String Implements IWin32ErrorUtility.GetErrorDescription
            Dim description As String = Nothing
            If ErrorDescriptions.TryGetValue(errorCode, description) Then
                Return description
            Else
                Return "Unknown error code"
            End If
        End Function

        ''' <summary>
        ''' Converts an integer error code to a <see cref="Win32ErrorCode"/> enumeration value.
        ''' </summary>
        ''' <param name="errorCode">The integer value representing the Win32 error code.</param>
        ''' <returns>
        ''' The corresponding <see cref="Win32ErrorCode"/> enumeration value. 
        ''' If the error code is not defined in the enumeration, returns <see cref="Win32ErrorCode.Unknown"/>.
        ''' </returns>
        Public Function ToWin32ErrorCode(errorCode As Integer) As Win32ErrorCode Implements  IWin32ErrorUtility.ToWin32ErrorCode
            If [Enum].IsDefined(GetType(Win32ErrorCode), errorCode) Then
                Return DirectCast([Enum].ToObject(GetType(Win32ErrorCode), errorCode), Win32ErrorCode)
            Else
                Return Win32ErrorCode.Unknown
            End If
        End Function
    End Class
End Namespace
