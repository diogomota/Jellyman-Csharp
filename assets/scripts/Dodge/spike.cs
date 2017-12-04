using UnityEngine;
using System.Collections;

public class spike : MonoBehaviour {
	public float speed=5f;
	public float min_h=0;
	public Controller script;
	// Use this for initialization
	void Start () {
		script = GameObject.Find ("Controller").GetComponent<Controller>();
		speed = script.speed;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		transform.Translate(0,speed*Time.deltaTime,0);
		if(transform.position.y<min_h){
			Destroy(gameObject);
			script.score+=1;
		}
		
	}
}
