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

    public enum BotSelection
    {
        TheThrongler, // The Throngler is Horizontal 2 Wheel Drive
        TheCube, 
    }
    public BotSelection botSelection;
    /// <summary>
    /// The Cube is just placeholder.
    /// In the future, I'd like to have a bot selection menu, like a choose your player.
    /// Each bot should have it's own unique properties already attached to it so the controller knows what input is valid.
    /// i.e. If it is a passive weapon bot, the controller should know not to try to spin up a weapon.
    /// </summary>

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
        /// <summary>
        /// This calls specific movement scripts within each bot's custom movement.
        /// It is important to note that "forward" and "backward" is all relative to the bot.
        /// This is to simulate important combat roboticist skills such as driving upside down or turning.
        /// This is PC Key based so there is no diagonal movement. 
        /// An RC Controller can go diagonal throttle but it only works on input that is on a sliding scale like joysticks!
        /// </summary>
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
        else if(Input.GetKey(KeyCode.S))
        {
            bot.SpinDownWeapon();
        }
        else
        {
            bot.SpinDownWeapon();
        }
    }
}
