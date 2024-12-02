//////////////////////////////////////////////////////////////////////
// ARGUMENTS
//////////////////////////////////////////////////////////////////////

//Information("Build Started at {}",DateTime.Now);

var target = Argument("target", "Default");
var configuration = Argument("configuration", "Release");

////////////////////////////////////////////////////////////////////
// PREPARATION
//////////////////////////////////////////////////////////////////////

var currentDirectory=MakeAbsolute(Directory("./"));

Information("current Directory is {0}",currentDirectory);

//////////////////////////////////////////////////////////////////////
// TASKS
//////////////////////////////////////////////////////////////////////

Task("Clean")
    .Does(() =>{
    CleanDirectories("./tools/hooks");
    CleanDirectories("../.git/hooks");
});

Task("Restore-NuGet-Packages")
    .IsDependentOn("Clean")
    .Does(() =>{
        NuGetInstall("Syncfusion.Git.Templates", new NuGetInstallSettings {
            ExcludeVersion  = true,
            OutputDirectory = "./tools/hooks/NuGetPackages",
            Source=new List<String>{"http://rs.syncfusion.com:1330/nuget"}    
            });
});

Task("Install-Git-Templates")
.IsDependentOn("Restore-NuGet-Packages")
.Does(()=>{
    var files = GetFiles("./tools/hooks/NuGetPackages/Syncfusion.Git.Templates/tools/*");
	if (!DirectoryExists("../.git/hooks/"))
	{
		CreateDirectory("../.git/hooks/");
	}
    CopyFiles(files, "../.git/hooks/");
});

//////////////////////////////////////////////////////////////////////
// TASK TARGETS
//////////////////////////////////////////////////////////////////////

Task("Default")
    .IsDependentOn("Install-Git-Templates");

//////////////////////////////////////////////////////////////////////
// EXECUTION
//////////////////////////////////////////////////////////////////////

RunTarget(target);