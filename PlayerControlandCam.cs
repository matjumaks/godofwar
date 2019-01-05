using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerControlandCam : MonoBehaviour {
	
	private Rigidbody rb;
	public float speedCharW, speedCharS, speedCharA, speedCharD,speedCharRun;
	public float rotateChar = 2f;
	public Transform Axe;
	public Transform Axe2;
	public float x;
	public float y;
	public float z;
	public Vector3 AxePos;
	public Quaternion myCamera, myCamera3;
	public Quaternion AxeRot;
	public Quaternion AxeRotEnd,playerRot;
	private Animator anim;
	public GameObject AxeBack, trot, AxeGO;
	public Vector3 myCamera2, playerR;
	public AudioSource scream, scream2, axeS, source, AxeReturnSound, hurt,waterSteps;
	public Transform camRot;
	public RayCheck raycheck;
	public RayCheck2 raycheck2;
	private bool AxeFly = false;
	public GameObject enemy, shieldMesh, shieldColl,AxeBone, enemyD;
	public Collider AxeColl;
	public bool HitUp = false;
	public bool HitL = false;
	public bool HitR = false;
	
	bool swing = true;
	public float health ;
	public float startHealth = 1f;
	public Image healthBar;
	private float _hitTime = .5f;
	private float _hitTimer = 1f;
	
	void Awake(){
		anim = gameObject.GetComponentInChildren<Animator>();
		anim.SetBool("Floor", true);
		playerRot = transform.rotation;
	}
	
     void Start()
    {
		Physics.IgnoreLayerCollision(10,11);
		health = 1.0f;
		healthBar.fillAmount = health;
        rb = GetComponent<Rigidbody>();
		AxeColl = AxeBone.GetComponent<Collider>();
		source.Play();	
		waterSteps.Play();
    }
 
    void Update()
    {
		//track positions, rotations
		myCamera = GameObject.FindGameObjectWithTag("Cam").transform.rotation;
		myCamera2 = GameObject.FindGameObjectWithTag("Cam").transform.position;
		AxeGO = (GameObject.FindGameObjectWithTag("Axe"));
		
		//audio steps
		if((anim.GetInteger("AnimPar") == 1 || anim.GetInteger("AnimPar") == 3 || anim.GetInteger("AnimPar") == 5 || 
		anim.GetInteger("AnimPar") == 4) && anim.GetBool("Floor") == true) {
			source.mute = false;
		}else{
			source.mute = true;
		}
		
		if(raycheck2.hitCollider == "water"  && anim.GetInteger("AnimPar") == 1 || anim.GetInteger("AnimPar") == 3 || anim.GetInteger("AnimPar") == 5 || 
		anim.GetInteger("AnimPar") == 4 && anim.GetBool("Floor") == true) {
			waterSteps.mute = false;
			source.mute = true;
		}else{
			waterSteps.mute = true;
		}
		
		//hitTimer
		_hitTimer += Time.deltaTime;

		//check ifFloor true
		if(raycheck.hitCollider == "Floor"){
			anim.SetBool("Floor" , true);
		}
		else
		{
			anim.SetBool("Floor" , false);
			transform.Translate((Vector3.forward * Time.deltaTime * speedCharW) );
		}
	
		//movements
		if(anim.GetBool("Floor") == true)
			{			 
				//Axe Throw and Return 
				if(AxeGO != null)
					{
						AxePos = GameObject.FindGameObjectWithTag("Axe").GetComponent<ThrowAxe>().position;
						playerR = transform.position - AxePos;
						AxeRot = GameObject.FindGameObjectWithTag("Axe").GetComponent<ThrowAxe>().rotation;
					}	 
					
				 
				if(Input.GetMouseButtonDown(1)) 
				{   
					if(AxeFly == false){
					axeS.Play();
					anim.Play("Throw");
					anim.SetInteger("AnimPar",2);
					StartCoroutine("AxeThr");
					AxeFly = true;			
					}else{
						if(GameObject.FindGameObjectWithTag("Axe") == null){
							Instantiate(Axe2,AxePos,transform.rotation);
							AxeFly = false;
							anim.Play("AxeCatch");
						}
					}
				}
				
				if(anim.GetInteger("AnimPar") != 2 ){
				anim.SetInteger("AnimPar",0);
				}
				
				//movement controls 
				if(Input.GetKey(KeyCode.W))
				{
					if(!Input.GetKey(KeyCode.LeftShift)){
						anim.SetInteger("AnimPar",1);
						if(anim.GetInteger("AnimPar") == 1){
						//anim.Play("Trot");
						transform.Translate((Vector3.forward * Time.deltaTime * speedCharW) );
						if(Input.GetKey(KeyCode.A))
							{
							transform.Translate( Vector3.left * Time.deltaTime * speedCharA / 2f);
							}
							else if(Input.GetKey(KeyCode.D))
							{
								transform.Translate( Vector3.right * Time.deltaTime * speedCharD / 2f);
							}
						}
					}
					else if(Input.GetKey(KeyCode.LeftShift)){
						anim.SetInteger("AnimPar",8);
						if(anim.GetInteger("AnimPar") == 8){
						//anim.Play("Run");
						transform.Translate((Vector3.forward * Time.deltaTime * speedCharRun));
						}
					}
				}else if(Input.GetKey(KeyCode.S)){
					anim.SetInteger("AnimPar",5);
					if(anim.GetInteger("AnimPar") == 5){
						//anim.Play("TrotBack");
						transform.Translate( -1*Vector3.forward * Time.deltaTime * speedCharS);
						if(Input.GetKey(KeyCode.A)){
							transform.Translate( Vector3.left * Time.deltaTime * speedCharA / 2f);
						}
						else if(Input.GetKey(KeyCode.D))
						{
						transform.Translate( Vector3.right * Time.deltaTime * speedCharD / 2f);
						}
					}
				}else if(Input.GetKey(KeyCode.A)) {
					anim.SetInteger("AnimPar",3);
					if(anim.GetInteger("AnimPar") == 3){
						//anim.Play("LeftTrot");
						transform.Translate( Vector3.left * Time.deltaTime * speedCharA); 
					}
				}
				else if(Input.GetKey(KeyCode.D)) 
				{
					anim.SetInteger("AnimPar",4);
					if(anim.GetInteger("AnimPar") == 4){
						//anim.Play("RightTrot");
						transform.Translate( Vector3.right * Time.deltaTime * speedCharD);
					}
				}
						
				if(Input.GetMouseButtonDown(0)){
					PullAxe();
				}
				 
				//jump	
				if(Input.GetKeyDown(KeyCode.Space))
				{ 
					rb.velocity = new Vector3(0, 6, 0);
				}
			}
		
		//animation reset
		if(Input.GetMouseButton(2))
		{		
			if(anim.GetInteger("AnimPar") != 2)
			{
				anim.SetInteger("AnimPar",7);
			}
		}
		
		//Axe collider	
		if((anim.GetCurrentAnimatorStateInfo(0).IsName("SwingR") != true) && (anim.GetCurrentAnimatorStateInfo(0).IsName("SwingL") != true) && (anim.GetCurrentAnimatorStateInfo(0).IsName("SwingDown") != true))
		{
			AxeColl.enabled = false;
			HitL = false;
			HitR = false;
		}
		
		//swings
		if(Input.GetKeyDown(KeyCode.Q) && swing == true && (anim.GetCurrentAnimatorStateInfo(0).IsName("SwingL") != true)  && (anim.GetCurrentAnimatorStateInfo(0).IsName("SwingR") != true))
		{
			anim.Play("SwingL");
			scream.Play();
			anim.SetInteger("AnimPar",2);
			AxeColl.enabled = true;
			HitL = true;
			rb.AddForce(transform.forward * 1 * 12f, ForceMode.Impulse);
		}

		if(Input.GetKeyDown(KeyCode.E) && swing == true && (anim.GetCurrentAnimatorStateInfo(0).IsName("SwingR") != true) && (anim.GetCurrentAnimatorStateInfo(0).IsName("SwingL") != true))
		{
			scream2.Play();
			anim.Play("SwingR");
			anim.SetInteger("AnimPar",2);
			AxeColl.enabled = true;
			HitR = true;
			rb.AddForce(transform.forward * 1 * 12f, ForceMode.Impulse);
		}
		
		if(Input.GetKeyDown(KeyCode.Z) && swing == true && (anim.GetCurrentAnimatorStateInfo(0).IsName("SwingL") != true)  && (anim.GetCurrentAnimatorStateInfo(0).IsName("SwingR") != true) && (anim.GetCurrentAnimatorStateInfo(0).IsName("SwingDown") != true))
		{
			anim.Play("SwingDown");
			scream.Play();
			anim.SetInteger("AnimPar",2);
			AxeColl.enabled = true;
			rb.AddForce(transform.forward * 1 * 1000f);
		}
		
		//swingdown
		if(anim.GetCurrentAnimatorStateInfo(0).IsName("SwingDown") == true){
			HitUp = true;
		}else{
			HitUp = false;
		}
		
		//spawn enemy test
		if(Input.GetKeyDown(KeyCode.P))
		{
			Instantiate(enemy,transform.position+(transform.forward * 65f),transform.rotation);
		}
		
		//destroy enemy test
		if(Input.GetKeyDown(KeyCode.C))
		{
			enemyD = GameObject.FindGameObjectWithTag("Enemy");
			Destroy(enemyD);
		}
		
				
		if(anim.GetCurrentAnimatorStateInfo(0).IsName("Shield") != true)
		{	
			shieldColl.gameObject.SetActive(false);
			shieldMesh.gameObject.SetActive(false);	
		}
		
		//shield
		if(Input.GetKeyDown(KeyCode.R) && (anim.GetCurrentAnimatorStateInfo(0).IsName("Shield") != true))
		{
			anim.SetInteger("AnimPar",2);
			scream2.Play();
			anim.Play("Shield");
			shieldColl.gameObject.SetActive(true);
			shieldMesh.gameObject.SetActive(true);	
		}

		
		if(Input.GetKeyDown(KeyCode.LeftAlt) && Input.GetKey(KeyCode.A))
			{ 
				anim.Play("RollLeft");
				rb.AddForce(transform.right * -1 * 1900);
			}
		if(Input.GetKeyDown(KeyCode.LeftAlt) && Input.GetKey(KeyCode.D))
			{ 
				rb.AddForce(transform.right * 1 * 1900);
			}
    }
	
	//Coorutines <-----
	IEnumerator AxeThr(){
		yield return new WaitForSeconds(0.4f);
		AxeBack.gameObject.SetActive(false);
		if(!Input.GetMouseButton(2))
		{
			Instantiate(Axe,transform.position+(transform.right*1.4f)+(transform.forward*1.1f)+(transform.up*3),myCamera);
			anim.SetInteger("AnimPar",0);			
		}
		else{
			myCamera3 = GameObject.FindGameObjectWithTag("CamClose").transform.rotation;
			Instantiate(Axe,transform.position+(transform.right*0.8f)+(transform.forward*2)+(transform.up*2),myCamera3);
		}
	}
	
	IEnumerator AxeRe(){
			yield return new WaitForSeconds(.2f);
			AxeBack.gameObject.SetActive(true);
		}
		
	void PullAxe(){
		if(anim.GetInteger("AnimPar") == 2){
			anim.SetInteger("AnimPar",0);
			}else{
				anim.SetInteger("AnimPar",2);
			}
		}

	
	//colissions
	void OnCollisionEnter(Collision theCollision)
		{
			if (theCollision.gameObject.name == "axeSCULPT5finalRE")
				{
					StartCoroutine("AxeRe");
					anim.Play("AxeCatchPosHide");
					AxeReturnSound.Play();
				}
				
			if (theCollision.gameObject.name == "Sword")
			{	
				if(_hitTimer > _hitTime){
				healthBar.fillAmount -= .1f;
				health -= .1f;
				_hitTimer = 0;
				anim.Play("DPlayer");
				rb.AddForce(transform.forward * -1 * 1500f);
				hurt.Play();
				}
			}
		}	
		
		void LateUpdate(){
			
			//control with camera
			if(Input.GetKey(KeyCode.W))
				{
					Quaternion target = Quaternion.Euler(0.0f,camRot.localEulerAngles.y,0.0f);
					transform.rotation = Quaternion.Slerp(transform.rotation,target, Time.deltaTime*10.0f);
				}
			if(Input.GetKey(KeyCode.A))
				{
					Quaternion target = Quaternion.Euler(0.0f,camRot.localEulerAngles.y,0.0f);
					transform.rotation = Quaternion.Slerp(transform.rotation,target, Time.deltaTime*10.0f);
				}
			if(Input.GetKey(KeyCode.D))
				{
					Quaternion target = Quaternion.Euler(0.0f,camRot.localEulerAngles.y,0.0f);
					transform.rotation = Quaternion.Slerp(transform.rotation,target, Time.deltaTime*10.0f);
				}
			if(Input.GetKey(KeyCode.S))
				{
					Quaternion target = Quaternion.Euler(0.0f,camRot.localEulerAngles.y,0.0f);
					transform.rotation = Quaternion.Slerp(transform.rotation,target, Time.deltaTime*10.0f);
				}
			if(Input.GetMouseButton(2))
				{
					Quaternion target = Quaternion.Euler(0.0f,camRot.localEulerAngles.y,0.0f);
					transform.rotation = Quaternion.Slerp(transform.rotation,target, Time.deltaTime*10.0f);
				}
		}
		
		void TurnOffShield(){
			shieldColl.gameObject.SetActive(false);
		}
		
		void TurnOffAxe(){
			AxeColl.enabled = false;
		}

}
