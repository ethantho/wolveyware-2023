using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerFieldwork : MonoBehaviour
{
    public float accel = 5.0f;
    public float maxSpeed = 5.0f;
    private Rigidbody2D rb;
    public float walkPace;

    private GameObject leftArm;
    private GameObject rightArm;
    private float walkStage = 0;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        leftArm = GameObject.Find("left");
        rightArm = GameObject.Find("right");
    }

    // Update is called once per frame
    void Update()
    {
        //left
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(new Vector2(-accel * Time.deltaTime, 0));
        }
        //right
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(new Vector2(accel * Time.deltaTime, 0));
        }
        //down
        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(new Vector2(0,-accel * Time.deltaTime));
        }
        //up
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(new Vector2(0, accel * Time.deltaTime));
        }

        if (rb.velocity.magnitude>maxSpeed)
        {
            rb.velocity = rb.velocity.normalized * maxSpeed;
        }
        
        transform.rotation = Quaternion.Euler(new Vector3 (0,0,(180/3.14f) * (float)Math.Atan2(rb.velocity.y,rb.velocity.x)));

        rightArm.transform.position = transform.position + transform.up *-0.45f + transform.right * (float)Math.Sin(walkStage) * 0.23f + transform.forward * 0.5f;
        leftArm.transform.position = transform.position + transform.up * 0.45f + transform.right * -(float)Math.Sin(walkStage) * 0.23f + transform.forward * 0.5f;
        walkStage += rb.velocity.magnitude*walkPace*Time.deltaTime;

    }
}
