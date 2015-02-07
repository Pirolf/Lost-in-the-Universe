﻿
using UnityEngine;
using System.Collections;
using System;
public class TerrainTile : MonoBehaviour, IComparable{
	public int iron;
	public int copper;

	void Awake(){

	}

	void Update(){
		
	}

	// default sorting: descending on iron
	int IComparable.CompareTo(object obj)
	{
		TerrainTile t=(TerrainTile)obj;
		return (t.iron).CompareTo(this.iron);
	}

	/*
	// Method to return IComparer object for sort helper.
	public static IComparer TileSortHelper()
	{      
		return (IComparer) new TileSortHelper();
	}

	//descending sort on iron
	private class TileSortHelper : IComparer{
		int IComparer.Compare(object a, object b){
		TerrainTile t1 = (TerrainTile)a;
		TerrainTile t2 = (TerrainTile)b;
		if (t1.iron < t1.iron)
		 return 1;
		if (t1.iron > t2.iron)
		 return -1;
		else
		 return 0;
		}
	}
	*/
	
}