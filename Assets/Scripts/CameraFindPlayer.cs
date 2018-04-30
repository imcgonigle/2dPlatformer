using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraFindPlayer : MonoBehaviour
{
	public GameObject player;

	void Start ()
	{
		player = GameObject.FindGameObjectWithTag ("Player");
		if (player) {
			gameObject.GetComponent<CinemachineVirtualCamera> ().m_Follow = player.transform;
		}
	}

	void Update ()
	{
		if (!player) {
			player = GameObject.FindGameObjectWithTag ("Player");
			if (player) {
				gameObject.GetComponent<CinemachineVirtualCamera> ().Follow = player.transform;
			}
		}
	}
}
