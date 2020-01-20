using GeneralComponents;
using Helpers;
using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentBehavior : BaseAgentBehavior
{
    

    //reasoners here too.
    //also - data collection

    // Start is called before the first frame update
    void Start()
    {
        /*
        foreach(GameObject vessel in vessels)
        {
            vessel.GetComponent<VesselBehavior>().VesselReturns += OnVesselReturn;
        }

        foreach (MAction a in actions)
        {
            a.execute(this);
            
        }
        */
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void updateBeliefs()
    {
        //update internal state
    }

    void setGoal()
    {
        // pick a goal
    }

    void deliberate()
    {
        //
        //pick action/norm
    }

    void execute()
    {
        //execute action/norm
    }

    public void OnVesselReturn(object source, System.EventArgs args)
    {
        Debug.Log("Vessel returns");
    }

    
}
