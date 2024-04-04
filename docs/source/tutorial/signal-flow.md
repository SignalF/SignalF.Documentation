# Signal flow

In the `Devices` chapter of this tutorial, we added a CPU temperature device to our SignalF application, but the temperature signals are not yet read in by SignalF. In this chapter I would like to show how signals are read or written by SignalF. 

## Signal-Hub
The signal hub is the central pool for all signals available in the system of a SignalF application. Signals are written to or read from the signal hub at predefined times. If, for example, a signal from a sensor is to be forwarded to an actuator, the exchange always takes place via the signal hub. The signals from a sensor are written to the signal hub during a write process. Actuators can read this signal during the execution of a read process.\
Calculators are called up between the write and read processes. These can read signals from the signal hub, process or aggregate the signals and write the processed signals back to the signal hub. 

## Tasks
In order for signals from sensors to be read or sent to actuators, they must be assigned to a SignalF task. Tasks are called by the scheduler one after the other in fixed time intervals according to their priority. Each task then calls up a corresponding read or write operation on the signal processors assigned to it (sensors, actuators, calulators).

The following task types are available:
- Init 
- Write
- Calculate
- Read
- Exit

### Init task
The Init task is called once before another task is executed when switching to measurement mode.

### Write task
Signal processors can write signals to the signal hub within a write task.

### Calculate task
Signals can be processed within a Calculate Task. Calculators are always assigned to a Calculate task and should never be assigned directly to a Write or Read task.  When executing the Calculate task, the calculators are always called first in Read mode, then in Calculate mode and finally in Write mode. Calculators therefore read signals from the signal hub, process them and then write the processed signals back to the signal hub. As the processing takes place in the order in which they are assigned to a task, calculators can also process the results of other calculators.

### Read task
Within a read task, signal processors can read signals from the signal hub.

### Exit task
The exit task is called up once when measurement mode is ended. No other tasks are executed after the exit task.

## Create a task
So that we can monitor the CPU temperature in our monitoring system, we need a write task in which the device implementation can write the temperature to the signal hub.
We create two new extension methods for the task configuration. One for defining the tasks and a second for mapping the signal processors to the tasks.

Monitoring the CPU temperature to the second is sufficient for our monitoring system. We therefore define a write task with a raster of 1 second.  

```{literalinclude} assets/code/TaskExtensions.cs
---
language: csharp
lines: 1-9,13-17,20-23,31-
emphasize-lines: 9,15
---
```

In the next step, we add a new extension method to assign the device to the task.
Here we assign the device with the name "CPU" to the 1s task.

```{literalinclude} assets/code/TaskExtensions.cs
---
language: csharp
lines: 25-30
emphasize-lines: 3
---
```