using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointSpawner : MonoBehaviour
{
    public GameObject startWaypointPrefab;
    public GameObject waypointPrefab; //Red
    
    public GameObject ground;
    public Vector2 platformBounds;

    public Timer timerText;
    public bool redWaypointExists = false;

    // Start is called before the first frame update
    void Start()
    {
        platformBounds = new Vector2(ground.transform.localScale.x, ground.transform.localScale.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (timerText.timerStarted && !redWaypointExists)
        {
            SpawnWaypoint();
        }
    }
    public void SpawnWaypoint()
    {
        Debug.Log("Waypoint Spawned");
        redWaypointExists = true;
        
        float x = Random.Range(-platformBounds.x / 2, platformBounds.x / 2);
        float z = Random.Range(-platformBounds.y / 2, platformBounds.y / 2);
        Vector3 spawnPosition = new Vector3(x, 0.2f, z); // Adjust y as needed

        // Instantiate the red waypoint prefab
        Instantiate(waypointPrefab, spawnPosition, Quaternion.identity);
    }
    public void OnWaypointCollected()
    {
        redWaypointExists = false; // Allow spawning of a new waypoint
    }
    
}
