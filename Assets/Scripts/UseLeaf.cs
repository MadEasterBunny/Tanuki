using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class UseLeaf : MonoBehaviour
{
    Transform player;
    Transform enemy;
    public GameObject tanukiGFX;
    public GameObject otherGFX;
    public GameObject leafButton;

	// Use this for initialization
	void Start ()
    {
        player = PlayerManager.instance.player.transform;
        enemy = EnemyManager.instance.enemy.transform;
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void ChangeForms()
    {
        OtherForm();
        Invoke("Tanuki", 15);
    }

    public void Tanuki()
    {
        player.GetComponent<ParticleSystem>().Play();
        player.GetComponent<CharacterAnimator>().enabled = true;
        player.GetComponent<PlayerHealth>().enabled = true;
        enemy.GetComponent<EnemyView>().enabled = true;
        enemy.GetComponent<EnemyFlee>().enabled = false;
        player.tag = "Player";
        otherGFX.SetActive(false);
        tanukiGFX.SetActive(true);
    }

    public void OtherForm()
    {
        player.GetComponent<ParticleSystem>().Play();
        player.GetComponent<CharacterAnimator>().enabled = false;
        player.GetComponent<PlayerHealth>().enabled = false;
        enemy.GetComponent<EnemyView>().enabled = false;
        enemy.GetComponent<EnemyFlee>().enabled = true;
        player.tag = "ForestMonster";
        tanukiGFX.SetActive(false);
        otherGFX.SetActive(true);
        leafButton.SetActive(false);
    }
}
