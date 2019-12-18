using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using System.Linq;

public class VesselBehavior : MonoBehaviour
{
    public delegate void VesselReturnsEventHandler(object source, EventArgs args);
    public event VesselReturnsEventHandler VesselReturns;

    public Tilemap resourceMap;
    public Vector3Int homeTileIndex;
    public Vector3Int currentTileIndex;

    public float currentCatch = 0;
    public float monthlyCatch = 0;
    public float yearCatch = 0;
    public float speed;

    public float efficiency = 0.6f;
    public float capacity = 0;

    public float costs;
    public float fishPrice;
    public float currentProfit;
    public float currentGrossProfit;
    public float totalProfit;
    public float yearProfit;

    public SimProfile sim;
    public SimStep step;
    public Timer timer;

    public ResourceGrid grid;

    public float quota;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startBoat()
    {
        speed = 40f;
        homeTileIndex = resourceMap.WorldToCell(transform.position);
       // ResourceTile mostTile = grid.resourceTiles.ElementAt(UnityEngine.Random.Range(0, grid.resourceTiles.Count)).Value;
        fishPrice = step.avgFishPrice;
        capacity = step.maxBoatCapacity;
        
        costs = fishPrice * .1f * capacity * 15;
    }

        public void OnBeginDay(object source, EventArgs args)
    {
        Debug.Log("Going fishing...");
        // start fishing trip
        StartCoroutine("goFish");
    }

    public void OnEndDay(object source, EventArgs args)
    {
        Debug.Log("... and it's done.");
        StartCoroutine("goHome");
       // OnVesselReturns();
    }

    public virtual void OnVesselReturns()
    {
        if (VesselReturns != null)
        {
            VesselReturns(this, EventArgs.Empty);
        }
    }

    public IEnumerator goFish()
    {
        ResourceTile mostTile = grid.resourceTiles.ElementAt(UnityEngine.Random.Range(0, grid.resourceTiles.Count)).Value;

        int stagger = UnityEngine.Random.Range(5, 30);

        for(int i =0; i<stagger; i++)
        {
            yield return null;
        }

        yield return StartCoroutine(moveBoat(mostTile.tileIndex()));

        mostTile.isHere(gameObject);
        //fish(mostTile.tileIndex());
        mostTile.fishingHere(gameObject);

        yield return null;
        mostTile.getFish(gameObject);

        currentGrossProfit = currentCatch * fishPrice;
        currentProfit = currentCatch * fishPrice - costs;

        yield return null;
        mostTile.leftHere(gameObject);
    }

    IEnumerator moveBoat(Vector3Int tileIndex)
    {
        Vector3 targetPosition = new Vector3(tileIndex.x + UnityEngine.Random.Range(.1f, .9f), tileIndex.y + UnityEngine.Random.Range(.1f, .9f));

        while (Vector3.Distance(transform.position, targetPosition) > 0.1f)
        {
            float step = speed * Time.deltaTime; // calculate distance to move
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);
            yield return null;
        }
       // transform.position = new Vector3(tileIndex.x + UnityEngine.Random.Range(.1f, .9f), tileIndex.y + UnityEngine.Random.Range(.1f, .9f));

        //Debug.Log("Boat at: " + "[" + tileIndex.x + ", " + tileIndex.y + "] /" + "[" + transform.position.x + ", " + transform.position.y + "]" );
    }

    IEnumerator goHome()
    {

        //TODO better stagger - framerate and sim step dependent, none of this magic number crap. also speed. I think this generates some weird race conditions.
        int stagger = UnityEngine.Random.Range(5, 30);

        for (int i = 0; i < stagger; i++)
        {
            yield return null;
        }

        yield return StartCoroutine(moveBoat(homeTileIndex));
        OnVesselReturns();
    }
}
