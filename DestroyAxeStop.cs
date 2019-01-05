using UnityEngine;
using System.Collections;

public class DestroyAxeStop : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButton(1))
				{
					Destroy(this.gameObject);
				}
	}
}
