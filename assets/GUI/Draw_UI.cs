using UnityEngine;
using System.Collections;

public class Draw_UI : MonoBehaviour {
	//EDGEINSETS v1 was screen.height/9 no screen.heigt*.18f
	public UIToolkit backgroundToolkit;
	public UIToolkit menuToolkit;
	
	private bool startanim=false;
	
	private UIHorizontalLayout horiz; 
	private UIGridLayout grid1;
	private UIGridLayout grid2;
	private UIGridLayout grid3;
	private UIStateSprite loading;
	public int state=0;
	// Use this for initialization
	void Start () {
		//Create a save game if not created
		if(!PlayerPrefs.HasKey("LEVEL")){
			PlayerPrefs.SetInt("LEVEL",0);
		}
		//////////////
		//Background//
			var background = UIStateSprite.create(backgroundToolkit,"Backgound.png",0,0);
			var scale_factor = Screen.width/background.width;
			background.setSize(background.width*scale_factor,background.height*scale_factor);
			background.positionCenter();
		//background end//
		//LOADING//
			loading = UIStateSprite.create(backgroundToolkit,"Loading.png",0,0);
			loading.setSize(loading.width*scale_factor,loading.height*scale_factor);
			loading.positionFromBottom(0,0);
			loading.hidden=true;
		//#############MAIN MENU###########//
		//################################//
		
		
			//PLAY
			var Playbutton = UIButton.create( menuToolkit,"Play.png","Play_pressed.png", 0, 0);
			Playbutton.setSize(Playbutton.width*scale_factor,Playbutton.height*scale_factor);
			Playbutton.onTouchUpInside += onTouchUpInsidePlay;
			//Playbutton.positionFromCenter(-.33f,0f);
			//extras
			var Extrasbutton = UIButton.create(menuToolkit,"Extras.png","Extras_pressed.png",0,0);
			Extrasbutton.setSize(Extrasbutton.width*scale_factor,Extrasbutton.height*scale_factor);
			Extrasbutton.onTouchUpInside += onTouchUpInsideExtras;
			//Extrasbutton.positionFromCenter(0f,0f);
			//Quit
			var Quitbutton = UIButton.create (menuToolkit,"Quit.png","Quit_pressed.png",0,0);
			Quitbutton.setSize(Quitbutton.width*scale_factor,Quitbutton.height*scale_factor);
			Quitbutton.onTouchUpInside += exit_game;
			//Quitbutton.positionFromCenter(.33f,0f);
		
		
		//################CHAPTER SELECT########//
		//#####################################//
		
		
			var scrollable = new UIScrollableHorizontalLayout( 20 );
			scrollable.beginUpdates();
			// if you plan on making the scrollable wider than the item width you need to set your edgeInsets so that the
			// left + right inset is equal to the extra width you set
			scrollable.edgeInsets = new UIEdgeInsets( (int)(Screen.height*.18f), (int)(Screen.width-(300*scale_factor))/2, 0, (int)(Screen.width-(300*scale_factor))/2 );
			scrollable.setSize(Screen.width,Screen.height);
			
			scrollable.pagingEnabled = true;
			scrollable.pageWidth =Screen.width;
			// Screen.width - Screen.width*(2/3) ) / 2
			scrollable.position = new Vector3(Screen.width, 0, 0 );
		
			//add 1st chapter no matter what
					var chap1 = UIButton.create (backgroundToolkit,"chap_1.png","chap_1_pressed.png",0,0);
					chap1.btn_val=1;
					chap1.onTouchUpInside +=chapter_btn_down;
					chap1.setSize(chap1.width*scale_factor,chap1.height*scale_factor);
					scrollable.addChild(chap1);
					chap1.zIndex=-1; // to be on top of the background(same texture atlas)

			//chapter 2 btn
					var chap2 = UIButton.create (menuToolkit,"chap_2.png","chap_2_pressed.png",0,0);
					chap2.btn_val=2;
					chap2.onTouchUpInside +=chapter_btn_down;
					chap2.setSize(chap2.width*scale_factor,chap2.height*scale_factor);
					scrollable.addChild(chap2);

			scrollable.endUpdates();
			scrollable.endUpdates();
		
		
		//########## LEVEL SELECT BUTTONS ############//
		//###########################################//
		
		
			//level-1-10
			grid1 = new UIGridLayout(2,5,2);
			grid1.edgeInsets=new UIEdgeInsets( 0, (int)(Screen.width*.03f), 0, (int)(Screen.height*.18f) );
			
			UISprite[] lvl_btns_1 = new UISprite[10];
			
			for (var i=0;i<=9;i++){
			if(i<PlayerPrefs.GetInt("LEVEL")+1){
				var lvl_btn = UIButton.create (menuToolkit,"lvl_"+(i+1)+".png","lvl_"+(i+1)+"_pressed.png",0,0);
				lvl_btn.setSize(lvl_btn.width*scale_factor,lvl_btn.height*scale_factor);
				lvl_btn.btn_val = i+1;
				lvl_btn.onTouchUpInside += level_selected;
				lvl_btns_1[i]=lvl_btn;
			}else{
					var lvl_btn=UIButton.create (menuToolkit,"lvl_locked.png","lvl_locked.png",0,0);
					lvl_btn.setSize(lvl_btn.width*scale_factor,lvl_btn.height*scale_factor);
					lvl_btns_1[i]=lvl_btn;
			
			}
			}
			grid1.addChild(lvl_btns_1);
			grid1.position = new Vector3((2*Screen.width)*1.1f,0,0);
		
			//level 10-20
		
			grid2 = new UIGridLayout(2,5,2);
			grid2.edgeInsets=new UIEdgeInsets( 0, (int)(Screen.width*.03f), 0, (int)(Screen.height*.18f) );
			
			UISprite[] lvl_btns_2 = new UISprite[10];
			
			for (var i=0;i<=9;i++){
			if(i+10<PlayerPrefs.GetInt("LEVEL")+1){
				var lvl_btn = UIButton.create (menuToolkit,"lvl_"+(i+11)+".png","lvl_"+(i+11)+"_pressed.png",0,0);
				lvl_btn.setSize(lvl_btn.width*scale_factor,lvl_btn.height*scale_factor);
				lvl_btn.btn_val = i+11;
				lvl_btn.onTouchUpInside += level_selected;
				lvl_btns_2[i]=lvl_btn;
			}else{
					var lvl_btn=UIButton.create (menuToolkit,"lvl_locked.png","lvl_locked.png",0,0);
					lvl_btn.setSize(lvl_btn.width*scale_factor,lvl_btn.height*scale_factor);
					lvl_btns_2[i]=lvl_btn;
			}
				
				
			}
			grid2.addChild(lvl_btns_2);
			grid2.position = new Vector3((2*Screen.width)*1.1f,0,0);
		
		//########### EXTRAS ############//
		//##############################//
		
		UISprite[] extras = new UISprite[3];
		grid3 = new UIGridLayout(1,3,30);
		grid3.edgeInsets=new UIEdgeInsets( 0, (int)(Screen.width/5), (int)(2*Screen.width/3), (int)(Screen.height*.18f) );

		var dodge = UIButton.create(menuToolkit,"dodge.png","dodge_pressed.png",0,0);
		dodge.setSize(dodge.width*scale_factor*1.1f,dodge.height*scale_factor*1.1f);
		dodge.btn_val=1;
		dodge.onTouchUpInside +=extras_selected;
		extras[0]=dodge;
		
		if(PlayerPrefs.GetInt("LEVEL")>=10){
			var shoot = UIButton.create(menuToolkit,"shoot.png","shoot_pressed.png",0,0);
			shoot.setSize(shoot.width*scale_factor*1.1f,shoot.height*scale_factor*1.1f);
			shoot.btn_val=3;
			shoot.onTouchUpInside +=extras_selected;
			extras[1]=shoot;
		}else{
			var shoot = UIButton.create(menuToolkit,"lvl_locked.png","lvl_locked.png",0,0);
			shoot.setSize(shoot.width*scale_factor*1.4f,shoot.height*scale_factor*1.4f);
			extras[1]=shoot;
		}
		
		if(PlayerPrefs.GetInt("LEVEL")>=20){
		
			var climb = UIButton.create(menuToolkit,"climb.png","climb_pressed.png",0,0);
			climb.setSize(climb.width*scale_factor*1.1f,climb.height*scale_factor*1.1f);
			climb.btn_val=2;
			climb.onTouchUpInside +=extras_selected;
			extras[2]=climb;
		}else{
			var climb = UIButton.create(menuToolkit,"lvl_locked.png","lvl_locked.png",0,0);
			climb.setSize(climb.width*scale_factor*1.4f,climb.height*scale_factor*1.4f);
			extras[2]=climb;
		}
		grid3.addChild(extras);
		grid3.position= new Vector3(-Screen.width,0,0);

		
		//END EXTRAS//
		
		// add menu buttons to a panel for easy scroll animation
			var Panel = new UIVerticalLayout(30);
			Panel.beginUpdates();
			Panel.positionFromTopLeft(0f,.333f);
			Panel.edgeInsets = new UIEdgeInsets( (int)(Screen.height*.18f), ((Screen.width/3))/4, 0, -10+(Screen.width/3) );
			Panel.addChild( Playbutton, Extrasbutton, Quitbutton);
			Panel.endUpdates();
		
		horiz = new UIHorizontalLayout(50);
		var space_1 = new UISpacer(Screen.width,Screen.height);
		var space_2 =new UISpacer(Screen.width,Screen.height);
		var space_3 = new UISpacer(Screen.width,Screen.height);
		horiz.addChild(space_1,space_2,space_3);
		scrollable.parentUIObject= horiz;
		Panel.parentUIObject = horiz;
		grid1.parentUIObject=horiz;
		grid1.hidden=true;
		grid2.parentUIObject =horiz;
		grid2.hidden=true;
		grid3.parentUIObject=horiz;
		
	}
	void Update(){
		if(Input.GetKeyDown(KeyCode.Escape)){
			state-=1;
			startanim=true;
			StartCoroutine(animatePanel(horiz,true));
			
		}
	}
	//Panel animation Coroutine
	private IEnumerator animatePanel( UIObject sprite, bool reverse )
	{
		if( startanim )
		{
			yield return new WaitForSeconds( 0 );
			audio.Play();
			if(!reverse){
				if(state == 1)
				{
					var ani = sprite.positionTo( 0.7f, new Vector3( -(Screen.width), 0, 0 ), Easing.Quartic.easeIn );
					ani.autoreverse = false;
				}
				if(state == 2)
				{
					var ani = sprite.positionTo( 0.7f, new Vector3( -2*(Screen.width)*1.1f, 0, 0 ), Easing.Quartic.easeIn );
					ani.autoreverse = false;
				}
				if(state == 3)
				{
					var ani = sprite.positionTo( 0.7f, new Vector3( (Screen.width), 0, 0 ), Easing.Quartic.easeIn );
					ani.autoreverse = false;
				}
			}
			if(reverse){
				if(state==1){
					var ani = sprite.positionTo( 0.7f, new Vector3( -(Screen.width)*1.1f, 0, 0 ), Easing.Quartic.easeIn );
					ani.autoreverse = false;
				}
				if(state==0){
					var ani = sprite.positionTo( 0.7f, new Vector3(0, 0, 0 ), Easing.Quartic.easeIn );
					ani.autoreverse = false;
				}
				if(state == 2){
					var ani = sprite.positionTo(.7f, new Vector3(0, 0, 0 ), Easing.Quartic.easeIn );
					ani.autoreverse=false;
					state =0;
				}
				if(state<=-1){
					Application.Quit();
				}
			}

			
		}
	}
	// Input actions //
	public void onTouchUpInsidePlay( UIButton sender ){
		startanim=true;
		state=1;
		StartCoroutine(animatePanel(horiz,false));
	}
	void onTouchUpInsideExtras(UIButton sender){
		startanim=true;
		state=3;
		StartCoroutine(animatePanel(horiz,false));
		
	}
	public void chapter_btn_down(UIButton sender){
		if( sender.btn_val == 1)
		{
			grid1.hidden=false;
			grid2.hidden=true;
			state=2;
			StartCoroutine(animatePanel(horiz,false));
		}
		if( sender.btn_val == 2)
		{
			grid1.hidden=true;
			grid2.hidden=false;
			state=2;
			StartCoroutine(animatePanel(horiz,false));
		}
	}
	public void level_selected(UIButton sender){
		loading.hidden=false;
		Application.LoadLevel(sender.btn_val+1);
	}
	void extras_selected(UIButton sender){
		loading.hidden=false;
		if(sender.btn_val==1){
			Application.LoadLevel("Dodge");
		}
		if(sender.btn_val==2){
			Application.LoadLevel("Climb");
		}
		if(sender.btn_val==3){
			Application.LoadLevel("Shoot");
		}
	}
	void exit_game(UIButton sender){
		Application.Quit();
	}

}
