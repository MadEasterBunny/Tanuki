using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class OldManDialogue2 : MonoBehaviour
{
    private GameObject enemy;
    public GameObject flowchart2Object;
    //public GameObject flowchart3Object;
    public Flowchart flowchart2;

    private GameObject player;

    private bool canRead;
    private bool readDialogue;
    // Use this for initialization
    void Start ()
    {
        enemy = EnemyManager.instance.enemy.gameObject;
        player = PlayerManager.instance.player.gameObject;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            //canRead = false;
            flowchart2.ExecuteBlock("Dialogue2");
            //ReadDialogue();
            if (readDialogue)
            {
                Invoke("ChangeScripts", 10f);
                //flowchart3Object.SetActive(true);
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
        enemy.GetComponent<OldManDialogue3>().enabled = true;
        flowchart2Object.SetActive(false);
        enemy.GetComponent<OldManDialogue2>().enabled = false;   
    }
}
