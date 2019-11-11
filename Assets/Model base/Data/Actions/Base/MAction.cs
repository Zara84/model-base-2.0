using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEditor;


public abstract class MAction : SerializedScriptableObject
{
    //  [OdinSerialize]
    [BoxGroup("In filter")]
    public List<mEntity> inFilter = new List<mEntity>();
    [BoxGroup("In filter")]
    [Button("Add new entity to in filter")]
    private void addInEntity()
    {
        addEntity(inFilter, "InFilter");
    }

    [BoxGroup("Out filter")]
    public List<mEntity> outFilter = new List<mEntity>();
    [BoxGroup("Out Filter")]
    [Button("Add new entity to out filter")]
    private void addOutEntity()
    {
        addEntity(outFilter, "OutFilter");
    }

    void addEntity(List<mEntity> list, string folderName)
    {
        EntityAdder.AddEntity(list, folderName);
        
    }
    public abstract bool  isDoable(MonoBehaviour owner);

    public abstract float distanceToGoal(MonoBehaviour owner, Goal goal);

    public abstract void execute(MonoBehaviour owner);

    public abstract List<mEntity> getTargets(MonoBehaviour owner);

    public abstract bool canBeAppliedTo(MonoBehaviour owner, mEntity entity);


}
