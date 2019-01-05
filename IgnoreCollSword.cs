using UnityEngine;
using System.Collections;

public class IgnoreCollSword : MonoBehaviour {

	public Animator anim;
	public EnemyController enemy;
	//public Rigidbody rb;
	public Collider sword;

	// Use this for initialization
	void Start () {
			Physics.IgnoreLayerCollision(15,17);
			//rb = enemy.GetComponent<Rigidbody>();
			sword = GetComponent<Collider>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnCollisionEnter(Collision theCollision)
		{
		if (theCollision.gameObject.name == "Palm_L")
			{	
				enemy.test();
			}
		}
		
			public void SwordColliedeOn(){
			sword.enabled = true;
			StartCoroutine("SwordColliedeOff");
		}
	
	IEnumerator SwordColliedeOff(){
			yield return new WaitForSeconds(.5f);
			sword.enabled = false;
		}
}
