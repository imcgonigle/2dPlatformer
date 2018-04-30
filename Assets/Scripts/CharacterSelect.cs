using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelect : MonoBehaviour
{

	public void ChooseCharacter (int characterIndex)
	{
		PlayerPrefs.SetInt ("SelectedCharacter", characterIndex);
	}

	public void LoadScene ()
	{
		DataManagement.datamanagement.LoadData ();
		DataManagement.datamanagement.livesLeft = 3;
		DataManagement.datamanagement.SaveData ();
		SceneManager.LoadScene ("Level 1");
	}
}
