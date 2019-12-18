using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class mEntity : SerializedScriptableObject
{

    [OnValueChanged("Rename")]
  //  [GUIColor("SetColorName")]
    new public string name;

    public string ID;

   // [GUIColor("SetColorComponents")]
    public List<IComponent> components = new List<IComponent>();

    public void Rename()
    {
        string path = "";
        string newname = "";

        if(name == "")
        {
            newname = "New Entity";
            path = AssetDatabase.GetAssetPath(Selection.activeObject);
            AssetDatabase.RenameAsset(path, newname + ".asset");
        }
        else
        {
            newname = name;
            path = AssetDatabase.GetAssetPath(Selection.activeObject);
            AssetDatabase.RenameAsset(path, newname + ".asset");
        }

        
    }
    public Color SetColorName()
    {
        if (name == "")
            return Color.red;
        else
            return Color.green;
    }

    public Color SetColorComponents()
    {
        if (components.Count==0)
            return Color.red;
        else
            return Color.green;
    }
}
