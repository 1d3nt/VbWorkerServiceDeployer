# VBWorkerServiceDeployer

## Overview
**VBWorkerServiceDeployer** is a .NET 8.0 application designed to install the **VbWorkerServicePinvokeLauncher** service, the first project in a trilogy that showcases the power of P/Invoke for Windows API interactions. This project emphasizes the use of P/Invoke in the context of service installation and uninstallation, demonstrating the intricacies of interacting with Windows APIs for service management.

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

## Installation
### Prerequisites
- .NET 8.0 SDK
- A compatible development environment (e.g., Visual Studio 2022 or later).

### Steps to Install
1. **Clone the Repository**:
   ```bash
   git clone https://github.com/1d3nt/VBWorkerServiceDeployer.git
   ```
2. **Navigate to the Project Directory**:
    ```bash
    cd VBWorkerServiceDeployer
    ```
3. Build the Project: Open the project in Visual Studio and build it to generate the executable.
4. Run the Application: Execute the built application from the command line or Visual Studio to install the service.
