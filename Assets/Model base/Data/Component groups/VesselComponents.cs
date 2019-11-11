using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VesselComponents
{
    public class Capacity : IComponent
    {
        public float capacity = 0;
    }

    public class Catch : IComponent
    {
        public float size = 0;
        public string species = "";
    }

    public class Gear : IComponent
    {
        public string name = "";
        public string targetSpecies = "";
    }

    public class BaseQuota : IComponent
    {
        public float quota = 0;
        public string species = "";
    }

    public class Crew : IComponent
    {
        public int crewNumber = 0;
    }

    public class VesselObject : IComponent
    {
        public VesselBehavior vessel = new VesselBehavior();
    }

    public class Depth
    {
        public int depth = 0;
    }

}