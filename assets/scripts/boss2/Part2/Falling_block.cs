using UnityEngine;
using System.Collections;

public class Falling_block : MonoBehaviour {
	private float distance=25f;
	private Transform player;
	private bool can_move=false;
	public int reverse=1;
	// Use this for initialization
	void Start () {
		player = GameObject.Find("player").transform;
	}
	
	// Update is called once per frame
	void Update () {
		if(Mathf.Abs(player.position.x-transform.position.x)<6){
			can_move=true;
		}
		if(can_move){
			distance -=Time.deltaTime*25;
			if(distance>0){
				transform.Translate(new Vector3(0,-25*Time.deltaTime*reverse,0));
			}
		}
	}
}
