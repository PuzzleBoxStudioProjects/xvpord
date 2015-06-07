using UnityEngine;
using System.Collections;

public class Buttons : MonoBehaviour 
{

	public delegate void ButtonEvent(string name);
	public static event ButtonEvent ButtonPressed;

	public string buttonName;
	public float selectTime;
	public bool currentlySelected;
	
	private SpriteRenderer  buttonRenderer;
	private float 			currentTime;

	private void Start()
	{
	
		buttonRenderer = GetComponent<SpriteRenderer>();
	

	}

	private void Update()
	{
		if(currentlySelected)
		{
			if(currentTime < selectTime)
			{
				currentTime += Time.deltaTime;
			}
			else
			{
				if(ButtonPressed != null)
					ButtonPressed(buttonName);

			}

		}
		else
			currentTime = 0;
	}

	public void OnLook(bool isLooking)
	{
		currentlySelected = isLooking;
	}
}
