using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private Transform target;
    private float distance;

    [SerializeField] private float speed;
    [SerializeField] private float hp;
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
        Rusher,
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
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        hp = enemyHP[HPType];
        speed = enemySpeed[SpeedType];
    }

    // Update is called once per frame
    void Update()
    {
        enemyMovement(movementType);
    }

    void enemyMovement(MovementType type)
    {
        if (type == MovementType.Direct) //tracks player movement and follows (slow, direct)
        {
            distance = Vector2.Distance(transform.position, target.position);
            Vector2 direction = target.position - transform.position;
            direction.Normalize();
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            transform.position = Vector2.MoveTowards(this.transform.position, target.position, (speed / 3) * Time.deltaTime);
            transform.rotation = Quaternion.Euler(Vector3.forward * angle);
        }

        else if (type == MovementType.Rusher) // tracks player movement and follows (fast, direct)
        {
            distance = Vector2.Distance(transform.position, target.position);
            Vector2 direction = target.position - transform.position;
            direction.Normalize();
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            transform.position = Vector2.MoveTowards(this.transform.position, target.position, (speed + 2) * Time.deltaTime);
            transform.rotation = Quaternion.Euler(Vector3.forward * angle);
        }

        else if (type == MovementType.Avoider) //tracks player movement and avoids (slow-ish)
        {
            distance = Vector2.Distance(transform.position, target.position);
            Vector2 direction = target.position - transform.position;
            direction.Normalize();
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            transform.position = Vector2.MoveTowards(this.transform.position, target.position, -1 * (speed / 2) * Time.deltaTime);
            transform.rotation = Quaternion.Euler(Vector3.forward * angle);
        }

        else if (type == MovementType.Rotator) //tracks player movement and rotates around player while closing in (rotate semi-fast, close in slow)
        {

        }

        else if (type == MovementType.Migrater) // ? not sure yet
        {

        }
    }


}
