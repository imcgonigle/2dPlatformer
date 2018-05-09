using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingCoin : MonoBehaviour {

    private bool hasMoved;

	void Start () {
        hasMoved = false;
	}
	
	void Update () {
        if(FindEnemies().Length == 0 && !hasMoved)
        {
            GetComponent<Transform>().position += new Vector3(0, 4);
            hasMoved = true;
        }
	}

    GameObject[] FindEnemies()
    {
        return GameObject.FindGameObjectsWithTag("enemy");
    }
}
