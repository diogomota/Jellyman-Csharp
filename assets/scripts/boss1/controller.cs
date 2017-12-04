using UnityEngine;
using System.Collections;

public class controller : MonoBehaviour {
	
	public Transform[] pos;
	public GameObject robot;
	public GameObject laser;
	public GameObject Circular_bot;
	private float count =0;
	public int score=0;
	public int Max_score=1000;
	public GameObject boss;
	private Object boss_spawned;
	
	// Use this for initialization
	void Start () {
		//spawn robots
		for(var i=0; i<=3;i++){
			Instantiate(robot,pos[i].position + new Vector3(0,0,Random.Range(0,5)),Quaternion.identity);
		}
		//spawn lasers
		for(var i=0; i<=3;i++){
			Instantiate(laser,pos[i].position,new Quaternion(0f,180f,0f,0f));
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log(score);
		if(score>=Max_score){
			spawn_boss();
		}
	}
	
	public void respawn(float x,int state){	
		if(score<Max_score){
			Instantiate(robot,new Vector3(x,0,Random.Range(0,10)),Quaternion.identity);
			if(state==0){
				score+=10;
			}
		}
	}
	
	public void respawn_lasers(float x,int state){
		if(score<Max_score){
			count +=0.25f;
			if(state==0){
				score+=20;
			}
			if(count==1)
			{
			
				for(var i=0; i<=3;i++){
					Instantiate(laser,pos[i].position,new Quaternion(0f,180f,0f,0f));
				}
			count=0;
			}	
		}
	}
	public void Respawn_circular_bot(Vector3 pos,Transform parent,int state){
		if(score<Max_score){
			//1
			if(state==0){
				score+=30;
			}
			GameObject circ_bot= (GameObject)Instantiate(Circular_bot,new Vector3(pos.x,pos.y,-7.3f+Random.Range(0,3)),Quaternion.identity);
			StartCoroutine(wait(circ_bot,parent));
		}
		//3
	}
	
	IEnumerator wait(GameObject bot,Transform parent){
		//2
		yield return new WaitForSeconds(Random.Range(0,2));
		//4
		bot.transform.parent=parent;
		
		
	}
	void spawn_boss(){
		if(boss_spawned==null){
			boss_spawned = Instantiate(boss,pos[0].position,Quaternion.identity);
		}
	}
	
}
