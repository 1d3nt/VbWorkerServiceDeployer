Namespace Utilities.ErrorHandling

    ''' <summary>
    ''' Provides utility methods for handling Win32 errors.
    ''' </summary>
    ''' <remarks>
    ''' In the context of managed code, using the <see cref="Marshal.GetLastWin32Error"/> method 
    ''' is essential instead of calling the Win32 <c>GetLastError</c> API directly.
    ''' This is because the CLR may make additional system calls while transitioning 
    ''' from unmanaged to managed code, which can overwrite the last error code.
    ''' For more details, see Adam Nathan's blog post:
    ''' <a href="https://web.archive.org/web/20151221201611/http://blogs.msdn.com/b/adam_nathan/archive/2003/04/25/56643.aspx">
    ''' Archived Version</a> or the 
    ''' <a href="http://blogs.msdn.com/b/adam_nathan/archive/2003/04/25/56643.aspx">Original URL</a>.
    ''' </remarks>
    ''' <seealso cref="IWin32ErrorHelper"/>
    Friend Class Win32ErrorHelper
        Implements IWin32ErrorHelper

        ''' <summary>
        ''' Retrieves the last Win32 error code.
        ''' </summary>
        ''' <returns>
        ''' The last Win32 error code saved by the CLR. This code is typically retrieved after a P/Invoke call 
        ''' to ensure it accurately reflects the error state of the unmanaged API call.
        ''' </returns>
        ''' <remarks>
        ''' The <see cref="Marshal.GetLastWin32Error"/> method should be used to retrieve the error code. 
        ''' This is important because the CLR saves the result of <c>GetLastError</c> immediately after the unmanaged API call completes, 
        ''' preventing it from being overwritten by subsequent system calls made by the CLR.
        ''' </remarks>
        Friend Function GetLastWin32Error() As Integer Implements IWin32ErrorHelper.GetLastWin32Error
            Return Marshal.GetLastWin32Error()
        End Function
    End Class
End Namespace
