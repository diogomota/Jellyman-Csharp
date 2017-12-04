using UnityEngine;
using System.Collections;

public class Laser_button_disable : MonoBehaviour {
	public GameObject laser_set;
	// Use this for initialization
	void Start () {
	Physics.gravity=new Vector3(0,-20,0);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter(){
		if (laser_set !=null)
		{
			GameObject.Destroy(laser_set);
			animation.Play("off");
		}
	 Light button_light = GetComponent<Light>();
		if ( button_light != null)
		{
			button_light.enabled=false;
		}
	}
}
