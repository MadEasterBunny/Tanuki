using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public GameObject leafButton;
	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public virtual void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            leafButton.SetActive(true);
            Destroy(this.gameObject);
        }
    }
}
