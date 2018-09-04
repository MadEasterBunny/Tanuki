using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
using UnityEngine.AI;

public class DialogueTriggerDog : MonoBehaviour
{
    public float dialogueWait;
    private GameObject player;
    //public NavMeshAgent agent;

    public Flowchart flowchart;

    //Camera switch
    public GameObject cam1;
    public GameObject cam2;

    void Start()
    {
        player = PlayerManager.instance.player.gameObject;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            player.GetComponent<NavMeshAgent>().isStopped = true;
            StartCoroutine("DogCutscene");
            Invoke("Dialogue", dialogueWait);
            player.GetComponent<NavMeshAgent>().isStopped = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            Invoke("OnDestroy", 1f);
        }
    }

    void Dialogue()
    {
        flowchart.ExecuteBlock("Dog Cutscene");
    }

    private void OnDestroy()
    {
        cam2.SetActive(false);
        Destroy(this.gameObject);
    }

    IEnumerator DogCutscene()
    {
        cam1.SetActive(false);
        yield return new WaitForSeconds(5f);
        cam1.SetActive(true);
    }
}
