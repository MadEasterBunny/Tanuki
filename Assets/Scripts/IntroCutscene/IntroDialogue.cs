using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroDialogue : MonoBehaviour
{
    public IntroCutsceneDialogue dialogue;
    public Animator animator;
	
	void Awake ()
    {
        animator.SetBool("gameStarted", true);
        StartCoroutine("StartCutscene", 10f);
        TriggerDialogue();

	}
    public void TriggerDialogue()
    {
        FindObjectOfType<IntroCutscene>().StartDialogue(dialogue);
    }

    IEnumerator StartCutscene(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
    }
}
