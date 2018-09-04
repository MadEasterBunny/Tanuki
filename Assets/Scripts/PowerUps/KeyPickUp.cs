using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPickUp : MonoBehaviour
{
    private GameObject player;
    public float keyRotationSpeed;
	
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
            HouseDoor.hasKey = true;
            Destroy(this.gameObject);
        }
    }
}
