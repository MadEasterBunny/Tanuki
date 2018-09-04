﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class OldManDialogue : MonoBehaviour
{
    public GameObject gameManager; 
    public Flowchart flowchart1;

    private GameObject player;

    public int enteredDialogue;

    void Start ()
    {
        player = PlayerManager.instance.player.gameObject;
	}
	
	
	void Update ()
    {
        CanChangeForm();
        enteredDialogue = flowchart1.GetIntegerVariable("AllTalks");
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == player)
        {
            flowchart1.ExecuteBlock("Dialogue1");
            flowchart1.SetBooleanVariable("FirstTalk", true);
        }
    }

    void CanChangeForm()
    {
        if (enteredDialogue >= 3)
        {
            gameManager.GetComponent<UseLeaf>().enabled = true;
        }
    }
}
