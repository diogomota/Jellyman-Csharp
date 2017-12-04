using UnityEngine;
using System.Collections;

public class camera_animaion : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Time.timeSinceLevelLoad<=1.5f){
			transform.Translate(new Vector3(0,0,-50)*Time.deltaTime);
		}
	}
}
