using UnityEngine;
using System.Collections;

public class CamSlide : MonoBehaviour {

	public Transform P1;
	public Transform P2;
	
	public float speed = 1.0f;
	
	public float StartTime;
	
	public float dis;
	public CamSlide script;
	
	// Use this for initialization
	void Start () {
		StartTime = Time.time;
		dis = Vector3.Distance(P1.position,P2.position);
		Invoke("stopThisScript",4);
	}
	
	// Update is called once per frame
	void Update () {
		float disMade = (Time.time - StartTime) * speed;
		float disC = disMade / dis ;
		transform.position = Vector3.Lerp(P2.position, P1.position, disC);
		
	}
	void stopThisScript(){
		script.enabled = !script.enabled;
	}
}
