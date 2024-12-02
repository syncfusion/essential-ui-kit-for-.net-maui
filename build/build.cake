#tool nuget:?package=NUnit.ConsoleRunner&version=3.4.0
#addin nuget:?package=Cake.FileHelpers&version=3.3.0
#tool "nuget:?package=GitVersion.CommandLine&version=5.3.7"
#tool "docfx.console"
#addin nuget:?package=Cake.Docfx&version=0.13.1
#addin nuget:?package=Cake.Xamarin&version=3.1.0
#addin nuget:?package=Cake.WebDeploy&version=0.3.4
#addin "nuget:?package=Syncfusion.Build.CakePlugin"
#addin "nuget:?package=Syncfusion.UnitTest.CakePlugin"
#addin "nuget:?package=Syncfusion.APIReference.CakePlugin"


using System.IO;
using System.Collections.Generic;


//////////////////////////////////////////////////////////////////////
// ARGUMENTS
//////////////////////////////////////////////////////////////////////

var target = Argument("target", "Build");
var apiServerIP=Argument<string>("apiServerIP","");
var apiServerPort=Argument<string>("apiServerPort","");
var apiSiteName=Argument<string>("apiSiteName","");
var apiServerUserName=Argument<string>("apiServerUserName","");
var apiServerPassword=Argument<string>("apiServerPassword","");
var SourceBranch=Argument<string>("SourceBranch","");
var TargetBranch=Argument<string>("TargetBranch","");
var XAMLAWSAccessID=Argument<string>("XAMLAWSAccessID","");
var XAMLAWSAccessKey=Argument<string>("XAMLAWSAccessKey","");
var currentDirectory = MakeAbsolute(Directory("../"));

//////////////////////////////////////////////////////////////////////
// TASKS
//////////////////////////////////////////////////////////////////////

Task("Build").Does(() =>
{
   Syncfusion.Build.CakePlugin.BuildAlias.CompileProjects(Context);
})
.OnError(exception =>
{
	FileWriteText("../cakelog.txt", "Error on Build task:" + exception.ToString());
	throw new Exception("Cake process Failed on Build task");
});

Task("APIReference")
.Does(() =>
{
   if(IsRunningOnWindows())
   {
		Syncfusion.APIReference.CakePlugin.ApiReferenceAlias.Generate(Context);
   }
})
.OnError(exception =>
{
	FileWriteText("../cakelog.txt", "Error on APIReference task:" + exception.ToString());
	throw new Exception("Cake process Failed on APIReference Task");
});

Task("CodeViolation").Does(() =>
{
	if(IsRunningOnWindows())
	{
		Syncfusion.Build.CakePlugin.BuildAlias.GetStyleCopReports(Context);
		Syncfusion.Build.CakePlugin.BuildAlias.GetFxCopReports(Context);
	}
})
.OnError(exception =>
{
	FileWriteText("../cakelog.txt", "Error on CodeViolation task:" + exception.ToString());
	throw new Exception("Cake process Failed on CodeViolation Task");
});

//////////////////////////////////////////////////////////////////////
// Test
//////////////////////////////////////////////////////////////////////

Task("Tests").Does(() =>
{
	if(!IsRunningOnWindows())
	{
	    Syncfusion.UnitTest.CakePlugin.UnitTestAlias.RunXamariniOS(Context);
	}
	else
	{
		Syncfusion.UnitTest.CakePlugin.UnitTestAlias.RunXamarinAndroid(Context);
	}
})
.OnError(exception =>
{
	FileWriteText("../cakelog.txt", "Error on Tests task:" + exception.ToString());
	throw new Exception("Cake process Failed on Tests Task");
});

Task("publish")
.Does(() =>
{
	if(IsRunningOnWindows())
	{
		Syncfusion.Build.CakePlugin.BuildAlias.Publish(Context);
	}
RunTarget("APIPublish");
RunTarget("APIPublishInAWS");
})
.OnError(exception =>
{
	FileWriteText("../cakelog.txt", "Error publish task:" + exception.ToString());
	throw new Exception("Cake process Failed on publish Task");
});

//////////////////////////////////////////////////////////////////////
// API Publish
//////////////////////////////////////////////////////////////////////

Task("APIPublish")
.IsDependentOn("APIReference")
.Does(() =>
    {
	     EnsureDirectoryExists("../cireports/API");
         var filesPath= GetFiles(currentDirectory+"/API/**/api/toc.html");
		 var publishContent="";
         foreach(var files in filesPath)
         {
		  var appentContent=files.ToString();
		  appentContent=appentContent.Replace(currentDirectory+"/API","http://"+apiServerIP+":"+apiServerPort);
		  publishContent=publishContent+appentContent+"\r\n";
		  System.IO.StreamWriter file = new System.IO.StreamWriter(currentDirectory+"/cireports/API/Publish.txt");
          file.WriteLine(publishContent);
		  file.Close();
         } 
	 Zip("../API","../API.zip");
    });

Task("APIPublishInAWS")
.IsDependentOn("APIReference")
.Does(() =>
{	
	var information = "SourceBranch:" + SourceBranch + ",\nXAMLAWSAccessID:" + XAMLAWSAccessID  + ",\nXAMLAWSAccessKey:"+ XAMLAWSAccessKey;
	StreamWriter infoFile = new StreamWriter(currentDirectory+"/cireports/information.txt");
    infoFile.WriteLine(information);
	infoFile.Close();
	Syncfusion.Build.CakePlugin.BuildAlias.PublishAPIInAWS(Context);
}).OnError(exception =>
{
	Information(exception);
	throw new Exception("Cake process Failed on API Publish In AWS Task");
});


RunTarget(target);
