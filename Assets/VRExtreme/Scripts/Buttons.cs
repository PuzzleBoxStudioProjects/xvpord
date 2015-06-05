using UnityEngine;
using System.Collections;

public class Buttons : MonoBehaviour 
{

	public delegate void ButtonEvent(string name);
	public static event ButtonEvent ButtonPressed;

	public string buttonName;
	public float selectSpeed;
	public bool currentlySelected;

	private SpriteRenderer 	progressRenderer;
	private SpriteRenderer  buttonRenderer;
	private GameObject 	progress;
	private Vector3		emptyBar;
	private Vector3 	fullBar;

	private void Start()
	{
		progress = transform.FindChild("progress").gameObject;
		progressRenderer = progress.GetComponent<SpriteRenderer>();
		buttonRenderer = GetComponent<SpriteRenderer>();
		fullBar = progress.transform.localScale;
		emptyBar = new Vector3(0,progress.transform.localScale.y, progress.transform.localScale.z);

	}

	private void Update()
	{
		if(currentlySelected)
		{
			if(progress.transform.localScale.x < fullBar.x)
			{
				emptyBar = new Vector3(selectSpeed * Time.deltaTime, 0, 0);
				progress.transform.localScale += emptyBar;
			}
			else
			{
				if(ButtonPressed != null)
					ButtonPressed(buttonName);

				ShowLoading();
			}

		}
		else
			HideLoading();
	}

	private void ShowLoading()
	{
		progressRenderer.enabled = true;
	}
	private void HideLoading()
	{
		emptyBar = new Vector3(0,progress.transform.localScale.y, progress.transform.localScale.z);
		progress.transform.localScale = emptyBar;
		progressRenderer.enabled = false;
	}
	
	public void OnLook(bool isLooking)
	{
		currentlySelected = isLooking;
		ShowLoading();
	}
}
