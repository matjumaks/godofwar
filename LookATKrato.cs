using UnityEngine;
using System.Collections;

public class LookATKrato : MonoBehaviour {
	
	public Vector3 target, player;
	public IgnoreCollSword ignoreCollSword;
	public EnemyController enemyController;
	public GameObject EC;
	
	void Start(){
		//target = GameObject.FindGameObjectWithTag("Player").transform.position;	
		enemyController = transform.parent.gameObject.GetComponent<EnemyController>();
	}
	
	// Update is called once per frame
	void Update () {
		/*target = GameObject.FindGameObjectWithTag("Player").transform.position;	
		target = new Vector3 (transform.position.x,-22,transform.position.z);
		transform.LookAt(target);
		transform.rotation = Quaternion.Euler (transform.rotation.eulerAngles.x,transform.rotation.eulerAngles.y,transform.rotation.eulerAngles.z);*/
	}
	
	public void SC(){
		ignoreCollSword.SwordColliedeOn();
	}
	
	//public void SCoff(){
	//	ignoreCollSword.SwordColliedeOff();
	//}
	
	public void Sword(){
		enemyController.Sword();
	}
		
	public void Roar1(){
		enemyController.Roar1();
	}
	
	public void ResumeEnemy(){
		enemyController.ResumeEnemy();
	}
	
	public void Kinematic(){
		enemyController.Kinematic();
	}
}
