using UnityEngine;
using System.Collections;

public class ImgFade : MonoBehaviour {

	public Animator anim;
	public int a = 0;

	// Update is called once per frame
	void Update () {
		while(a<1){
			a++;
			anim.SetInteger("Img",1);
		}
	}
}
