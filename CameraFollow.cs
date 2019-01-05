using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {
	
	public float rotationY = 0f;
	//private float rotationX = 0f;
	public Transform startMarker;
	public Transform endMarker;
	public float speed;
	private float startTime;
	public float journeyLength;
	public float a;
	public GameObject player;
	private Vector3 offset;
	
	void Start(){
		offset = transform.position - player.transform.position;
	}
	
	//camera follow 
	void Update () {   
	a = transform.localEulerAngles.y;
	//Debug.Log(a);
	if(!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A)){
		rotationY += Input.GetAxis("Mouse X") * 10 ;
		//rotationY = Mathf.Clamp (rotationY, -10, 7);
		//rotationX += Input.GetAxis("Mouse X")  ;
		//rotationX = Mathf.Clamp (rotationX, -20, 8);
		transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, rotationY, transform.localEulerAngles.z);	
		}else{
			if(transform.localEulerAngles.y < 180  && transform.localEulerAngles.y > 5) {
					float angle = Mathf.LerpAngle(a,0.0f,Time.deltaTime);
					Quaternion target = Quaternion.Euler(transform.localEulerAngles.x,0.0f,transform.localEulerAngles.z);
					transform.rotation = Quaternion.Slerp(transform.rotation,target, Time.deltaTime*5.0f);
					rotationY = angle;
				}else if (transform.localEulerAngles.y > 180  ){
					float angle = Mathf.LerpAngle(a,359.9f,Time.deltaTime);
					Quaternion target = Quaternion.Euler(transform.localEulerAngles.x,0.0f,transform.localEulerAngles.z);
					transform.rotation = Quaternion.Slerp(transform.rotation,target, Time.deltaTime*5.0f);
					//transform.eulerAngles = new Vector3(transform.localEulerAngles.x,angle,transform.localEulerAngles.z);
					rotationY = angle;
					//Debug.LogError("rot2");
			}	
		}
	}
			void LateUdate(){
				transform.position = player.transform.position + offset;
			}
}
