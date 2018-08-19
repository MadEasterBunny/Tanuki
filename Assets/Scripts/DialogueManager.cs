using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class DialogueManager : MonoBehaviour
{
    private Queue<string> sentences;

    public Text nameText;
    public Text dialogueText;
    public Animator animator;
    public NavMeshAgent agent;

	
	void Start ()
    {
        sentences = new Queue<string>();
	}

    public void StartDialogue(Dialogue dialogue)
    {
        agent.isStopped = true;
        animator.SetBool("isOpen", true);
        nameText.text = dialogue.name;

        sentences.Clear();

        foreach(string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        ContinueDialogue();
    }
	
	public void ContinueDialogue()
    {
        if(sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        dialogueText.text = sentence;
    }

    void EndDialogue()
    {
        agent.isStopped = false;
        animator.SetBool("isOpen", false);
        //Debug.Log("End of conversation.");
    }
}
