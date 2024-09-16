Namespace CoreServices.WindowsApiInterop.Enums

    ''' <summary>
    ''' Defines common Windows error codes.
    ''' </summary>
    ''' <remarks>
    ''' This enum includes a selection of standard Windows error codes that are commonly encountered.
    ''' Each value corresponds to a specific error condition as defined in the Windows API.
    ''' 
    ''' <para>
    ''' The following bullet points map the <see cref="Win32ErrorCode"/> enum values to their C++ equivalents:
    ''' <list type="bullet">
    '''     <item><description><see cref="Success"/> corresponds to the constant <c>ERROR_SUCCESS</c> in C++.</description></item>
    '''     <item><description><see cref="FileNotFound"/> corresponds to the constant <c>ERROR_FILE_NOT_FOUND</c> in C++.</description></item>
    '''     <item><description><see cref="PathNotFound"/> corresponds to the constant <c>ERROR_PATH_NOT_FOUND</c> in C++.</description></item>
    '''     <item><description><see cref="SharingViolation"/> corresponds to the constant <c>ERROR_SHARING_VIOLATION</c> in C++.</description></item>
    '''     <item><description><see cref="NetNameDeleted"/> corresponds to the constant <c>ERROR_NETNAME_DELETED</c> in C++.</description></item>
    '''     <item><description><see cref="AccessDenied"/> corresponds to the constant <c>ERROR_ACCESS_DENIED</c> in C++.</description></item>
    '''     <item><description><see cref="InvalidHandle"/> corresponds to the constant <c>ERROR_INVALID_HANDLE</c> in C++.</description></item>
    '''     <item><description><see cref="NotEnoughMemory"/> corresponds to the constant <c>ERROR_NOT_ENOUGH_MEMORY</c> in C++.</description></item>
    '''     <item><description><see cref="InvalidParameter"/> corresponds to the constant <c>ERROR_INVALID_PARAMETER</c> in C++.</description></item>
    '''     <item><description><see cref="MessageNotFound"/> corresponds to the constant <c>ERROR_MR_MID_NOT_FOUND</c> in C++.</description></item>
    '''     <item><description><see cref="BufferTooSmall"/> corresponds to the constant <c>ERROR_INSUFFICIENT_BUFFER</c> in C++.</description></item>
    '''     <item><description><see cref="PrivilegeNotHeld"/> corresponds to the constant <c>ERROR_PRIVILEGE_NOT_HELD</c> in C++.</description></item>
    '''     <item><description><see cref="ServiceDoesNotExist"/> corresponds to the constant <c>ERROR_SERVICE_DOES_NOT_EXIST</c> in C++.</description></item>
    '''     <item><description><see cref="Unknown"/> represents an unknown Win32 error code that does not map to any known error constants.</description></item>
    ''' </list>
    ''' </para>
    ''' 
    ''' For more information about error codes, refer to:
    ''' <see href="https://learn.microsoft.com/en-us/windows/win32/debug/system-error-codes--0-499-">System Error Codes (0-499)</see>.
    ''' </remarks>
    Public Enum Win32ErrorCode As Integer

        ''' <summary>
        ''' The operation completed successfully.
        ''' </summary>
        ''' <remarks>
        ''' Corresponds to the constant <c>ERROR_SUCCESS</c> in C++.
        ''' </remarks>
        Success = 0

        ''' <summary>
        ''' The system cannot find the file specified.
        ''' </summary>
        ''' <remarks>
        ''' Corresponds to the constant <c>ERROR_FILE_NOT_FOUND</c> in C++.
        ''' </remarks>
        FileNotFound = 2

        ''' <summary>
        ''' The system cannot find the path specified.
        ''' </summary>
        ''' <remarks>
        ''' Corresponds to the constant <c>ERROR_PATH_NOT_FOUND</c> in C++.
        ''' </remarks>
        PathNotFound = 3

        ''' <summary>
        ''' The process cannot access the file because it is being used by another process.
        ''' </summary>
        ''' <remarks>
        ''' Corresponds to the constant <c>ERROR_SHARING_VIOLATION</c> in C++.
        ''' </remarks>
        SharingViolation = 32

        ''' <summary>
        ''' The specified network name is no longer available.
        ''' </summary>
        ''' <remarks>
        ''' Corresponds to the constant <c>ERROR_NETNAME_DELETED</c> in C++.
        ''' </remarks>
        NetNameDeleted = 64

        ''' <summary>
        ''' Access is denied.
        ''' </summary>
        ''' <remarks>
        ''' Corresponds to the constant <c>ERROR_ACCESS_DENIED</c> in C++.
        ''' </remarks>
        AccessDenied = 5

        ''' <summary>
        ''' The handle is invalid.
        ''' </summary>
        ''' <remarks>
        ''' Corresponds to the constant <c>ERROR_INVALID_HANDLE</c> in C++.
        ''' </remarks>
        InvalidHandle = 6

        ''' <summary>
        ''' Not enough storage is available to process this command.
        ''' </summary>
        ''' <remarks>
        ''' Corresponds to the constant <c>ERROR_NOT_ENOUGH_MEMORY</c> in C++.
        ''' </remarks>
        NotEnoughMemory = 8

        ''' <summary>
        ''' The parameter is incorrect.
        ''' </summary>
        ''' <remarks>
        ''' Corresponds to the constant <c>ERROR_INVALID_PARAMETER</c> in C++.
        ''' </remarks>
        InvalidParameter = 87

        ''' <summary>
        ''' The system cannot find the message text for message number 0x%1 in the message file for %2.
        ''' </summary>
        ''' <remarks>
        ''' Corresponds to the constant <c>ERROR_MR_MID_NOT_FOUND</c> in C++.
        ''' </remarks>
        MessageNotFound = 182

        ''' <summary>
        ''' The data area passed to a system call is too small.
        ''' </summary>
        ''' <remarks>
        ''' Corresponds to the constant <c>ERROR_INSUFFICIENT_BUFFER</c> in C++.
        ''' </remarks>
        BufferTooSmall = 122

        ''' <summary>
        ''' A required privilege is not held by the client.
        ''' </summary>
        ''' <remarks>
        ''' Corresponds to the constant <c>ERROR_PRIVILEGE_NOT_HELD</c> in C++.
        ''' </remarks>
        PrivilegeNotHeld = 1314

        ''' <summary>
        ''' The specified service does not exist as an installed service.
        ''' </summary>
        ''' <remarks>
        ''' Corresponds to the constant <c>ERROR_SERVICE_DOES_NOT_EXIST</c> in C++.
        ''' </remarks>
        ServiceDoesNotExist = 1060

        ''' <summary>
        ''' Represents an unknown Win32 error code that does not map to any known error constants.
        ''' </summary>
        ''' <remarks>
        ''' This value is used to indicate that the error code does not correspond to any predefined 
        ''' Win32 error code in the enumeration. It serves as a fallback for handling unexpected or 
        ''' unrecognized error codes that may arise. This is useful for robust error handling and debugging.
        ''' </remarks>
        Unknown = -1
    End Enum
End Namespace
