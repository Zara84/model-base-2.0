using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;
using XNodeEditor;

public class NodeFilter : SerializedScriptableObject
{
   // [HideInInspector]
    public Node parent;
 //   [ListDrawerSettings(OnEndListElementGUI = "DrawPort"), HideInInspector]
    public List<NodeMEntity> filter = new List<NodeMEntity>();
 //   [HideInInspector]
    public NodePort port;
//    [HideInInspector]
    public NodeFilterStyle style = new NodeFilterStyle();

    public PortOrientation orientation;

    public NodeFilter(List<mEntity> entities, Node node, PortOrientation orientation)
    {
        this.orientation = orientation;
        //Debug.Log("Adding entities to new filter");
        foreach(mEntity e in entities)
        {
            parent = node;
            NodeMEntity mE = new NodeMEntity(e, node, orientation);
            mE.parentFilter = this;
            filter.Add(mE);
        }

        if (orientation == PortOrientation.Out)
            port = node.AddDynamicOutput(typeof(bool));
        else
            port = node.AddDynamicInput(typeof(bool));

        style = new NodeFilterStyle();
        style.unfolded = false;
        style.portVisible = true;
    }

    public void Dispose()
    {
        foreach(NodeMEntity ent in filter)
        {
            ent.Dispose();
        }
    }

    public void DrawPort(int i)
    {
        NodeEditorGUILayout.AddPortField(filter[i].port);
    }
}