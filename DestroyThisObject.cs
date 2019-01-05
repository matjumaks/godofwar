using UnityEngine;
using System.Collections;

public class DestroyThisObject : MonoBehaviour {
	

	// Use this for initialization
	void Start () {
		Destroy(this.gameObject, 1.9f);
	}
}
