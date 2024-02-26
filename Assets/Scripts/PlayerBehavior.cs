using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    public float MoveSpeed = 8f;
    

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        LookAtMouse();
        PlayerMovement();
    }

    void LookAtMouse()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        Vector3 direction = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);

        transform.up = direction;
    }

    void PlayerMovement()
    {
        Vector3 pos = transform.position;

        if (Input.GetKey("w"))
        {
            pos.y += MoveSpeed * Time.deltaTime;
        }

        if (Input.GetKey("s"))
        {
            pos.y -= MoveSpeed * Time.deltaTime;
        }

        if (Input.GetKey("d"))
        {
            pos.x += MoveSpeed * Time.deltaTime;
        }

        if (Input.GetKey("a"))
        {
            pos.x -= MoveSpeed * Time.deltaTime;
        }

        transform.position = pos;
    }
}
