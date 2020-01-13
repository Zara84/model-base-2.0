using Community;
using GeneralComponents;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ScenarioManager : MonoBehaviour
{
    public mEntity scenarioProfile;
    public List<GameObject> communities = new List<GameObject>();
    public Tilemap resourceMap;
    public MarineResourceBehavior resource;
    // public ResourceGrid grid = new ResourceGrid();
    public int sizeX = 15;
    public int sizeY = 11;

    public Color maxColor;
    public Color minColor;

    #region Events
    public delegate void UpdateResourceEventHandler(object source, EventArgs args);
    public event UpdateResourceEventHandler UpdateResource;
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        initResource();
        initCommunities();
    }

    

    // Update is called once per frame
    void Update()
    {
        
    }
    #region Initializers

    private void initResource()
    {
        resource = resourceMap.GetComponent<MarineResourceBehavior>();
        UpdateResource += resource.OnUpdateResource;

        Debug.Log("Resource initialized");
    }

    void initCommunities()
    {
        List<Inventory> inventories = ECUtils.GetComponents<Inventory>(scenarioProfile);
        List<mEntity> comms = new List<mEntity>();

        foreach(Inventory inv in inventories)
        {
            if(inv.name.Contains("Communities"))
            {
                foreach(mEntity com in inv.list)
                {
                    comms.Add(com);
                    GameObject comGO = Instantiate(ECUtils.GetComponent<Prefab>(com).prefab);
                    ECUtils.GetComponent<SceneObject>(com).gameObject = comGO;
                   // sceneObject = comGO;
                    communities.Add(comGO);
                    comGO.transform.position = ECUtils.GetComponent<Position>(com).position;
                    comGO.GetComponent<SpriteRenderer>().color = ECUtils.GetComponent<ColorComponent>(com).color;

                    List<Inventory> comInv = ECUtils.GetComponents<Inventory>(com);
                    foreach(Inventory cinv in comInv)
                    {
                        if(cinv.name.Contains("Harbors"))
                        {
                            foreach(mEntity harborProfile in cinv.list)
                            {
                                initHarbor(harborProfile, comGO, com);
                            }
                        }

                        if (cinv.name.Contains("Workplaces"))
                        {
                            foreach (mEntity workProfile in cinv.list)
                            {
                                initWorkPlace(workProfile, comGO, com);
                            }
                        }
                    }
                }
            }
        }
    }

    void initHarbor(mEntity harborProfile, GameObject comGO, mEntity comProfile)
    {
        GameObject harborGO = Instantiate(ECUtils.GetComponent<Prefab>(harborProfile).prefab);
        harborGO.transform.position = ECUtils.GetComponent<Position>(harborProfile).position;
        harborGO.GetComponent<SpriteRenderer>().color = ECUtils.GetComponent<ColorComponent>(comProfile).color;
        ECUtils.GetComponent<SceneObject>(harborProfile).gameObject = harborGO;

        ECUtils.GetComponent<CommunityProfile>(harborProfile).profile = comProfile;
        ECUtils.GetComponent<CommunityObject>(harborProfile).community = comGO;

        harborGO.transform.parent = comGO.transform;

        //add this profile to the harbor behavior script
        harborGO.GetComponent<HarborScript>().profile = harborProfile;
    }

    void initWorkPlace(mEntity workProfile, GameObject comGO, mEntity comProfile)
    {
        GameObject workGO = Instantiate(ECUtils.GetComponent<Prefab>(workProfile).prefab);
        workGO.transform.position = ECUtils.GetComponent<Position>(workProfile).position;
        workGO.GetComponent<SpriteRenderer>().color = ECUtils.GetComponent<ColorComponent>(comProfile).color;
        ECUtils.GetComponent<SceneObject>(workProfile).gameObject = workGO;

        ECUtils.GetComponent<CommunityProfile>(workProfile).profile = comProfile;
        ECUtils.GetComponent<CommunityObject>(workProfile).community = comGO;

        workGO.transform.parent = comGO.transform;

        workGO.GetComponent<WorkPlaceScript>().profile = workProfile;
    }

    #endregion

    #region RaiseEvents

    public virtual void OnUpdateResource()
    {
        if (UpdateResource != null)
        {
            UpdateResource(this, EventArgs.Empty);
        }
    }
    #endregion
}
