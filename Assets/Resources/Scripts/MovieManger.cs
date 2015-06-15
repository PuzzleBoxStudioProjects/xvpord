using UnityEngine;
using System.Collections;

public class MovieManger : MonoBehaviour 
{

	// Use this for initialization
	void Awake () 
	{
		XtremeManager.OnUpdate += new XtremeManager.XtremeUpdate(OnUpdate);
		Buttons.ButtonPressed += new Buttons.ButtonEvent(ButtonHit);
	}

	void OnDestroy()
	{
		XtremeManager.OnUpdate -= new XtremeManager.XtremeUpdate(OnUpdate);
		Buttons.ButtonPressed -= new Buttons.ButtonEvent(ButtonHit);
	}
	// Update is called once per frame
	void OnUpdate () 
	{
	
	}

	void ButtonHit(string name)
	{

	}
}
