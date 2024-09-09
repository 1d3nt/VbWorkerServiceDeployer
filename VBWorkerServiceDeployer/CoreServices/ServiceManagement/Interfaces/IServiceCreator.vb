Namespace CoreServices.ServiceManagement.Interfaces

    ''' <summary>
    ''' Defines the contract for creating services.
    ''' </summary>
    Public Interface IServiceCreator

        ''' <summary>
        ''' Creates the service.
        ''' </summary>
        ''' <param name="serviceControlManager">The handle to the Service Control Manager.</param>
        ''' <returns>An IntPtr representing the handle to the newly created service.</returns>
        Function Create(serviceControlManager As IntPtr) As IntPtr
    End Interface
End Namespace
