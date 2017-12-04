using UnityEngine;
using System.Collections;

public class Player_laser : MonoBehaviour {
	
	private float life_span = 6f;
	
	// Use this for initialization
	
	void Start () {
	transform.Rotate(90,0,0);
	}
	
	// Update is called once per frame
	void Update () {
		life_span-=Time.deltaTime;
		if(life_span<0)
		{
			Destroy(gameObject);
		}
		
		transform.Translate(Vector3.up*10*Time.deltaTime);
	}
	void OnTriggerStay(Collider other)
	{	
		if(other.tag == "D_jmp_edge_fix"){
			Destroy(gameObject);
		}
		
	}
}
