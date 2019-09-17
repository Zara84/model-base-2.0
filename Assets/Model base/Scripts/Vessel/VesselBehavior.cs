using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VesselBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnBeginDay(object source, EventArgs args)
    {
        Debug.Log("A new day...");
        // start fishing trip
    }

    public void OnEndDay(object source, EventArgs args)
    {
        Debug.Log("... and it's done.");
    }
}
