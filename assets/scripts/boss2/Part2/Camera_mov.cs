using UnityEngine;
using System.Collections;

public class Camera_mov : MonoBehaviour {
	public float min_speed;
	private int multiplier = 7;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(new Vector3(min_speed*Time.deltaTime*multiplier,0,0));
	}
}
