using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public GameObject roadTile;
    private Transform playerTransform;
    private float allTiles = 0.0f;
    private float tileLength = 20.6f;
    private float safe = 25.0f;
    public int tilesOnScreen = 15;
    

    private List <GameObject> roadPrefabs = new List<GameObject>();


    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag ("Player").transform;

        for (int i = 0; i < tilesOnScreen; i++ )
        {
            createTile();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerTransform.position.z - safe > (allTiles - tilesOnScreen * tileLength))
        {
            createTile();
            deleteTile();
        }
    }

    //create & delete roat tiles
    private void createTile()
    {
        GameObject go;
        go = Instantiate(roadTile as GameObject);
        go.transform.SetParent(transform);
        go.transform.position = Vector3.forward * allTiles;
        allTiles += tileLength;
        roadPrefabs.Add(go);
    }

    private void deleteTile()
    {
        Destroy(roadPrefabs[0]);
        roadPrefabs.RemoveAt(0);
    }
    
}
