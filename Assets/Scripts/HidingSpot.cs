using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HidingSpot : MonoBehaviour
{
    GameObject player;
	// Use this for initialization
	void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            player.tag = "Hiding";
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Hiding")
        {
            player.tag = "Player";
        }
    }
}
