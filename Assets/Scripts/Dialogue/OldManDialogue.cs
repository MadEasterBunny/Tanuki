﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class OldManDialogue : MonoBehaviour
{
    private GameObject enemy;
    public GameObject flowchart1Object;
    //public GameObject flowchart2Object;

    public Flowchart flowchart1;

    private GameObject player;

    private bool canRead;
    private bool readDialogue;
    
    //private bool canChange;

    void Start ()
    {
        enemy = EnemyManager.instance.enemy.gameObject;
        player = PlayerManager.instance.player.gameObject;
	}
	
	
	void Update ()
    {
        
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == player)
        {
            //canRead = false;
            flowchart1.ExecuteBlock("Dialogue1");
            //ReadDialogue();
            readDialogue = true;
            if (readDialogue)
            {
                Invoke("ChangeScripts", 3f);
                //flowchart2Object.SetActive(true);
            }
            readDialogue = false;
        }
    }

    /*private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            canRead = true;
        }
    }*/

    /*IEnumerator ReadDialogue()
    {
        yield return new WaitForSeconds(3f);
        readDialogue = true;
    }*/

    void ChangeScripts()
    {
        enemy.GetComponent<OldManDialogue>().enabled = false;
        enemy.GetComponent<OldManDialogue2>().enabled = true;
    }
}
