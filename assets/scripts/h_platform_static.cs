using UnityEngine;
using System.Collections;

public class h_platform_static : MonoBehaviour {
	public float distance = 10f;
	private int direction = 1;
	public float speed = 2f;
	float starttimer;
	public bool Reverse;
	//store variables
	private int store_dir=1;
	private float store_speed;
	// Use this for initialization
	void Start () {
		//store the start value
		if(Reverse)
		{
			direction = -1;
			store_dir=-1;
		}
		starttimer = distance;
	}
	
	
	// Update is called once per frame
	void Update () {
		// remove the moved distance in each frame
		distance -= Time.deltaTime * speed;
		//move code
		transform.Translate(new Vector3(speed,0,0)*Time.deltaTime*direction);
		//invert direction
		//reset distance
		if(distance<0)
		{	
			distance = starttimer;
			direction *= -1;
		}
	}
	void StopOnPlayerStay(bool state){ //message sent by player
		
		if(state){
			// store values and make them 0
			store_speed=speed;
			speed = 0;
			store_dir = direction;
			direction = 0;
		}
		if(!state){
			//restore previous values
			speed = store_speed;
			direction = store_dir;
		}
	}
	
}
