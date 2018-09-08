using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class OldManDialogue : MonoBehaviour
{
    public GameObject gameManager;
    public Collider dialogueTrigger;
    public Flowchart flowchart1;
    //public Flowchart flowchart2;

    private GameObject player;

    public int enteredDialogue;

    public static bool foundLeaf;

    void Start ()
    {
        player = PlayerManager.instance.player.gameObject;
        dialogueTrigger = this.GetComponent<SphereCollider>();
	}
	
	
	void Update ()
    {
        CanChangeForm();
        enteredDialogue = flowchart1.GetIntegerVariable("AllTalks");
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == player && foundLeaf)
        {
            flowchart1.ExecuteBlock("Dialogue1");
            flowchart1.SetBooleanVariable("FirstTalk", true);
        }
    }

    void CanChangeForm()
    {
        if (enteredDialogue >= 3)
        {
            flowchart1.ExecuteBlock("Tanuki");
            gameManager.GetComponent<UseLeaf>().enabled = true;
            dialogueTrigger.enabled = false;
            
        }
    }
}
