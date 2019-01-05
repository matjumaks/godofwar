using UnityEngine;
using System.Collections;

public class CamFollowPlayer : MonoBehaviour {
	
	public float rotationY = 0f;
	public float rotationX = 0f;
	public float curYrot;
	public GameObject player;
	public Vector3 offset;
	public Camera cam;

	void Start () {
		offset = transform.position - player.transform.position;
	}
	
	void Update(){
		rotationY += Input.GetAxis("Mouse X") * 10 ;
		//rotationY = Mathf.Clamp (rotationY, -10, 7);
		rotationX += Input.GetAxis("Mouse Y") * -5 ;
		rotationX = Mathf.Clamp (rotationX, -30, 20);
		transform.localEulerAngles = new Vector3(rotationX, rotationY, transform.localEulerAngles.z);	
	}
	void LateUpdate () {
			transform.position = player.transform.position + offset;	
			if(Input.GetMouseButton(2)) 
			{   
				cam.gameObject.SetActive(true);	
			}
			else{
				cam.gameObject.SetActive(false);
				offset = new Vector3(0f,.38f,0f);
			}
		}
	}

