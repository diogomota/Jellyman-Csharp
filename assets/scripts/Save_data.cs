using UnityEngine;
using System.Collections;

public class Save_data : MonoBehaviour {
	// Update is called once per frame
	public void Save(){
		//-1 for the splash screen level
		if(PlayerPrefs.GetInt("LEVEL")<Application.loadedLevel-1)
		{
			PlayerPrefs.SetInt("LEVEL",Application.loadedLevel-1);
			PlayerPrefs.Save();
			Debug.Log(Application.loadedLevel);
		}
		GameObject.Find("UI_Drawer").SendMessage("next_lvl_menu");
		if(Application.loadedLevel==10){
			GameObject.Find("text_ui").SendMessage("extra_unlocked");
		}
		//Application.LoadLevel(Application.loadedLevel+1);
	}
}
