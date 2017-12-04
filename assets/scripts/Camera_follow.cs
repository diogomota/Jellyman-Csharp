using UnityEngine;
using System.Collections;

public class Camera_follow : MonoBehaviour {
	public Transform target;
	public float CameraSmoothFactor=0.2f;
	public float zoom=10;
	public float y=3;
	// Use this for initialization
	void Start () {
	
	}
	// Update is called once per frame
	void LateUpdate () {
		// Camera Smooth Motion
		//(Start.pos ; final.pos; step)
		if(!Input.GetKey(KeyCode.V))
		{
			transform.position = Vector3.Lerp(transform.position,target.position + new Vector3(0, y, -zoom),CameraSmoothFactor);  
		}
		if(Input.GetKey(KeyCode.V))
		{
			transform.position = Vector3.Lerp(transform.position,target.position + new Vector3(0, y, -zoom-20),CameraSmoothFactor);
		}
	}
}
