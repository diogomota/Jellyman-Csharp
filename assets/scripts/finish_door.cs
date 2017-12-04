using UnityEngine;
using System.Collections;

public class finish_door : MonoBehaviour {
	public float act_distance=5f;
	public GameObject Player;
	private bool closed=true;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		//Animate door open
		if((transform.position-Player.transform.position).magnitude < act_distance && closed){
			closed=false;
			animation.Play ();
		}
		
	}
}
