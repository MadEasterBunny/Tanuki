using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public GameObject leafButton;
    public AudioClip pickupSound;

    private GameObject player;

	void Start ()
    {
        player = PlayerManager.instance.player.gameObject;
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public virtual void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            AudioSource.PlayClipAtPoint(pickupSound, player.transform.position, 0.8f);
            leafButton.SetActive(true);
            this.gameObject.SetActive(false);
            //Destroy(this.gameObject);
        }
    }
}
