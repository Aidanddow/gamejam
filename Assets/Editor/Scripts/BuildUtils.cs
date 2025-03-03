using UnityEditor;

public class BuildUtils
{
    [MenuItem("Build/Build WebGL")]
    public static void BuildWebGL()
    {
        BuildPipeline.BuildPlayer(
            new string[] { "Assets/_Game/Scenes/SampleScene.unity" },
            "Build/WebGL", 
            BuildTarget.WebGL, 
            BuildOptions.None
        );
    }
}