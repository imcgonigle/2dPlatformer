using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player_Score : MonoBehaviour
{

	private float timeLeft = 120;
	public int playerScore = 0;
	public int livesLeft;
	public GameObject timeLeftUI;
	public GameObject playerScoreUI;
	public GameObject livesLeftUI;

	void Start ()
	{
		timeLeftUI = GameObject.Find ("TimeLeft");
		playerScoreUI = GameObject.Find ("Score");
		livesLeftUI = GameObject.Find ("Lives");

		DataManagement.datamanagement.LoadData ();

		livesLeft = DataManagement.datamanagement.livesLeft;
		livesLeftUI.gameObject.GetComponent<Text> ().text = ("Lives Left: " + livesLeft);
	}

	// Update is called once per frame
	void Update ()
	{
		timeLeft -= Time.deltaTime;
		timeLeftUI.gameObject.GetComponent<Text> ().text = ("Time Left: " + (int)timeLeft);
		playerScoreUI.gameObject.GetComponent<Text> ().text = ("Score: " + playerScore);
		if (timeLeft < 0.1f) {
			SceneManager.LoadScene ("Level 1");
		}
	}

	void OnTriggerEnter2D (Collider2D trig)
	{
		if (trig.name == "EndLevel") {
			GameObject.Find ("EndLevelAudio").GetComponent<AudioSource> ().Play ();
			string nextLevel = trig.gameObject.GetComponent<EndLevel> ().nextLevel;
			CountScore ();
			DataManagement.datamanagement.SaveData ();
			SceneManager.LoadScene (nextLevel);
		}
		if (trig.tag == "coin") {
			playerScore += 10;
			Destroy (trig.gameObject);
		}
	}

	void CountScore ()
	{
		playerScore = playerScore + (int)(timeLeft * 10);
		if (playerScore > DataManagement.datamanagement.highScore) {
			DataManagement.datamanagement.highScore = playerScore;
			DataManagement.datamanagement.SaveData ();
		}
	}
}
