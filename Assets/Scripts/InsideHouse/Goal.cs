using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
    private GameObject player;
    public Flowchart flowchart1;
    public GameObject playerChild;

    public static bool playerStop;
	void Start ()
    {
        player = PlayerManager.instance.player.gameObject;
	}
	
	
	void Update ()
    {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == player)
        {
            playerChild.GetComponent<Animator>().enabled = false;
            player.GetComponent<SideScrollerPlayerController>().enabled = false;
            flowchart1.ExecuteBlock("ToOutro");
            //Fix this below
            if (flowchart1.GetBooleanVariable("FadeDone"))
            {
                SceneManager.LoadScene(4);
            }
        }
    }
}
