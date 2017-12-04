using UnityEngine;
using System.Collections;

public class robot_anim : MonoBehaviour {
	
	private float distance;
	private int direction=1;
	private GameObject obj;
	public int val;
	private float x;
	public int lives=2;
	
	// Use this for initialization
	void Start () {
		obj=GameObject.Find("controller");
		x=transform.position.x;
	}
	
	// Update is called once per frame
	void Update () {
			transform.Translate(new Vector3(0,0,-4f)*Time.deltaTime);
			transform.Translate(new Vector3(8f,0,0)*Time.deltaTime*direction);
		
			distance += 4*Time.deltaTime;
			
			if(distance>3){
				direction*=-1;
				distance=0;
			}
		if(transform.position.z<-30){
			die(1);
			Destroy(this.gameObject);
		}
		
			
	}
	void die(int a){
		obj.GetComponent<controller>().respawn(x,a);
	}
	void OnTriggerEnter(Collider other){
		if(other.tag=="Player"){
			other.GetComponent<Player_mov>().enemy_collision(1);
			die (0);
			Destroy(this.gameObject);
		}
		if(other.tag=="Player_laser"){
			lives-=1;
			if(lives<0){
				die (0);
				Destroy(this.gameObject);
			}
		}
	}
	
}
