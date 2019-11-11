using Sirenix.OdinInspector;
using Sirenix.OdinInspector.Editor;
using UnityEngine;
using XNode;
using static XNode.Node;

public class NodeIComponent : SerializedScriptableObject
{
   // [FoldoutGroup("TestGroup")]
    public IComponent component;
  //  [HideInInspector]
    public Node parent;

    public NodeMEntity parentEntity;

    public PropertyTree tree;
  //  [HideInInspector]
    public NodePort port;
 //   [HideInInspector]
    public NodeIComponentStyle style = new NodeIComponentStyle();

    public NodeIComponent(IComponent c, Node node, PortOrientation orientation)
    {
        parent = node;
        component = c;
        //  tree = PropertyTree.Create(component);

        if (orientation == PortOrientation.Out)
            port = node.AddDynamicOutput(typeof(bool));
        else
            port = node.AddDynamicInput(typeof(bool));

        style = new NodeIComponentStyle();
        style.unfolded = false;
        style.portVisible = false;

        tree = PropertyTree.Create(component);
    }

    public void Dispose()
    {
        //if (tree != null)
           // tree.Dispose();
    }
}
