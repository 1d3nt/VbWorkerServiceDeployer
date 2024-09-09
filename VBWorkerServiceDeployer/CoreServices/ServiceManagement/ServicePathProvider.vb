Namespace CoreServices.ServiceManagement

    ''' <summary>
    ''' Provides methods to obtain service paths and names.
    ''' </summary>
    ''' <remarks>
    ''' The <see cref="ServicePathProvider"/> class implements the <see cref="IServicePathProvider"/> interface
    ''' and provides the actual logic for retrieving the paths and names of services to be installed.
    ''' </remarks>
    Public Class ServicePathProvider
        Implements IServicePathProvider

        ''' <summary>
        ''' Gets the full path to the service executable.
        ''' </summary>
        ''' <returns>The full path to the service executable.</returns>
        Public Function GetServicePath() As String Implements IServicePathProvider.GetServicePath
            ' Logic to obtain the service path
            Return "C:\Users\Owner\Desktop\ServiceTest\WorkerService\VbWorkerServicePinvokeLauncher.exe"
        End Function

        ''' <summary>
        ''' Gets the name of the service.
        ''' </summary>
        ''' <returns>
        ''' A <see cref="String"/> representing the name of the service.
        ''' </returns>
        Public Function GetServiceName() As String Implements IServicePathProvider.GetServiceName
            Dim assemblyName As String = Reflection.Assembly.GetExecutingAssembly().GetName().Name
            Return assemblyName
        End Function
    End Class
End Namespace
