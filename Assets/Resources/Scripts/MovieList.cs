using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Movie
{
	public Sprite image;
	public string movieName;
	public string movieUrl;
	public float  movieLegth;
	public bool   flatMovie;
	

	public Movie CreateMovie(string name, string url, float length,bool flatVid, string aImage)
	{
		Movie theMovie = new Movie();

		theMovie.movieName = name;
		theMovie.movieUrl = url;
		theMovie.movieLegth = length;
		theMovie.flatMovie = flatVid;
		theMovie.image = (Sprite)Resources.Load(aImage, typeof(Sprite));

		return theMovie;
	}
}

public class MovieList : Movie 
{
	public List<Movie> allMovies = new List<Movie>();
	Movie movieObject;

	public void Init()
	{
		movieObject = new Movie();
		allMovies.Add(movieObject.CreateMovie("Best of Redbull","https://db.tt/ZEP9AWmn",168,true,"Texture/Redbull/Movies/BestOf"));
		allMovies.Add(movieObject.CreateMovie("Motocross Race POV","https://db.tt/dFCcx0U8",127,true,"Texture/Redbull/Movies/MotocrossPOV"));
		allMovies.Add(movieObject.CreateMovie("Intense Downhill Mtb POV","https://db.tt/1tHzkQHD",248,true,"Texture/Redbull/Movies/MTBDownhill"));
		allMovies.Add(movieObject.CreateMovie("Redbull Sking POV","https://db.tt/0FsDUJs5",70,true,"Texture/Redbull/Movies/Sking"));
		allMovies.Add(movieObject.CreateMovie("Insane Urban Mtb POV","https://db.tt/8YEfmGwE",200,true,"Texture/Redbull/Movies/MTBUrban"));
		allMovies.Add(movieObject.CreateMovie("Redbull Space Jump POV","https://db.tt/i1yZ4C4a",497,true,"Texture/Redbull/Movies/SpaceJump"));
		allMovies.Add(movieObject.CreateMovie("Wingsuit Over NewYork POV","https://db.tt/ghYnd6nK",112,true,"Texture/Redbull/Movies/WingflightNY"));
		allMovies.Add(movieObject.CreateMovie("Pikes Peak Run POV","https://db.tt/eZ5CrqaW",550,true,"Texture/Redbull/Movies/pikesRacing"));
		allMovies.Add(movieObject.CreateMovie("360Deg Redbull F1","https://db.tt/4nOKctge",134,false,"Texture/Redbull/Movies/360RedbullF1Racing"));
		allMovies.Add(movieObject.CreateMovie("360Deg Windsuffing","https://db.tt/iHs3eaD4",77,false,"Texture/Redbull/Movies/WindSurfing"));
		allMovies.Add(movieObject.CreateMovie("360Deg Wingsuit Flying","https://db.tt/IXxBM7ln",73,false,"Texture/Redbull/Movies/360Wingsuit"));
	}


}
