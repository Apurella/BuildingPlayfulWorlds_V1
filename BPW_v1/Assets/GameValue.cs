using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameValue : MonoBehaviour {
    public Camera mainCamera, bossCam;
    // Use this for initialization
     void Start () {
        mainCamera.enabled = true;
        bossCam.enabled = false;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
