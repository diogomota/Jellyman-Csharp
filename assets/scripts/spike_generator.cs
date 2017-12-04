using UnityEngine;
using System.Collections;

public class spike_generator : MonoBehaviour {
	public Object spike;
	public float timer=3f;
	public float reset;
	public float max_coordinate;
	
	// Use this for initialization
	void Start () {
		reset = timer;
	}
	
	// Update is called once per frame
	void Update () {
		timer -= Time.deltaTime;
		if(timer < 0){
			Instantiate(spike,transform.position + new Vector3(Random.Range(0,max_coordinate),0,0),transform.rotation);
			timer = reset;
		}
	}
}
