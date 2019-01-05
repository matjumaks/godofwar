using UnityEngine;
using System.Collections;

public class IgnoreCollison : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Physics.IgnoreLayerCollision(11,14);
		Physics.IgnoreLayerCollision(10,14);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
