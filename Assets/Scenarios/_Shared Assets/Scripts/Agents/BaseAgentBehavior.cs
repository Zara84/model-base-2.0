using GeneralComponents;
using Helpers;
using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseAgentBehavior : SerializedMonoBehaviour
{
    //superclass holds data

    public mEntity profile;

    public mEntity communityProfile;

    public List<mEntity> entities = new List<mEntity>(); //beliefs

    public List<MAction> actions = new List<MAction>(); //intentions

    public List<MNorm> norms = new List<MNorm>();

    public List<MGoal> goals = new List<MGoal>(); //desires

    public List<GameObject> vessels = new List<GameObject>();

    public void init()
    {
        //populate lists from profile. Profile has archetypes. 
        //DO NOT USE ARCHETYPES. I will hurt you!
        //Make copies for use

        Debug.Log("Initializing agent");

        List<Inventory> inventories = profile.getComponents<Inventory>();

        List<MAction> acts = profile.getComponent<ActionListComponent>().list;
        List<MGoal> gls = profile.getComponent<GoalListComponent>().list;
        List<MNorm> nrms = profile.getComponent<NormListComponent>().list;

        List<mEntity> ents = new List<mEntity>();

        foreach (Inventory inv in inventories)
        {
            if (inv.name.Contains("Entities"))
            {
                ents = inv.list;
            }
        }

        entities.Clear();

        Debug.Log("Populating entities");

        foreach (mEntity entity in ents)
        {
            Debug.Log("Copying " + entity.entityName);
            mEntity e = ECUtils.DeepCopyEntity(entity);//entity.copy();
            entities.Add(e);
        }

        actions.Clear();
        Debug.Log("Populating actions");
        foreach (MAction action in actions)
        {
            //  MAction act = ECUtils.DeepCopy<MAction>(action);
            //   actions.Add(act);
        }

        goals.Clear();
        Debug.Log("Populating goals");
        foreach (MGoal goal in gls)
        {
            //goals.Add(ECUtils.DeepCopy<MGoal>(goal));
        }

        norms.Clear();
        Debug.Log("Populating norms");
        foreach (MNorm norm in nrms)
        {
            // norms.Add(ECUtils.DeepCopy<MNorm>(norm));
        }
    }
}
