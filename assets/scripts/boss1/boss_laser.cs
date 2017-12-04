using UnityEngine;
using System.Collections;

public class boss_laser : MonoBehaviour {
	private float life_span=7f;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		life_span-=Time.deltaTime;
		if(life_span<0)
		{
			Destroy(gameObject);
		}
		
		transform.Translate(Vector3.up*-15*Time.deltaTime);
	}
}
