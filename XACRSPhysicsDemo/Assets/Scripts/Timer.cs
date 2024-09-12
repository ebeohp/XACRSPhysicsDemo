using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
/// IMPORTANT: This Timer Class has evolved to become a general UI controller class.
/// Would need to fix the organizational naming of this reference.
/// </summary>
public class Timer : MonoBehaviour 
{
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] TextMeshProUGUI scoreText; 

    [SerializeField] public TextMeshProUGUI smallScoreText; 
    public GameObject scoreTextObject;
    [SerializeField] float remainingTime;
    public float score = 0f; // Track the score

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
        timerStarted = false;
        //Create score text
        scoreTextObject.SetActive(true);
        scoreText.text = "Score:\n" + score.ToString();
    }
}
