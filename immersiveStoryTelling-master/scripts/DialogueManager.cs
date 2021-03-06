﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

	public Text nameText;
	public Text convoText;

	public Animator animator;

	private Queue<string> sentences;

	// Use this for initialization
	void Start () {
		sentences = new Queue<string>();
	}
	
	public void StartDialogue(Dialogue dialogue)
	{
		animator.SetBool("isOpen", true);
		Debug.Log("Starting conversation with " + dialogue.name);

		nameText.text = dialogue.name;

		sentences.Clear();

		foreach(string sentence in dialogue.sentences)
		{
			sentences.Enqueue(sentence);
		}

		DisplayNextSentence();
	}

	public void DisplayNextSentence()
	{
		if(sentences.Count == 0)
		{
			EndDialogue();
			return;
		}

		string sentence = sentences.Dequeue();
		convoText.text = sentence;
		Debug.Log(sentence);
	}
	
	void EndDialogue()
	{
		animator.SetBool("isOpen", false);
		Debug.Log("Conversation has Ended.");
	}
}
