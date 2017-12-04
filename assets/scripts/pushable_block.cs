using UnityEngine;
using System.Collections;

public class pushable_block : MonoBehaviour {
	public GameObject player;
	float dir_values;
	
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if(player != null)
		{
		dir_values = player.GetComponent<player>().direction;
		}
	}
	void OnTriggerStay(Collider collision_object)
	{	
		if(collision_object.tag=="Player")
		{
			if(dir_values == 1 && transform.position.x > collision_object.transform.position.x)
			{
				rigidbody.MovePosition(rigidbody.position + new Vector3(4,0,0)*Time.deltaTime);
			}
			if(dir_values == -1 && transform.position.x < collision_object.transform.position.x)
			{
				rigidbody.MovePosition(rigidbody.position + new Vector3(-4,0,0)*Time.deltaTime);
			}
			if(dir_values == 0)
			{
				rigidbody.MovePosition(rigidbody.position);
			}
		}
		if(collision_object.tag == "treadmill")
		{
				rigidbody.MovePosition(rigidbody.position +  new Vector3(4,0,0)*collision_object.GetComponent<Treadmill>().dir * Time.deltaTime);
		}
		
	}

}
