using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MakeAssets 
{
    [MenuItem("Assets/Create/Model Assets/SimStep")]
    public static void Create()
    {
        SimStep asset = ScriptableObject.CreateInstance<SimStep>();
        AssetDatabase.CreateAsset(asset, "Assets/Model base/Data/SimStep.asset");
        AssetDatabase.SaveAssets();
        EditorUtility.FocusProjectWindow();
        Selection.activeObject = asset;
    }

    [MenuItem("Assets/Create/Model Assets/Vessel Archetypes")]
    public static void CreateVesselArchetype()
    {
        VesselArchetypes asset = ScriptableObject.CreateInstance<VesselArchetypes>();
        AssetDatabase.CreateAsset(asset, "Assets/Model base/Data/Entities/VesselArchetypes.asset");
        AssetDatabase.SaveAssets();
        EditorUtility.FocusProjectWindow();
        Selection.activeObject = asset;
    }

    [MenuItem("Assets/Create/Model Assets/Actions/Test")]
    public static void CreateTestAction()
    {
        TestAction asset = ScriptableObject.CreateInstance<TestAction>();
        AssetDatabase.CreateAsset(asset, "Assets/Model base/Data/Actions/TestAction.asset");
        AssetDatabase.SaveAssets();
        EditorUtility.FocusProjectWindow();
        Selection.activeObject = asset;
    }

    [MenuItem("Assets/Create/Model Assets/Norms/Test")]
    public static void CreateTestNorm()
    {
        TestNorm asset = ScriptableObject.CreateInstance<TestNorm>();
        AssetDatabase.CreateAsset(asset, "Assets/Model base/Data/Norms/TestNorm.asset");
        AssetDatabase.SaveAssets();
        EditorUtility.FocusProjectWindow();
        Selection.activeObject = asset;
    }

    [MenuItem("Assets/Create/Model Assets/Goals/Test")]
    public static void CreateTestGoal()
    {
        TestGoal asset = ScriptableObject.CreateInstance<TestGoal>();
        AssetDatabase.CreateAsset(asset, "Assets/Model base/Data/Goals/TestGoal.asset");
        AssetDatabase.SaveAssets();
        EditorUtility.FocusProjectWindow();
        Selection.activeObject = asset;
    }
}
