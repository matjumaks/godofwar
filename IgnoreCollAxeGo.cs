using UnityEngine;
using System.Collections;

public class IgnoreCollAxeGo : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Physics.IgnoreLayerCollision(12,15);
	}
}
