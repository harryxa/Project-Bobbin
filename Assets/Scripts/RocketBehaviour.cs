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

    private Vector2 shipMoveVector;
    private float halfScreenWidth;

    void Start ()
    {
        halfScreenWidth = Screen.width / 2;
        rb = GetComponent<Rigidbody2D>();
        gravity = GetComponent<Gravity>();
    }
	
	void Update ()
    {
        shipMoveVector = (upDir.position - transform.position).normalized * thrust;
        speed = rb.velocity.magnitude;

        TurnShip();
        Vector2 shipPos = new Vector2(transform.position.x, transform.position.y);
        
        rb.AddForce(shipMoveVector);
        
        Debug.DrawLine(transform.position, shipMoveVector + shipPos, Color.red);

               
    }

    private void TurnShip()
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
            thrust = 2f;
        }

    }
}


