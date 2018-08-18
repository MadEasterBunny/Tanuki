using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    private GameObject player;

	// Use this for initialization
	void Start ()
    {
        player = PlayerManager.instance.player.gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == player)
        {
            TriggerDialogue();
        }
    }
}
