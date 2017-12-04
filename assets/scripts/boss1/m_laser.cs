using UnityEngine;
using System.Collections;

public class m_laser : MonoBehaviour {
	private float life_span = 3f;
	// Use this for initialization
	void Start () {
	transform.Rotate(-90,0,0);
	}
	
	// Update is called once per frame
	void Update () {
		life_span-=Time.deltaTime;
		if(life_span<0)
		{	
			transform.parent.GetComponent<boss1_path>().attack_timeout=Random.Range (5,10);
			transform.parent.GetComponent<boss1_path>().phase=1;
			Destroy(gameObject);
		}
	}
	void OnTriggerEnter(Collider other){
		if(other.tag=="Player"){
			other.GetComponent<Player_mov>().enemy_collision(5);
		}
	}
}
