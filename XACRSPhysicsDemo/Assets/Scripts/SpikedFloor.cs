using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikedFloor : MonoBehaviour
{
    public float forceAmount = 10f;   // Amount of force to apply when colliding with the spiked floor
    public float upwardDistance = 0.1f; // Distance to move the spiked floor upward
    public float speed = 0.05f;          // Speed of the upward and downward movement
    public float interval = 5f;       // Time interval for the spiked floor to pop up

    private Vector3 originalPosition; // Original position of the spiked floor

    private void Start()
    {

        originalPosition = transform.position;
        StartCoroutine(PopUpAndDown());
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the colliding object has a Rigidbody and is tagged "chassis"
        
        Rigidbody collidingRb = other.GetComponent<Rigidbody>();
        if (collidingRb != null && other.CompareTag("chassis"))
        {
            Debug.Log("Spiked!");
            // Apply an upward impulse to the colliding object
            collidingRb.AddForce(Vector3.up * forceAmount, ForceMode.Impulse);
        }
    }

    private IEnumerator PopUpAndDown()
    {
        while (true)
        {
            // Move up
            Vector3 targetPosition = originalPosition + Vector3.up * upwardDistance;
            yield return StartCoroutine(MoveToPosition(targetPosition));

            // Pause at the top
            yield return new WaitForSeconds(interval);

            // Move down
            yield return StartCoroutine(MoveToPosition(originalPosition));

            // Pause at the bottom
            yield return new WaitForSeconds(interval);
        }
    }

    private IEnumerator MoveToPosition(Vector3 targetPosition)
    {
        float elapsedTime = 0f;
        Vector3 startingPosition = transform.position;

        while (elapsedTime < speed)
        {
            transform.position = Vector3.Lerp(startingPosition, targetPosition, (elapsedTime / speed));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPosition; // Ensure the final position is exactly at the target
    }
}
