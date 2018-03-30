using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCutScene : MonoBehaviour
{
    public GameObject player;

    private GameObject bossCam;

    private bool triggerCutscene = false;

	// Use this for initialization
	void Start ()
    {
        bossCam = transform.Find("Camera").gameObject;
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "Player" && coll.transform.parent != null)
        {
            triggerCutscene = true;
            coll.transform.parent.Find("FirstPersonCharacter").GetComponent<Camera>().enabled = false;
            bossCam.GetComponent<OrbitCamera>().beginOrbiting();
            bossCam.GetComponent<Camera>().enabled = true;

            player.GetComponent<CharacterController>().enabled = false;
        }
    }
}
