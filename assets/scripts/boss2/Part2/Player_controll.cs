using UnityEngine;
using System.Collections;

public class Player_controll : MonoBehaviour {
	public float H_dir=0f;
	public float V_dir=0f;
	public float min_speed=0f;
	new public Camera camera;
	private int multiplier=7;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
#if UNITY_EDITOR || UNITY_STANDALONE
		V_dir=0;
		H_dir=0;
		if(Input.GetKey(KeyCode.DownArrow)){
			V_dir=-1f;
		}
		if(Input.GetKey (KeyCode.UpArrow)){
			V_dir=1f;
		}
		if(Input.GetKey(KeyCode.LeftArrow)){
			H_dir=-1f;
		}
		if(Input.GetKey (KeyCode.RightArrow)){
			H_dir=1f;
		}
#endif
		if(V_dir<0){
			if(transform.position.y<camera.ScreenToWorldPoint(new Vector3(0,0)).y+1f){
				V_dir=0f;
			}
		}
		if(V_dir>0){
			if(transform.position.y>camera.ScreenToWorldPoint(new Vector3(0,camera.pixelHeight)).y-1f){
				V_dir=0f;
			}
		}
		if(H_dir<0){
			if(transform.position.x<camera.ScreenToWorldPoint(new Vector3(0,0)).x+2f){
				H_dir=0f;
			}
		}
		if(H_dir>0){
			if(transform.position.x>camera.ScreenToWorldPoint(new Vector3(camera.pixelWidth,0)).x-2f){
				H_dir=0;
			}
		}
			transform.Translate(new Vector3((min_speed+H_dir)*Time.deltaTime*multiplier,V_dir*Time.deltaTime*multiplier,0));
		if(transform.position.x>310){
			Application.LoadLevel(0);
		}
	}
	void OnCollisionEnter()
	{
		Application.LoadLevel(Application.loadedLevel);
	}
}
