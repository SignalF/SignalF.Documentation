# CPU-Temperature

In this tutorial we will develop a simple temperature monitoring system with SignalF for the Raspberry Pi. Depending on the processor temperature, the system will control various LEDs and a fan to cool the processor. 

![Raspberry Temperature Control](RaspberryTemperatureControl.png)


You will learn how to integrate devices and data output components into SignalF. We will also create a simple logic to monitor the temperature. In the last step, we will connect the individual components using configuration.

## Create the project

First create a new project for a .NET 8 console application.

:::{hint}
Further information on how to create a SignalF application can be found in the chapter [Getting started with SignalF](/getting-started/getting-started.md).
:::


Open the file `Program.cs` after you have created the project. Then enter the following code.

```{literalinclude} Program.cs
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

Now add the following lines.

```{literalinclude} Program.cs
---
language: csharp
lines: 16,17,19-21,29-
emphasize-lines: 2,5
---
```