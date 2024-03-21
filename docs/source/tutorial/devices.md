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

We could now add the configuration for the CPU temperature component directly to the `Configure()` method in the previously created `SystemConfiguration` class. For reasons of clarity, we create a new extension method for this and add the configuration there.

```{literalinclude} assets/code/DeviceExtensions.cs
---
language: csharp
lines: 1-21,29-
emphasize-lines: 12
---
```

