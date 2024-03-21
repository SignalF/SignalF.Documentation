# CPU-Temperature

## Introduction

In this tutorial we will develop a simple temperature monitoring system with SignalF for the Raspberry Pi. Depending on the processor temperature, the system will control various LEDs and a fan to cool the processor. 

![Raspberry Temperature Control](assets/images/RaspberryTemperatureControl.png)


You will learn how to integrate devices and data output components into SignalF. We will also create a simple logic to monitor the temperature. In the last step, we will connect the individual components using configuration.

## Create the project

First create a new project for a .NET 8 console application.

:::{hint}
Further information on how to create a SignalF application can be found in the chapter [Getting started with SignalF](/getting-started/getting-started.md).
:::


Open the file `Program.cs` after you have created the project. Then enter the following code.

```{literalinclude} assets/code/Program.cs
---
language: csharp
lines: 1,8-16,19-20,29-
---
```

To add the SignalF functionality, we need the Nuget package `SignalF.Extensions.Controller`.
Execute the following command in the Package Manager Console to install the Nuget package.

```powershell
Install-Package SignalF.Extensions.Controller
```

Now add the highlighted lines.

```{literalinclude} Program.cs
---
language: csharp
lines: 16,17,19-21,29-
emphasize-lines: 2,5
---
```

`UseSignalFController()` adds the SignalF functionality to the application. With services.`AddSignalFControllerService()` we define the behaviour of the SignalF application. The SignalF Controller Service automatically loads the configuration at startup, initialises all services and starts measurement operation.

## First run

You can now compile and start the SignalF application. \
Click **Debug > Start Without Debugging** in the menu to start the app. You should now see the following text in the console window:

```text
Default process is running ........
```

SignalF is now up and running. Press Ctrl-C to exit the application. 