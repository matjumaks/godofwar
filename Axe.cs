using UnityEngine;
using System.Collections;

public class Axe : MonoBehaviour {

	//public GameObject axe;

	// Use this for initialization
	void Start () {
		//this.gameObject.transform.parent = axe.transform;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision col) {
		Debug.LogError("Dziala");
			if(col.gameObject.name != ""){
				Debug.LogError("Dziala");
	    }
	}
}
