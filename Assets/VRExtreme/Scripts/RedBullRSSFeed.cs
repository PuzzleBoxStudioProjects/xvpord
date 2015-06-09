using UnityEngine;
using System.Collections;

public class RedBullRSSFeed : MonoBehaviour
{
	// Use this for initialization
	IEnumerator Start ()
	{
		WWW www = new WWW("http://www.redbull.com/us/en/rss/index.rss");
		yield return www;
	}

	IEnumerator DisplayFeed(string url)
	{
		Debug.Log(url);

		WWW www = new WWW(url);
		yield return www;
		GetComponent<Renderer>().material.mainTexture = www.texture;
	}

	// Update is called once per frame
	void Update ()
	{
	
	}
}
