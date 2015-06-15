using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Buttons : MonoBehaviour 
{

	public delegate void ButtonEvent(string name);
	public static event ButtonEvent ButtonPressed;

	public string buttonName;
	public float selectTime;
	public bool canSelect;
	public bool currentlySelected;
	
	private float currentTime;
	private Image reticle;
	private void Start()
	{
		reticle = GameObject.FindGameObjectWithTag("Reticle").GetComponent<Image>();
		canSelect = true;
	}

	private void Update()
	{
		if(currentlySelected && canSelect)
		{
			if(currentTime < selectTime)
			{
				currentTime += Time.deltaTime;
				reticle.fillAmount -= Time.deltaTime *.33f;
			}
			else
			{
				if(canSelect)
				{
					if(ButtonPressed != null)
						ButtonPressed(buttonName);

					reticle.fillAmount = 1;
					canSelect = false;
				}
			}

		}
		else
		{
			if(!canSelect && reticle.fillAmount < 1)
			{
				reticle.fillAmount += Time.deltaTime; 
			}
			else if(!canSelect)
			{
				reticle.fillAmount = 1;
				canSelect = true;
				currentTime = 0;
			}
			else
			{
				if(reticle.fillAmount < 1)
					reticle.fillAmount += Time.deltaTime;
				else
				{
					reticle.fillAmount = 1;
					currentTime = 0;
				}
			}
		}
	}

	public void OnLook(bool isLooking)
	{
		currentlySelected = isLooking;
	}
}
