using UnityEngine;
using System.Collections;

public class player_rotator : MonoBehaviour {
	public GameObject player;
	float direction_headed;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Time.timeScale!=0){
			direction_headed = player.GetComponent<player>().direction;
			if(direction_headed != 0)
			{
				transform.eulerAngles=new Vector3(0,90*direction_headed,0);
			}
			else
			{
				transform.eulerAngles=new Vector3(0,180,0);
			}
		}
			
	}
}
