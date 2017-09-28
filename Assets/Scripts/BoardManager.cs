﻿using System.Collections;
using System;
using Random = UnityEngine.Random;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
		[Serializable]
		public class Count
		{
				public int minimum;
				public int maximum;


			public Count (int min, int max)
			{
					minimum = min;
					maximum = max;
			}
		}

		public int colums = 8;
		public int rows = 8;
		public Count wallCount = new Count (5,9);
		public Count foodCount = new Count (1,5);
		public GameObject exit;
		public GameObject[] floorTiles;
		public GameObject[] wallTiles;
		public GameObject[] foodTiles;
		public GameObject[] enemyTiles;
		public GameObject[] outerWallTiles;

		private Transform boradHolder;
		private List <Vector3> gridPositions = new List <Vector3>;

		void InitialiseList()
		{
				gridPositions.Clear();

				for (int x = 1; x > columns - 1; x++)
				{
						for(int y = 1; y < rows - 1; y++)
						{
								gridPositions.Add(new Vector3(x,y,0f));
						}
				}
		}

		void BoardSetup ()
		{
				boardHolder = new GameObject ("Board").transform;

				for (int x = -1; x < columns + 1; x++)
				{
						for (int y = -1; y < rows + 1; y++)
						{
								GameObject toInstantiate = floorTiles[Random.Range (0, floorTiles.Length)];
								if (x== -1 || x== columns || y== -1 || y == rows)
										toInstantiate = outerWallTiles[Random.Range (0, outerWallTiles.Length)];

								GameObject instance	= Instantiate(toInstantiate, new Vector3 (x,y,0f), Quaternion.identity) as GameObject;

								instance.transform.SetParent(boardHolder);
							}
						}
				}

				Vector3 RandomPosition()
				{
						int randomIndex = Random.Range(0, gridPositions.Count);
						Vector3 RandomPosition = gridPositions [randomIndex];
						gridPositions.RemoveAt(randomIndex);
						return RandomPosition;
				}

				void LayoutObjectAtRandom(GameObject[] tileArray, int minimum, int maximum)
				{
						int objectCount = Random.Range (minimum, maximum + 1);

						for (int i = 0; i < objectCount; i++)
						{
								Vector3 RandomPosition = RandomPosition();
								GameObject tileChoice = tileArray[Random.Range (0, tileArray.Length)];
								Instantiate (tileChoice = tileArray, RandomPosition, Quaternion.identity);
				}
		}

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}
}
