using UnityEditor;

public class PackageCreator {
    [MenuItem("Tools/Create Package")]
    public static void CreatePackage() {
        var assets = new[] {
            "Assets/Scripts",
            "Assets/Scenes/TestBlock.unity"
        };
        AssetDatabase.ExportPackage(assets, "NeonDistrict_TestBlock_v0.1.unitypackage", ExportPackageOptions.Recurse);
        Debug.Log("Package saved to: " + System.IO.Directory.GetCurrentDirectory() + "/NeonDistrict_TestBlock_v0.1.unitypackage");
    }
}