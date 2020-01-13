using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class mEntity : SerializedScriptableObject
{
    [Delayed]
    [Required]
    [OnValueChanged("Rename")]
  //  [GUIColor("SetColorName")]
    public string entityName;

    public string ID;

   // [GUIColor("SetColorComponents")]
    public List<IComponent> components = new List<IComponent>();

    public void Rename()
    {
        string path = "";
        string newname = "";

        if(entityName == "")
        {
            newname = "New Entity";
            name = "New Entity";
            path = AssetDatabase.GetAssetPath(Selection.activeObject);
            AssetDatabase.RenameAsset(path, newname + ".asset");
        }
        else
        {
            newname = entityName;
            name = entityName;
            path = AssetDatabase.GetAssetPath(Selection.activeObject);
            AssetDatabase.RenameAsset(path, newname + ".asset");
        }

        AssetDatabase.SaveAssets();
    }

    public bool Contains(mEntity e)
    {
        bool contains = true;

        foreach(IComponent c in e.components)
        {
            if (!components.Contains(c))
                contains = false;
        }

        return contains;
    }
    public Color SetColorName()
    {
        if (entityName == "")
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
