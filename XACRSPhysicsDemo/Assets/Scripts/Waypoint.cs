using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    public GameObject ground; // To get the scale on x and z
    private Vector2 platformBounds;

    public bool isStartingWayPoint = false;

    public Timer timer; //Text GUI Script

    public void Start()
    {
        // Initialize platformBounds based on the ground's scale
        if (ground != null)
        {
            platformBounds = new Vector2(
                ground.transform.localScale.x * 0.5f, // Half of the scale on x
                ground.transform.localScale.z * 0.5f  // Half of the scale on z
            );
        }
        else
        {
            Debug.LogError("Ground GameObject is not assigned.");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Check if the collision is with the weapon and the calculate the force of the weapon.
        //Collect();

        // Check if the object colliding with the collectible has a Weapon script
        Weapon weapon = collision.gameObject.GetComponent<Weapon>();
        if (weapon != null)
        {
            CollectWaypoint();    
        }

        
    }

    public void CollectWaypoint()
    {
        if (isStartingWayPoint)
        {
            StartGame();
        }
        // Disable the collectible and start respawn coroutine
        
        Destroy(gameObject);
        

       
    }
    public void StartGame()
    {
        timer.timerStarted = true;
        
    }
    
}
