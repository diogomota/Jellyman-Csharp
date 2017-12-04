using UnityEngine;
using System.Collections;

public class Circular_bot_path : MonoBehaviour {
		private Vector3 start_pos;
		private GameObject obj;
		public Transform parent_obj;
		public int lives=3;
	// Use this for initialization
	void Start () {
			start_pos=transform.position;
			//Debug.Log (start_pos);
		obj=GameObject.Find("controller");
	}
	
	// Update is called once per frame
	void Update () {
		if(transform.parent!=null){
			
			transform.Rotate(0,transform.parent.GetComponent<Rotator>().speed*-Time.deltaTime,0);
			
			if(transform.position.z+transform.parent.position.z<-40){
				die(1);
				Destroy(this.gameObject);
			}
		}
	}
	void die(int a){
		obj.GetComponent<controller>().Respawn_circular_bot(start_pos,transform.parent,a);
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
