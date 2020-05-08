var target = Argument("target", "Default");
var configuration = Argument("configuration", "Release");

var projectName = "ChurnZeroApiClient.Lib";
var rootDir = Directory("../");
var sourcesDir = rootDir + Directory("src"); 
var automationDir = rootDir + Directory("automation"); 
 
var artifactsDir = automationDir + Directory("artifacts");
var artifactsZipsDir = artifactsDir + Directory("zips"); 
   
var packageProjDir = sourcesDir + Directory($"{projectName}");

Task("Clean")
    .Does(() =>
{
    CleanDirectory(artifactsDir); 
    CleanDirectory(artifactsZipsDir); 
	CleanDirectory(Directory($"{packageProjDir}/bin") + Directory(configuration)); 
	CleanDirectory(Directory($"{packageProjDir}/obj") + Directory(configuration)); 
});

Task("Build-ChurnZeroApiClient.Lib")
    .Does(() => {
        var settings = new DotNetCoreBuildSettings{
            Configuration = configuration
        };
        DotNetCoreBuild(packageProjDir, settings);
    });

Task("Pack-ChurnZeroApiClient.Lib")
    .IsDependentOn("Build-ChurnZeroApiClient.Lib")
    .Does(() =>
    {
        var nuGetPackSettings = new NuGetPackSettings
        {
            OutputDirectory = $"{artifactsDir}/lib",
            IncludeReferencedProjects = true,
            Properties = new Dictionary<string, string>
            {
                { "Configuration", configuration }
            }
        };

        NuGetPack($"{packageProjDir}/{projectName}.csproj", nuGetPackSettings);
    });

Task("ZipArtifacts-ChurnZeroApiClient.Lib")
    .IsDependentOn("Pack-ChurnZeroApiClient.Lib")
    .Does(() =>
    {
        EnsureDirectoryExists(artifactsZipsDir);
        Zip($"{artifactsDir}/{projectName}", $"{artifactsZipsDir}/{projectName}-Package.zip");
    });

Task("Publish")
	.IsDependentOn("Clean")
    .IsDependentOn("ZipArtifacts-ChurnZeroApiClient.Lib");

Task("Default")
    .IsDependentOn("Publish");

RunTarget(target);