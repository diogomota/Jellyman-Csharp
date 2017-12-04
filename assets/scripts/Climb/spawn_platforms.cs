using UnityEngine;
using System.Collections;

public class spawn_platforms : MonoBehaviour {
	public GameObject floor;
	private float max_h=0;
	private Transform player;
	private float limit=200f;
	private bool spawning=false;
	// Use this for initialization
	void Start () {
		while(max_h<200){
			var h=Random.Range(-8,8);
			var v=Random.Range (1,4);
			Instantiate (floor,new Vector3(h,max_h+v,1),Quaternion.identity);
			max_h+=v;
		}
		max_h=0;
		player=GameObject.Find("player").transform;
	}
	
	// Update is called once per frame
	void Update () {
		if(player.position.y>limit && spawning==false){
			spawning=true;
			spawn_more();
			
		}
	
	}
	void spawn_more(){
		limit+=200;
		while(max_h<limit){
			var h =Random.Range(-8,8);
			var v=Random.Range(1,4);
			Instantiate (floor,new Vector3(h,max_h+v,1),Quaternion.identity);
			max_h+=v;
		}
		spawning=false;
	}
}
