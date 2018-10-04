using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
using UnityEngine.AI;

public class DialogueTriggerLeaf : MonoBehaviour
{
    public float dialogueWait;
    private GameObject player;

    public Flowchart flowchart;

    private GameObject enemy;

    private NavMeshAgent agent;

    //Camera switch
    public GameObject cam1;

    void Start()
    {
        player = PlayerManager.instance.player.gameObject;
        agent = player.GetComponent<NavMeshAgent>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            agent.isStopped = true;
            player.GetComponent<PlayerController>().enabled = false;
            StartCoroutine("LeafCutscene");
            Invoke("Dialogue", dialogueWait);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            OldManDialogue.foundLeaf = true;
            Invoke("OnDestroy", 1f);
        }
    }

    void Dialogue()
    {
        flowchart.ExecuteBlock("Leaf Block");
    }

    private void OnDestroy()
    {
        Destroy(this.gameObject);
    }

    IEnumerator LeafCutscene()
    {
        cam1.SetActive(false);
        yield return new WaitForSeconds(4f);
        cam1.SetActive(true);
    }

    public void ResumeMovement()
    {
        agent.isStopped = false;
    }
}
