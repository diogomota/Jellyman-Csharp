using UnityEngine;
using System.Collections;

public class InGameUI : MonoBehaviour {
	
	public UIToolkit InGameMenu;
	private UIVerticalLayout v_container;
	private UIHorizontalLayout h_container;
	private UIButton next_lvl;
	private UIButton jump;
	private UIButton left;
	private UIButton right;
	private UIJoystick joystick;
	
	private int currentlvl;
	public GameObject Player;
	private player script;
	private  Player_mov script_lvl10;
	// Use this for initialization
	void Start () {
		float scale_factor=Screen.width/900f;
		currentlvl= Application.loadedLevel;
		// gain access to player script
		if(currentlvl!=11){
			script = Player.GetComponent<player>();
		}
		if(currentlvl==11 || Application.loadedLevelName=="Shoot"){
			script_lvl10 = Player.GetComponent<Player_mov>();
		}
		//joystick
		joystick = UIJoystick.create(InGameMenu,"arrow_square.png",new Rect(0,Screen.height/3,Screen.width/3,Screen.height/3),Screen.width/6,Screen.height/6);
		joystick.deadZone=new Vector2(0,0);
		joystick.positionFromBottomLeft(0,0);
		joystick.allowTouchBeganWhenMovedOver=true;
		//create control buttons
		/*left = UIButton.create(InGameMenu,"arrow_square.png","arrow_square.png",0,0);
		left.setSize(left.width*2*scale_factor,left.height*2*scale_factor);
		left.onTouchDown += moving_left;
		//left.onTouchUp +=not_moving_left;
		left.positionFromBottomLeft(0,0);
		left.highlighted=true;
		
		right = UIButton.create(InGameMenu,"arrow_square.png","arrow_square.png",0,0);
		right.setSize(right.width*2*scale_factor,right.height*2*scale_factor);
		right.onTouchDown += moving_right;
		right.onTouchUp +=not_moving_right;
		right.positionFromBottomRight(0,0);
		right.highlighted=true;*/
		
		jump = UIButton.create(InGameMenu,"jump.png","jump.png",0,0);
		jump.setSize(jump.width*3.5f*scale_factor/2f,jump.height*3.5f*scale_factor/2f);
		jump.onTouchDown +=jumping;
		jump.positionFromBottomRight(0,0);
		jump.highlighted=true;
		jump.index=10;
		
		//Pause & sound 
		var pause = UIButton.create(InGameMenu,"pause.png","pause_pressed.png",0,0);
		pause.setSize(pause.width*scale_factor,pause.height*scale_factor);
		pause.onTouchUpInside += pause_start;
		pause.positionFromTopRight(.01f,.01f);
		
		
		var names = new string[]{"sound_on.png","sound_off.png"};
		var sound = UIStateButton.create(InGameMenu,names,names,0,0);
		sound.setSize(sound.width*scale_factor,sound.height*scale_factor);
		sound.onStateChange += Sound_control;
		sound.positionFromTopRight(.01f,.12f);
		//to pass info between levels
		if(AudioListener.pause){
			sound.state=1;
		}
		
		//next lvl
		next_lvl = UIButton.create(InGameMenu,"next.png","next_pressed.png",0,0);
		next_lvl.setSize(next_lvl.width*scale_factor,next_lvl.height*scale_factor);
		next_lvl.onTouchUpInside += Go_to_next_lvl;
		next_lvl.hidden=true;
		
		//Paused interface
		var continue_btn = UIButton.create (InGameMenu,"continue.png","continue_pressed.png",0,0);
		continue_btn.setSize(continue_btn.width*scale_factor,continue_btn.height*scale_factor);
		continue_btn.centerize();
		continue_btn.onTouchUpInside += Resume_game;
		
		var main_menu = UIButton.create (InGameMenu,"main_menu.png","main_menu_pressed.png",0,0);
		main_menu.setSize(main_menu.width*scale_factor,main_menu.height*scale_factor);
		main_menu.onTouchUpInside += Go_to_Menu;
		
		var restart = UIButton.create (InGameMenu,"restart.png","restart_pressed.png",0,0);
		restart.setSize(restart.width*scale_factor,restart.height*scale_factor);
		restart.onTouchUpInside += Restart_game;
		
		h_container = new UIHorizontalLayout(Screen.width/19);
		h_container.addChild(main_menu,restart);
		
		v_container = new UIVerticalLayout(10);
		v_container.beginUpdates();
		v_container.addChild(continue_btn);
		v_container.pixelsFromCenter((int)(-continue_btn.height),(int)(-continue_btn.width/2));
		v_container.endUpdates();
		
		h_container.parentUIObject = v_container;
		h_container.pixelsFromTopLeft((int)(continue_btn.height),0);
		v_container.hidden=true;
		h_container.hidden=true;
	}
	void Update(){
		/*if(Input.touchCount==0){
			script.direction=0;
		}*/
		if(Input.GetKeyDown(KeyCode.Escape)){
			hardware_pause_start();
		}
#if !(UNITY_EDITOR) && !(UNITY_STANDALONE)
		if(currentlvl==10 || Application.loadedLevelName=="Shoot"){
			if(joystick.joystickPosition.x>0.1){
				script_lvl10.direction=1;
			}
			if(joystick.joystickPosition.x<-0.1){
				script_lvl10.direction=-1;
			}
			if(joystick.joystickPosition.x>-0.1 && joystick.joystickPosition.x<0.1){
				script_lvl10.direction=0;
			}
		}else{
			if(joystick.joystickPosition.x>0.05){
				script.direction=1;
			}
			if(joystick.joystickPosition.x<-0.05){
				script.direction=-1;
			}
			if(joystick.joystickPosition.x>-0.05 && joystick.joystickPosition.x<0.05){
				script.direction=0;
			}
		}
#endif
		Debug.Log(joystick.joystickPosition.x);
	}
	void Sound_control(UIStateButton sender,int state){//mute control
		if(state==0){
			AudioListener.pause=false;
		}
		if(state==1){
			AudioListener.pause=true;
		}
	}
	void pause_start(UIButton sender){
		Time.timeScale=0;
		v_container.hidden=false;
		h_container.hidden=false;
		jump.hidden=true;
		//left.hidden=true;
		//right.hidden=true;
		joystick.hidden=true;
	}
	public void Extras_death_menu(){
		Time.timeScale=0;
		h_container.hidden=false;
		jump.hidden=true;
		joystick.hidden=true;
	}
	void hardware_pause_start(){
		Time.timeScale=0;
		v_container.hidden=false;
		h_container.hidden=false;
		jump.hidden=true;
		//left.hidden=true;
		//right.hidden=true;
		joystick.hidden=true;
	}
	void Resume_game(UIButton sender){
		Time.timeScale=1;
		v_container.hidden=true;
		h_container.hidden=true;
		jump.hidden=false;
		//left.hidden=false;
		//right.hidden=false;
		joystick.hidden=false;
	}
	void Go_to_Menu(UIButton sender){
		Time.timeScale=1;
		Application.LoadLevel("GUI");
	}
	void Restart_game(UIButton sender){
		Time.timeScale=1;
		Application.LoadLevel(Application.loadedLevel);
		
	}
	void Go_to_next_lvl(UIButton sender){
		Time.timeScale=1;
		Application.LoadLevel(Application.loadedLevel+1);
	}
	public void next_lvl_menu(){
		Time.timeScale=0;
		h_container.beginUpdates();
		h_container.addChild(next_lvl);
		h_container.parentUIObject=null;
		h_container.refreshPosition();
		h_container.positionFromTopLeft(.4f,.33f);
		h_container.endUpdates();
		h_container.hidden=false;
		jump.hidden=true;
		//left.hidden=true;
		//right.hidden=true;
		joystick.hidden=true;
	}
	/*void moving_left(UIButton sender){
		script.direction=-1;
	}
	void not_moving_left(UIButton sender){
		//script.direction=0;
	}
	void moving_right(UIButton sender){

		script.direction=1;
	}
	void not_moving_right(UIButton sender){

		//script.direction=0;
	}*/
	void jumping(UIButton sender){
		if(currentlvl!=11 && Application.loadedLevelName!="Shoot"){
			script.jump=true;
		}else{script_lvl10.jump=true;}
	}
	
}

