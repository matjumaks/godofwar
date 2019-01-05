using UnityEngine;
using System.Collections;

public class GameControl : MonoBehaviour {

	public GameObject[] objects;
	int x = 0;
	// Use this for initialization
	void Awake () {
		//Cursor.visible = false;
		//Cursor.lockState = CursorLockMode.Locked;
		objects = GameObject.FindGameObjectsWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
		if ((objects[x].name) == "LowPoL 1(Clone)"){
			Destroy(objects[x]);
			x++;
		}
	}
}
