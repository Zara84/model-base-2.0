using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ResourceComponents
{
    public class SpawnRate : IComponent
    {
       public int spawnPeriod;
    }
    
    public class Species : IComponent
    {
        public string name;
    }

    public class ByCatch : IComponent
    {
        public float size;
    }
}
