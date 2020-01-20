using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

    public T getComponent<T>() where T : IComponent
    {
        foreach (IComponent c in components)
        {
            if (c is T)
                return c as T;
        }
        return null;
    }

    public List<T> getComponents<T>() where T : IComponent //move to UTILS
    {
        List<T> list = new List<T>();
        foreach (IComponent c in components)
        {
            if (c is T)
                list.Add(c as T);
        }
        return list;
    }

    public mEntity copy()
    {
        mEntity copy = CreateInstance<mEntity>();
        copy.name = this.name + "*";
        copy.entityName = this.entityName + "*";

       // copy.components = new List<IComponent>(this.components);//this.components.ToList();
        foreach(IComponent c in components)
        {
            copy.components.Add(ECUtils.DeepCopyComponent(c));
        }
        return copy;
    }
}
