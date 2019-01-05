using UnityEngine;
using System.Collections;

public class MoveTowards : MonoBehaviour {

	public Transform target;
	public float speed;
	public AudioSource AxeR;
	public GameObject playerAudio, PlayerAnim;
	public Animator anim;
	
	
	
	void Start(){
		target = GameObject.FindGameObjectWithTag("AxeCatchPoint").transform;
		playerAudio = GameObject.FindGameObjectWithTag("Player");
		AxeR = playerAudio.gameObject.GetComponent<AudioSource>();
		
		PlayerAnim = GameObject.FindGameObjectWithTag("Player");
		anim = PlayerAnim.gameObject.GetComponentInChildren<Animator>();
		Physics.IgnoreLayerCollision(9,10);
	}
	
	// Update is called once per frame
	void Update () {
		float step = speed * Time.deltaTime;
		transform.position = Vector3.MoveTowards(transform.position, target.position, step);
		
	}
			void OnCollisionEnter(Collision theCollision)
		{
			if (theCollision.gameObject.name == "LowPoL 1")
			{
				
				Destroy(this.gameObject);
			}
		}
}
