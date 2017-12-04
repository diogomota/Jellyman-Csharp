using UnityEngine;
using System.Collections;

public class Random_platform : MonoBehaviour {
	private Transform Player;
	// Use this for initialization
	void Start () {
		Player=GameObject.Find("player").transform;
	}
	
	// Update is called once per frame
	void Update () {
		if(Player.position.y<transform.position.y)
		{
			collider.isTrigger=true;
		}
		else
		{
			collider.isTrigger=false;
		}
		if(Player.position.y-transform.position.y>20){
			Destroy(this.gameObject);
		}
	}
}
