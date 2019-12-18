﻿using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Highgrade: MAction
{
    public override bool canBeAppliedTo(MonoBehaviour owner, mEntity entity)
    {
        //test if the action can be applied to a certain entity
        return false;
    }

    public override float distanceToGoal(MonoBehaviour owner, MGoal goal)
    {
        return goal.distance(owner, this);
    }

    public override void execute(MonoBehaviour owner)
    {
        //this is what the action does
    }

    public override List<mEntity> getTargets(MonoBehaviour owner)
    {
        //returns a list of entities belonging to the owner to which the action can be applied
        return new List<mEntity>();
    }

    public override bool isDoable(MonoBehaviour owner)
    {
        //check if action can be performed
        return false;
    }
}


