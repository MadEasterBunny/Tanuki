using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class OldManDialogue : MonoBehaviour
{
    public GameObject gameManager;

    private GameObject enemy;
    public GameObject flowchart1Object;
    //public GameObject flowchart2Object;

    public Flowchart flowchart1;

    private GameObject player;

    public int enteredDialogue;

    private bool readDialogue;
    
    //private bool canChange;

    void Start ()
    {
        enemy = EnemyManager.instance.enemy.gameObject;
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
            //canRead = false;
            flowchart1.ExecuteBlock("Dialogue1");
            flowchart1.SetBooleanVariable("FirstTalk", true);
            readDialogue = true;
            if(readDialogue)
            {
                //flowchart1.SetBooleanVariable("FirstTalk", false);
                flowchart1.SetBooleanVariable("SecondTalk", true);
            }
            
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
