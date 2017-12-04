using UnityEngine;
using System.Collections;

public class player_controll : MonoBehaviour {
	public int direction=0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
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
				Quaternion target = Quaternion.Euler(new Vector3(0,0,-45));
				transform.rotation = Quaternion.Slerp(transform.rotation,target,Time.deltaTime*5f);
				
		}
		//left
		if(direction==-1){
				Quaternion target = Quaternion.Euler(new Vector3(0,0,45));
				transform.rotation = Quaternion.Slerp(transform.rotation,target,Time.deltaTime*5f);
			}
		if(direction==0){
				Quaternion target = Quaternion.Euler(new Vector3(0,0,0));
				transform.rotation = Quaternion.Slerp(transform.rotation,target,Time.deltaTime*7f);
		}
			
		}
}
