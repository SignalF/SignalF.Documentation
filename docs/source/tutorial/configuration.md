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
However, before we can use this interface, we must first integrate it into the application. To do this, we must first install the corresponding Nuget package.

```powershell
Install-Package SignalF.Extensions.Configution
```

```{literalinclude} assets/code/Program.cs
---
language: csharp
lines: 16-19
emphasize-lines: 3
---
```

Im nächsten Schritt erstellen wir die Klasse `SystemConfiguration`, welche das `ISystemConfiguration` interface implementiert.
Diese Klasse wird später die gesamte Konfiguration des Systems enthalten.

```{literalinclude} assets/code/SystemConfiguration.cs
---
language: csharp
lines: 1-21,29-
---
```

Damit die neue Konfiguraton von SignalF verwendet werden kann, müssen wir diese nun noch in der Anwendung registrieren.

Die Main() Methode sollte nun wie folgt aussehen:

```{literalinclude} assets/code/Program.cs
---
language: csharp
lines: 14-22,29-
emphasize-lines: 9
---
```

The next time the SignalF application is started, it no longer uses the default configuration, but a configuration generated at runtime - which is still empty.