﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestGoal : Goal
{
    public override float distance(MonoBehaviour owner, Action action)
    {
        //calculate distance to goal after applying action

        return -1f;
    }
}
