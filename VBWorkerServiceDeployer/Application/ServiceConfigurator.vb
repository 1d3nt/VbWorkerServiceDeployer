Namespace Application

    ''' <summary>
    ''' Configures the services for dependency injection.
    ''' </summary>
    ''' <remarks>
    ''' The <see cref="ServiceConfigurator"/> class provides methods to configure and register services
    ''' for dependency injection. It creates a new instance of the <see cref="ServiceCollection"/> class,
    ''' registers various services and their corresponding implementations, and builds an <see cref="IServiceProvider"/>
    ''' which can be used to resolve services at runtime.
    ''' </remarks>
    Friend Class ServiceConfigurator

        ''' <summary>
        ''' Registers all services required by the application.
        ''' </summary>
        ''' <param name="services">
        ''' The service collection to add the services to.
        ''' </param>
        ''' <remarks>
        ''' This method calls individual methods to register different categories of services:
        ''' <list type="bullet">
        '''   <item>
        '''     <description>
        '''       <see cref="RegisterErrorHandlingServices"/> to register error handling services.
        '''     </description>
        '''   </item>
        '''   <item>
        '''     <description>
        '''       <see cref="RegisterUserInputServices"/> to register user input services.
        '''     </description>
        '''   </item>
        '''   <item>
        '''     <description>
        '''       <see cref="RegisterServiceManagementServices"/> to register service management services.
        '''     </description>
        '''   </item>
        ''' </list>
        ''' </remarks>
        Private Shared Sub RegisterServices(services As IServiceCollection)
            RegisterErrorHandlingServices(services)
            RegisterUserInputServices(services)
            RegisterServiceManagementServices(services)
        End Sub

        ''' <summary>
        ''' Registers error handling services.
        ''' </summary>
        ''' <param name="services">
        ''' The service collection to add the services to.
        ''' </param>
        ''' <remarks>
        ''' This method registers the following error handling services:
        ''' <list type="bullet">
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
        Private Shared Sub RegisterErrorHandlingServices(services As IServiceCollection)
            Dim errorHandlingServices As New Dictionary(Of Type, Type) From {
                {GetType(IWin32ErrorHelper), GetType(Win32ErrorHelper)},
                {GetType(IWin32ErrorUtility), GetType(Win32ErrorUtility)},
                {GetType(IErrorHandlingService), GetType(ErrorHandlingService)}
            }
            AddServices(services, errorHandlingServices)
        End Sub

        ''' <summary>
        ''' Registers user input services.
        ''' </summary>
        ''' <param name="services">
        ''' The service collection to add the services to.
        ''' </param>
        ''' <remarks>
        ''' This method registers the following user input services:
        ''' <list type="bullet">
        '''   <item>
        '''     <description>
        '''       <see cref="IUserInputReader"/> is implemented by <see cref="UserInputReader"/>.
        '''       This service handles reading user inputs during interaction processes.
        '''     </description>
        '''   </item>
        '''   <item>
        '''     <description>
        '''       <see cref="IUserPrompter"/> is implemented by <see cref="UserPrompter"/>.
        '''       This service prompts the user for inputs, typically used in setup tasks where user confirmation is needed.
        '''     </description>
        '''   </item>
        '''   <item>
        '''     <description>
        '''       <see cref="IUserInputChecker"/> is implemented by <see cref="UserInputChecker"/>.
        '''       This service handles user interactions to verify decisions, such as whether to proceed with setup tasks.
        '''     </description>
        '''   </item>
        ''' </list>
        ''' </remarks>
        Private Shared Sub RegisterUserInputServices(services As IServiceCollection)
            Dim userInputServices As New Dictionary(Of Type, Type) From {
                {GetType(IUserInputReader), GetType(UserInputReader)},
                {GetType(IUserPrompter), GetType(UserPrompter)},
                {GetType(IUserInputChecker), GetType(UserInputChecker)}
            }
            AddServices(services, userInputServices)
        End Sub

        ''' <summary>
        ''' Registers service management services.
        ''' </summary>
        ''' <param name="services">
        ''' The service collection to add the services to.
        ''' </param>
        ''' <remarks>
        ''' This method registers the following service management services:
        ''' <list type="bullet">
        '''   <item>
        '''     <description>
        '''       <see cref="IServicePathProvider"/> is implemented by <see cref="ServicePathProvider"/>.
        '''       This service provides paths for services.
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
        '''       <see cref="IServiceStarter"/> is implemented by <see cref="ServiceStarter"/>.
        '''       This service handles starting services.
        '''     </description>
        '''   </item>
        '''   <item>
        '''     <description>
        '''       <see cref="IServiceStopper"/> is implemented by <see cref="ServiceStopper"/>.
        '''       This service handles stopping services.
        '''     </description>
        '''   </item>
        '''   <item>
        '''     <description>
        '''       <see cref="IServiceUninstaller"/> is implemented by <see cref="ServiceUninstaller"/>.
        '''       This service handles the uninstallation of services.
        '''     </description>
        '''   </item>
        ''' </list>
        ''' </remarks>
        Private Shared Sub RegisterServiceManagementServices(services As IServiceCollection)
            Dim serviceManagementServices As New Dictionary(Of Type, Type) From {
                {GetType(IServicePathProvider), GetType(ServicePathProvider)},
                {GetType(IServiceControlManager), GetType(ServiceControlManager)},
                {GetType(IServiceCreator), GetType(ServiceCreator)},
                {GetType(IServiceInstaller), GetType(ServiceInstaller)},
                {GetType(IServiceStarter), GetType(ServiceStarter)},
                {GetType(IServiceStopper), GetType(ServiceStopper)},
                {GetType(IServiceUninstaller), GetType(ServiceUninstaller)}
            }
            AddServices(services, serviceManagementServices)
        End Sub

        ''' <summary>
        ''' Adds the specified services to the service collection.
        ''' </summary>
        ''' <param name="services">
        ''' The service collection to add the services to.
        ''' </param>
        ''' <param name="serviceRegistrations">
        ''' The dictionary of service registrations.
        ''' </param>
        ''' <remarks>
        ''' This method iterates over the provided dictionary of service registrations and adds each service
        ''' to the <paramref name="services"/> collection with a transient lifetime.
        ''' </remarks>
        Private Shared Sub AddServices(services As IServiceCollection, serviceRegistrations As Dictionary(Of Type, Type))
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
