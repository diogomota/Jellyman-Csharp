using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour {
	public spike_generator script;
	public int score;
	public float speed=5f;
	// Use this for initialization
	void Start () {
		script = GameObject.Find("spike_generator").GetComponent<spike_generator>();
	}
	
	// Update is called once per frame
	void Update () {
		switch (score){
		case 0:
			script.reset=.4f;
			speed = 11f;
			break;
		
		case 50:
			script.reset=.3f;
			speed = 12f;
			break;
		
		case 100:
			script.reset=.2f;
			speed = 13f;
			break;
		
		case 150:
			speed = 14f;
			break;
		
		case 200:
			script.reset=.1f;
			break;
		
		case 250:
			script.reset=0.09f;
			speed = 15;
			break;
		case 300:
			script.reset=0.08f;
			break;
		case 350:
			script.reset=.07f;
			break;
		case 400:
			script.reset=.06f;
			break;
		default:
			break;
		}
		Debug.Log(score);
	}
}
