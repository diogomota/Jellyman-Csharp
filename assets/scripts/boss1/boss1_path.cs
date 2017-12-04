using UnityEngine;
using System.Collections;

public class boss1_path : MonoBehaviour {
	public GameObject laser;
	public int phase=1; //1 = idle 2=attack
	private float distance;
	public int direction=1;
	public float attack_timeout;
	//private int v_dir=1;
	private float v_dis;
	private float laser_timer=.7f;
	public int lives=25;
	public GameObject Mlaser;
	private bool not_spawned=true;
	// Use this for initialization
	void Start () {
		attack_timeout=Random.Range (5,10);
	}
	
	// Update is called once per frame
	void Update () {
		attack_timeout-=Time.deltaTime;
		if(attack_timeout>2){
			light.enabled=false;
		}
		if(attack_timeout<=2){
			light.enabled=true;
		}
		if(attack_timeout<=0){
			phase=2;
		}
		if(phase==1){
			not_spawned=true;
			laser_timer-=Time.deltaTime;
			if(laser_timer<0){
				Instantiate(laser,transform.position,Quaternion.identity);
				laser_timer=.7f;
			}
			transform.Translate(new Vector3(8f,0,0)*Time.deltaTime*direction);
			distance += 4*Time.deltaTime;
			
			if(distance>12){
				direction*=-1;
				distance=0;
			}
		}
		if(phase==2){
			/*transform.Translate(new Vector3(0,0,-25f)*Time.deltaTime*v_dir);
			v_dis +=25*Time.deltaTime;
			
			if(v_dis>14 && v_dir==1){
				v_dir=-1;
				v_dis=0;
			}
			if(v_dis>14 && v_dir==-1){
				v_dis=0;
				v_dir=1;
				attack_timeout=Random.Range (5,10);
				phase=1;
			}*/
			if(not_spawned){
				not_spawned=false;
				var obj = Instantiate(Mlaser,transform.position,Quaternion.identity);
				GameObject.Find(obj.name).transform.parent=transform;
			}
		}
	}
	void OnTriggerEnter(Collider other){
		if(other.tag=="Player"){
			other.GetComponent<Player_mov>().enemy_collision(5);
		}
		if(other.tag=="Player_laser"){
			lives-=1;
			if(lives<0){
				Destroy(this.gameObject);
				var a =new Save_data();
				a.Save();
			}
		}
	}
}
