using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightPlayer : MonoBehaviour
{
    public static int rightPlayerScore;

    float rectangleHeight;


    void Start()
    {
        rectangleHeight = transform.GetComponent<SpriteRenderer>().bounds.size.y/2;
    }

    void Update()
    {
        float m = Input.GetAxis("Arrow Vertical");

        Vector2 pos = transform.position;
        pos.y = Mathf.Clamp(pos.y, -5.2f + rectangleHeight, 5.2f - rectangleHeight) ;
        pos.y += m * Time.deltaTime * 15;
        transform.position = pos;
    }
}

