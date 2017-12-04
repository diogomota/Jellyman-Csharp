using UnityEngine;
using System.Collections;

public class boss : MonoBehaviour {
	private float min_speed=2;
	private int multiplier = 7;
	private int reverse =1;
	new public Camera camera;
	private float distance;
	private float reset;
	// Use this for initialization
	void Start () {
		distance =camera.ScreenToWorldPoint(new Vector3(0,camera.pixelHeight)).y-camera.ScreenToWorldPoint(new Vector3(0,0)).y;
		reset = distance;
	}
	
	// Update is called once per frame
	void Update () {
		min_speed+=Time.deltaTime*Time.deltaTime*.3f;
		transform.Translate(new Vector3(min_speed*Time.deltaTime*multiplier,Time.deltaTime*reverse*multiplier,0));
		
		distance -=Time.deltaTime*multiplier;
		if(distance<0){
			reverse*=-1;
			distance = reset;
		}
	}
	void OnTriggerEnter(Collider other)
	{Debug.Log ("Hllo");
		if(other.tag=="crusher"){
			Destroy(this.gameObject);
		}
		if(other.tag=="Player"){
			Application.LoadLevel(Application.loadedLevel);
		}
	}
}
