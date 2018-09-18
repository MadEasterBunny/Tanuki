using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Fungus;

public class HouseDoor : MonoBehaviour
{
    public ParticleSystem doorEffect;
    public Flowchart houseChart;

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
            houseChart.ExecuteBlock("Fade Block");
            //SceneManager.LoadScene("InsideTheHouse");
        }
    }

    public void DoorParticle()
    {
        doorEffect.Play();
    }
}
