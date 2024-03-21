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