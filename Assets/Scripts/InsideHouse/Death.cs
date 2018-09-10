using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    private GameObject player;
    private Vector3 respawnPoint;
	
	void Start ()
    {
        player = PlayerManager.instance.player.gameObject;
        respawnPoint = player.transform.position;
	}
	

	void Update ()
    {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == player)
        {
            player.gameObject.SetActive(false);
            player.transform.position = respawnPoint;
            player.gameObject.SetActive(true);
        }
    }
}
