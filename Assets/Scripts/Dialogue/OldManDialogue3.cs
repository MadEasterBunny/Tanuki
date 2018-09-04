using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class OldManDialogue3 : MonoBehaviour
{
    private GameObject enemy;

    public GameObject gameManager;

    public GameObject flowchart3Object;
    public Flowchart flowchart3;

    public int enteredDialogue;

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
        CanChangeForm();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            //canRead = false;
            flowchart3.ExecuteBlock("Dialogue3");
            //ReadDialogue();
            if (readDialogue)
            {
                enteredDialogue += 1;
                Invoke("StopScript", 10f);
                //flowchart3Object.SetActive(false);
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

    void CanChangeForm()
    {
        if (enteredDialogue >= 1)
        {
            gameManager.GetComponent<UseLeaf>().enabled = true;
        }
    }

    /*IEnumerator ReadDialogue()
    {
        yield return new WaitForSeconds(3f);
        readDialogue = true;
    }*/

    void StopScript()
    {
        flowchart3Object.SetActive(false);
        enemy.GetComponent<OldManDialogue3>().enabled = false;
    }
}
