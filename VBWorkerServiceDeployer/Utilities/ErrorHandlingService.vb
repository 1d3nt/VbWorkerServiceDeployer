Namespace Utilities

    ''' <summary>
    ''' Provides methods for handling Win32 errors, including retrieving and interpreting error descriptions.
    ''' </summary>
    ''' <remarks>
    ''' This class implements the <see cref="IErrorHandlingService"/> interface and utilizes 
    ''' <see cref="IWin32ErrorHelper"/> and <see cref="IWin32ErrorUtility"/> to handle Win32 errors 
    ''' by retrieving error codes and their corresponding descriptions.
    ''' </remarks>
    Public Class ErrorHandlingService
        Implements IErrorHandlingService

        ''' <summary>
        ''' Provides utility methods for retrieving Win32 error codes.
        ''' </summary>
        Private ReadOnly _win32ErrorHelper As IWin32ErrorHelper

        ''' <summary>
        ''' Provides utility methods for retrieving descriptions of Win32 error codes.
        ''' </summary>
        Private ReadOnly _win32ErrorUtility As IWin32ErrorUtility

        ''' <summary>
        ''' Initializes a new instance of the <see cref="ErrorHandlingService"/> class.
        ''' </summary>
        ''' <param name="win32ErrorHelper">
        ''' An instance of <see cref="IWin32ErrorHelper"/> used to retrieve the last Win32 error code.
        ''' </param>
        ''' <param name="win32ErrorUtility">
        ''' An instance of <see cref="IWin32ErrorUtility"/> used to retrieve error descriptions for Win32 error codes.
        ''' </param>
        ''' <remarks>
        ''' This constructor initializes the <see cref="ErrorHandlingService"/> with the provided instances of 
        ''' <see cref="IWin32ErrorHelper"/> and <see cref="IWin32ErrorUtility"/>. The <see cref="_win32ErrorHelper"/> 
        ''' field is used to obtain the last Win32 error code, while the <see cref="_win32ErrorUtility"/> field is 
        ''' used to retrieve human-readable descriptions of error codes.
        ''' </remarks>
        Public Sub New(win32ErrorHelper As IWin32ErrorHelper, win32ErrorUtility As IWin32ErrorUtility)
            _win32ErrorHelper = win32ErrorHelper
            _win32ErrorUtility = win32ErrorUtility
        End Sub

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
        Public Sub HandleWin32Error(serviceControlManager As IntPtr) Implements IErrorHandlingService.HandleWin32Error
            If Equals(serviceControlManager, NativeMethods.NullHandleValue) Then
                Throw CreateWin32Exception()
            End If
        End Sub

        ''' <summary>
        ''' Creates an <see cref="InvalidOperationException"/> with the Win32 error code and description.
        ''' </summary>
        ''' <returns>
        ''' An <see cref="InvalidOperationException"/> containing the error code and description.
        ''' </returns>
        ''' <remarks>
        ''' This method retrieves the last Win32 error code using <see cref="IWin32ErrorHelper"/> and translates it 
        ''' into a human-readable error description using <see cref="IWin32ErrorUtility"/>.
        ''' </remarks>
        Private Function CreateWin32Exception() As InvalidOperationException
            Dim lastErrorCode As Integer = _win32ErrorHelper.GetLastWin32Error()
            Dim errorCode As Win32ErrorCode = _win32ErrorUtility.ToWin32ErrorCode(lastErrorCode)
            Dim errorDescription As String = _win32ErrorUtility.GetErrorDescription(errorCode)
            Return New InvalidOperationException($"Failed to create service. Error code: {lastErrorCode} - {errorDescription}")
        End Function
    End Class
End Namespace
