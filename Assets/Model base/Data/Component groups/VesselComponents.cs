using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VesselComponents
{
    public struct Capacity : IComponent
    {
        public float capacity;
    }

    public struct Catch : IComponent
    {
        public float size;
        public string species;
    }

    public struct Gear : IComponent
    {
        public string name;
        public string targetSpecies;
    }

    public struct BaseQuota : IComponent
    {
        public float quota;
        public string species;
    }

    public struct Crew : IComponent
    {
        public int crewNumber;
    }

    public struct VesselObject : IComponent
    {
        public VesselBehavior vessel;
    }

}