using UnityEngine;
using System.Collections;

public class movementTest : MonoBehaviour {

	public float speedChar = 5f;
	public float rotationY = 0f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.W))
		{
		rotationY += Input.GetAxis("Mouse X") * 10 ;
		transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, rotationY, transform.localEulerAngles.z);
        transform.Translate((Vector3.forward * Time.deltaTime * speedChar) );
		}

        if(Input.GetKey(KeyCode.S)) 
		{
		transform.Translate( -1*Vector3.forward * Time.deltaTime * speedChar);
		}
   
		if(Input.GetKey(KeyCode.A)) 
		{
		transform.Translate( Vector3.left * Time.deltaTime * speedChar); 
		}
			
		if(Input.GetKey(KeyCode.D)) 
		{
		transform.Translate( Vector3.right * Time.deltaTime * speedChar);
		}
	}
}
