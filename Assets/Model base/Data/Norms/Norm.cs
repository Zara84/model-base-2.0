using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Norm : SerializedScriptableObject
{
    public List<mEntity> context = new List<mEntity>();
    public Action action;
    public bool active;

    public abstract bool isActive(MonoBehaviour owner);
    public abstract bool isDoable(MonoBehaviour owner);
    public abstract void execute(MonoBehaviour owner);
}
