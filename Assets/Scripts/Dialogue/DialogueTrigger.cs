using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    private GameObject player;

	void Start ()
    {
        player = PlayerManager.instance.player.gameObject;
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
            Invoke("OnDestroy", 1f);
        }
    }

    private void OnDestroy()
    {
        Destroy(this.gameObject);
    }
}
