﻿using Sirenix.OdinInspector;
using Sirenix.OdinInspector.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class NewNorm: Norm
{
    public override void execute(MonoBehaviour owner)
    {
        action.execute(owner);
    }

    public override bool isActive(MonoBehaviour owner)
    {
        // check if the context matches beliefs
        return false;
    }

    public override bool isDoable(MonoBehaviour owner)
    {
        return action.isDoable(owner);
    }

    
}
