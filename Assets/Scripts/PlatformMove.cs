using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMove : MonoBehaviour
{
    private Vector2 startPosition;

    public float speed = 3;

      void Start()
    {
        startPosition = transform.position;
        
    }

     void Update()
    {
      transform.position = new Vector2(startPosition.x+Mathf.Sin(Time.time*speed),transform.position.y);
    }
}
