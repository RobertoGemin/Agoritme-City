﻿using UnityEngine;
using System.Collections;

public class BuildingUpdate : MonoBehaviour {

	// Use this for initialization
	public GameObject prefab;
	public string[] ArrayBuildingFloor = new string[] {"ground5", "ground6", "ground7"};
	//public string[] ArrayBuildingCenter = new string[] {"Newfloor5","Newfloor5",};//{"center1", "center2", "center3","center4","center5"};
	//public string[] ArrayBuildingTop = new string[] {"roof5","roof6", "roof7","roof8"};
	public string[] ArrayBuildingRoof = new string[] {"roof5","roof6", "roof7","roof8"};

	public GameObject[] GameObjectArrayBuildingFloor = new GameObject[]{};
	public GameObject[] GameObjectArrayBuildingCenter = new GameObject[]{};
	public GameObject[] GameObjectArrayBuildingTop = new GameObject[]{};



	public int rowCount = 2;	
	GameObject Level;
	GameObject floorGroup ;
	GameObject centerGroup ;
	GameObject TopGroup;
	GameObject Block;
	
	void Awake()
	{
		Level = new GameObject();
		Level.name = "Level";
		floorGroup = new GameObject();
		floorGroup.name = "Floor Group";
		centerGroup = new GameObject();
		centerGroup.name = "Center Group";
		TopGroup = new GameObject();
		TopGroup.name = "Top Group";
		Block = new GameObject();
		Block.name = "Block Group";
	}
	
	
	
	public void MakeRow(int rowSize,int rowX)
	{
		/*
		float randomDistance = 4f;
		GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
		cube.transform.localScale = new Vector3((rowSize*8), 0.25f, 4f);
		
		cube.transform.position = new Vector3(rowSize*4, 0, (rowX * 8f)+4f);
		cube.name= "cube" +rowSize + rowX +" Name: " + ArrayBuildingFloor[0].ToString();
		cube.transform.parent = Block.transform;
		cube.renderer.material.color = Color.black;
		*/
	}
	
	
	public void MakeBuildingEmpty(int rowZ,int rowX)
	{
		float randomDistance = 8f;
		GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
		cube.transform.localScale = new Vector3((randomDistance), 0.25f, 4f);
		
		cube.transform.position = new Vector3((randomDistance*rowZ), 0, rowX * 8f);
		cube.name= "cube" +rowZ + rowX +" Name: " + ArrayBuildingFloor[0].ToString();
		cube.transform.parent = Block.transform;
	}
	
	public void MakeBuilding(int rowZ,int rowX,string count)
	{
		int RandomFloor = Random.Range(0, GameObjectArrayBuildingFloor.Length);
		float randomDistance = 8f;
		//float randomDistance = Random.Range(6.25f, 6.5f);
		//Debug.Log(ArrayBuildingFloor[RandomFloor]);
		//GameObject floor = Resources.LoadAssetAtPath<GameObject>("Assets/Buildings/ground1.obj");
		//GameObject floor = Resources.LoadAssetAtPath<GameObject>("Assets/Export/"+ArrayBuildingFloor[RandomFloor].ToString()+".obj");		 
		GameObject floor = GameObjectArrayBuildingFloor[RandomFloor];
		(Instantiate(floor, new Vector3(randomDistance*rowZ, 0, rowX * 8f), Quaternion.identity)as GameObject).transform.parent = floorGroup.transform;
		floor.name= "floor" +rowZ + rowX +" Name: " + GameObjectArrayBuildingFloor[RandomFloor].ToString() ;
		floor.tag =count;
		int j;
		int RandomFloors;
		if(rowZ %2==0)
		{	
			RandomFloors = Random.Range(1,5);
		}
		else
		{
			RandomFloors = Random.Range(2,10);	
		}
		
		for(j = 0;j <RandomFloors;j++ )
		{
			int RandomCenter = Random.Range(0, GameObjectArrayBuildingCenter.Length);
			//GameObject center = Resources.LoadAssetAtPath<GameObject>("Assets/Export/"+ArrayBuildingCenter[RandomCenter].ToString()+".obj");
			GameObject center = GameObjectArrayBuildingCenter[RandomCenter];

			(Instantiate(center, new Vector3(randomDistance*rowZ, 1.5f +(1.5f *j), rowX * 8f), Quaternion.identity)as GameObject).transform.parent = centerGroup.transform;;
			center.name ="center" +rowZ + rowX +  " Name: " + GameObjectArrayBuildingCenter[RandomCenter].ToString();
			center.tag =count;

		}
		int RandomTop = Random.Range(0, ArrayBuildingRoof.Length);
		GameObject top = UnityEditor.AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Buildings/"+ArrayBuildingRoof[RandomTop].ToString()+".obj");
		(Instantiate(top, new Vector3(randomDistance*rowZ, 1.5f +(1.5f *RandomFloors), rowX * 8f), Quaternion.identity)as GameObject).transform.parent = TopGroup.transform;;
		top.name ="top" +rowZ +rowX +" Name: " + ArrayBuildingRoof[RandomTop].ToString() ;
		top.tag =count;
		
		
	}
	void old()
	{
		GameObject Level = new GameObject();
		//Instantiate(Level, new Vector3(0, 0, 0), Quaternion.identity);
		Level.name = "Level";
		GameObject floorGroup = new GameObject();
		//(Instantiate(floorGroup, new Vector3(0, 0, 0), Quaternion.identity)as GameObject).transform.parent = Level.transform;
		floorGroup.name = "Floor Group";
		GameObject centerGroup = new GameObject();
		//(Instantiate(centerGroup, new Vector3(0, 0, 0), Quaternion.identity)as GameObject).transform.parent = Level.transform;
		centerGroup.name = "Center Group";
		GameObject TopGroup = new GameObject();
		//Instantiate(TopGroup, new Vector3(0, 0, 0), Quaternion.identity);
		TopGroup.name = "Top Group";
		for (int rowX = 0;rowX <rowCount;rowX++)
		{
			GameObject sideWalkcube = GameObject.CreatePrimitive(PrimitiveType.Cube);
			sideWalkcube.transform.localScale = new Vector3(rowCount*6f,0.25f, 4f);
			
			//cube.transform.
			sideWalkcube.transform.position = new Vector3((rowCount*2.5f), 0, (rowX*8)-4);
			sideWalkcube.name= "SideWalk";
			
			for(int rowZ = 0;rowZ <rowCount;rowZ++)
			{
				int RandomFloor = Random.Range(0, ArrayBuildingFloor.Length);
				float randomDistance = 5f;
				//float randomDistance = Random.Range(6.25f, 6.5f);
				GameObject floor = UnityEditor.AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Buildings/"+ArrayBuildingFloor[RandomFloor].ToString()+".obj");
				//	(Instantiate(floor, new Vector3(4.5f*rowZ, 0, rowX * 7.5f), Quaternion.identity)as GameObject).transform.parent = floorGroup.transform;
				(Instantiate(floor, new Vector3(randomDistance*rowZ, 0, rowX * 8f), Quaternion.identity)as GameObject).transform.parent = floorGroup.transform;
				floor.name= "floor" +rowZ + rowX +" Name: " + ArrayBuildingFloor[RandomFloor].ToString() ;
				//	(Instantiate(GameObject.CreatePrimitive(PrimitiveType.Cube), new Vector3((4.5f*rowZ)+ 2.25f , 0, rowX * 7.5f), Quaternion.identity)as GameObject).transform.parent = floorGroup.transform;
				//tempDist
				GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
				cube.transform.localScale = new Vector3((randomDistance/5), 0.25f, 4f);
				
				//cube.transform.
				cube.transform.position = new Vector3((randomDistance*rowZ)- 2.5f, 0, rowX * 8f);
				cube.name= "cube" +rowZ + rowX +" Name: " + ArrayBuildingFloor[RandomFloor].ToString() ;
				cube.GetComponent<Renderer>().material.color = Color.black;
				int j;
				int RandomFloors;
				if(rowZ %2==0)
				{	
					RandomFloors = Random.Range(1,5);
				}
				else
				{
					RandomFloors = Random.Range(2,10);	
				}
				
				for(j = 0;j <RandomFloors;j++ )
				{
					int RandomCenter = Random.Range(0, GameObjectArrayBuildingTop.Length);
					//GameObject center = Resources.LoadAssetAtPath<GameObject>("Assets/Buildings/"+ArrayBuildingCenter[RandomCenter].ToString()+".obj");
					GameObject center =GameObjectArrayBuildingTop[RandomCenter];

					(Instantiate(center, new Vector3(randomDistance*rowZ, 1.5f +(1.0f *j), rowX * 8f), Quaternion.identity)as GameObject).transform.parent = centerGroup.transform;;
					center.name ="center" +rowZ + rowX +  " Name: " + GameObjectArrayBuildingTop[RandomCenter].ToString();
				}
				int RandomTop = Random.Range(0, GameObjectArrayBuildingTop.Length);
				//GameObject top = Resources.LoadAssetAtPath<GameObject>("Assets/Buildings/"+ArrayBuildingTop[RandomTop].ToString()+".obj");

				GameObject top = GameObjectArrayBuildingTop[RandomTop];
				(Instantiate(top, new Vector3(randomDistance*rowZ, 1.5f +(1.0f *RandomFloors), rowX * 8f), Quaternion.identity)as GameObject).transform.parent = TopGroup.transform;;
				top.name ="top" +rowZ +rowX +" Name: " + GameObjectArrayBuildingTop[RandomTop].ToString() ;
			}
		}
	}
	
}
