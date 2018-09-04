using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HouseDoor : MonoBehaviour
{
    private GameObject player;

    public static bool hasKey;
	
	void Start ()
    {
        player = PlayerManager.instance.player.gameObject;
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == player && hasKey)
        {
            SceneManager.LoadScene("InsideTheHouse");
        }
    }
}
