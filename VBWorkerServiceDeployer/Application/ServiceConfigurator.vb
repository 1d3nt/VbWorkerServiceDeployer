Imports Microsoft.Extensions.DependencyInjection

Namespace Application

    ''' <summary>
    ''' Configures the services for dependency injection.
    ''' </summary>
    ''' <returns>
    ''' An <see cref="IServiceProvider"/> that provides the configured services.
    ''' </returns>
    ''' <remarks>
    ''' The <c>ConfigureServices</c> method creates a new instance of the <see cref="ServiceCollection"/>
    ''' and registers various services and their corresponding implementations. The method then builds
    ''' and returns an <see cref="IServiceProvider"/> which can be used to resolve services at runtime.
    ''' 
    ''' The following services are configured:
    ''' <list type="bullet">
    '''   <item>
    '''     <description>
    '''       <see cref="IUserInputChecker"/> is implemented by <see cref="UserInputChecker"/>.
    '''       This service handles user interactions for decisions, such as whether to proceed with setup tasks.
    '''     </description>
    '''   </item>
    ''' </list>
    ''' </remarks>
    Friend Class ServiceConfigurator

        ''' <summary>
        ''' Configures the services for dependency injection.
        ''' </summary>
        ''' <returns>
        ''' An <see cref="IServiceProvider"/> that provides the configured services.
        ''' </returns>
        ''' <remarks>
        ''' The <see cref="ConfigureServices"/> method creates a new instance of the <see cref="ServiceCollection"/>
        ''' and registers various services and their corresponding implementations. The method then builds
        ''' and returns an <see cref="IServiceProvider"/> which can be used to resolve services at runtime.
        ''' 
        ''' The following services are configured:
        ''' <list type="bullet">
        '''   <item>
        '''     <description>
        '''       <see cref="IUserInputChecker"/> is implemented by <see cref="UserInputChecker"/>. 
        '''       This service handles user interactions for decisions, such as whether to proceed with setup tasks.
        '''     </description>
        '''   </item>
        ''' </list>
        ''' </remarks>
        Friend Shared Function ConfigureServices() As IServiceProvider
            Dim services As New ServiceCollection()
            services.AddTransient(Of IUserInputChecker, UserInputChecker )()
            Return services.BuildServiceProvider()
        End Function
    End Class
End Namespace
