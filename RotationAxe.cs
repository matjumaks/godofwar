using UnityEngine;
using System.Collections;

public class RotationAxe : MonoBehaviour {
	
	public Transform target;
	
	void Start(){
		target = GameObject.FindGameObjectWithTag("Player").transform;
		transform.LookAt(target);
	}
	
}
