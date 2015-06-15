using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MovieGenerator : MonoBehaviour 
{
	public GameObject moviePrefabs;
	private Movie[] movies;
	private MovieList moviesList;
	// Use this for initialization
	void Start () 
	{
		moviesList = new MovieList();
		moviesList.Init();
		Vector3 localScale = moviePrefabs.transform.localScale;
		int count = 0;
		for(int i = 0; i < moviesList.allMovies.Count/2; i++)
		{
			for(int n = 0; n < 2; n++)
			{
				GameObject clone = Instantiate(moviePrefabs, transform.position, Quaternion.identity)as GameObject;
				clone.transform.SetParent(transform);
				clone.transform.localScale = localScale;
				if(n%2 == 1)
					clone.transform.localPosition = new Vector3(-28, -63 + (i*20),0);
				else
					clone.transform.localPosition = new Vector3(23, -63+ (i*20),0);
		

				clone.transform.FindChild("Title").gameObject.GetComponent<Text>().text = moviesList.allMovies[count].movieName;
				clone.transform.FindChild("Thumb").GetComponent<Image>().sprite = moviesList.allMovies[count].image;
				count++;
			}
		}

	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
}
