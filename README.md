# VbWorkerServiceDeployer

## Overview
**VbWorkerServiceDeployer** is a .NET 8.0 application designed to install the **VbWorkerServicePinvokeLauncher** service, the first project in a trilogy that showcases the power of P/Invoke for Windows API interactions. This project emphasizes the use of P/Invoke in the context of service installation and uninstallation, demonstrating the intricacies of interacting with Windows APIs for service management.

**VBWorkerServiceDeployer** is a .NET 8.0 application designed to install the [VbWorkerServicePinvokeLauncher](https://github.com/1d3nt/VbWorkerServicePinvokeLauncher) service, the first project in a trilogy that showcases the power of P/Invoke for Windows API interactions. 

This project emphasizes the use of P/Invoke in the context of service installation and uninstallation, demonstrating the intricacies of interacting with Windows APIs for service management. 

A key focus of **VBWorkerServiceDeployer** is on implementing dependency injection, allowing for a flexible and testable architecture. Using dependency injection, we ensure that each component can be easily replaced or mocked during testing, facilitating better maintainability and scalability.

Furthermore, we adhere to the Single Responsibility Principle, ensuring that each class in the project has a distinct and focused responsibility. This design choice enhances code clarity and reduces complexity, making the application easier to understand and maintain.

## Functionality
This project is responsible for:
- **Installing the Worker Service**: It creates and configures the Windows service that utilizes token duplication to launch processes under the SYSTEM account.
- **Configuring File Paths**: Ensures that the service executable is located at:

  ```bash
   <drive_letter>:\Users\<username>\Desktop\ServiceTest\WorkerService\VbWorkerServicePinvokeLauncher.exe
  ```
  
- **Appsettings Configuration**: The service relies on a configuration file (`appsettings.json`) to define the executable path for the user account verification tool:
```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.Hosting.Lifetime": "Information"
    }
  },
  "WorkerServiceSettings": {
   "FilePath": "<drive_letter>:\\Users\\<username>\\Desktop\\ServiceTest\\ExampleExecutable\\VbUserAccountTypeChecker.exe"
  }
}
```

## Project Structure

```bash
|-- Application
|   |-- AppRunner.vb
|   +-- ServiceConfigurator.vb
|  
|-- CoreServices
|   |-- ServiceManagement
|   |   |-- Interfaces
|   |   |   |-- IServiceControlManager.vb
|   |   |   |-- IServiceCreator.vb
|   |   |   |-- IServiceDeleter.vb
|   |   |   |-- IServiceInstaller.vb
|   |   |   |-- IServicePathProvider.vb
|   |   |   |-- IServiceStarter.vb
|   |   |   |-- IServiceStatusChecker.vb
|   |   |   |-- IServiceStopper.vb
|   |   |   +-- IServiceUninstaller.vb
|   |   |-- ServiceControlManager.vb
|   |   |-- ServiceCreator.vb
|   |   |-- ServiceDeleter.vb
|   |   |-- ServiceInstaller.vb
|   |   |-- ServicePathProvider.vb
|   |   |-- ServiceStarter.vb
|   |   |-- ServiceStatusChecker.vb
|   |   |-- ServiceStopper.vb
|   |   +-- ServiceUninstaller.vb
|   +-- WindowsApiInterop
|       |-- Enums
|       |   |-- DesiredAccess.vb
|       |   |-- ServiceControlCodes.vb
|       |   |-- ServiceErrorControlFlags.vb
|       |   |-- ServiceManagerAccessFlags.vb
|       |   |-- ServiceType.vb
|       |   |-- StartType.vb
|       |   +-- Win32ErrorCodes.vb
|       |-- Methods
|       |   |-- HandleManager.vb
|       |   |-- MemoryManager.vb
|       |   +-- NativeMethods.vb
|       |-- Structs
|       |   +-- ServiceStatus.vb
|       +-- ExternDll.vb
|  
|-- Utilities
|   |-- ErrorHandling
|   |   |-- Interfaces
|   |   |   |-- IErrorHandlingService.vb
|   |   |   |-- IWin32ErrorHelper.vb
|   |   |   +-- IWin32ErrorUtility.vb
|   |   |-- ErrorHandlingService.vb
|   |   |-- Win32ErrorHelper.vb
|   |   +-- Win32ErrorUtility.vb
|   |-- Interfaces
|   |   |-- IUserInputChecker.vb
|   |   |-- IUserInputReader.vb
|   |   +-- IUserPrompter.vb
|   |-- AsynchronousProcessor.vb
|   |-- UserInputChecker.vb
|   |-- UserInputReader.vb
|   +-- UserPrompter.vb
|  
|-- GlobalAttributes.vb
+-- Program.vb
```

## Installation
### Prerequisites
- .NET 8.0 SDK
- A compatible development environment (e.g., Visual Studio 2022 or later).

### Steps to Install
1. **Clone the Repository**:
   ```bash
   git clone https://github.com/1d3nt/VbWorkerServiceDeployer.git
   ```
2. **Navigate to the Project Directory**:
    ```bash
    cd VbWorkerServiceDeployer
    ```
3. Build the Project: Open the project in Visual Studio and build it to generate the executable.
4. Run the Application: Execute the built application from the command line or Visual Studio to install the service.

![My Image](https://i.imgur.com/j9GatYU.png)