﻿using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

[Serializable]

public struct CarryCapacity : IComponentData
{
    public float carryCapacity;
}
