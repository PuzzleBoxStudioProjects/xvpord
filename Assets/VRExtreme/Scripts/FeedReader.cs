using UnityEngine;
using System;
using System.Collections;
using System.Xml;

public class FeedReader : MonoBehaviour 
{
	IEnumerator Start()
	{
		string url = "http://www.redbull.com/us/en/rss/index.rss";

		WWW web = new WWW(url);


		yield return web;
		string[] text = new string[100];
		int count = 0;
		if(web.error == null)
		{
			Debug.Log("Succesfully Loaded feed");

			//XmlDocument doc = new XmlDocument();
			//doc.LoadXml(web.text);

		}
		else 
			Debug.Log("Error: " + web.error);
	}

	private void StripFeed(XmlNodeList nodes)
	{
		Feed feed;

		foreach(XmlNode node in nodes)
		{
			string [] elementz = new string[10];
			int count = 0;
			foreach(XmlElement element in node)
			{
				int innerCount = 0;
				elementz[count] = element.InnerText;
				count++;
				foreach(XmlAttribute attribute in element.Attributes)
				{
					string [] attributes = new string[10];
					attributes[innerCount] = attribute.InnerText;
					innerCount++;
				}
			}
		}
	}
}
