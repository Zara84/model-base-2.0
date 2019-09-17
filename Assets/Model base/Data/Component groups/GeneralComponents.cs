using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralComponents 
{
    public struct Efficiency : IComponent
    {
        public float efficiency;
    }

    public struct Cost : IComponent
    {
        public float cost;
    }

    public struct MaintenanceCost : IComponent
    {
        public float cost;
        public int period;
    }

    public struct Speed : IComponent
    {
        public float speed;
    }

    public struct Position : IComponent
    {
        public Vector3 position;
    }

    public struct ColorComponent : IComponent
    {
        public Color color;
    }

    public struct Profit : IComponent
    {
        public float profit;
    }

    public struct Income : IComponent
    {
        public float income;
    }

    public struct Price : IComponent
    {
        public float price;
    }

    public struct Owner : IComponent
    {
        public GameObject owner;
    }

    public struct Loan : IComponent
    {
        public float size;
        public float repaymentRate;
    }
}