using UnityEngine;
using System.Collections;

public class IgnoreCollAxe : MonoBehaviour {
	
	public Collider Axe, Floor;

	// Use this for initialization
	void Start () {
		Floor = GameObject.FindGameObjectWithTag("Floor").GetComponent<Collider>();
		Physics.IgnoreCollision(Axe,Floor);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
