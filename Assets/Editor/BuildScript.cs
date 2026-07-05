using UnityEngine;
using UnityEditor;

public class BuildScript {
    [MenuItem("Build/Windows")]
    public static void BuildWindows() => Build("NeonDistrict_Win");

    [MenuItem("Build/macOS")]
    public static void BuildMacOS() => Build("NeonDistrict_macOS", "macOSStandalone");

    [MenuItem("Build/Android")]
    public static void BuildAndroid() {
        EditorUserBuildSettings.androidBuildSystem = AndroidBuildSystem.Gradle;
        PlayerSettings.SetScriptingBackend(NativePlatform.Android, ScriptingImplementation.Mono);
        Build("NeonDistrict_Android.apk", "Android");
    }

    static void Build(string path, string target = "StandaloneWindows64") {
        var scenes = new[] { "Assets/Scenes/TestBlock.unity" };
        var options = BuildPlayerOptions.defaultBuildOptions;
        options.locationPathName = $"builds/{path}";
        options.target = BuildTarget.StandaloneWindows64;

        if (target == "Android") {
            options.target = BuildTarget.Android;
            options.options |= BuildOptions.IncludeTestScenes;
        } else if (target == "macOS") {
            options.target = BuildTarget.StandaloneOSX;
        }

        BuildPipeline.BuildPlayer(scenes, $"builds/{path}", options.target, options);
    }
}