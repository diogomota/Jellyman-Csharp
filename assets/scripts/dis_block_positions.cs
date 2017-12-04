using UnityEngine;
using System.Collections;

public class dis_block_positions : MonoBehaviour {
	public Transform[] positions; //position array
	public float timer=2f;
	private float reset;
	private int posIndex=0;
	public float delay=0;
	// Use this for initialization
	void Start () {
		reset=timer;
		timer +=delay;
	}
	
	// Update is called once per frame
	void Update () {
		timer -= Time.deltaTime;//countdown
		
		transform.position = positions[posIndex].position; //change pos
		
		if(timer <=0)
		{
			posIndex+=1; //change position index
			timer = reset;//reset timer
		}
		if(posIndex >= positions.Length){
			posIndex =0; //reset at the end of the array;
		}
	}
}
