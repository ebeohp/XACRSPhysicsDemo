using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    /// <summary>
    /// NOTE: In the future, would like create some kind of class inheritance structure for different varieties of weapons.
    /// This is a weapon class that only applies to horizontal spinners for now. 
    /// Weapon could also be a polymorphism of a wheel.
    /// </summary>
    
    public Timer timer; //NOTE: Would like to have a more efficient way of tracking this in the future.
    public HingeJoint weaponHingeJoint;
    private JointMotor weaponMotor; // Changed from 'var' to 'JointMotor'
    
    public void Start()
    {
        weaponHingeJoint = GetComponent<HingeJoint>();
        if (weaponHingeJoint != null)
        {
            weaponMotor = weaponHingeJoint.motor;
        }
        else
        {
            Debug.LogError("HingeJoint component not found.");
        }
    }
    //NOTE: These currently only apply input from PC. 
    public void SpinUp(float spinForce, float targetVelocity)
    {
        //var weaponMotor = weaponHingeJoint.motor;

        //wheel.GetComponent<Rigidbody>().freezeRotation = false;
        weaponMotor.force = spinForce;
        weaponMotor.targetVelocity = targetVelocity; //Use this when implementing joysticks: targetVelocity * botControllerAxis.y;
        weaponMotor.freeSpin = false; //If freeSpin is true, the motor will not brake at targetVelocity
        weaponHingeJoint.motor = weaponMotor; // NOTE: This was needed to actually get it to spin. Not sure why. Will need to research more.
        weaponHingeJoint.useMotor = true;
    }
    public void StopSpin()
    {
        //Turn off the motor and apply damper. 
        //var weaponMotor = weaponHingeJoint.motor;

        //wheel.GetComponent<Rigidbody>().freezeRotation = false;
        weaponMotor.force = 0;
        weaponMotor.targetVelocity = 0; //Use this when implementing joysticks: targetVelocity * botControllerAxis.y;
        weaponMotor.freeSpin = false; //If freeSpin is true, the motor will not brake at targetVelocity
        weaponHingeJoint.motor = weaponMotor; // NOTE: This was needed to actually get it to spin. Not sure why. Will need to research more.
        weaponHingeJoint.useMotor = true;

    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("waypoint"))
        {
            // Calculate the force of the weapon
            float weaponForce = GetSpinForce(); // Assuming Weapon script has a GetSpinForce method
            Debug.Log(weaponForce);
            AddScore(weaponForce);
            
            
        }
        else
        {
            Debug.Log("Collision object does not have waypoint tag.");
        }

        
    }
    public float GetSpinForce()
    {
        return weaponMotor.force;
    }
    

    public void AddScore(float scoreAdd)
    {
        if(scoreAdd == 0)
        {
           timer.score += 1; //+1 for eaching the target without spinning weapon.
        }
        timer.score += scoreAdd;
        
        if(scoreAdd < 1)
        {
            timer.smallScoreText.text = "Spin it Up!\n +" + 1;
        }
        else if (scoreAdd > 50)
        {
            timer.smallScoreText.text = "Hit!\n +" + scoreAdd.ToString();
        }
    }

    
}
