using UnityEngine;
using System.Collections;

public class player_anim : MonoBehaviour {
	private Player_controll script;
	// Use this for initialization
	void Start () {
	script=transform.parent.GetComponent<Player_controll>();
	}
	
	// Update is called once per frame
	void Update () {
		Quaternion target = Quaternion.Euler(new Vector3(0,90,0)+new Vector3(0,0,35*script.V_dir));
		transform.rotation = Quaternion.Slerp(transform.rotation,target,Time.deltaTime*5f);
	}
}
