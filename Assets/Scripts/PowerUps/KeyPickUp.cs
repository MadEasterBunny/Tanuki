using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPickUp : MonoBehaviour
{
    private GameObject player;
    public float keyRotationSpeed;
    public AudioClip keyPickup;
	
	void Start ()
    {
        player = PlayerManager.instance.player.gameObject;
	}
	
	
	void Update ()
    {
        this.transform.Rotate(Vector3.up * keyRotationSpeed * Time.deltaTime, Space.World);
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == player)
        {
            AudioSource.PlayClipAtPoint(keyPickup, player.transform.position, 0.5f);
            HouseDoor.hasKey = true;
            DoorEnterDialogue.doorDialogue = true;
            Destroy(this.gameObject);
        }
    }
}
