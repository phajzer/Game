using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour {
    public GameObject ship;
    public GameObject cannon;
    
    private float enemVal;

    [Header("Spawn Settings")]
    //set custom range for random position
    public float MinX = 5;
    public float MaxX = 20;
    public float MinZ = 5;
    public float MaxZ = 20;
    public float MinY = 1;
    public float MaxY = 5;

    // Use this for initialization
    void Start () {
        var Player = (GameObject)Instantiate(ship, new Vector3(0, 1, 0), Quaternion.identity);
        enemVal = SetEnemys.EnemyValue;
        Debug.Log(enemVal);
        for(int i = 1; i <= enemVal; i++)
        {
            float x = Random.Range(MinX, MaxX);
            float y = Random.Range(MinY, MaxY);
            float z = Random.Range(MinZ, MaxZ);
            var Enemy = (GameObject)Instantiate(cannon, new Vector3(x, y, z), Quaternion.identity);
        }
        
    }
    
}
