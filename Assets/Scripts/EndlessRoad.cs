using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessRoad : MonoBehaviour {
    public GameObject[] Road;
    private Transform Player;
    private float spawnz=0.0f;
    private float safezone = 65.0f;
    private float RoadLength=60.0f;
    private int createRoadInrow = 2;
    private int lastCreatedRoadIndex = 0;
    private List<GameObject> CreatedRoad;
     public int PlatformCount;
	// Use this for initialization
	void Start () {
        CreatedRoad = new List<GameObject>();
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        for(int i=0;i<createRoadInrow;i++)
        {
           spawnRoad();
            PlatformCount++;
        }
	}
	
	// Update is called once per frame
	void Update () {
		if(Player.transform.position.x-safezone>(spawnz-createRoadInrow*RoadLength)&& PlatformCount<=14)
        {
            if(PlatformCount<14)
            {
                spawnRoad();
                RemoveRoad();
            }
            else
            {
                spawnRoad(5);
                RemoveRoad();
            }
            PlatformCount++;
            Debug.Log("PlatForm Count=" + PlatformCount);
        }
	}
    private void spawnRoad(int PrefabsIndex = -1)
    {
        GameObject CreateRoad;
        if(PrefabsIndex==-1)
            CreateRoad = Instantiate(Road[RandomSpawn()]) as GameObject;
        else
            CreateRoad = Instantiate(Road[PrefabsIndex]) as GameObject;
        CreateRoad.transform.SetParent(transform);
        CreateRoad.transform.position = Vector3.right * spawnz;
        spawnz += RoadLength;
        CreatedRoad.Add(CreateRoad);
    }
    private int RandomSpawn()
    {
        if (Road.Length <= 1)
            return 0;
        int RandomIndex = lastCreatedRoadIndex;
        while(RandomIndex==lastCreatedRoadIndex)
        {
            RandomIndex = Random.Range(0, Road.Length-1);
        }
        lastCreatedRoadIndex = RandomIndex;
        return RandomIndex;
    }
    private void RemoveRoad()
    {
        
        Destroy(CreatedRoad[0]);
        CreatedRoad.RemoveAt(0);
        
    }
}
