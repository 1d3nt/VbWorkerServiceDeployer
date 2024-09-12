''' <author>
''' Sam (ident)
''' Twitter: <see href="https://twitter.com/1d3nt">https://twitter.com/1d3nt</see>
''' GitHub: <see href="https://github.com/1d3nt">https://github.com/1d3nt</see>
''' Email: <see href="mailto:ident@simplecoders.com">ident@simplecoders.com</see>
''' VBForums: <see href="https://www.vbforums.com/member.php?113656-ident">https://www.vbforums.com/member.php?113656-ident</see>
''' ORCID: <see href="https://orcid.org/0009-0007-1363-3308">https://orcid.org/0009-0007-1363-3308</see>
''' </author>
''' <date>07/09/2024</date>
''' <summary>
''' The entry point for the application.
''' </summary>
''' <remarks>
''' This module contains the <see cref="Main"/> method, which sets up and starts the application host.
''' 
''' This project includes P/Invoke declarations and methods for interacting with Windows API functions.
''' Contributions and enhancements are welcomed to further extend the functionality and improve the integration.
''' 
''' Just a hobby programmer that enjoys P/Invoke.
''' </remarks>
Module Program

    ''' <summary>
    ''' Entry point for the console application.
    ''' This application manages user interactions to configure and set up services. It prompts users for input
    ''' to determine whether to proceed with various setup tasks and performs actions based on their responses.
    ''' </summary>
    ''' <param name="args">Command-line arguments (not used).</param>
    ''' <remarks>
    ''' The <paramref name="args"/> parameter is included to adhere to the standard signature for a console application's
    ''' <see cref="Main"/> method. While this parameter is not utilized in the current implementation, including it
    ''' follows best practices and ensures consistency with the conventional entry point signature. 
    ''' 
    ''' The method calls <see cref="AppRunner.RunAsync"/> and waits for its completion using 
    ''' <see cref="M:System.Threading.Tasks.Task.GetAwaiter().GetResult"/>. This approach ensures that the asynchronous operations in 
    ''' <see cref="AppRunner.RunAsync"/> complete before the application exits. It avoids potential deadlock issues 
    ''' that can arise with the use of <see cref="M:System.Threading.Tasks.Task.Wait()"/> and is appropriate for the console application's 
    ''' synchronous entry point.
    ''' </remarks>
    <SuppressMessage("Style", "IDE0060:Remove unused parameter", Justification:="Standard Main method parameter signature.")>
    Sub Main(args As String())
        Dim serviceProvider As IServiceProvider = ServiceConfigurator.ConfigureServices()
        Dim appRunner As New AppRunner(serviceProvider)
        appRunner.RunAsync().GetAwaiter().GetResult()
    End Sub
End Module
