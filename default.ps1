Properties {
	$build_dir = Split-Path $psake.build_script_file	
	$build_artifacts_dir = "$build_dir\BuildArtifacts\"
	$code_dir = Join-Path $build_dir "src"
	$library_dir = "$build_dir\lib"
	$release_dir = "$build_dir\Release"
}

FormatTaskName "[Task: {0}]"

Task Default -depends Build

Task Clean {
	Remove-Item -force -recurse $build_artifacts_dir -ErrorAction SilentlyContinue 
	Remove-Item -force -recurse $release_dir -ErrorAction SilentlyContinue 

	Exec { MsBuild "$code_dir\Facebook.sln" /t:Clean }
}

Task Init -Depends Clean {
	New-Item $release_dir -itemType directory
	New-Item $build_artifacts_dir -itemType directory
}

Task Build -Depends Init {
	Exec { MsBuild "$code_dir\Facebook.sln" /t:Build /p:Configuration=Release /p:OutDir=$build_artifacts_dir }
}