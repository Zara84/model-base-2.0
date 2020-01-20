using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class MGoal : SerializedScriptableObject
{
    [BoxGroup("Filter")]
    public List<mEntity> filter = new List<mEntity>();
    [BoxGroup("Filter")]
    [Button("Add new entity to filter")]
    private void addInEntity()
    {
        addEntity(filter, "Filter");
    }
    void addEntity(List<mEntity> list, string folderName)
    {
        EntityAdder.AddEntity(list, folderName);
    }
    public abstract float distance(BaseAgentBehavior owner, MAction action);
}
