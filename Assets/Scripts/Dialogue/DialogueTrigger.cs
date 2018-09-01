using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public float dialogueWait;
    private GameObject player;

    //Camera switch
    public GameObject cam1;
    //public GameObject cam2;

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
            StartCoroutine("DogCutscene");
            Invoke("Dialogue", dialogueWait);   
            //Invoke("OnDestroy", 1f);
        }
    }

    private void OnTriggerExit(Collider other)
    {
         if(other.gameObject == player)
        {
            //TriggerDialogue();
            Invoke("OnDestroy", 1f);
        }
    }

    void Dialogue()
    {
        TriggerDialogue();
    }

    private void OnDestroy()
    {
        Destroy(this.gameObject);
    }

    IEnumerator DogCutscene()
    {
        cam1.SetActive(false);
        yield return new WaitForSeconds(5f);
        cam1.SetActive(true);
    }
}
