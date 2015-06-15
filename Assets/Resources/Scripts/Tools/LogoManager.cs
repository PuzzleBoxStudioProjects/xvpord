using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LogoManager : MonoBehaviour
{

	Image 	thisRender;
	float 		alpha;
	// Use this for initialization
	void Start () 
	{
		thisRender = this.GetComponent<Image>();
		alpha = 0;
		StartCoroutine(TweenAlpha());
	}


	private IEnumerator TweenAlpha()
	{
		while(alpha < 1)
		{
			alpha += (Time.deltaTime*.25f);
			thisRender.color = new Color(thisRender.color.r, thisRender.color.g, thisRender.color.b, alpha);

			yield return alpha;
		}
		thisRender.color = new Color(thisRender.color.r, thisRender.color.g, thisRender.color.b, 255);
		yield return new WaitForSeconds(2);
		Application.LoadLevel("Menu");
	}
}
