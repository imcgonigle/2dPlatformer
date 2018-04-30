using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Health : MonoBehaviour
{
	public static Player_Health playerHealth;

	void Awake ()
	{
		playerHealth = this;
	}

	void Update ()
	{
		if (gameObject.transform.position.y < -7) {
			Die ();
		}
	}

	public void Die ()
	{
		int livesLeft = DataManagement.datamanagement.livesLeft--;
		DataManagement.datamanagement.SaveData ();
		if (livesLeft > 0) {
			SceneManager.LoadScene ("Level 1");
		} else {
			SceneManager.LoadScene ("CharacterSelect");
		}
	}
}
