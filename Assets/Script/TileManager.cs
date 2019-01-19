using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public GameObject[] roadTiles;

    private Transform playerTransform;
    private float allTiles = 0.0f;
    private float tileLength = 20.6f;
    private float safe = 25.0f;
    public int tilesOnScreen = 15;
    
    private int random;
    private int index;
    private int roadTile;
    

    private List <GameObject> roadPrefabs = new List<GameObject>();
    

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag ("Player").transform;
        random = Random.Range(3,10);
        Debug.Log(random + "random");
        index = 0;

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
        index++;
        GameObject go;
        Debug.Log(index + "i");

        if (index == random)
         {
             index = 0;
            random = Random.Range(0, 15);
            Debug.Log(random + "random");
            roadTile++;
             if (roadTile > 3)
             {
                 roadTile = 0;
             }
          }

             switch (roadTile)
             {
                case 0:
                    go = Instantiate(roadTiles[0] as GameObject);
                    break;
                case 1:
                    Debug.Log(roadTile + "tile");
                    go = Instantiate(roadTiles[1] as GameObject);
                    roadTile++;
                    break;
                case 2:
                    go = Instantiate(roadTiles[2] as GameObject);
                    break;
                case 3:
                    go = Instantiate(roadTiles[3] as GameObject);
                    roadTile++;
                    break;
                default:
                    go = Instantiate(roadTiles[0] as GameObject);
                    break;

        }
         


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
