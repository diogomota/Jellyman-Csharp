using UnityEngine;
using System.Collections;

public class Player_mov : MonoBehaviour {
	public int direction=0;
	public int lives=5;
	public bool jump=false;//used to fire in this obj
	public GameObject laser;
	public float x_coord;
	new public Camera camera;
	// Use this for initialization
	void Start () {
		x_coord=transform.position.x;//limit x_movement
	}
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Space)){
			jump=true;
		}
		if(jump){
			Instantiate(laser,transform.position,Quaternion.identity);
			audio.Play();
			jump=false;
		}
		if(lives<0){
			death_code();
		}
		if(Input.GetKey(KeyCode.LeftArrow)){
			direction=-1;
		}
		if(Input.GetKey(KeyCode.RightArrow)){
			direction=1;
		}
		if(!Input.anyKey){
			direction=0;
		}
		//right
		if(direction==1){
			if(transform.position.x<camera.ScreenToWorldPoint(new Vector3(camera.pixelWidth,0,0)).x-1){
				transform.Translate(new Vector3(20f,0,0)*Time.deltaTime);
				}
		}
		//left
		if(direction==-1){
			if(transform.position.x>camera.ScreenToWorldPoint(new Vector3(0,0,0)).x+1){
				transform.Translate(new Vector3(-20f,0,0)*Time.deltaTime);
			}
			
		}
	}
	public void enemy_collision(int subtract){
		lives-=subtract;
	}
	void OnTriggerEnter(Collider other){
		if(other.tag=="Laser"){
			enemy_collision (1);
		}
	}
	void death_code(){
		if(Application.loadedLevelName=="Shoot"){
			GameObject.Find("UI_Drawer").GetComponent<InGameUI>().Extras_death_menu();
			if(PlayerPrefs.GetInt("High_shoot")<GameObject.Find("controller").GetComponent<controller>().score){
					PlayerPrefs.SetInt("High_shoot",GameObject.Find("controller").GetComponent<controller>().score);
					PlayerPrefs.Save();
			}
			return;
		}
		Application.LoadLevel(Application.loadedLevel);
	}
}
