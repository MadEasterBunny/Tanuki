using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
using UnityEngine.AI;

public class DialogueTriggerOldMan : MonoBehaviour
{
    public float dialogueWait;
    private GameObject player;
    public GameObject dog1;
    public GameObject dog2;

    public Flowchart flowchart;

    private GameObject enemy;

    private NavMeshAgent agent;

    //Camera switch
    public GameObject cam1;
    public GameObject cam3;

    void Start()
    {
        player = PlayerManager.instance.player.gameObject;
        enemy = EnemyManager.instance.enemy.gameObject;
        agent = player.GetComponent<NavMeshAgent>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            agent.isStopped = true;
            player.GetComponent<PlayerController>().enabled = false;
            enemy.GetComponent<EnemyView>().enabled = false;
            dog1.GetComponent<DogView>().enabled = false;
            dog2.GetComponent<DogView>().enabled = false;
            StartCoroutine("OldManCutscene");
            Invoke("Dialogue", dialogueWait);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            cam3.SetActive(false);
            enemy.GetComponent<EnemyView>().enabled = true;
            Invoke("OnDestroy", 1f);
        }
    }

    void Dialogue()
    {
        flowchart.ExecuteBlock("Spotted Old Man");
    }

    private void OnDestroy()
    {
        Destroy(this.gameObject);
    }

    IEnumerator OldManCutscene()
    {
        cam1.SetActive(false);
        yield return new WaitForSeconds(5f);
        cam1.SetActive(true);
    }

    public void ResumeMovement()
    {
       agent.isStopped = false;
    }
}
