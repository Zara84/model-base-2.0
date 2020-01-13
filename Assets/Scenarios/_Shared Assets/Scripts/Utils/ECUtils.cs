using System.Collections;
using System.Collections.Generic;
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
}
