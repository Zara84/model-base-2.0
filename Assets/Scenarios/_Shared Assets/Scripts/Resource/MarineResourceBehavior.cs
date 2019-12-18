using Sirenix.OdinInspector;
using Sirenix.Serialization;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;



public class MarineResourceBehavior : SerializedMonoBehaviour
{
    //[OdinSerialize]
    public ResourceGrid grid = new ResourceGrid();

    public Color maxColor;
    public Color minColor;

    public SimProfile sim;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void makeTiles(Tilemap resourceMap, int sizeX, int sizeY, SimProfile sim)
    {
        this.sim = sim;
        grid.addTiles(resourceMap, sizeX, sizeY, sim);
        colorResource();
    }

    public void setResourceTileColors()
    {
        ColorUtility.TryParseHtmlString("#0182FF", out maxColor);
        ColorUtility.TryParseHtmlString("#9A9A9A", out minColor);
    }

    public void colorResource()
    {
        for (int i = 0; i < grid.sizeX; i++)
        {
            for (int j = 0; j < grid.sizeY; j++)
            {
                if (grid.getTileAt(i, j) != null)
                {
                    Color color = Color.Lerp(minColor, maxColor, (grid.getTileAt(i, j).currentResource / sim.getMaxCarry()));
                    setTileColor(color, new Vector3Int(i, j, 0), gameObject.GetComponent<Tilemap>());

                    // Debug.Log(g.getTileAt(i, j).currentResource / g.maxCarry);
                }
            }
        }
    }

    void setTileColor(Color color, Vector3Int position, Tilemap tilemap)
    {
        tilemap.SetTileFlags(position, TileFlags.None);
        tilemap.SetColor(position, color);
    }

    public void OnUpdateResource(object source, EventArgs args)
    {
        foreach (KeyValuePair<Vector3Int, ResourceTile> tile in grid.resourceTiles)
        {
           // tile.Value.spawnResource();
        }
        colorResource();

        Debug.Log("Resource updated");
    }
}
