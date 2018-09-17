using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    private GameObject player;
    private Vector3 respawnPoint;

    public Camera mainCamera;
    public ParticleSystem deathEffect;
    private Vector3 cameraRespawnPoint;

    public AudioSource audioSource;
    public AudioClip deathSound;
	
	void Start ()
    {
        player = PlayerManager.instance.player.gameObject;
        respawnPoint = player.transform.position;
        cameraRespawnPoint = mainCamera.transform.position;
	}
	

	void Update ()
    {
        deathEffect.transform.position = player.transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == player)
        {
            StartCoroutine("Respawn");
        }
    }

    IEnumerator Respawn()
    {
        player.gameObject.SetActive(false);
        deathEffect.Play();
        audioSource.PlayOneShot(deathSound, 0.7f);
        yield return new WaitForSeconds(3f);
        player.transform.position = respawnPoint;
        mainCamera.transform.position = cameraRespawnPoint;
        player.gameObject.SetActive(true);
    }
}
