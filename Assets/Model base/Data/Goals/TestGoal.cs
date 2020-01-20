using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestGoal : MGoal
{
    public override float distance(BaseAgentBehavior owner, MAction action)
    {
        //calculate distance to goal after applying action

        return -1f;
    }
}
