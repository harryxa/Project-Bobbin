using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketBehaviour : MonoBehaviour
{
    private Rigidbody2D rb;
    private Gravity gravity;
    public Transform upDir;

    public float thrust;
    public float maxSpeed;
    public float speed;

    private Vector2 shipAccelerationVector;
    private float halfScreenWidth;

    void Start ()
    {
        halfScreenWidth = Screen.width / 2;
        rb = GetComponent<Rigidbody2D>();
        gravity = GetComponent<Gravity>();
    }
	
	void Update ()
    {
        shipAccelerationVector = (upDir.position - transform.position).normalized * thrust;
        speed = rb.velocity.magnitude;

        ShipControls();
        Vector2 shipPos = new Vector2(transform.position.x, transform.position.y);
        
        rb.AddForce(shipAccelerationVector);
        
        Debug.DrawLine(transform.position, shipAccelerationVector + shipPos, Color.red);
        Debug.DrawLine(transform.position, gravity.allGravityVectors + shipPos, Color.blue);
        Debug.DrawLine(transform.position, rb.velocity + shipPos, Color.green);

        LimitSpeed();



    }

    private void ShipControls()
    {
        if (Input.GetAxis("Fire1") > 0f)
        {
            if (Input.mousePosition.x < halfScreenWidth)
            {
                rb.transform.eulerAngles -= Vector3.forward * 2;
            }
            else if (Input.mousePosition.x >= halfScreenWidth)
            {
                rb.transform.eulerAngles += Vector3.forward * 2;
            }
        }

        if (Input.GetKey(KeyCode.A))
        {
            rb.transform.eulerAngles -= Vector3.forward * 5;
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.transform.eulerAngles += Vector3.forward * 5;
        }
        if (Input.GetKey(KeyCode.Space))
        {
            thrust += 1 * Time.deltaTime;
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            thrust = 5f;
        }

    }

    public void LimitSpeed()
    {
        if (speed >= maxSpeed)
        {
            rb.velocity = rb.velocity.normalized * maxSpeed;
        }
    }
}


