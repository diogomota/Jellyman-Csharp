using UnityEngine;
using System.Collections;

public class vertical_platform_level19 : MonoBehaviour {

	public float distance = 10f;
	private int direction = 1;
	public float speed = 2f;
	public Transform Player;
	public bool can_move = false;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if(can_move){
		// remove the moved distance in each frame
		distance -= Time.deltaTime * Mathf.Abs(speed);
		//move code
		transform.Translate(new Vector3(0,speed,0)*Time.deltaTime*direction);
		//invert direction
		//reset distance
		if(distance<0)
		{	
			speed=0;
		}
		}
		if(Player.position.y<transform.position.y)
		{
			collider.isTrigger=true;
		}
		else
		{
			collider.isTrigger=false;
		}
	}
}
