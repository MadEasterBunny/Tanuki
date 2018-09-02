using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class OldManDialogue : MonoBehaviour
{
    public Flowchart flowchart;
    private GameObject player;
	
	void Start ()
    {
        player = PlayerManager.instance.player.gameObject;
	}
	
	
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == player)
        {
            flowchart.ExecuteBlock("Dialogue1");
        }
    }
}
