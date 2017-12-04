using UnityEngine;
using System.Collections;

public class level6_lever : MonoBehaviour {

	public GameObject player;
	public GameObject treadmill;
	public Transform[] pos;
	
	private float player_direction;
	private int reverse_state=-1;
		
	public float delay=0.7f;
	private float countdown;
	// Use this for initialization
	void Start () {
		//start inactive
		if(reverse_state==-1)
		{
			animation.Play("right");
			treadmill.gameObject.transform.position	= pos[0].position;
		}
		//start counter
		countdown = delay;
	}

	// Update is called once per frame
	void Update(){
		//fetch updated values
		player_direction = player.GetComponent<player>().direction;	
		//countdown
		countdown -=Time.deltaTime;
	}
	void OnTriggerStay(Collider other){
		if(other.tag=="Player")
		{
			if(player_direction != 0 && countdown<0)
			{
				//change direction in all the treadmills

				reverse_state *=-1;//invert direction
				
				//change animation
				if(reverse_state==1)
				{
					animation.Play("left");
								treadmill.gameObject.transform.position	= pos[1].position;
					//treadmill.gameObject.SetActiveRecursively(true);
				}
				if(reverse_state==-1)
				{
					animation.Play("right");
								treadmill.gameObject.transform.position	= pos[0].position;
					//treadmill.gameObject.SetActiveRecursively(false);
				}
				//reset countdown
				countdown=delay;
			}
		}
	}
}
