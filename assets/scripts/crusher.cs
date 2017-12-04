using UnityEngine;
using System.Collections;

public class crusher : MonoBehaviour {

	public float distance = 10f;
	private int direction = 1;
	public float speed = 2f;
//	float starttimer;
	// Use this for initialization
	void Start () {
		//store the start value
		//starttimer = distance;
	}
	
	// Update is called once per frame
	void Update () {
		// remove the moved distance in each frame
		//distance -= Time.deltaTime * Mathf.Abs(speed);
		//move code
		transform.Translate(new Vector3(0,speed,0)*Time.deltaTime*direction);
	
	}
	void OnTriggerEnter(Collider other){
		if(other.tag=="Crush_limit"){
			audio.Play();
			direction*=-1;
		}
	}
}
