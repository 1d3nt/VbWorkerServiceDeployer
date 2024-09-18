Namespace Utilities.ErrorHandling

    ''' <summary>
    ''' Provides utility methods for handling Win32 errors, including retrieving friendly error descriptions.
    ''' </summary>
    ''' <remarks>
    ''' This class implements the <see cref="IWin32ErrorUtility"/> interface to provide a mapping between Win32 error codes 
    ''' and their corresponding human-readable descriptions. The error descriptions are stored in a dictionary, allowing for 
    ''' quick lookups and efficient retrieval of error messages. Using a dictionary provides better performance and 
    ''' flexibility compared to a switch or select case statement, especially when dealing with a large number of error codes. 
    ''' The dictionary approach allows for easy updates and maintenance of error descriptions without modifying the control flow 
    ''' logic of the code.
    ''' 
    ''' For more information on the <see cref="Dictionary(Of TKey, TValue)"/> class, refer to the 
    ''' <a href="https://docs.microsoft.com/dotnet/api/system.collections.generic.dictionary-2">Microsoft Documentation</a>.
    ''' </remarks>
    ''' <seealso cref="IWin32ErrorUtility"/>
    Friend Class Win32ErrorUtility
        Implements IWin32ErrorUtility

        ''' <summary>
        ''' Dictionary to map Win32 error codes to their friendly descriptions.
        ''' </summary>
        ''' <remarks>
        ''' This dictionary is used to store and quickly retrieve human-readable descriptions for Win32 error codes. 
        ''' By using a dictionary, the implementation can efficiently map error codes to their descriptions, offering 
        ''' faster lookups compared to alternative methods such as switch or select case statements. The dictionary can 
        ''' be easily extended or modified as needed to accommodate additional error codes or update existing descriptions.
        ''' 
        ''' The keys in this dictionary are <see cref="Win32ErrorCode"/> enum values, and the values are the corresponding
        ''' descriptions of these error codes. For more information about error codes, refer to:
        ''' <see href="https://learn.microsoft.com/en-us/windows/win32/debug/system-error-codes--0-499-">System Error Codes (0-499)</see>.
        ''' 
        ''' The following bullet points map the <see cref="Win32ErrorCode"/> enum values to their descriptions:
        ''' <list type="bullet">
        '''     <item><description><see cref="Win32ErrorCode.Success"/>: The operation completed successfully.</description></item>
        '''     <item><description><see cref="Win32ErrorCode.FileNotFound"/>: The system cannot find the file specified.</description></item>
        '''     <item><description><see cref="Win32ErrorCode.PathNotFound"/>: The system cannot find the path specified.</description></item>
        '''     <item><description><see cref="Win32ErrorCode.SharingViolation"/>: The process cannot access the file because it is being used by another process.</description></item>
        '''     <item><description><see cref="Win32ErrorCode.NetNameDeleted"/>: The specified network name is no longer available.</description></item>
        '''     <item><description><see cref="Win32ErrorCode.AccessDenied"/>: Access is denied.</description></item>
        '''     <item><description><see cref="Win32ErrorCode.InvalidHandle"/>: The handle is invalid.</description></item>
        '''     <item><description><see cref="Win32ErrorCode.NotEnoughMemory"/>: Not enough storage is available to process this command.</description></item>
        '''     <item><description><see cref="Win32ErrorCode.InvalidParameter"/>: The parameter is incorrect.</description></item>
        '''     <item><description><see cref="Win32ErrorCode.MessageNotFound"/>: The system cannot find the message text for message number 0x%1 in the message file for %2.</description></item>
        '''     <item><description><see cref="Win32ErrorCode.BufferTooSmall"/>: The data area passed to a system call is too small.</description></item>
        '''     <item><description><see cref="Win32ErrorCode.PrivilegeNotHeld"/>: A required privilege is not held by the client.</description></item>
        '''     <item><description><see cref="Win32ErrorCode.ServiceDoesNotExist"/>: The specified service does not exist as an installed service.</description></item>
        '''     <item><description><see cref="Win32ErrorCode.Unknown"/>: Represents an unknown Win32 error code that does not map to any known error constants.</description></item>
        ''' </list>
        ''' </remarks>
        ''' <seealso cref="Win32ErrorCode"/>
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
        ''' This method is responsible for converting Win32 error codes into human-readable messages
        ''' to make error handling more informative and easier to understand.
        ''' </remarks>
        Friend Function GetErrorDescription(errorCode As Win32ErrorCode) As String Implements IWin32ErrorUtility.GetErrorDescription
            Dim description As String = Nothing
            If ErrorDescriptions.TryGetValue(errorCode, description) Then
                Return description
            Else
                Return "Unknown error code"
            End If
        End Function

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
        Friend Function ToWin32ErrorCode(errorCode As Integer) As Win32ErrorCode Implements IWin32ErrorUtility.ToWin32ErrorCode
            If [Enum].IsDefined(GetType(Win32ErrorCode), errorCode) Then
                Return DirectCast([Enum].ToObject(GetType(Win32ErrorCode), errorCode), Win32ErrorCode)
            Else
                Return Win32ErrorCode.Unknown
            End If
        End Function
    End Class
End Namespace
