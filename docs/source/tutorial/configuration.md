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

Due to the size and high complexity of this file, manual creation of the configuration is very time-consuming and error-prone. I will therefore not go into the structure of this file in detail here.

