using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    //variables
    public Collider2D foodArea;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        RandomPosition();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log(collision);
        RandomPosition();
    }

    void RandomPosition()
    {
        float minX = foodArea.bounds.min.x;
        float maxX = foodArea.bounds.max.x;
        float minY = foodArea.bounds.min.y;
        float maxY = foodArea.bounds.max.y;
        Vector3 foodNewPosition = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), 0);
        transform.position = foodNewPosition;
    }
}
