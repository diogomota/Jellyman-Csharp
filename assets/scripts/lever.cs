using UnityEngine;
using System.Collections;

public class lever : MonoBehaviour {
	public GameObject player;
	public GameObject[] treadmill; //array to control 2+ treadmills from each lever
	
	private float player_direction;
	private int treadmill_direction;
	
	public float delay=0.7f;
	private float countdown;
	// Use this for initialization
	void Start () {
		//define start direction
		if(treadmill[0].GetComponent<Treadmill>().start_left) //for multiple treadmills they must point to the same direction
		{
			animation.Play("left");	
		}
		else{
			animation.Play("right");
		}
		//start counter
		countdown = delay;
	}

	// Update is called once per frame
	void Update(){
		//fetch updated values
		treadmill_direction=treadmill[0].GetComponent<Treadmill>().dir;
		player_direction = player.GetComponent<player>().direction;	
		//countdown
		countdown -=Time.deltaTime;
	}
	void OnTriggerStay(Collider other){
		if(other.tag=="Player")
		{
			if(player_direction != 0 && countdown<0)
			{
				for(int i = 0;i<treadmill.Length;i++)//change direction in all the treadmills
				{
				treadmill[i].GetComponent<Treadmill>().dir *=-1;//invert direction
				}
				//change animation
				if(treadmill_direction==1)
				{
					animation.Play("left");
				}
				if(treadmill_direction==-1)
				{
					animation.Play("right");
				}
				//reset countdown
				countdown=delay;
			}
		}
	}
}
