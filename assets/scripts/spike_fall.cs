using UnityEngine;
using System.Collections;

public class spike_fall : MonoBehaviour {
	public float speed=5f;
	public float min_h=0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		transform.Translate(0,speed*Time.deltaTime,0);
		if(transform.position.y<min_h){
			Destroy(gameObject);
		}
		
	}
	
}
