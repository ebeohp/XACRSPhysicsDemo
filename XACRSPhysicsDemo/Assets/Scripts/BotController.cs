using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotController : MonoBehaviour
{

    /// <summary>
    /// -1 is Counter CLockwise Spin
    /// +1 is Clockwise Spin
    /// This is PC input controls that applies forces differently than joysticks which are on a sliding scale.
    /// </summary>


    //Store bot parent game objects here.

    public Wheel wheelLeft; // For testing
    public Wheel wheelRight; // For testing
    public enum BotSelection
    {
        TheThrongler, // The Throngler is Horizontal 2 Wheel Drive
        TheCube, 
    }
    public BotSelection botSelection;

    // Reference to the current bot
    private IBot bot;

     // Public field to assign the specific bot controller
    public ThronglerController thronglerController;
    //public TheCubeController theCubeController;

    private void Start()
    {
        // Initialize the bot based on selection
        InitializeBot();
    }
   
    

    private void InitializeBot()
    {
        switch (botSelection)
        {
            case BotSelection.TheThrongler:
                bot = thronglerController; // Ensure ThronglerController implements IBot
                break;
            case BotSelection.TheCube:
                //bot = theCubeController; // Ensure TheCubeController implements IBot
                break;
        }

        if (bot == null)
        {
            Debug.LogError("No bot controller assigned.");
        }
    }
    private void Update()
    {
        if(Input.GetKey(KeyCode.UpArrow))
        {
            bot.MoveForward();
        }
        else if(Input.GetKey(KeyCode.LeftArrow))
        {
            bot.TurnCounterClockwise();
        }
        else if(Input.GetKey(KeyCode.RightArrow))
        {
            bot.TurnClockwise();
        }

        else if(Input.GetKey(KeyCode.DownArrow))
        {
            bot.MoveBackward();
        }
        else
        {
            bot.StopMove();
        }

        if(Input.GetKey(KeyCode.W))
        {
            bot.SpinUpWeapon();
        }
        if(Input.GetKey(KeyCode.S))
        {
            bot.SpinDownWeapon();
        }
    }
}
