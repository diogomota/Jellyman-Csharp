using UnityEngine;
using System.Collections;

public class robot_horizontal_movement : MonoBehaviour {
	public float distance = 10f;
	private int direction = 1;
	public float speed = 2f;
	float starttimer;
	public bool Reverse;
	public float lvl14_start_pos =0;
	// Use this for initialization
	void Start () {
		//store the start value
		if(Reverse)
		{
			direction = -1;
		}
		starttimer = distance;
		distance -= lvl14_start_pos;
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
}
