using UnityEngine;
using System.Collections;

public class ThrowAxe : MonoBehaviour {

	public float thrust;
	public float rot;
	private Rigidbody rb;
	public Vector3 position;
	public Quaternion rotation, AxeStopRot;
	public GameObject parent,AxeStop,player;
	public int x,y,z,w;
	public Vector3 collisonPoint;
	
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
		rb.maxAngularVelocity = 100;
		Axe();
		StartCoroutine("Rotation");
		Destroy(parent.gameObject, 2f);
	}
	
	// Update is called once per frame
	void Axe () {
			rb.AddForce(transform.forward * thrust);
	}
	
	void Update()
	{
		player = GameObject.FindGameObjectWithTag("Player");
		AxeStopRot = Quaternion.Euler(player.transform.localEulerAngles.x,player.transform.localEulerAngles.y,90f);
		position = transform.position;
		rotation = transform.rotation;
	}
	
	IEnumerator Rotation(){
		yield return new WaitForSeconds(0.1f);
		rb.AddTorque(transform.up * rot);
	}
				void OnCollisionEnter(Collision theCollision)
		{		
				if(theCollision.gameObject.name != "LowPoL 1")
				{
					collisonPoint = theCollision.contacts[0].point;
					Instantiate(AxeStop,collisonPoint,AxeStopRot);
					Destroy(parent.gameObject);
				}
				
				if(theCollision.gameObject.name == "LowPoL 1")
				{
					Destroy(parent.gameObject, 2f);
				}
				
		}
}
