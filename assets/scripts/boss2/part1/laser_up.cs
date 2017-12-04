using UnityEngine;
using System.Collections;

public class laser_up : MonoBehaviour {
	public float speed = 5;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(new Vector3(speed*Time.deltaTime,0,0));
	}
}
