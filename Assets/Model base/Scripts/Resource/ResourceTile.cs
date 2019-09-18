using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

    public class ResourceTile
    {
        public float carryCapacity { get; set; }
        public float currentResource { get; set; }
        public float updatedResource { get; set; }
        public float growthRate { get; set; }
        public float addedResource { get; set; }

        public int x { get; set; }
        public int y { get; set; }

        public List<GameObject> boatsHere = new List<GameObject>();
        public List<GameObject> boatsFishing = new List<GameObject>();

        bool speak = false;

        /*public float extract(float resource)
        {
            //this needs a bit of adjustment so that it also depends on current fish density
            if (currentResource > resource)
                currentResource -= resource;
            else
                resource = 0;

            return resource;
        }*/

        public void isHere(GameObject boat)
        {
            boatsHere.Add(boat);
        }

        public void leftHere(GameObject boat)
        {
            boatsHere.Remove(boat);
        }

        public void fishingHere(GameObject boat)
        {
            boatsFishing.Add(boat);
        }

        public void getFish(GameObject vessel, float quota)
        {
            float fish = 0f;
            float totalFish = 0f;
            bool enough = false;

            for (int i = 0; i < boatsFishing.Count; i++)
            {
                BoatTileMovement boat = boatsFishing[i].GetComponent<BoatTileMovement>();

                float maxCatch = boat.efficiency * boat.capacity * 15 > quota ? boat.efficiency * boat.capacity * 15 : quota;
                totalFish += maxCatch;
            }

            enough = currentResource > totalFish ? true : false;

            BoatTileMovement vesselComp = vessel.GetComponent<BoatTileMovement>();
            if (enough)
            {
                float luck = Random.Range(currentResource / carryCapacity, ((currentResource / carryCapacity) + 1f) / 2);
                float maxCatch = vesselComp.efficiency * vesselComp.capacity * 15 * luck;
                float allowedCatch = quota;
                vesselComp.currentCatch = quota > maxCatch ? maxCatch : quota;
                currentResource -= vesselComp.currentCatch;
            }
            else
            {
                float maxCatch = currentResource / boatsFishing.Count;
                float allowedCatch = quota;
                vesselComp.currentCatch = maxCatch < quota ? maxCatch : quota;
                currentResource -= vesselComp.currentCatch;
            }

            boatsFishing.Remove(vessel);
        }

        public void getFish(GameObject vessel)
        {
            float fish = 0f;
            float totalFish = 0f;
            bool enough = false;

            for (int i = 0; i < boatsFishing.Count; i++)
            {
                VesselBehavior boat = boatsFishing[i].GetComponent<VesselBehavior>();
                totalFish += boat.efficiency * boat.capacity * 15;
            }

            enough = currentResource > totalFish ? true : false;

            VesselBehavior vesselComp = vessel.GetComponent<VesselBehavior>();
            if (enough)
            {
                float luck = Random.Range(currentResource / carryCapacity, ((currentResource / carryCapacity) + 1f) / 2);

                vesselComp.currentCatch = vesselComp.efficiency * vesselComp.capacity * 15 * luck;
                currentResource -= vesselComp.currentCatch;//vesselComp.efficiency * vesselComp.capacity * 15;
            }
            else
            {
                vesselComp.currentCatch = currentResource / boatsFishing.Count;
                currentResource -= currentResource / boatsFishing.Count;
            }

            boatsFishing.Remove(vessel);
        }

        public struct Neighbors
        {
            public ResourceTile N, S, E, W, NE, NW, SE, SW;
        }

        public Vector3Int tileIndex()
        {
            return new Vector3Int(x, y, 0);
        }

        public void spawnResource()
        {
            updatedResource = currentResource * (float)System.Math.Pow(System.Math.E, (growthRate * (1 - (currentResource / carryCapacity))));
            if (updatedResource > carryCapacity) updatedResource = carryCapacity;

            if (updatedResource < carryCapacity * .1f) updatedResource = 0;

            addedResource = (updatedResource - currentResource);

            currentResource = updatedResource;
        }

        public Neighbors neighbors;
    }
