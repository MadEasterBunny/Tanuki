using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class UseLeaf : MonoBehaviour
{
    Transform player;
    public GameObject tanukiGFX;
    public GameObject otherGFX;
    public GameObject leafButton;

	// Use this for initialization
	void Start ()
    {
        player = PlayerManager.instance.player.transform;
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void ChangeForms()
    {
        OtherForm();
        Invoke("Tanuki", 5);
    }

    public void Tanuki()
    {
        player.GetComponent<ParticleSystem>().Play();
        player.gameObject.layer = 0;
        player.GetComponent<PlayerController>().enabled = true;
        player.GetComponent<PlayerMotor>().enabled = true;
        player.GetComponent<NavMeshAgent>().enabled = true;
        player.GetComponent<CharacterAnimator>().enabled = true;
        otherGFX.SetActive(false);
        tanukiGFX.SetActive(true);
    }

    public void OtherForm()
    {
        player.gameObject.layer = 10;
        player.GetComponent<ParticleSystem>().Play();
        player.GetComponent<PlayerController>().enabled = false;
        player.GetComponent<PlayerMotor>().enabled = false;
        player.GetComponent<NavMeshAgent>().enabled = false;
        player.GetComponent<CharacterAnimator>().enabled = false;
        tanukiGFX.SetActive(false);
        otherGFX.SetActive(true);
        leafButton.SetActive(false);
    }
}
