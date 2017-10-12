# Logging Microservice

An ASP.NET Core 2.0 microservice exposing an API that writes log messages from external services to a text file.

## Development environment

### Dependencies

The following system dependencies are required to build the solution:

* [Visual Studio 2017](https://www.visualstudio.com/downloads/)
* [.NET Core 2.0 SDK](https://www.microsoft.com/net/download/core)

### Build the solution

Open the solution in Visual Studio, and build / run it for debugging purposes. For build servers, run `build.ps1`, which uses [Cake](https://cakebuild.net) for building, running unit tests, and publishing.