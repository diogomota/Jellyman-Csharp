using UnityEngine;
using System.Collections;

public class Rotator : MonoBehaviour {
	public float speed=100f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		transform.Rotate(0,Time.deltaTime*speed,0);
	}
}
