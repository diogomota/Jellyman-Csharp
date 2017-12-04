using UnityEngine;
using System.Collections;

public class lasers : MonoBehaviour {
private int phase=1;
	private float distance;
	private int direction=1;
	public float timer = 2f;
	public Object laser_shot;
	private int count=0;
	private GameObject obj;
	private float x;
	public int lives=2;
	// Use this for initialization
	void Start () {
		obj=GameObject.Find("controller");
		x=transform.position.x;
	}
	
	// Update is called once per frame
	void Update () {
		
		timer -= Time.deltaTime;
		//shot
		if(timer < 0 )
		{
			timer = 1f;
			Instantiate(laser_shot,transform.position,transform.rotation);
			audio.Play();
		}
		
		if(phase==1){
			transform.Translate(new Vector3(0,0,15f)*Time.deltaTime);
			distance += 10*Time.deltaTime;
			if(distance> 2){
				phase=2;
				distance=0;
			}
			
			
		}
		if(phase==2){
			transform.Translate(new Vector3(-8f,0,0)*Time.deltaTime*direction);
			distance += 4*Time.deltaTime;
			
			if(distance>8){
				direction*=-1;
				distance=0;
				count+=1;
			}
			if(count==5){
				//phase = 3;
				StartCoroutine(count_down());
			}
			
		}
		if(phase==3){
			transform.Translate(new Vector3(0,0,20f)*Time.deltaTime);
		}
		if(transform.position.z<-30){
			die(1);
			Destroy(this.gameObject);
		}
		
	}
	void die(int a){
		obj.GetComponent<controller>().respawn_lasers(x,a);
	}
	IEnumerator count_down(){
		yield return new WaitForSeconds(Random.Range(0,6)+Random.value);
		phase=3;
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
