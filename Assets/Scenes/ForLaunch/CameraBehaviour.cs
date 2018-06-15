using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour {

    private float startSize = 1.0f;
    private float endSize = 5.0f;

    static float t = 0.0f;

    private Camera m_cam;
    private bool launched;

	// Use this for initialization
	void Start () {
        m_cam = GetComponent<Camera>();
        launched = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetAxis("Fire1") > 0f)
        {
            launched = true;
        }

        if (launched)
        {
            Begin();
        }
	}

    void Begin()
    {
        t += 0.5f * Time.deltaTime;
        m_cam.orthographicSize = Mathf.Lerp(startSize, endSize, t);
    }

}
