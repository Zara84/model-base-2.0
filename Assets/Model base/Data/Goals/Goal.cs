using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Goal : SerializedScriptableObject
{
    public List<mEntity> filter = new List<mEntity>();

    public abstract float distance(MonoBehaviour owner, Action action);
}
