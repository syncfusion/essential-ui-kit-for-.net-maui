node ('Maui') 
{
timestamps
{
timeout(time: 7200000, unit: 'MILLISECONDS') 
{
    stage 'Checkout' 
    try
    {	
	  checkout scm
    }
    catch(Exception e)
    {
        echo "Exception in checkout stage \r\n"+e
        currentBuild.result = 'FAILURE'
    }
if (currentBuild.result != 'FAILURE')
{ 
	stage('Install Software') {
		try
		{
			bat 'powershell.exe -ExecutionPolicy ByPass -File ./Install.ps1'
		}
		 catch(Exception e)
		 {
		    echo "Exception in software installation stage \r\n"+e
			currentBuild.result = 'FAILURE'
		 }
	}
}
     
if(currentBuild.result != 'FAILURE')
{ 
	stage 'Build Source'
	try
	{		
	    gitlabCommitStatus("Build")
		{
			bat 'powershell.exe -ExecutionPolicy ByPass -File build/build.ps1 -Script '+env.WORKSPACE+"/build/build.cake -Target build -OutputPath Assemblies -StudioVersion  "+env.studio_version+' -TargetBranch '+githubTargetBranch+' -NugetServerUrl '+env.nugetserverurls
	 	}
                 def files = findFiles(glob: '**/cireports/errorlogs/*.txt')

                 if(files.size() > 0)
                 {
                    currentBuild.result = 'FAILURE'
                 }
    }
	 catch(Exception e) 
    {
        echo "Exception in build stage \r\n"+e
		currentBuild.result = 'FAILURE'
    }
}
if(currentBuild.result != 'FAILURE')
{
	stage 'Code violation'
	try
	{
	    gitlabCommitStatus("Code violation")
	    {
			bat 'powershell.exe -ExecutionPolicy ByPass -File build/build.ps1 -Script '+env.WORKSPACE+"/build/build.cake -Target codeviolation"  
	    }
	}
	catch(Exception e) 
	{
	    echo "Exception in code violation stage \r\n"+e
		currentBuild.result = 'FAILURE'
	}
}  

if(currentBuild.result != 'FAILURE' && env.publishBranch.contains(githubSourceBranch))
{
	stage 'Publish'
	try
	{
	  //method to get release notes content
	   env.PATH = "C:\\Program Files\\Git\\mingw64\\bin;${env.PATH}"
	   def branchCommit = '"'+'https://github.com/essential-studio/essential-ui-kit-for-.net-maui/pulls'+env.pullRequestId+'/commits'
	   String branchCommitDetails = bat returnStdout: true, script: 'curl -H "Accept: application/vnd.github.v3+json" -u SyncfusionBuild:' +env.GithubBuildAutomation_PrivateToken+" "+branchCommit
	   def splitCommitDetails=branchCommitDetails.split('\n')
	   def splitMessageDetails = splitCommitDetails[2].split('"message":')
	   def releaseNotesContent=""; 
		for(int k=1; k<splitMessageDetails.size();k++)
		{
			def commitDetails = splitMessageDetails[k].split('"author_email":')
			for(int j=1; j<commitDetails.size(); j++)
			{			
				 releaseNotesContent+=commitDetails[0].replace(',"author_name":',' - ').replace('\\n','').replace('",','"')+"\r\n";
			}
		}
		if (releaseNotesContent) 
		{  
		   writeFile file: env.WORKSPACE+"/cireports/releasenotes/releasenotes.txt", text: releaseNotesContent
		}
		else  
		{
		   writeFile file: env.WORKSPACE+"/cireports/releasenotes/releasenotes.txt", text: "No commit details found for this job."
		}

	  gitlabCommitStatus("Publish")
	    {		    
		if(githubSourceBranch.contains("internal-development"))
		{
		   bat 'powershell.exe -ExecutionPolicy ByPass -File build/build.ps1 -Script '+env.WORKSPACE+"/build/build.cake -Target APIPublishInAWS -apiServerPort 8253 -apiSiteName essential-ui-kit-for-.net-maui -StudioVersion  "+env.studio_version+' -nugetapikey '+env.nugetapikey+' -SourceBranch '+githubSourceBranch+' - TargetBranch '+githubTargetBranch+' -XAMLAWSAccessID '+env.XAMLAWSAccessID+' -XAMLAWSAccessKey '+env.XAMLAWSAccessKey+' -apiServerIP '+env.apiServerIP+' -apiServerUserName '+env.apiServerUserName+' -revisionNumber '+env.revisionNumber+' -apiServerPassword '+env.apiServerPassword+' -nugetserverurl '+env.nugetserverurls
	        }
		else
	        {
		   bat 'powershell.exe -ExecutionPolicy ByPass -File build/build.ps1 -Script '+env.WORKSPACE+"/build/build.cake -Target publish -apiServerPort 8253 -apiSiteName essential-ui-kit-for-.net-maui -StudioVersion  "+env.studio_version+' -nugetapikey '+env.nugetapikey+' -SourceBranch '+githubSourceBranch+' -TargetBranch '+githubTargetBranch+' -XAMLAWSAccessID '+env.XAMLAWSAccessID+' -XAMLAWSAccessKey '+env.XAMLAWSAccessKey+' -apiServerIP '+env.apiServerIP+' -apiServerUserName '+env.apiServerUserName+' -revisionNumber '+env.revisionNumber+' -apiServerPassword '+env.apiServerPassword+' -nugetserverurl '+env.nugetserverurls
	        }
	    }
	}
	catch(Exception e) 
	{
	    echo "Exception in publish stage \r\n"+e
		currentBuild.result = 'FAILURE'
	}
}
	stage 'Delete Workspace'
	
	// Archiving artifacts when the folder was not empty
	
    def files = findFiles(glob: '**/cireports/**/*.*')      
    
    if(files.size() > 0) 		
    { 		
        archiveArtifacts artifacts: 'cireports/', excludes: null 		
    }
	
	   step([$class: 'WsCleanup']) 	
}}
}
