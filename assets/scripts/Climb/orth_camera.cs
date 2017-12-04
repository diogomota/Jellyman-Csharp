using UnityEngine;
using System.Collections;

public class orth_camera : MonoBehaviour {
	public Transform target;
	public float CameraSmoothFactor=0.2f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = Vector3.Lerp(transform.position,new Vector3(0, target.position.y+4, -10),CameraSmoothFactor);
	}
}
