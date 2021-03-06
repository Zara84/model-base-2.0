﻿using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class MNorm : SerializedScriptableObject
{
    [BoxGroup("Filter")]
   // [AssetList]
    public List<mEntity> context = new List<mEntity>();
    [BoxGroup("Context")]
    [Button("Add new entity to context")]
    private void addInEntity()
    {
        addEntity(context, "Context");
    }
    void addEntity(List<mEntity> list, string folderName)
    {
        EntityAdder.AddEntity(list, folderName);
    }

    [AssetList]
    public MAction action;
    public bool active;

    public abstract bool isActive(BaseAgentBehavior owner);
    public abstract bool isDoable(BaseAgentBehavior owner);
    public abstract void execute(BaseAgentBehavior owner);

}
