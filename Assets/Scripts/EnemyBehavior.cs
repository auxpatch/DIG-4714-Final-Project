using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject player;
    public float speed;
    private float distance;
    public string HPType;
    public string SpeedType;
    public AttackType attackType;
    public MovementType movementType;

    public enum AttackType //type of attack
    {
        Melee,
        Range,
        Polluter,
        Area
    }

    public enum MovementType //type of movement
    {
        Direct,
        Avoider,
        Rotator,
        Migrater
    }

    Dictionary<string, int> enemyHP = new Dictionary<string, int>() //hp dict
    {
        {"Boss", 100 },
        {"Heavy", 50 },
        {"Medium", 25 },
        {"light", 10 }
    };

    Dictionary<string, float> enemySpeed = new Dictionary<string, float>() //speed dict
    {
        {"Shambler", 5 },
        {"Rusher", 10 },
        {"Basic", 7 }
    };




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void enemyMovementBasic()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
        transform.rotation = Quaternion.Euler(Vector3.forward * angle);

    }
}
