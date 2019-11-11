using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralComponents 
{
    public class Efficiency : IComponent
    {
        public float efficiency = 0;
    }

    public class Cost : IComponent
    {
        public float cost = 0;
    }

    public class MaintenanceCost : IComponent
    {
        public float cost = 0;
        public int period = 0;
    }

    public class Speed : IComponent
    {
        public float speed = 0;
    }

    public class Position : IComponent
    {
        public Vector3 position = Vector3.zero;
    }

    public class ColorComponent : IComponent
    {
        public Color color = Color.black;
    }

    public class Profit : IComponent
    {
        public float profit = 0;
    }

    public class Income : IComponent
    {
        public float income = 0;
    }

    public class Price : IComponent
    {
        public float price = 0;
    }

    public class Owner : IComponent
    {
        public GameObject owner = new GameObject();
    }

    public class Loan : IComponent
    {
        public float size = 0;
        public float repaymentRate = 0;
    }

    public class Inventory : IComponent
    {
        public List<mEntity> list = new List<mEntity>();
    }
}