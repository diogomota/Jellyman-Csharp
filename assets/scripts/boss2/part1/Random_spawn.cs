using UnityEngine;
using System.Collections;

public class Random_spawn : MonoBehaviour {
	public GameObject floor;
	private float max_h=0;
	private Transform player;
	// Use this for initialization
	void Start () {
		while(max_h<200){
			var h=Random.Range(-8,8);
			var v=Random.Range (1,4);
			Instantiate (floor,new Vector3(h,max_h+v,1),Quaternion.identity);
			max_h+=v;
		}
		player=GameObject.Find("player").transform;
	}
	
	// Update is called once per frame
	void Update () {
		if(player.position.y>200){
			Application.LoadLevel("level_20_pt2");
		}
	
	}
}
