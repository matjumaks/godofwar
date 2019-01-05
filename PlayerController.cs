using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	
	private Rigidbody rb;
	bool isGrounded = true;
	public float speedChar = 5f;
	public float rotateChar = 1.5f;
	public GameObject cam;
	float camX;

     void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
 
    void Update()
    {
		cam.transform.localEulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z);
		//movement controls 
        if(Input.GetKey(KeyCode.W))
		{
        transform.Translate((Vector3.forward * Time.deltaTime * speedChar) );
		//follow CharCam
		//cam.transform.localEulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z);
		camX = transform.position.x + 1;
		cam.transform.position = new Vector3(camX,transform.position.y+2,transform.position.z-3);
		}
         
        if(Input.GetKey(KeyCode.S)) 
		transform.Translate( -1 * Vector3.forward * Time.deltaTime * speedChar);
         
        if(Input.GetKey(KeyCode.A)) 
        transform.Translate( Vector3.left * Time.deltaTime * speedChar * 1.2F); 
	
        if(Input.GetKey(KeyCode.D)) 
        transform.Translate( Vector3.right * Time.deltaTime * speedChar);
		
		//rotate on X-axis
		if(Input.GetAxis("Mouse X") < 0)
		transform.Rotate((Vector3.up) * -rotateChar);
	
		if(Input.GetAxis("Mouse X") > 0)
		transform.Rotate((Vector3.up) * rotateChar );

		//jump	
		if(isGrounded == true)
			{
				if(Input.GetKey(KeyCode.Space)) 
				rb.velocity = new Vector3(0, 6, 0);
			}
	
    }
	
	//isGrounded check
	void OnCollisionEnter(Collision theCollision)
		{
			if (theCollision.gameObject.name == "Floor")
				{
					isGrounded = true;
				}
		}	
	void OnCollisionExit(Collision theCollision)
		{
			if (theCollision.gameObject.name == "Floor")
			{
				isGrounded = false;
			}
		}
  
}