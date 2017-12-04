using UnityEngine;
using System.Collections;

public class horizontal_platform_movement : MonoBehaviour {
	public float distance = 10f;
	private int direction = 1;
	public float speed = 2f;
	float starttimer;
	public bool Reverse;
	public Transform Player;
	// Use this for initialization
	void Start () {
		//store the start value
		if(Reverse)
		{
			direction = -1;
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
		//enter platform from below
		if(Player.position.y<transform.position.y)
		{
			collider.isTrigger=true;
		}
		else
		{
			collider.isTrigger=false;
		}
	}
	void tell_the_speed(bool state){//send platform speed to the player
		if(Player !=null){
			Player.GetComponent<player>().platform_speed = speed * direction;
			//Debug.Log("sent");
		}
	}
}
