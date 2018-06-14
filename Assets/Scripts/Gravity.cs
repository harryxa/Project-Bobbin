using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{

    const float G = 667.4f;
    public Vector2 force;
    //public static List<Attractor> Attractors;

    public Rigidbody2D rb;

    void FixedUpdate()
    {
        GameObject[] celestialBodys = GameObject.FindGameObjectsWithTag("CelestialBody");
        foreach (GameObject celestialBody in celestialBodys)
        {
            Attract(celestialBody);
        }
        //foreach (Attractor attractor in Attractors)
        //{
        //    if (attractor != this)
        //        Attract(attractor);
        //}
    }

    //void OnEnable()
    //{
    //    if (Attractors == null)
    //        Attractors = new List<Attractor>();

    //    Attractors.Add(this);
    //}

    //void OnDisable()
    //{
    //    Attractors.Remove(this);
    //}

    void Attract(GameObject objToAttract)
    {
        //Rigidbody2D rbToAttract = objToAttract.GetComponent<Rigidbody2D>();

        Vector2 direction = transform.position - objToAttract.transform.position;
        float distance = direction.magnitude;

        if (distance == 0f)
            return;

        //5 is a hardcoded mass for the celestial body atm
        float forceMagnitude = G * (rb.mass * 1f) / Mathf.Pow(distance, 2);
        force = direction.normalized * forceMagnitude * -1f;

        //rb.AddForce(force);
    }

}