using GeneralComponents;
using Sirenix.Serialization;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class ECUtils
{
    public static T GetComponent<T>(mEntity item) where T : IComponent //move to UTILS
    {
        foreach (IComponent c in item.components)
        {
            if (c is T)
                return c as T;
        }
        return null;
    }

    public static List<T> GetComponents<T>(mEntity item) where T : IComponent //move to UTILS
    {
        List<T> list = new List<T>();
        foreach (IComponent c in item.components)
        {
            if (c is T)
                list.Add(c as T);
        }
        return list;
    }

    public static IComponent DeepCopyComponent(IComponent original)
    {
        
        if(original is Inventory)
        {
            Inventory inv = new Inventory();
            foreach(mEntity e in ((Inventory)original).list)
            {
                mEntity ent = DeepCopyEntity(e);
                inv.list.Add(ent);
            }
            return inv;
        }

        byte[] copy = SerializationUtility.SerializeValue<IComponent>(original, DataFormat.Binary, null);
        var data = SerializationUtility.DeserializeValue<IComponent>(copy, DataFormat.Binary);

        return (IComponent)data;
    }

    public static mEntity DeepCopyEntity(mEntity entity)
    {
        mEntity e = new mEntity();
        
        foreach(IComponent c in entity.components)
        {
            IComponent comp = new IComponent();
            comp = DeepCopyComponent(c);
            e.components.Add(comp);
        }

        e.name = ((string)entity.name.Clone()) + "*";
        e.entityName = ((string)entity.entityName.Clone()) + "*";
        return e;
    }

    public static T DeepCopyAction<T>(T action) where T : MAction
    {
        var act = new Object() as T;
        

        foreach(mEntity e in action.inFilter)
        {
            mEntity newE = new mEntity();
            newE = e.copy();
            act.inFilter.Add(newE);
        }
        foreach (mEntity e in action.outFilter)
        {
            mEntity newE = new mEntity();
            newE = e.copy();
            act.outFilter.Add(newE);
        }

        return act as T;
    }

    public static T DeepCopyGoal<T>(T goal) where T : MGoal
    {
        var g = new Object() as MGoal;

        return g as T;
    }

  /*  public static T DeepCopy<T>(T original)
    {
    //not a terrible idea, but doesn't copy references. and i need references.

        List<UnityEngine.Object> unityObjectReferences = new List<UnityEngine.Object>();
        List<UnityEngine.Object> objref = new List<UnityEngine.Object>();

        byte[] copy = SerializationUtility.SerializeValue<T>(original, DataFormat.Binary, out unityObjectReferences);
        Debug.Log("serialized data " + copy);

        var data = SerializationUtility.DeserializeValue<T>(copy, DataFormat.Binary, unityObjectReferences);

        return (T)data;
    }
    */
}
