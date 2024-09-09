Namespace Application

    ''' <summary>
    ''' Configures the services for dependency injection.
    ''' </summary>
    ''' <remarks>
    ''' The <see cref="ServiceConfigurator"/> class provides methods to configure and register services
    ''' for dependency injection. It creates a new instance of the <see cref="ServiceCollection"/>,
    ''' registers various services and their corresponding implementations, and builds an <see cref="IServiceProvider"/>
    ''' which can be used to resolve services at runtime.
    ''' </remarks>
    Friend Class ServiceConfigurator

        ''' <summary>
        ''' Registers the services for dependency injection.
        ''' </summary>
        ''' <param name="services">The service collection to which services will be added.</param>
        ''' <remarks>
        ''' This method registers various services and their corresponding implementations.
        ''' The following services are configured:
        ''' <list type="bullet">
        '''   <item>
        '''     <description>
        '''       <see cref="IUserInputChecker"/> is implemented by <see cref="UserInputChecker"/>.
        '''       This service handles user interactions for decisions, such as whether to proceed with setup tasks.
        '''     </description>
        '''   </item>
        '''   <item>
        '''     <description>
        '''       <see cref="IServiceControlManager"/> is implemented by <see cref="ServiceControlManager"/>.
        '''       This service manages interactions with the service control manager.
        '''     </description>
        '''   </item>
        '''   <item>
        '''     <description>
        '''       <see cref="IServiceCreator"/> is implemented by <see cref="ServiceCreator"/>.
        '''       This service is responsible for creating services.
        '''     </description>
        '''   </item>
        '''   <item>
        '''     <description>
        '''       <see cref="IServiceInstaller"/> is implemented by <see cref="ServiceInstaller"/>.
        '''       This service handles the installation of services.
        '''     </description>
        '''   </item>
        '''   <item>
        '''     <description>
        '''       <see cref="IServicePathProvider"/> is implemented by <see cref="ServicePathProvider"/>.
        '''       This service provides paths for services.
        '''     </description>
        '''   </item>
        '''   <item>
        '''     <description>
        '''       <see cref="IWin32ErrorHelper"/> is implemented by <see cref="Win32ErrorHelper"/>.
        '''       This service helps retrieve Win32 error codes.
        '''     </description>
        '''   </item>
        '''   <item>
        '''     <description>
        '''       <see cref="IWin32ErrorUtility"/> is implemented by <see cref="Win32ErrorUtility"/>.
        '''       This service provides descriptions for Win32 error codes.
        '''     </description>
        '''   </item>
        '''   <item>
        '''     <description>
        '''       <see cref="IErrorHandlingService"/> is implemented by <see cref="ErrorHandlingService"/>.
        '''       This service handles Win32 errors.
        '''     </description>
        '''   </item>
        ''' </list>
        ''' </remarks>
        Private Shared Sub RegisterServices(services As IServiceCollection)
            Dim serviceRegistrations As New Dictionary(Of Type, Type) From {
                {GetType(IUserInputChecker), GetType(UserInputChecker)},
                {GetType(IServiceControlManager), GetType(ServiceControlManager)},
                {GetType(IServiceCreator), GetType(ServiceCreator)},
                {GetType(IServiceInstaller), GetType(ServiceInstaller)},
                {GetType(IServicePathProvider), GetType(ServicePathProvider)},
                {GetType(IWin32ErrorHelper), GetType(Win32ErrorHelper)},
                {GetType(IWin32ErrorUtility), GetType(Win32ErrorUtility)},
                {GetType(IErrorHandlingService), GetType(ErrorHandlingService)}
            }
            For Each kvp As KeyValuePair(Of Type, Type) In serviceRegistrations
                services.AddTransient(kvp.Key, kvp.Value)
            Next
        End Sub

        ''' <summary>
        ''' Configures the services for dependency injection.
        ''' </summary>
        ''' <returns>
        ''' An <see cref="IServiceProvider"/> that provides the configured services.
        ''' </returns>
        ''' <remarks>
        ''' The <see cref="ConfigureServices"/> method creates a new instance of the <see cref="ServiceCollection"/>
        ''' and registers various services and their corresponding implementations by calling the <see cref="RegisterServices"/> method.
        ''' The method then builds and returns an <see cref="IServiceProvider"/> which can be used to resolve services at runtime.
        ''' </remarks>
        Friend Shared Function ConfigureServices() As IServiceProvider
            Dim services As New ServiceCollection()
            RegisterServices(services)
            Return services.BuildServiceProvider()
        End Function
    End Class
End Namespace
