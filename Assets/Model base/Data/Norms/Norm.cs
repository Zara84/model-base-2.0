using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Norm : SerializedScriptableObject
{
    public List<mEntity> context = new List<mEntity>();
    public Action action;
    public bool active;

    public abstract bool isActive();
    public abstract void execute();
}
