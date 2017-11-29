using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalManager : MonoBehaviour {

	void Awake(){
		Screen.SetResolution(Screen.height * 9 / 16, Screen.height, true);
		Application.targetFrameRate = 60;
	}
	
	void OnApplicationQuit()
	{
		
	}

	void OnApplicationPause(bool pauseStatus)
	{
		
	}

	void OnApplicationFocus(bool focusStatus)
	{
		
	}
}
