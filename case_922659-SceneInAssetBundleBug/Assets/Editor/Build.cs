using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class Build
{
    [MenuItem("Build/Bundles")]
    private static void BuildBundles()
    {
        if (Directory.Exists(Application.streamingAssetsPath))
        {
            Directory.Delete(Application.streamingAssetsPath, true);
        }
        Directory.CreateDirectory(Application.streamingAssetsPath);
        BuildPipeline.BuildAssetBundles(Application.streamingAssetsPath, GetBundlesToBuild(), BuildAssetBundleOptions.StrictMode | BuildAssetBundleOptions.DeterministicAssetBundle, EditorUserBuildSettings.activeBuildTarget);
    }

    private static AssetBundleBuild[] GetBundlesToBuild()
    {
        return new AssetBundleBuild[]
        {
            new AssetBundleBuild()
            {
                assetBundleName = "test",
                assetNames = new string[]
                {
                    "Assets/Lightmapped.unity"
                }
            }
        };
    }

    [MenuItem("Build/App")]
    public static void DoBuild()
    {
        BuildBundles();
        BuildPipeline.BuildPlayer(new string[] {"Assets/Loader.unity"}, GetPathForPlatform(EditorUserBuildSettings.activeBuildTarget), EditorUserBuildSettings.activeBuildTarget, BuildOptions.None);
    }

    private static string GetPathForPlatform(BuildTarget target)
    {
        switch (target)
        {
            case BuildTarget.Android:
                return "Build/Test.apk";
            case BuildTarget.StandaloneWindows:
            case BuildTarget.StandaloneWindows64:
                return "Build/Test/Test.exe";
            case BuildTarget.StandaloneOSXIntel:
            case BuildTarget.StandaloneOSXIntel64:
            case BuildTarget.StandaloneOSXUniversal:
                return "Build/Test.app";
            default:
                return "Build/Test";
        }
    }
}