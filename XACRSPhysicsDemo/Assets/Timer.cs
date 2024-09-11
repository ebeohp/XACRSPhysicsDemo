using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    public GameObject scoreText;
    [SerializeField] float remainingTime;
    // Update is called once per frame

    public bool timerStarted = false;

    public WaypointSpawner wayPointSpawner;
    void Update()
    {
        if(timerStarted)
        {
            if(remainingTime > 0)
            {  
                remainingTime -= Time.deltaTime;
            }
            else if (remainingTime < 0)
            {
                remainingTime = 0;
                //Game Over(); //Enable a popup that shows the amount of waypoints collected in time. 
                timerText.color = Color.red;
                EndTimer();
            }
            int minutes = Mathf.FloorToInt(remainingTime/60);
            int seconds = Mathf.FloorToInt(remainingTime % 60);
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
        
    }
    public void StartTimer()
    {
        timerStarted = true;
    }
    public void EndTimer()
    {
        //Create score text
        scoreText.SetActive(true);
        //scoreText.text = 1000; // Replace with a counter for how many way points gotten.
    }
}
