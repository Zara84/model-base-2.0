using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Sirenix.OdinInspector;
using Sirenix.Serialization;


public abstract class Action : SerializedScriptableObject
{
    [OdinSerialize]
    public List<mEntity> inFilter = new List<mEntity>();
    public List<mEntity> outFilter = new List<mEntity>();

    public abstract bool isDoable(MonoBehaviour owner);

    public abstract float distanceToGoal(MonoBehaviour owner, Goal goal);

    public abstract void execute(MonoBehaviour owner);

    public abstract List<mEntity> getTargets(MonoBehaviour owner);

    public abstract bool canBeAppliedTo(MonoBehaviour owner, mEntity entity);
}
