using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GenerateMap : MonoBehaviour 
{
	List<Vector3> TileLocations = new List<Vector3>(9);//list holding locations of larger background tiles
	List<Vector3> MapObjectLocations = new List<Vector3>(25);


	[System.Serializable]//makes it show up in editor
	public class MapObjects//specific objects on map
	{
		public GameObject GameObjs;//physical game objects; Collisions, interact, etc.
		public int GOSizeBySquares = 1; //number of 128x128 squares

		public MapObjects(GameObject go, int size)//initilizer
		{
			GameObjs = go;
			GOSizeBySquares = size;
		}
	}
	[System.Serializable]
	public class Quadrants//holds info on each large square (Tile)
	{
		public List<MapObjects> mapobs = new List<MapObjects>();//contains info of MapObjects on this Tile
		public GameObject background;//background image

		public Quadrants(List<MapObjects> L_mo, GameObject bg)//initializer
		{
			mapobs = L_mo;
			background = bg;
		}

		public Quadrants()
		{
			//mapobs = null;
			//background = null;
		}
	}

	public List<Quadrants> largeSquareAreas = new List<Quadrants>(9);//Creates empty list of size 9

	void initializeList(List<int> l)//initializes int list so it can be edited
	{
		for(int i = 0; i < l.Capacity; i++)
		{
			l.Add(0);
		}
	}

	void initializeList(List<Vector3> l)//initializes v3 list so it can be edited
	{
		for(int i = 0; i < l.Capacity; i++)
		{
			l.Add(new Vector3(0,0,0));
		}
	}

	List<int> fixNineToZero(List<int> l)
	{
		/*
		if(l.Contains(9))
		{
			for(int i = 0; i < l.Count; i++)
			{
				if(l[i] == 9)
					l[i] = 0;
			}
		}*/
		if(l.Contains(l.Count))
		{
			for(int i = 0; i < l.Count; i++)
			{
				if(l[i] == l.Count)
					l[i] = 0;
			}
		}
		return l;
	}//brute force fix

	List<int> ExclusiveRandomInt(int min, int max)//creates exclusive random number excluding min, including max
	{
		List<int> r = new List<int>((max-min));
		initializeList(r);//*
		int rand;//stores random()

		for(int i = min; i < max; i++)//difference between min and max will be number of loops
		{
			//print("i = " + i);
			rand = Random.Range(min,max+1);//generates random number between min and max 
			while(r.Contains(rand))
			{
				rand = Random.Range(min,max+1);//generates random number between min and max 
			}
			r[i] = rand;
		}
		r = fixNineToZero(r);
		return r;//returns List<int>
	}

	void SetTileLocations()//initializes list with default locations of 9 Tiles
	{
		initializeList(TileLocations);
		TileLocations[0] = new Vector3(-12,12,0);
		TileLocations[1] = new Vector3(0,12,0);
		TileLocations[2] = new Vector3(12,12,0);
		TileLocations[3] = new Vector3(-12,0,0);
		TileLocations[4] = new Vector3(0,0,0);
		TileLocations[5] = new Vector3(12,0,0);
		TileLocations[6] = new Vector3(-12,-12,0);
		TileLocations[7] = new Vector3(0,-12,0);
		TileLocations[8] = new Vector3(12,-12,0);
	}

	void SetMapObjectLocations()//initializes locations of 25 spawn points on tile 
	{
		initializeList(MapObjectLocations);
		MapObjectLocations[0] = new Vector3(-4.8f,4.8f,-1);
		MapObjectLocations[1] = new Vector3(-2.4f,4.8f,-1);
		MapObjectLocations[2] = new Vector3(0f,4.8f,-1);
		MapObjectLocations[3] = new Vector3(2.4f,4.8f,-1);
		MapObjectLocations[4] = new Vector3(4.8f,4.8f,-1);
		MapObjectLocations[5] = new Vector3(-4.8f,2.4f,-1);
		MapObjectLocations[6] = new Vector3(-2.4f,2.4f,-1);
		MapObjectLocations[7] = new Vector3(0f,2.4f,-1);
		MapObjectLocations[8] = new Vector3(2.4f,2.4f,-1);
		MapObjectLocations[9] = new Vector3(4.8f,2.4f,-1);
		MapObjectLocations[10] = new Vector3(-4.8f,0f,-1);
		MapObjectLocations[11] = new Vector3(-2.4f,0f,-1);
		MapObjectLocations[12] = new Vector3(0f,0f,-1);
		MapObjectLocations[13] = new Vector3(2.4f,0f,-1);
		MapObjectLocations[14] = new Vector3(4.8f,0f,-1);
		MapObjectLocations[15] = new Vector3(-4.8f,-2.4f,-1);
		MapObjectLocations[16] = new Vector3(-2.4f,-2.4f,-1);
		MapObjectLocations[17] = new Vector3(0f,-2.4f,-1);
		MapObjectLocations[18] = new Vector3(2.4f,-2.4f,-1);
		MapObjectLocations[19] = new Vector3(4.8f,-2.4f,-1);
		MapObjectLocations[20] = new Vector3(-4.8f,-4.8f,-1);
		MapObjectLocations[21] = new Vector3(-2.4f,-4.8f,-1);
		MapObjectLocations[22] = new Vector3(0f,-4.8f,-1);
		MapObjectLocations[23] = new Vector3(2.4f,-4.8f,-1);
		MapObjectLocations[24] = new Vector3(4.8f,-4.8f,-1);
	}
		

	void MakeTheMap(ref List<Quadrants> quads, List<int> exclusiverandint)//generates Tiles
	{
		SetTileLocations();
		List<Quadrants> temp = new List<Quadrants>();
		for(int i = 0; i < quads.Count; i++)
		{
			Instantiate(quads[exclusiverandint[i]].background,TileLocations[i], Quaternion.identity).name = "Tile" + i;//instantiates each Tile in randomized spot
			temp.Add(null);
			temp[i] = quads[exclusiverandint[i]];
			//print("temp[" + i + "] = " + temp[i].background.name);
		}
		quads = temp;
		//temp.Clear();
	}

	void SetTheTerrain(List<Quadrants> quads)
	{
		SetMapObjectLocations();
		List<int> rand;
		Vector3 loc = new Vector3();

		for(int i = 0; i < quads.Count; i++)//for each tile...
		{
			//TileLocations[i]
			rand = ExclusiveRandomInt(0,25);//creates random list

			for (int j = 0; j < quads[i].mapobs.Count; j++)//for each map objects on each tile...
			{
				loc = new Vector3(MapObjectLocations[rand[j]].x + TileLocations[i].x, 
					MapObjectLocations[rand[j]].y + TileLocations[i].y,
					MapObjectLocations[rand[j]].z + TileLocations[i].z);

				Instantiate(quads[i].mapobs[j].GameObjs,loc, Quaternion.identity);
			}
			rand.Clear();
		}

	}


	// Use this for initialization
	void Start () 
	{
		MakeTheMap(ref largeSquareAreas, ExclusiveRandomInt(0,largeSquareAreas.Count));
		SetTheTerrain(largeSquareAreas);
	}
}
