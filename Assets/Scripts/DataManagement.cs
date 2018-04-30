using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class DataManagement : MonoBehaviour
{

	public static DataManagement datamanagement;

	public int highScore;
	public int livesLeft;


	void Awake ()
	{
		if (datamanagement == null) {
			DontDestroyOnLoad (gameObject);
			datamanagement = this;
		} else if (datamanagement != this) {
			Destroy (gameObject);
		}
	}

	public void SaveData ()
	{
		BinaryFormatter binForm = new BinaryFormatter (); // creates a bin formatter
		FileStream file = File.Create (Application.persistentDataPath + "/gameInfo.dat"); // creates file
		GameData data = new GameData (); // creates container for data

		data.highScore = highScore; // set highscore
		data.livesLeft = livesLeft;
		binForm.Serialize (file, data); // serializes data
		file.Close (); // closes file and saves data
	}

	public void LoadData ()
	{
		if (File.Exists (Application.persistentDataPath + "/gameInfo.dat")) {
			BinaryFormatter binForm = new BinaryFormatter ();
			FileStream file = File.Open (Application.persistentDataPath + "/gameInfo.dat", FileMode.Open);
			GameData data = (GameData)binForm.Deserialize (file);
			file.Close ();
			highScore = data.highScore;
			livesLeft = data.livesLeft;
		}
	}

}

[Serializable]
class GameData
{
	public int highScore;
	public int livesLeft;
}
