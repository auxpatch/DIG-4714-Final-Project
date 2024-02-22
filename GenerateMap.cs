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
    public GameObject asteroidObstacle;
    private GameObject[] tiles;

    // Start is called before the first frame update
    void Start()
    {
        levelX = 5; //size of map on X-axis
        levelY = 5; //size of map on Y-axis
        obstacleDensity = "low"; //options off, low, medium, high
        levelType = "space";
        BuildBackground(levelType, levelX, levelY);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void BuildBackground(string levelType, int levelX, int levelY)
    {
        Quaternion target = Quaternion.Euler(-90, 0, 0);

        for (int i = 0 ; i < levelX; i++)
        {
            for(int j  = 0 ; j < levelY; j++)
            {
                GameObject tiles = GameObject.CreatePrimitive(PrimitiveType.Plane);
                tiles.transform.rotation = target;
                tiles.transform.position = new Vector3(i*10, j*10, 0);
            }
        }

        if (levelType == "space") //loop through 
        {
            //assign material to plane
        }
    }

    void SpawnObstacles(string obstacleDensity, int tileAmount)
    {
        int obstacleAmount = 0;
        switch(obstacleDensity)
        {
            case "off":
                break;
            case "low": //1 obstacle per 3 tiles
                obstacleAmount = ;

            case "medium": //1 obstacle per 2 tiles

            case "high": //1 obstacle per tile

            default:
                //shrug
            break;

        }
    }
}
