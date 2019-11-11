using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

public abstract class CognitiveElementNode : Node
{
    public NodeFilter populateFilter(NodeFilter filter, List<mEntity> source, PortOrientation orientation)
    {
        filter = new NodeFilter(source, this, orientation);
        return filter;
    }
}
