using UnityEngine;
using System.Collections;

public class AxeReturn : MonoBehaviour {

	public float rot;
	private Rigidbody rb;
	public GameObject parent;
	
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
		rb.maxAngularVelocity = 100;
		StartCoroutine("Rotation");	
	}
	
	IEnumerator Rotation(){
		yield return new WaitForSeconds(0.1f);
		rb.AddTorque(transform.right * rot);
	}
	
				void OnCollisionEnter(Collision theCollision)
		{	
				if(theCollision.gameObject.name == "LowPoL 1")
				{
					Destroy(parent.gameObject);
				}
		}
}
