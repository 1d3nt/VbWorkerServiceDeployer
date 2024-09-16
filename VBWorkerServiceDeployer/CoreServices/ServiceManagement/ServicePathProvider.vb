Namespace CoreServices.ServiceManagement

    ''' <summary>
    ''' Provides methods to obtain service paths and names.
    ''' </summary>
    ''' <remarks>
    ''' The <see cref="ServicePathProvider"/> class implements the <see cref="IServicePathProvider"/> interface
    ''' and provides the actual logic for retrieving the paths and names of services to be installed.
    ''' </remarks>
    Friend Class ServicePathProvider
        Implements IServicePathProvider

        ''' <summary>
        ''' Gets the full path to the service executable.
        ''' </summary>
        ''' <returns>The full path to the service executable.</returns>
        Friend Function GetServicePath() As String Implements IServicePathProvider.GetServicePath
            ' Logic to obtain the service path
            Return "C:\Users\Owner\Desktop\ServiceTest\WorkerService\VbWorkerServicePinvokeLauncher.exe"
        End Function

        ''' <summary>
        ''' Gets the name of the service.
        ''' </summary>
        ''' <returns>
        ''' A <see cref="String"/> representing the name of the service.
        ''' </returns>
        Friend Function GetServiceName() As String Implements IServicePathProvider.GetServiceName
            Dim servicePath As String = GetServicePath()
            Dim serviceName As String = IO.Path.GetFileNameWithoutExtension(servicePath)
            Return serviceName
        End Function
    End Class
End Namespace
