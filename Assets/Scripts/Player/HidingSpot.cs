using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HidingSpot : MonoBehaviour
{
    GameObject player;
    GameObject player2;
    GameObject player3;
    // Use this for initialization
    void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        player2 = GameObject.FindGameObjectWithTag("Player2");
        player3 = GameObject.FindGameObjectWithTag("Player3");
    }
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject == player)
        {
            player.tag = "Invisible";
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject == player)
        {
            player.tag = "Player";
        }
        if (other.gameObject == player2)
        {
            player.tag = "Player2";
        }
        if (other.gameObject == player3)
        {
            player.tag = "Player3";
        }
    }
}
