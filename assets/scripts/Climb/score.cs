using UnityEngine;
using System.Collections;

public class score : MonoBehaviour {
	public int Max_hight=0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(transform.position.y>Max_hight){
			Max_hight=(int)transform.position.y;
		}
	}
}
