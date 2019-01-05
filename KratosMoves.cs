using UnityEngine;
using System.Collections;

public class KratosMoves : MonoBehaviour {

	private Animator anim;
	private CharacterController controller;
	public float Speed = 1.0f;
	public float turnSpeed = 60.0f;
	private Vector3 moveDirection = Vector3.zero;
	public float gravity = 20.0f;
	public float JumpForce = 10.0f;

	// Use this for initialization
	void Start () {
		anim = gameObject.GetComponentInChildren<Animator>();
		controller = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey("z")){
			anim.SetInteger("AnimPar",1);
			//Debug.LogError("bang");
		}else if (Input.GetKey("x")){
			anim.SetInteger("AnimPar",0);
		}
		else if (Input.GetKey("c")){
			anim.SetInteger("AnimPar",2);
		}
		
		if(controller.isGrounded){
			moveDirection = transform.forward * Input.GetAxis("Vertical") * Speed;
		}
		
		if(Input.GetKey("space") && controller.isGrounded){
			moveDirection.y += JumpForce;
		}
		
		float turn = Input.GetAxis("Horizontal");
		transform.Rotate(0, turn * turnSpeed * Time.deltaTime, 0);
		controller.Move(moveDirection* Time.deltaTime);
		moveDirection.y -= gravity * Time.deltaTime;
	}
}