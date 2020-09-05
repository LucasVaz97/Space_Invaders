using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spaceScript : MonoBehaviour
{

    public float currentVelocity;

    float y_position;

    private void Start()
    {
        y_position = transform.position.y;

    }

    void Update()
    {
        y_position -= currentVelocity * Time.deltaTime;
        transform.position = new Vector3(transform.position.x, y_position, 0f);
        if (transform.position.y <= -21.1)
        {
            transform.position =new Vector2(transform.position.x, 42.5f);
            y_position = transform.position.y;
        }
    }


}
