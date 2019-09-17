using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Sirenix.OdinInspector;
using Sirenix.Serialization;


public class Action : SerializedScriptableObject
{
    public int x = 2;

    [OdinSerialize]
    public List<mEntity> inFilter = new List<mEntity>();
    public List<mEntity> outFilter = new List<mEntity>();

    public virtual bool isDoable()
    {
        return true;
    }

    public virtual float distanceToGoal()
    {
        return 0;
    }

    public virtual void execute()
    {

    }
}
