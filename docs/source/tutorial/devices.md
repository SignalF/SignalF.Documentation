# Devices

In this part of the tutorial, I would like to show you how to add devices to a SignalF application and integrate them using configuration. In this tutorial we will add a device for reading the processor temperature.

## Thermal zones

Processors and other hardware (e.g. graphics cards) on Linux systems provide the temperature in certain thermal zones via the sysfs driver. Heat management solutions can trigger certain actions based on these values, such as activating cooling devices or throttling processor performance. The exact meaning of the temperature zones and their names depend on the hardware and are defined in the respective drivers.

:::{seealso}
Under the following link you will find more information about the sysfs driver:
[Generic Thermal Sysfs driver How To](https://www.kernel.org/doc/Documentation/thermal/sysfs-api.txt){target="_blank"}
:::

On the Raspberry Pi 4, the processor temperature can be obtained by reading the file `/sys/class/thermal/thermal_zone0/temp`. The name of this zone can be found in the file `/sys/class/thermal/thermal_zone0/type`. 

:::{warning}
Which file must actually be read out to obtain the processor temperature depends on the hardware and the operating system. Execute the following command to obtain a list of all available thermal zones.
```bash
cat /sys/class/thermal/thermal_zone*/type
```
:::

## CPU-Temperature
SignalF.Devices contains a simple component for reading the current CPU temperature. Execute the following command to install the corresponding Nuget package.
```powershell
Install-Package -IncludePrerelease SignalF.Devices.CpuTemperature
```

To make the component available for SignalF, we now need to register it.

```{literalinclude} assets/code/Program.cs
---
language: csharp
lines: 19-25,29
emphasize-lines: 7
---
```

We could now add the configuration for the CPU temperature component directly to the `Configure()` method in the previously created `SystemConfiguration` class. However, for reasons of clarity, we create a new extension method for this and add the configuration there. 

```{literalinclude} assets/code/DeviceExtensions.cs
---
language: csharp
lines: 1-21,29-
emphasize-lines: 12
---
```

We now call the extension method we have just created in the `Configure()` method.

```{literalinclude} assets/code/SystemConfiguration.cs
---
language: csharp
lines: 18-23,28-
emphasize-lines: 6
---
```

## Naming conventions

In the configuration, we can assign a name for the device and for the signal. In this case, we call the device 'CPU' and the signal 'Temperature'. The device name must be unique within the configuration. This means that only one device may ever be given this name. The signal names must also be unique. However, it is sufficient here if the signals within a device are unique./
If signals outside a device are to be referenced, they are always addressed using a composite name. This name always follows the pattern `DEVICENAME.SIGNALNAME`. In our case, this is `CPU.Temperature`.

:::{tip}
Ideally, the signal names within a configuration should also be unique. This makes it easier to track the signal flow in larger projects.
:::

