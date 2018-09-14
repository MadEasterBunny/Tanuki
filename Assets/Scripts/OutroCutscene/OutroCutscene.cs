using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OutroCutscene : MonoBehaviour
{
    public Text resultsNumbersText;
   
	void Start ()
    {
        resultsNumbersText.text = PlayerPrefs.GetInt("Score").ToString() + "/42";
	}
	
    public void EndGame()
    {
        SceneManager.LoadScene(0);
    }
}
