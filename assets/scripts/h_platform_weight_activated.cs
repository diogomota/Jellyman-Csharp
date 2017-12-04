using UnityEngine;
using System.Collections;

public class h_platform_weight_activated : MonoBehaviour {

	public float distance = 10f;
	private int direction = 1;
	public float speed = 2f;
	public bool Reverse;
	public bool can_move = false;
	private Vector3 start_pos;
	private float start_distance;
	private float start_speed;
	public GameObject player;
	// Use this for initialization
	void Start () {
		start_speed=speed;
		start_distance = distance;
		start_pos = transform.position;
		//store the start value
		if(Reverse)
		{
			direction = -1;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(can_move)
		{
			// remove the moved distance in each frame
			distance -= Time.deltaTime * speed;
			//move code
			transform.Translate(new Vector3(speed,0,0)*Time.deltaTime*direction);
			//stop at the end;
			if(distance<0)
			{	
				speed=0;
			}
		}
	}
	void ResetPos(){
		speed = start_speed;
		distance = start_distance;
		can_move = false;
		transform.position=start_pos;
	}
	void tell_the_speed(bool state){//send platform speed to the player
		if(player !=null){
			player.GetComponent<player>().platform_speed = speed * direction;
			//Debug.Log("sent");
		}
	}
}
