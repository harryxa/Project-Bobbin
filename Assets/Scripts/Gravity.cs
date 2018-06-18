using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{

    const float G = 667.4f;
    public Vector2 force;
    public Vector2 allGravityVectors;
    public Vector2 temp;
    
    //public static List<GameObject> Celestialbodys;

    public Rigidbody2D rb;
    Vector2 shipPos;

    private void Start()
    {
    }
    void FixedUpdate()
    {
        GameObject[] celestialBodys = GameObject.FindGameObjectsWithTag("CelestialBody");
        shipPos = new Vector2(transform.position.x, transform.position.y);
        temp = Vector2.zero;
        foreach (GameObject celestialBody in celestialBodys)
        {
            Attract(celestialBody);
            temp += force;
        }
        allGravityVectors = temp;
    }



    void Attract(GameObject objToAttract)
    {
        //Rigidbody2D rbToAttract = objToAttract.GetComponent<Rigidbody2D>();

        Vector2 direction = transform.position - objToAttract.transform.position;
        float distance = direction.magnitude;

        if (distance == 0f)
            return;

        float mass = 2f;
        float forceMagnitude = G * (rb.mass * mass) / Mathf.Pow(distance, 2);

        if (forceMagnitude > 20f)
        {
            forceMagnitude = 20f;
        }

        force = direction.normalized * forceMagnitude * -1f;
        rb.AddForce(force);
        Debug.DrawLine(transform.position, force + shipPos, Color.cyan);
        //if (forceMagnitude > 9f)
        //{
        //    Debug.Log(forceMagnitude);
        //}
           
    }

}