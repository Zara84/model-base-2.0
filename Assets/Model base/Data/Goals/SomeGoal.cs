﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SomeGoal: MGoal
{
    public override float distance(MonoBehaviour owner, MAction action)
    {
        //calculate distance to goal after applying action

        return -1f;
    }
}
