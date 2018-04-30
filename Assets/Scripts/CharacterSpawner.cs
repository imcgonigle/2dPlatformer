using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSpawner : MonoBehaviour
{

	public GameObject[] players;

	void Start ()
	{
		SetPlayer (PlayerPrefs.GetInt ("SelectedCharacter"));

	}

	void SetPlayer (int index)
	{
		GameObject player = Instantiate (players [(index)], Vector2.zero, Quaternion.identity);
		player.tag = "Player";
	}
}
