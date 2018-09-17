using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectableGoods : MonoBehaviour
{
    public GameObject collectablesCounter;
    public Text goodsText;
    public static int stolenGoods;
    public AudioSource audioSource;
    public AudioClip pickupSoundEffect;

    void Start ()
    {
        if(goodsText != null)
        {
            goodsText.text = "盗んだ物の数：" + stolenGoods.ToString();
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "Player")
        {
            audioSource.PlayOneShot(pickupSoundEffect, 1f);
            stolenGoods++;
            goodsText.text = "盗んだ物の数：" + stolenGoods.ToString();
            PlayerPrefs.SetInt("Score", stolenGoods);
            Destroy(this.gameObject);
        }
    }
}
