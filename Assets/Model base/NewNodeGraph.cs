using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using XNode;
using XNodeEditor;

[CreateAssetMenu]
public class NewNodeGraph : NodeGraph
{
    public bool isDirty;
    NewNode dummy;

    public void OnEnable()
    {
        isDirty = true;
    }
    [ContextMenu("Talk")]
    public void talk()
    {
        Debug.Log("Meh");
    }

    [ContextMenu("Make node")]
    public void makeNode()
    {
        AddNode(typeof(NewNode));
    }

    [ContextMenu("Clear All")]
    public void clearAll()
    {
        while (nodes.Count > 0)
        {
            NewNode node = nodes[nodes.Count - 1] as NewNode;
            RemoveNode(node);
            UnityEngine.Object.DestroyImmediate(node, true);
            if (NodeEditorPreferences.GetSettings().autoSave) AssetDatabase.SaveAssets();
        }
    }

    [ContextMenu("Set Dirty")]
    public void setDirty()
    {
        EditorUtility.SetDirty(this);
        
    }
   
}