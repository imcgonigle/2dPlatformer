﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableBox : MonoBehaviour
{

	private AudioSource breakableBoxAudio;

	void Start ()
	{
		GameObject audioObject = GameObject.Find ("BreakableBoxAudio");

		if (audioObject) {
			breakableBoxAudio = audioObject.GetComponent<AudioSource> ();
		}
	}

	void OnDestroy ()
	{
        GameObject diamond = GameObject.Find("Diamond");
        if (diamond)
        {
		    diamond.GetComponent<DialogueTrigger> ().TriggerDialogue ();
        }
		if (breakableBoxAudio) {
			breakableBoxAudio.Play ();
		}
	}
}
