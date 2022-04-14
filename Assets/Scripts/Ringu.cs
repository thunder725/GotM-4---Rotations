using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

    // ====================== ROTATING METHODS ======================
    // ringTwo.transform.Rotate(Vector3.up * tempSpeed * Time.deltaTime, Space.Self);
    // ringThree.transform.Rotate(Vector3.up * tempSpeed * Time.deltaTime, Space.Self);
    // ringFour.transform.Rotate(Vector3.up * tempSpeed * Time.deltaTime, Space.Self);
    // ringFive.transform.Rotate(Vector3.up * tempSpeed * Time.deltaTime, Space.Self);

public class Ringu : MonoBehaviour
{
    [SerializeField] Ring_Parameters[] Rings;
    PlayerController playerController;
    [SerializeField] float resetTimer; // Timer for them to reset
    public bool areRingsResetting; // If the rings should NOT be interacted with right now

    public bool eeeee;

    void Awake()
    {
        playerController = FindObjectOfType<PlayerController>();
    }

    void Start()
    {

    }

    void Update()
    {
        for (int i = 0; i < 4; i++)
        {
            Rings[i].DebugText.text = Rings[i].Name + ": " + VerifyRotationDifference(Rings[i].GO, Rings[i].StartingAngle);
        }
    }

    // ===============================================
    //      ROTATION METHODS
    // ===============================================

    float VerifyRotationDifference(GameObject ring, float startZRotation)
    {
        float angleDifference = 0;

        // The angle difference is just the angle between the ring's forward vector and the Parent Ring One's forward vector
        // When the ring is perfectly colinear (I don't care about if it's rotated 180° it's still aligned visually), the difference is 0, and it caps at 90°

        // This sounds like the principle of the Dot Product: positive or negative but most importantly,
        // it's close to 0 when they're perpandicular and 1 when they're aligned
        // I want the opposite so I'll use the Sin instead and voilà, we have a measure of how misaligned we are to the center ring

        // Calculates the Sin of the angle between the ring's forward and the parent's forward
        angleDifference = Mathf.Sin(Mathf.Deg2Rad * Vector3.Angle(transform.forward, ring.transform.forward));

        return angleDifference;
    }

    // Resets all rotations
    void ResetRings()
    {
        for (int i = 0; i < 4; i ++)
        {
            Rings[i].transform.localRotation = Quaternion.identity;
        }
    }

    // Puts the rings in new rotations in quasi-animation
    public IEnumerator NewRingRotations()
    {
        
        // ==========================================================
        // =====================================================================================
        // Version 2
        // =====================================================================================
        // ==========================================================

        /*
                Workflow for this version:

                - Reset all rotations to (0,0,0)
                - Randomize the Blue Axis and immediatly set it (0,0,z)
                - Get a random Green (y) value that has gotten +- several increments of 180
                - Only animate the Green axis inside of the while loop

                Let's try this
        */


        ResetRings();

        // ==========================================================
        //                      VARIABLE SETUPS
        // ==========================================================

        // Stop all interactions with those
        areRingsResetting = true;

        // Start timer
        float currentTimer = 0;

        // Get the new Green rotation for all rings
        float[] newRotationsY = new float[4]{0, 0, 0, 0};

        // Set the rotations to only one random Z value
        // First ring has a value between 5 and 85, then the second one has a value between 95 and 175, etc...
        // This will prevent having rings with rotations too similar in the end
        for (int i = 0; i < 4; i ++)
        {
            // Set the blue rotation
            Rings[i].transform.eulerAngles = Vector3.forward * ((i + 1) * 90 + Random.Range(5, 85f));


            // Getting new Green rotation
            newRotationsY[i] = ((i+1)*90 + Random.Range(5, 85f));
        }



        // ==========================================================
        //                      ACTUALLY ROTATING
        // ==========================================================

        while (currentTimer < 1)
        {
            // So that it starts at 0 and ends at 1 at Timer
            // It's to have lerps more easily
            currentTimer += Time.deltaTime / resetTimer;
        
            for (int i = 0; i < 4; i ++)
            {
                // Rotate of the value which is "Finish the whole thing in Timer value, and have it finish in newRotationY"
                Rings[i].transform.Rotate(Vector3.up * newRotationsY[i] * Time.deltaTime / resetTimer, Space.Self);
            }

            yield return new WaitForEndOfFrame();
        }


        areRingsResetting = false;

        StopAllCoroutines();
        yield return null;
    }

    // Rotates around the Green circle axis, the one that the player will change
    void RotateRing(GameObject _ring, float rotationValue)
    {
        _ring.transform.Rotate(Vector3.up * rotationValue, Space.Self); 
    }

    // Rotates around the Blue circle axis, so modifies how the RotateRing rotates
    void RotateRingPivot(GameObject _ring, float rotationValue)
    {
        _ring.transform.Rotate(Vector3.forward * rotationValue, Space.Self); 
    }

}
