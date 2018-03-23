using System.IO;
using UnityEditor;

public class CreateAssetBundles
{
    [MenuItem("Assets/Build AssetBundles/Win64")]
    static void BuildAllAssetBundlesWin64()
    {
        string assetBundleDirectory = "Assets/StreamingAssets/AssetBundles";
        if (!Directory.Exists(assetBundleDirectory))
        {
            Directory.CreateDirectory(assetBundleDirectory);
        }
        BuildPipeline.BuildAssetBundles(assetBundleDirectory, BuildAssetBundleOptions.None, BuildTarget.StandaloneWindows64);
    }

    [MenuItem("Assets/Build AssetBundles/Win32")]
    static void BuildAllAssetBundlesWin32()
    {
        string assetBundleDirectory = "Assets/StreamingAssets/AssetBundles";
        if (!Directory.Exists(assetBundleDirectory))
        {
            Directory.CreateDirectory(assetBundleDirectory);
        }
        BuildPipeline.BuildAssetBundles(assetBundleDirectory, BuildAssetBundleOptions.None, BuildTarget.StandaloneWindows);
    }


    [MenuItem("Assets/Build AssetBundles/Adroid")]
    static void BuildAllAssetBundlesAdroid()
    {
        string assetBundleDirectory = "Assets/StreamingAssets/AssetBundles";
        if (!Directory.Exists(assetBundleDirectory))
        {
            Directory.CreateDirectory(assetBundleDirectory);
        }
        BuildPipeline.BuildAssetBundles(assetBundleDirectory, BuildAssetBundleOptions.None, BuildTarget.Android);
    }
    [MenuItem("Assets/Build AssetBundles/IOS")]
    static void BuildAllAssetBundlesIOS()
    {
        string assetBundleDirectory = "Assets/StreamingAssets/AssetBundles";
        if (!Directory.Exists(assetBundleDirectory))
        {
            Directory.CreateDirectory(assetBundleDirectory);
        }
        BuildPipeline.BuildAssetBundles(assetBundleDirectory, BuildAssetBundleOptions.None, BuildTarget.iOS);
    }
}
