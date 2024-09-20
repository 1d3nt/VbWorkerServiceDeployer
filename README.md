# VBWorkerServiceDeployer

## Overview
**VBWorkerServiceDeployer** is a .NET 8.0 application designed to install the **VbWorkerServicePinvokeLauncher** service, the first project in a trilogy that showcases the power of P/Invoke for Windows API interactions. This project emphasizes the use of P/Invoke in the context of service installation and uninstallation, demonstrating the intricacies of interacting with Windows APIs for service management.

## Functionality
This project is responsible for:
- **Installing the Worker Service**: It creates and configures the Windows service that utilizes token duplication to launch processes under the SYSTEM account.
- **Configuring File Paths**: Ensures that the service executable is located at:

  ```bash
  C:\Users\Owner\Desktop\ServiceTest\WorkerService\VbWorkerServicePinvokeLauncher.exe
  ```


