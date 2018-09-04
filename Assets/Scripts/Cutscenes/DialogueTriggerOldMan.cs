using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
using UnityEngine.AI;

public class DialogueTriggerOldMan : MonoBehaviour
{
    public float dialogueWait;
    private GameObject player;
    public NavMeshAgent agent;

    public Flowchart flowchart;

    private GameObject enemy;

    //Camera switch
    public GameObject cam1;

    void Start()
    {
        player = PlayerManager.instance.player.gameObject;
        enemy = EnemyManager.instance.enemy.gameObject;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            enemy.GetComponent<EnemyView>().enabled = false;
            StartCoroutine("OldManCutscene");
            Invoke("Dialogue", dialogueWait);
            agent.isStopped = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
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
        agent.isStopped = true;
        yield return new WaitForSeconds(5f);
        cam1.SetActive(true);
    }
}
