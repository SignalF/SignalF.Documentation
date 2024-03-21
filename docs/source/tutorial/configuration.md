# Configuration

In the first part of this tutorial, we created a simple SignalF application. In the second part, I would now like to take a closer look at the configuration.


## The configuration file

SignalF uses a configuration file based on XML. This is automatically read by the application when it is started.

Here is a short extract from the default configuration.

```{literalinclude} assets/code/DefaultConfiguration.xml
---
language: xml
lines: 1-6,28-40
---
```

Due to the size and high complexity of this file, manual creation of the configuration is very time-consuming and error-prone. I will therefore not go into the details here.


## The datamodel

SignalF uses a comprehensive [data model](https://github.com/Signal-F/SignalF.Controller/tree/develop/Source/Datamodel){target="_blank"} generated from the configuration [schema files](https://github.com/Signal-F/SignalF.Controller/tree/develop/Schemas/Configuration){target="_blank"} to access the configuration file.

Using the data model makes it much easier to create the configuration, but deep knowledge of the structure of the configuration is still required. One possible area of application would be, for example, the automated creation or customisation of configurations.


## The fluent interface

SignalF comes with a fluent interface for simple and intuitive configuration. \
However, before we can use this interface, we must integrate it into the application. To do this, we have to install the corresponding Nuget package.

```powershell
Install-Package SignalF.Extensions.Configuration
```

```{literalinclude} assets/code/Program.cs
---
language: csharp
lines: 16-19
emphasize-lines: 3
---
```

In the next step, we create the class `SystemConfiguration`, which implements the `ISystemConfiguration` interface. This class will later contain the entire configuration of the system.

```{literalinclude} assets/code/SystemConfiguration.cs
---
language: csharp
lines: 1-21,29-
---
```

In order for the new configuration to be used, we need to register it in the application.

The Main() method should now look like this:

```{literalinclude} assets/code/Program.cs
---
language: csharp
lines: 14-22,29-
emphasize-lines: 9
---
```

The next time the SignalF application is started, it no longer uses the default configuration, but a configuration generated at runtime - which is still empty.