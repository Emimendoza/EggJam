using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeggBoiBehavoir : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    private float _distanceFromFloor = Mathf.Infinity;
    private float _distanceFromLeft = Mathf.Infinity;
    private float _distanceFromRight = Mathf.Infinity;
    public float speed = 10;
    public float jumpSpeed = 100;
    private Animator _animator;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = this.GetComponent<Rigidbody2D>();
        _animator = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        var input = Input.GetAxis("Horizontal");
        if (_distanceFromRight < 0.23 && input < 0)
        {
            _rigidbody2D.velocity = new Vector2(input * speed, _rigidbody2D.velocity.y);
        }
        if (_distanceFromLeft < 0.23 && input > 0)
        {
            _rigidbody2D.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, _rigidbody2D.velocity.y);
        }

        if (_distanceFromLeft > 0.23 && _distanceFromRight > 0.23)
        {
            _rigidbody2D.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, _rigidbody2D.velocity.y);
        }
        if (_distanceFromFloor<0.52 && Input.GetKeyDown(KeyCode.Space))
        {
            _rigidbody2D.AddForce(Vector2.up*jumpSpeed);
        }
    }

    private void FixedUpdate()
    {
        var pos = transform.position;
        var pos2 = new Vector3(pos.x, pos.y - 0.4f,pos.z);
        RaycastHit2D hitDown = Physics2D.Raycast(pos, Vector2.down,100,Physics2D.DefaultRaycastLayers,-Mathf.Infinity,99);
        RaycastHit2D hitLeft = Physics2D.Raycast(pos2, Vector2.left,100,Physics2D.DefaultRaycastLayers,-Mathf.Infinity,99);
        RaycastHit2D hitRight = Physics2D.Raycast(pos2, Vector2.right,100,Physics2D.DefaultRaycastLayers,-Mathf.Infinity,99);
        
        _distanceFromFloor = hitDown.collider != null ? Mathf.Abs(hitDown.point.y - pos.y) : Mathf.Infinity;
        _distanceFromLeft = hitLeft.collider != null ? Mathf.Abs(hitLeft.point.x - pos.x) : Mathf.Infinity;
        _distanceFromRight = hitRight.collider != null ? Mathf.Abs(hitRight.point.x - pos.x) : Mathf.Infinity;
        //Debug.Log("Distance (Left, Down, Right): ("+_distanceFromLeft+", "+_distanceFromFloor+", "+_distanceFromRight+")");
    }

    void OnTriggerEnter2D()
    {
      Debug.Log("Can detect triggers");
    }
}
