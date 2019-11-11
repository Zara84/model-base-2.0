using Sirenix.OdinInspector;
using Sirenix.OdinInspector.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;
using XNodeEditor;

public class NodeMEntity : SerializedScriptableObject
{
  //  [HideInInspector]
    public Node parent;
    public NodeFilter parentFilter;

   // [ListDrawerSettings(OnEndListElementGUI = "DrawPort"), FoldoutGroup("TestGroup")]
    public List<NodeIComponent> components = new List<NodeIComponent>();

   // [HideInInspector]
    public NodePort port;
  //  [HideInInspector]
    public NodeMEntityStyle style = new NodeMEntityStyle();
    //public PropertyTree tree;
    public PortOrientation orientation;
    public NodeMEntity(mEntity entity, Node node, PortOrientation orientation)
    {
        this.orientation = orientation;

        parent = node;

        foreach(IComponent c in entity.components)
        {
            NodeIComponent comp = new NodeIComponent(c, node, orientation);
            comp.parentEntity = this;
            components.Add(comp);
        }

        // tree = PropertyTree.Create(components);
        if (orientation == PortOrientation.Out)
            port = node.AddDynamicOutput(typeof(bool));
        else
            port = node.AddDynamicInput(typeof(bool));

        style = new NodeMEntityStyle();
        style.unfolded = false;
        style.portVisible = false;
    }

    public void Dispose()
    {
        foreach(NodeIComponent c in components)
        {
            c.Dispose();
        }
    }

    
}
