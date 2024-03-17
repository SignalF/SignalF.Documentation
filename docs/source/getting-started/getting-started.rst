Getting started with SignalF
============================

Prerequisites
-------------
SignalF is based on .NET 8 and .NET Standard 2.1. To compile SignalF you need Visual Studio 2022 (version 17.8.0 or newer). If you are using a different development environment, you must install the |dotnet_sdk|.

Create a new project
--------------------
- Open Visual Studio.
- Click on New project
- Select Console app with the tag C# and click Next
- Enter SignalFStarted as the name and then click Create.

Install SignalF
---------------

Execute the following command in the Package Manager Console to install SignalF.

.. code-block:: powershell

   Install-Package SignalF.Extensions.Controller


Create the code
---------------

Open the file ``Program.cs`` and enter the following code.

.. literalinclude:: Program.cs
  :language: c#


Run the app
-----------

Click **Debug > Start Without Debugging** in the menu to start the app.


.. |dotnet_sdk| raw:: html

   <a href="https://dotnet.microsoft.com/en-us/download/dotnet/8.0" target="_blank">.NET 8 SDK</a>
