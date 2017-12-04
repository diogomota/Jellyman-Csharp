using UnityEngine;
using System.Collections;

public class Timeout : MonoBehaviour {
	//private Material start;
	//public Material end;
	// Use this for initialization
	void Start(){
		//start = renderer.material;
		StartCoroutine(LeaveScene());
	}
	void Awake ()
	{
    	//StartCoroutine(LeaveScene());
	}
	void Update(){
		/*if(Time.timeSinceLevelLoad>1f){
			//float lerp = Mathf.PingPong(Time.time, 100f) / 100f;
			//this.renderer.material.Lerp(start,end,1);
		}*/
	}
 

	IEnumerator LeaveScene ()
	{
    	yield return new WaitForSeconds(3f);
    	Application.LoadLevel("GUI");
	}
}
