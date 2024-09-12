using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Wheel : MonoBehaviour
{
    public HingeJoint wheelHingeJoint;
    
    
    public void Start()
    {
        wheelHingeJoint = GetComponent<HingeJoint>();
        

    }
    //NOTE: These currently only apply input from PC. 
    public void SpinForward(float spinForce, float targetVelocity)
    {
        var wheelMotor = wheelHingeJoint.motor;

        //wheel.GetComponent<Rigidbody>().freezeRotation = false;
        wheelMotor.force = spinForce;
        wheelMotor.targetVelocity = targetVelocity; //Use this when implementing joysticks: targetVelocity * botControllerAxis.y;
        wheelMotor.freeSpin = false; //If freeSpin is true, the motor will not brake at targetVelocity
        wheelHingeJoint.motor = wheelMotor; // NOTE: This was needed to actually get it to spin. Not sure why. Will need to research more.
        wheelHingeJoint.useMotor = true;
    }

    public void SpinBackward(float spinForce, float targetVelocity)
    {
        
        var wheelMotor = wheelHingeJoint.motor;

        //wheel.GetComponent<Rigidbody>().freezeRotation = false;
        wheelMotor.force = spinForce;
        wheelMotor.targetVelocity = -targetVelocity; //Use this when implementing joysticks: targetVelocity * botControllerAxis.y;
        wheelMotor.freeSpin = false; //If freeSpin is true, the motor will not brake at targetVelocity
        wheelHingeJoint.motor = wheelMotor; // NOTE: This was needed to actually get it to spin. Not sure why. Will need to research more.
        wheelHingeJoint.useMotor = true;
    }
    public void StopSpin()
    {
        //Turn off the motor and apply damper. 
        var wheelMotor = wheelHingeJoint.motor;

        //wheel.GetComponent<Rigidbody>().freezeRotation = false;
        wheelMotor.force = 0;
        wheelMotor.targetVelocity = 0; //Use this when implementing joysticks: targetVelocity * botControllerAxis.y;
        wheelMotor.freeSpin = false; //If freeSpin is true, the motor will not brake at targetVelocity
        wheelHingeJoint.motor = wheelMotor; // NOTE: This was needed to actually get it to spin. Not sure why. Will need to research more.
        wheelHingeJoint.useMotor = true;

    }
}
