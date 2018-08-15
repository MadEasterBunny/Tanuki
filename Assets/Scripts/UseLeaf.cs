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
    public Rigidbody attack;

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
        player.GetComponent<CharacterAnimator>().enabled = true;
        player.GetComponent<PlayerAttack>().enabled = false;
        otherGFX.SetActive(false);
        tanukiGFX.SetActive(true);
    }

    public void OtherForm()
    {
        player.GetComponent<ParticleSystem>().Play();
        player.GetComponent<CharacterAnimator>().enabled = false;
        player.GetComponent<PlayerAttack>().enabled = true;
        tanukiGFX.SetActive(false);
        otherGFX.SetActive(true);
        leafButton.SetActive(false);
    }
}
