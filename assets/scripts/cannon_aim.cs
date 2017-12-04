using UnityEngine;
using System.Collections;

public class cannon_aim : MonoBehaviour {
	public Transform target;
	public float timer = 2f;
	public Object laser_shot;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//aim
		transform.LookAt(target);
		timer -= Time.deltaTime;
		//shot
		if(timer < 0 )
		{
			timer = 1f;
			Instantiate(laser_shot,transform.position,transform.rotation);
			audio.Play();
		}
	}
}
