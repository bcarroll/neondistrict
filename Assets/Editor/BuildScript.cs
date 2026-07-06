using UnityEngine;
using UnityEditor;

public class BuildScript {
    [MenuItem("Build/Windows")]
    public static void BuildWindows() => Build("NeonDistrict_Win", BuildTarget.StandaloneWindows64);

    [MenuItem("Build/macOS")]
    public static void BuildMacOS() => Build("NeonDistrict_macOS", BuildTarget.StandaloneOSX);

    [MenuItem("Build/Android")]
    public static void BuildAndroid() => Build("NeonDistrict_Android.apk", BuildTarget.Android);

    static void Build(string path, BuildTarget target) {
        var scenes = new[] { "Assets/Scenes/TestBlock.unity" };
        
        EditorUserBuildSettings.development = true;
        EditorUserBuildSettings.allowDebugging = true;
        
        var options = new BuildPlayerOptions();
        options.scenes = scenes;
        options.locationPathName = $"builds/{path}";
        options.target = target;

        var result = BuildPipeline.BuildPlayer(options);
        Debug.Log($"Build completed: {result.summary.outputPath}");
    }
}