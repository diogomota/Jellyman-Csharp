using UnityEngine;
using System.Collections;

public class Treadmill : MonoBehaviour {
	public Texture2D left;
	public Texture2D right;
	public bool start_left=false;
	public int dir;
	// Use this for initialization
	void Start () {
		//set start texture
		if (start_left){
			renderer.material.mainTexture=left;
			dir=-1;
		}
		else{
			renderer.material.mainTexture=right;
			dir=1;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(dir==-1){
			renderer.material.mainTexture=left;
		}
		if(dir==1){
			renderer.material.mainTexture=right;
		}
	}
}
