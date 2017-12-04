using UnityEngine;
using System.Collections;

public class text_UI : MonoBehaviour {
	public UIToolkit Text;
	public UITextInstance text1,text2;
	public Controller script;
	public score script2;
	public controller script3;
	public Player_mov script4;
	public Transform player;
	private int state;
	// Use this for initialization
	void Start () {
		var text = new UIText(Text,"font","font.png");
		//level 10 lives
		if(Application.loadedLevel==11){
			state=4;
			text1=text.addTextInstance("Shields:",0f,0f);
			text1.positionFromTopLeft(0f,0f);
			text1.textScale=Screen.width/900f;
			
			if(!(PlayerPrefs.GetInt("LEVEL")>=10)){//only if it is the first time unlocking
				text2=text.addTextInstance("EXTRA UNLOCKED!",0f,0f);
				text2.positionFromCenter(-.3f,0f);
				text2.textScale=Screen.width/900f;
				text2.hidden=true;
			}
		}
		if(Application.loadedLevel==21){
			
			if(!(PlayerPrefs.GetInt("LEVEL")>=20)){
				state=5;
				text2=text.addTextInstance("EXTRA UNLOCKED!",0f,0f);
				text2.positionFromTopLeft(0,0);
				text2.textScale=Screen.width/900f;
				text2.hidden=true;
			}
		}
		//extras
		if(Application.loadedLevelName=="Dodge"){
			state=1;
			
			if(!PlayerPrefs.HasKey("High_dodge")){
				PlayerPrefs.SetInt("High_dodge",0);
				PlayerPrefs.Save();
			}
			script = GameObject.Find("Controller").GetComponent<Controller>();
			
			text1 = text.addTextInstance("Score",0f,0f);
			text1.positionFromTopLeft(0f,0f);
			text1.textScale=Screen.width/900f;
			
			text2 = text.addTextInstance ("Highscore:",0f,0f);
			text2.positionFromCenter(-0.3f,0f);
			text2.textScale=Screen.width/900f;
			text2.hidden=true;
		}
		if(Application.loadedLevelName=="Climb"){
			state=2;
			
			if(!PlayerPrefs.HasKey("High_climb")){
				PlayerPrefs.SetInt("High_climb",0);
				PlayerPrefs.Save();
			}
			
			script2 = GameObject.Find("score").GetComponent<score>();
			
			text1 = text.addTextInstance("Score",0f,0f);
			text1.positionFromTopLeft(0f,0f);
			text1.textScale=Screen.width/900f;
			
			text2 = text.addTextInstance("Highscore;",0f,0f);
			text2.positionFromCenter(-.3f,0f);
			text2.textScale=Screen.width/900f;
			text2.hidden=true;
			
		}
		if(Application.loadedLevelName=="Shoot"){
			state=3;
			
			if(!PlayerPrefs.HasKey("High_shoot")){
				PlayerPrefs.SetInt("High_shoot",0);
				PlayerPrefs.Save();
			}
			
			script3 = GameObject.Find("controller").GetComponent<controller>();
			
			text1 = text.addTextInstance("Score",0f,0f);
			text1.positionFromTopLeft(0f,0f);
			text1.textScale=Screen.width/900f;
			
			text2 = text.addTextInstance("Highscore;",0f,0f);
			text2.positionFromCenter(-.3f,0f);
			text2.textScale=Screen.width/900f;
			text2.hidden=true;
			
		}
		
		
	}
	
	// Update is called once per frame
	void Update () {
		if(state==1){
			text1.text="Score:"+ script.score;
			if(Time.timeScale==0){
				text2.text="Highscore:"+PlayerPrefs.GetInt("High_dodge");
				text2.hidden=false;
			}else{
				text2.hidden=true;
			}
		}
		if(state==2){
			text1.text="Score:"+script2.Max_hight;
			if(Time.timeScale==0){
				text2.text="Highscore:"+PlayerPrefs.GetInt("High_climb");
				text2.hidden=false;
			}else{
				text2.hidden=true;
			}
		}
		if(state==3){
			text1.text="Score:"+script3.score;
			if(Time.timeScale==0){
				text2.text="Highscore:"+PlayerPrefs.GetInt("High_shoot");
				text2.hidden=false;
			}else{
				text2.hidden=true;
			}
		}
		if(state==4){
			if(script4.lives>=0){
				text1.text="Shields:"+script4.lives;
			}
		}
		if(state==5){
		if(text2.hidden && player.position.y>175){
				text2.hidden=false;
				PlayerPrefs.SetInt("LEVEL",20);
				PlayerPrefs.Save();
			}
		}
	}
	void extra_unlocked(){
		text2.hidden=false;
	}
}
