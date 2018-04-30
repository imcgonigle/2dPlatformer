using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Health : MonoBehaviour
{

	void Update ()
	{
		if (gameObject.transform.position.y < -25) {
			Die ();
		}
	}

	void Die ()
	{
		Destroy (gameObject);
	}
}
