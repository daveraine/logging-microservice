//////////////////////////////////////////////////////////////////////
// ARGUMENTS
//////////////////////////////////////////////////////////////////////

var target = Argument("target", "Default");
var configuration = Argument("configuration", "Release");
var framework = Argument("framework", "netcoreapp2.0");
var runtime = Argument("runtime", "win10-x64");

//////////////////////////////////////////////////////////////////////
// PREPARATION
//////////////////////////////////////////////////////////////////////

// Define directories.
var projectDir = Directory("./src/LoggingMicroservice");
var buildDir = Directory("./src/LoggingMicroservice/bin") + Directory(configuration);
var objectDir = Directory("./src/LoggingMicroservice/obj") + Directory(configuration);
var publishDir = Directory("./publish");

// Define projects
var projectFile = File("./src/LoggingMicroservice/LoggingMicroservice.csproj");
var testProjectFile = File("./src/LoggingMicroservice.Tests/LoggingMicroservice.Tests.csproj");

//////////////////////////////////////////////////////////////////////
// TASKS
//////////////////////////////////////////////////////////////////////

Task("Clean")
    .Does(() =>
{
    CleanDirectory(buildDir);
    CleanDirectory(objectDir);
    CleanDirectory(publishDir);
});

Task("Restore-NuGet-Packages")
    .IsDependentOn("Clean")
    .Does(() =>
{
    DotNetCoreRestore(projectFile);
});

Task("Build")
    .IsDependentOn("Restore-NuGet-Packages")
    .Does(() =>
{
    var settings = new DotNetCoreBuildSettings
    {
        Framework = framework,
        Configuration = configuration,
        OutputDirectory = buildDir
    };

    DotNetCoreBuild(projectFile, settings);
});

Task("Publish")
    .IsDependentOn("Build")
    .Does(() =>
    {
        var settings = new DotNetCorePublishSettings
        {
            Framework = framework,
            Configuration = configuration,
            OutputDirectory = publishDir,
            Runtime = runtime
        };
 
        DotNetCorePublish(projectDir, settings);
    });

Task("Run-Unit-Tests")
    .IsDependentOn("Build")
    .Does(() =>
{
    var settings = new DotNetCoreTestSettings
    {

    };

    DotNetCoreTest(testProjectFile, settings);
});

//////////////////////////////////////////////////////////////////////
// TASK TARGETS
//////////////////////////////////////////////////////////////////////

Task("Default")
    .IsDependentOn("Run-Unit-Tests");

//////////////////////////////////////////////////////////////////////
// EXECUTION
//////////////////////////////////////////////////////////////////////

RunTarget(target);
