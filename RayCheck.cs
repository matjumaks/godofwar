using UnityEngine;
using System.Collections;

public class RayCheck : MonoBehaviour {

	public string hitCollider;
	
	// Update is called once per frame
	void Update () {
				
		RaycastHit hit = new RaycastHit();
		if(Physics.Raycast(transform.position , -Vector3.up,out hit, 1.5f)){
			Debug.DrawRay(transform.position, (-Vector3.up)* hit.distance,Color.yellow);
			hitCollider = hit.collider.tag ;
		}else{
			hitCollider = "none";
		}
	}
}
