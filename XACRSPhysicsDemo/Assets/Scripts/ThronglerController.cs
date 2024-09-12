using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThronglerController : MonoBehaviour, IBot // Inherit from a overall Bot Properties?
{

    //2 Wheel Drive with a Horizontal Spinner Weapon
    public Wheel wheelLeft;
    public Wheel wheelRight;
    public Weapon weapon;

    public float wheelSpinForce = 50f;
    public float wheelTargetVelocity = 500f;

    public float weaponSpinForce = 100f;
    public float weaponTargetVelocity = 1000f;

    public enum SpinWeaponProgram // These are the most common types of programming for spinning weapons
    {
        NegativeToPositive, // -1 to +1 Spin
        ZeroToOne, // 0 to +1 Spin
    }
    public SpinWeaponProgram spinWeaponProgram;
   
    // Have every method below properties how to drive the bot.
    
    public void TurnClockwise()
    {
        // Implement movement logic specific to The Throngler

        //Call Wheel Class Method
        wheelLeft.SpinForward(wheelSpinForce, wheelTargetVelocity);
        wheelRight.SpinBackward(wheelSpinForce, wheelTargetVelocity); //Negate the vlaues for spinning backward

    }
    public void TurnCounterClockwise()
    {
        // Implement movement logic specific to The Throngler

        //Call Wheel Class Method
        wheelLeft.SpinBackward(wheelSpinForce, wheelTargetVelocity);
        wheelRight.SpinForward(wheelSpinForce, wheelTargetVelocity);

    }
    public void MoveForward()
    {
        wheelLeft.SpinForward(wheelSpinForce, wheelTargetVelocity);
        wheelRight.SpinForward(wheelSpinForce, wheelTargetVelocity);
    }
    public void MoveBackward()
    {
        wheelLeft.SpinBackward(wheelSpinForce, wheelTargetVelocity);
        wheelRight.SpinBackward(wheelSpinForce, wheelTargetVelocity);
    }
    public void StopMove()
    {
        wheelLeft.StopSpin();
        wheelRight.StopSpin();
    }

    /// <summary>
    /// NOTE: Bot weapons can to have different programming for what "spin up" and "spin down" means.
    /// There is -1 to +1 spin. Spin up means clockwise. Spin down can mean counter clockwise.
    /// There is 0 to 1 spin. A 0 is spin down to stop applying more force to it.
    /// For now, these two methods are for the 0 to 1 Spin. 0 on Joysticks is technically not a brake. It is a brake here on PC.
    /// </summary>
    public void SpinUpWeapon()
    {
        // Implement weapon functionality
        weapon.SpinUp(weaponSpinForce, weaponTargetVelocity);
    }

    public void SpinDownWeapon()
    {
        // Implement weapon functionality
        weapon.StopSpin();
        //Call Weapon Class Method
    }
}
