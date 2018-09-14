using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectableGoods : MonoBehaviour
{
    public GameObject collectablesCounter;
    public Text goodsText;
    public static int stolenGoods;

    //private AudioSource pickUpSound;
    public AudioClip pickupSoundEffect;

    void Start ()
    {
        //pickUpSound = GetComponent<AudioSource>();
        if(goodsText != null)
        {
            goodsText.text = "盗んだ物の数：" + stolenGoods.ToString();
        }

        PlayerPrefs.GetInt("Score", 0);
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "Player")
        {
            AudioSource.PlayClipAtPoint(pickupSoundEffect, transform.position, 0.5f);
            stolenGoods++;
            goodsText.text = "盗んだ物の数：" + stolenGoods.ToString();
            PlayerPrefs.SetInt("Score", stolenGoods);
            if(stolenGoods > PlayerPrefs.GetInt("Score", 0))
            {
                PlayerPrefs.SetInt("Score", stolenGoods);
            }
            Destroy(this.gameObject);
        }
    }
}
