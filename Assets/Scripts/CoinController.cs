using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{

	private AudioSource coinAudio;

	void Start ()
	{
		GameObject audioObject = GameObject.Find ("CoinAudio");

		if (audioObject) {
			coinAudio = audioObject.GetComponent<AudioSource> ();
		}
	}

	void OnDestroy ()
	{
		if (coinAudio) {
			coinAudio.Play ();
		}
	}
}
