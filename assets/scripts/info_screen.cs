using UnityEngine;
using System.Collections;

public class info_screen : MonoBehaviour {
	public string text;
	public UI_info_text script;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter(Collider other){
		if(other.tag=="Player"){
			text=text.Replace("\\n"	,System.Environment.NewLine);
			script.text1.text=text;
			script.text1.hidden=false;
		}
	}
	void OnTriggerExit(Collider other){
		if(other.tag=="Player"){
			script.text1.hidden=true;
		}
	}
}
