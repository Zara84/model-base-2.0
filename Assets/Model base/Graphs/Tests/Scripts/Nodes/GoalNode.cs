using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[NodeTint(250f, 250f, 250f, .2f)]
public class GoalNode : CognitiveElementNode
{
    public NodeFilter filter;
    public Goal sourceGoal;
    public Type goalType;

    protected override void Init()
    {
        if (sourceGoal!=null)
        {
            if (filter != null)
            {
                filter.Dispose();
                filter = null;
                filter = populateFilter(filter, sourceGoal.filter, PortOrientation.In);
            }
        }
    }
}
