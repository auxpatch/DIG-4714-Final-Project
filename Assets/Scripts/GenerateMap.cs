using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.UIElements;

public class GenerateMap : MonoBehaviour
{
    public string obstacleDensity;
    public string levelType;
    public int levelX;
    public int levelY;
    private int tileAmount;
    public GameObject[] obstacles;
    public GameObject asteroid;
    private GameObject[] tiles;
    private Transform parentTile;
    private Transform parentObstacle;
    public Material[] space;

    public Dictionary<string, Material> spaceMat = new Dictionary<string, Material>();  //contains materials for diffrent level types

    void Start()
    {
        parentTile = new GameObject("Tiles").transform; // Create empty parent GameObject for tiles
        parentObstacle = new GameObject("Obstacles").transform; // Create empty parent GameObject for obstacles

        spaceMat.Add("outerspace", space[0]);
        spaceMat.Add("deepspace", space[1]);

        levelX = 5; //size of map on X-axis
        levelY = 5; //size of map on Y-axis
        tileAmount = levelX * levelY;

        obstacleDensity = "medium"; //options: off, low, medium, high

        levelType = "deepspace";

        BuildBackground(levelType, levelX, levelY, parentTile);
        SpawnObstacles(obstacleDensity, tileAmount, levelX, levelY, parentObstacle);
    }

    void BuildBackground(string levelType, int levelX, int levelY, Transform parent)
    {
        Quaternion target = Quaternion.Euler(-90, 0, 0);

        for (int i = 0 ; i < levelX; i++)
        {
            for(int j  = 0 ; j < levelY; j++)
            {
                GameObject tiles = GameObject.CreatePrimitive(PrimitiveType.Plane);
                tiles.transform.rotation = target;
                tiles.transform.position = new Vector3(i*10, j*10, 0);
                tiles.GetComponent<Renderer>().material = spaceMat[levelType];
                tiles.transform.SetParent(parent, false);
            }
        }

    }

    void SpawnObstacles(string obstacleDensity, int tileAmount, int levelX, int levelY, Transform parent)
    //To make function more modular for different types of obstacles the "asteroid" prefab at start of instantiate would get
    //switched to take an input of prefab type maybe from a dictionary like how materials are done.
    //Repetition of code in switch case should also get switched to a function probably. just did it like this for testing

    //another option to make asteroids possibly space better would be to call something like this function within BuildBackground with a radius the size of an individual tile ??
    {
        int obstacleAmount = 0;

        switch(obstacleDensity)
        {
            case "off":
                break;
            case "low": //1 obstacle per 3 tiles
                obstacleAmount = tileAmount/3;
                obstacles = new GameObject[obstacleAmount];
                for(int i = 0; i < obstacleAmount; i++)
                {
                    obstacles[i] = Instantiate(asteroid, new Vector3(Random.Range(-5, (levelX-1)*10),Random.Range(-5, (levelY-1)*10),0), Quaternion.identity); //-5 is used for the lower bounds of random since that's the edge of where tiles are generated
                    obstacles[i].transform.SetParent(parent, false);
                }

                Debug.Log("in low");
                break;

            case "medium": //1 obstacle per 2 tiles
                obstacleAmount = tileAmount/2;
                obstacles = new GameObject[obstacleAmount];
                for(int i = 0; i < obstacleAmount; i++)
                {
                    obstacles[i] = Instantiate(asteroid, new Vector3(Random.Range(-5, (levelX-1)*10),Random.Range(-5, (levelY-1)*10),0), Quaternion.identity);
                    obstacles[i].transform.SetParent(parent, false);
                }
                Debug.Log("in medium");
                break;

            case "high": //1 obstacle per tile
                obstacleAmount = tileAmount;
                obstacles = new GameObject[obstacleAmount];
                for(int i = 0; i < obstacleAmount; i++)
                {
                    obstacles[i] = Instantiate(asteroid, new Vector3(Random.Range(-5, (levelX-1)*10),Random.Range(-5, (levelY-1)*10),0), Quaternion.identity);
                    obstacles[i].transform.SetParent(parent, false);
                }
                Debug.Log("in high");
                break;

            default:
                Debug.Log("shrug");
                break;
        }
    }
}
