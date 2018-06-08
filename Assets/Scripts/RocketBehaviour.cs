using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketBehaviour : MonoBehaviour {

    public float thrust;
    public float maxSpeed;

    public Rigidbody2D rb;
    public float midPoint;
    public Transform upDir;

    // Use this for initialization
    void Start () {
        midPoint = Screen.width / 2;
        rb = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetAxis("Fire1") > 0f)
        {
            if (Input.mousePosition.x < midPoint)
            {
                rb.transform.eulerAngles -= Vector3.forward * 2;
            }
            else if (Input.mousePosition.x >= midPoint)
            {
                rb.transform.eulerAngles += Vector3.forward * 2;
            }
        }

        //if (rb.velocity.magnitude < maxSpeed)
        //{
            rb.AddForce((upDir.position - transform.position).normalized * thrust);
        //}
    }
}


