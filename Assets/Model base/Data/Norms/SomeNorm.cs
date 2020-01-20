using Sirenix.OdinInspector;
using Sirenix.OdinInspector.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SomeNorm: MNorm
{
    public override void execute(BaseAgentBehavior owner)
    {
        action.execute(owner);
    }

    public override bool isActive(BaseAgentBehavior owner)
    {
        // check if the context matches beliefs
        return false;
    }

    public override bool isDoable(BaseAgentBehavior owner)
    {
        return action.isDoable(owner);
    }

    
}
