using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour {
	
	public Transform target;
	private Animator anim;
	private Rigidbody rb;
	public int pull = 0;
	public NavMeshAgent agent;
	public int check = 0;
	public int check2 = 0;
	public float health ;
	public float startHealth = 1f;
	public Image healthBar;
	private float _hitTime = .5f;
	private float _hitTimer = 2f;
	bool notHit = true;
	public AudioSource shieldSound, hitSound, sword, roar1, roar2;

	public PlayerControlandCam playerControlandCam;
	public bool HitAnim = false;
	public bool HitL = false;
	public bool HitR = false;
	public Collider testE;

	// Use this for initialization
	void Start () {
		
		anim = gameObject.GetComponentInChildren<Animator>();
		agent = GetComponent<NavMeshAgent>();
		rb = GetComponent<Rigidbody>();
		health = 1.0f;
		healthBar.fillAmount = health;
		target = GameObject.FindGameObjectWithTag("Player").transform;
		playerControlandCam =  GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControlandCam>();
	}
	
	void Update(){
		
		HitAnim = playerControlandCam.HitUp;
		HitL = playerControlandCam.HitL;
		HitR = playerControlandCam.HitR;
		
		if(check2 == 1){
		_hitTimer += Time.deltaTime;
		}
		
		if(agent.enabled == true){
			if(agent.remainingDistance < 7)
			{
				anim.SetInteger("AnimPar",2);
			}else if(anim.GetInteger("AnimPar") != 1){
				anim.SetInteger("AnimPar",0);
			}
		}
		
			
		if(health > 0.2f && agent.enabled == true && notHit == true)
			{
				agent.SetDestination(target.position);
			}
		
		if(check == 1 && Input.GetMouseButtonDown(1))
		{
			anim.enabled = !anim.enabled;
			check = 0;
			agent.enabled = !agent.enabled;
			rb.isKinematic = true;
			rb.constraints = RigidbodyConstraints.None;
			rb.constraints = RigidbodyConstraints.FreezeRotation;
		}
		
		if(health < 0.2f)
		{
			rb.isKinematic = false;
			agent.Stop();
			Destroy(this.gameObject,4f);
			anim.Play("Fall");
			//rb.constraints = RigidbodyConstraints.None;
			StartCoroutine("KinOn3");
		}
	}
	
	void OnCollisionEnter(Collision theCollision)
		{
			if (theCollision.gameObject.name == "Palm_R")
			{	
				anim.SetInteger("AnimPar",0);
				check2 = 1;
				if(_hitTimer > _hitTime)
				{
					if(HitAnim == false){
						playerControlandCam.AxeColl.enabled = false;
						healthBar.fillAmount -= .1f;
						health -= .1f;
						_hitTimer = 0;
						if(anim.GetCurrentAnimatorStateInfo(0).IsName("Fly") != true && anim.GetCurrentAnimatorStateInfo(0).IsName("HitUp") != true &&
						anim.GetCurrentAnimatorStateInfo(0).IsName("Fly2") != true){
							if(HitL == true){
									anim.Play("HitL");
								}else if(HitR == true){
									anim.Play("HitR");
								}
						agent.Stop();
						rb.isKinematic = false;
						rb.AddForce(transform.forward * -1 * 20f, ForceMode.Impulse);
						StartCoroutine("KinOn");
						}
						if(anim.GetCurrentAnimatorStateInfo(0).IsName("Fly") == true || anim.GetCurrentAnimatorStateInfo(0).IsName("HitUp") == true || anim.GetCurrentAnimatorStateInfo(0).IsName("Fall2") == true){
							rb.AddForce(transform.forward * -1 * 1f,ForceMode.Impulse);
							StartCoroutine("Turbulance");
								anim.Play("HitAir");
						}
						hitSound.Play();
					}else{
						agent.Stop();
						//testE.enabled = false;
						playerControlandCam.AxeColl.enabled = false;
						healthBar.fillAmount -= .1f;
						health -= .1f;
						_hitTimer = 0;
						rb.isKinematic = false;
						//rb.constraints = RigidbodyConstraints.None;
						anim.Play("HitUp");
						
						//rb.AddForce(transform.up * 1 * 5f,ForceMode.Impulse);
						rb.AddForce(transform.forward * -1 * 15f,ForceMode.Impulse);
						StartCoroutine("KinOn4");
						hitSound.Play();
					}
				}
			}
			
				if (theCollision.gameObject.name == "axeSCULPT5final")
				{
				check = 1;
				agent.enabled = !agent.enabled;
				anim.enabled = !anim.enabled;
				rb.constraints = RigidbodyConstraints.FreezeAll;
				rb.isKinematic = false;
				}
				
				if (theCollision.gameObject.name == "Palm_L")
				{	
					shieldSound.Play();
					anim.Play("JHit");
					test2();
					//rb.constraints = RigidbodyConstraints.None;
				}
	}
	
		IEnumerator KinOn(){
			yield return new WaitForSeconds(.3f);
			rb.isKinematic = true;
			yield return new WaitForSeconds(.7f);
			notHit = true;
			rb.isKinematic = true;
			agent.Resume();
		}
		
		IEnumerator KinOn2(){
			yield return new WaitForSeconds(1.1f);
			rb.isKinematic = true;
			agent.Resume();
			rb.constraints = RigidbodyConstraints.FreezeRotation;
		}
		
		IEnumerator KinOn3(){
			yield return new WaitForSeconds(.1f);
			rb.isKinematic = true;
		}
		
		IEnumerator KinOn4(){
			yield return new WaitForSeconds(1f);
			rb.velocity = new Vector3(0, 0, 0);
			//yield return new WaitForSeconds(15f);
			
		}
		
		public void ResumeEnemy(){
			anim.Play("Run");
			
			rb.constraints = RigidbodyConstraints.FreezeRotation;
			agent.Resume();
		}
		
		public void Kinematic(){
			rb.isKinematic = true;
		}
		
		IEnumerator Turbulance(){
			yield return new WaitForSeconds(.3f);
			rb.velocity = new Vector3(0, 0, 0);
		}
		
	public void test(){
			notHit = false;
			agent.Stop();
			rb.isKinematic = false;
			rb.AddForce(transform.forward * -1 * 200);
			StartCoroutine("KinOn");
		}	
		
	public void test2(){
			agent.Stop();
			rb.isKinematic = false;
			rb.AddForce(transform.forward * -1 * 2000);
			StartCoroutine("KinOn2");
		}
	
	public void Sword(){
			sword.Play();
	}
	
	public void Roar1(){
			roar1.Play();
	}

}
