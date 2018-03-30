using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitCamera : MonoBehaviour
{
    private bool isOrbit = false;
    private float time = 0;

    public float speed = 2, timer = 2;

    public GameObject boss, player;
    public Camera mainCamera;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    // Made possible with Can-torial :D
    {
        if (isOrbit)
        {
            time += Time.deltaTime;
            transform.RotateAround(boss.transform.position, Vector3.up, Time.deltaTime * speed);

            if (time > timer) stopOrbiting();
        }
	}

    public void beginOrbiting()
    {
        isOrbit = true;
    }

    public void stopOrbiting()
    {
        isOrbit = false;
        GetComponent<Camera>().enabled = false;
        player.GetComponent<CharacterController>().enabled = true;
        player.transform.position = new Vector3(15, 1, -16);
        player.transform.LookAt(boss.transform);
        player.transform.GetChild(0).rotation = Quaternion.Euler(0, 0, 0);
        mainCamera.enabled = true;
    }
}
