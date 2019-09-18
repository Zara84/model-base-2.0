using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mEntity : SerializedScriptableObject
{
    public string ID;
    public string name;
    public List<IComponent> components = new List<IComponent>();

}
