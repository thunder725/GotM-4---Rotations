using System.Runtime.Serialization;
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
    public Ring_Parameters[] Rings;
    PlayerController playerController;
    [SerializeField] float resetTimer; // Timer for them to reset
    public bool areRingsResetting; // If the rings should NOT be interacted with right now
    bool isIslandRotating, startRingRotation;

    [SerializeField] LayerMask enemyShipsLayer;
    [SerializeField] GameObject entireIsland;
    [SerializeField] ScoreAddedScript scoreAddedTextScript;
    [SerializeField] Text scoreText;

    [SerializeField] float islandRotationTimer; // Time for the island to get to the next selected target
    Transform target;
    float finalTargetHeight, currentTimer;
    int totalScore; 
    public bool testingBool;
    Coroutine islandRotationNewTarget;
    EnemyShipsScript targetScript;
    Vector3 vectorToPreviousTarget;

    float currentNotAlignedEnoughTextTimer;
    [SerializeField] GameObject notAlignedEnoughText;

    int[] newRotationsY = new int[4]{0, 0, 0, 0};

    [SerializeField] GameObject ExplosionParticles;

    void Awake()
    {
        playerController = FindObjectOfType<PlayerController>();
    }

    void Start()
    {
        SelectNewTarget();

        startRingRotation = true;
        notAlignedEnoughText.SetActive(false);
    }

    void Update()
    {

        // Debug.Log(CalculateScore());

        for (int i = 0; i < 4; i++)
        {
            Rings[i].DebugText.text = Rings[i].Name + ": " + 1000 * VerifyRotationDifference(Rings[i].GO);
        }

        if (target != null && testingBool)
        {  
            
            // If the island is already rotating towards it with the coroutine, let it
            if (!isIslandRotating)
            {
                entireIsland.transform.LookAt(target, Vector3.up);
                entireIsland.transform.eulerAngles = Vector3.up * entireIsland.transform.eulerAngles.y;
                
                // Rotate vertically Ring One 
                transform.LookAt(target, Vector3.up);
            }

        }

        if (currentNotAlignedEnoughTextTimer > 0)
        {
            currentNotAlignedEnoughTextTimer -= Time.deltaTime;
            
            if (currentNotAlignedEnoughTextTimer <= 0)
            {
                notAlignedEnoughText.SetActive(false);
            }
        }

        // ==============================
        // ROTATION UPDATE 
        // This doesn't work 100%, but it's the 4th or 5th version of the rotation
        // It uses the method "RotateRings" to rotate, and the inputs activate RotateRings too
        // But the two rotations don't cancel out, I don't know why, I've asked help of at least 3 people on the server
        // No one knows why and it's pretty technical so it's annoying to explain each time because the code is complicated
        // No matter what, that works good *enough*. I'm not a programmer, that'll be enough
        // We have other homework to do I can't spend 3 entire weeks on this game 


        /*
            Later edit: Apparently it's because in the world of Quaternions???, doing what we would call "a full rotation of 360??" around any axis
            doesn't mean a full rotation when changed into Quaternions. So for this game, the only way to have a perfect score is to 
            turn the rings in the opposite way they rotated, because that way it'll cancel out and they'll be aligned,
            but keeping rotating won't always return yourself to the starting rotation, or it'll take a long while at least
            So if you're unlucky (it happens often to be honest) and you go the "wrong" way, the rings might never align

            This is a bad Game Design news, but we're the 5th of May,
            the game is due in 5 days and I spent AT LEAST 25 hours on this one rotation problem alone...
            
            so I'm not making a new game

            Screw Quaternions I guess?
        
        

            Or maybe it's a feature and you can't be perfect but you have to do as best as you can
            idk yet        
        */ 



        // Only for the first frame of the ring rotation
        if (startRingRotation)
        {
            // Boolean shenanigans
            startRingRotation = false;
            areRingsResetting = true;
        
            // Reset the rings' rotations
            ResetRings();


            // Stop all interactions with those
            areRingsResetting = true;

            // Start timer
            currentTimer = 0;

            // Get the new Green rotation for all rings
            newRotationsY = new int[4]{0, 0, 0, 0};

            // Set the rotations to only one random Z value
            // First ring has a value between 5 and 85, then the second one has a value between 95 and 175, etc...
            // This will prevent having rings with rotations too similar in the end
            for (int i = 0; i < 4; i ++)
            {
                // Set the blue rotation
                Rings[i].transform.localEulerAngles = Vector3.forward * ((i + 1) * 90 + Random.Range(5, 85f));

                // Getting new Green rotation


                newRotationsY[i] = Random.Range(0, 361);
            }

            // Debug.Log(Rings[1].transform.localEulerAngles);

            SaveAllUpVectors();
        }

        // Rest of the rotation 
        if (areRingsResetting)
        {
            if (currentTimer < resetTimer)
            {
                currentTimer += Time.deltaTime;
            
                for (int i = 0; i < 4; i ++)
                {
                    // Rotate of the value which is "Finish the whole thing in Timer value, and have it finish in newRotationY "

                    RotateRing(Rings[i].GO, Rings[i], newRotationsY[i] * Time.deltaTime);

                    // Rotate
                    // Rings[i].transform.Rotate(Rings[i].RotationUpVector * newRotationsY[i] * Time.deltaTime, Space.Self);
                }
            }
            else // When timer is finished so the rotation is finished
            {
                areRingsResetting = false;
                startRingRotation = false;
            }
        }
    }

    // ===============================================
    //      ROTATION METHODS
    // ===============================================

    float VerifyRotationDifference(GameObject ring)
    {
        float angleDifference = 0;

        // The angle difference is just the angle between the ring's forward vector and the Parent Ring One's forward vector
        // When the ring is perfectly colinear (I don't care about if it's rotated 180?? it's still aligned visually), the difference is 0, and it caps at 90??

        // This sounds like the principle of the Dot Product: positive or negative but most importantly,
        // it's close to 0 when they're perpandicular and 1 when they're aligned
        // I want the opposite so I'll use the Sin instead and voil??, we have a measure of how misaligned we are to the center ring

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

    
    
    // // Puts the rings in new rotations in quasi-animation
    // public IEnumerator NewRingRotations()
    // {
    //     // =====================================================================================
    //     /*
    //         THIS DOESN'T WORK
    //         I DON'T KNOW WHY NOR HOW
    //         BUT IT DOESN'T
    //         YOU CAN RE-ENABLE IT AND TEST IT BUT IT BUGS OUT
    //     */
    //     // =====================================================================================



        
    //     // ==========================================================
    //     // =====================================================================================
    //     // Version 3
    //     // =====================================================================================
    //     // ==========================================================

    //     /*
    //             Workflow for this version:

    //             - Reset all rotations to (0,0,0)
    //             - Randomize the Blue Axis and immediatly set it (0,0,z)
    //             - Get a random Green (y) value that has gotten +- several increments of 180
    //             - Only animate the Green axis inside of the while loop

    //             Let's try this
    //     */


    //     // ResetRings();

    //     // ==========================================================
    //     //                      VARIABLE SETUPS
    //     // ==========================================================

    //     // Stop all interactions with those
    //     areRingsResetting = true;

    //     // Start timer
    //     float currentTimer = 0;

    //     // Get the new Green rotation for all rings
    //     int[] newRotationsY = new int[4]{0, 0, 0, 0};

    //     // Set the rotations to only one random Z value
    //     // First ring has a value between 5 and 85, then the second one has a value between 95 and 175, etc...
    //     // This will prevent having rings with rotations too similar in the end
    //     for (int i = 0; i < 4; i ++)
    //     {
    //         // Set the blue rotation
    //         Rings[i].transform.localEulerAngles = Vector3.forward * ((i + 1) * 90 + Random.Range(5, 85f));

    //         // Getting new Green rotation


    //         newRotationsY[i] = Random.Range(0, 361);
    //     }

    //     Debug.Log(Rings[2].transform.localEulerAngles);

    //     SaveAllUpVectors();

    //     // ==========================================================
    //     //                      ACTUALLY ROTATING
    //     // ==========================================================

    //     while (currentTimer < resetTimer)
    //     {
    //         // So that it starts at 0 and ends at 1 at Timer
    //         // It's to have lerps more easily
    //         currentTimer += Time.deltaTime;
        
    //         for (int i = 0; i < 4; i ++)
    //         {
    //             // Rotate of the value which is "Finish the whole thing in Timer value, and have it finish in newRotationY"

    //             RotateRing(Rings[i].GO, Rings[i], newRotationsY[i] * Time.deltaTime);

    //             // Rotate
    //             // Rings[i].transform.Rotate(Rings[i].RotationUpVector * newRotationsY[i] * Time.deltaTime, Space.Self);
    //         }

    //         yield return new WaitForEndOfFrame();
    //     }


    //     areRingsResetting = false;

    //     StopCoroutine(ringRotation);
    //     yield return null;
    // }



    void SaveAllUpVectors()
    {
        for (int i = 0; i < 4; i++)
        {
            Rings[i].RotationUpVector = Rings[i].transform.up;
        }
    }


    // Rotates around the Green circle axis, the one that the player will change
    public void RotateRing(GameObject _ring, Ring_Parameters ringScript,  float rotationValue)
    {
        _ring.transform.Rotate(ringScript.RotationUpVector * rotationValue, Space.Self); 
    }

    // Rotates around the Blue circle axis, so modifies how the RotateRing rotates
    void RotateRingPivot(GameObject _ring, Ring_Parameters ringScript, float rotationValue)
    {
        _ring.transform.Rotate(_ring.transform.forward * rotationValue, Space.Self); 
    }

    IEnumerator RotateIslandTowardsNewTarget()
    {
        isIslandRotating = true;

        /*

        Get the current's forward // angle
        Predict the target's position at the end
                - The target's Speed (in its script) is in Angles in Degrees
                - Get the current target's position on the Horizontal Plane of the island (to avoid any height)
                - Apply a Quaternion rotation of (TargetSpeed * TimeToRotateTowardsIt) (on the Y axis) to its current position
                        This should predict its new positon after a rotation

        Divide the angle between the start and end position of the target by the time to rotate towards it
        Move by an angle of this result each second

        */

        // Target's Starting Position, projected on the horitontal plane
        Vector3 targetsStartingProjectedPosition = target.transform.position;
        targetsStartingProjectedPosition[1] = entireIsland.transform.position.y;

        // Target's angular speed in Degrees per second (because used in a RotateAround method)
        float targetsAngularSpeed = target.GetComponent<EnemyShipsScript>().movementSpeed;

        // The Quaterion rotation
        var predictedTotalRotaiton = Quaternion.Euler(0, targetsAngularSpeed * islandRotationTimer, 0);

        // The predicted's position of the target after its rotation
                    /// Debug.log'd to confirm working!!
                    // It successfully predicted where it would end!!!
        Vector3 targetsEndProjectedPosition = predictedTotalRotaiton * targetsStartingProjectedPosition;


        // Calculate the angle difference between the current angle and the angle to the end
        float totalRotation = Vector3.SignedAngle(entireIsland.transform.forward, targetsEndProjectedPosition - entireIsland.transform.position, Vector3.up);

        // How much should we rotate per second
        var rotationPerSecond = totalRotation / islandRotationTimer;






        
        /*
            Calculate how much RingOne should rotate up or down to look at the target in the end

                - We know the vector to the previous target
                - We know the height of the new target at the end of the rotation
                
            Do a basic Sin = O/H
                Opposite = height difference // H = Hypothenusis = distance to the last target
                - Calculate the height difference between those two targets
                - Do the angle
        */

        // Difference =>  previous height - new height <=> (vectorToTarget + position).height - new height
        float heightDifference = (vectorToPreviousTarget + transform.position).y - finalTargetHeight;

        float deltaAngle = Mathf.Sin(heightDifference / vectorToPreviousTarget.magnitude) * Mathf.Rad2Deg;

        var ringOneRotationPerSecond =  deltaAngle / islandRotationTimer;


        // Debug.Log("RingOne will rotate a total of " + (ringOneRotationPerSecond * islandRotationTimer) + " degrees in " + islandRotationTimer + " which is a speed of " + ringOneRotationPerSecond + " degrees/s.");


        float currentTimer = 0;

        while (currentTimer < 1)
        {
            // Rotate the island
            entireIsland.transform.Rotate(0, rotationPerSecond * Time.deltaTime, 0);

            // Also rotate the main ring towards the Target's final height
            transform.Rotate(ringOneRotationPerSecond * Time.deltaTime, 0, 0);

            // Increase current timer
            currentTimer += Time.deltaTime / islandRotationTimer;

            yield return new WaitForEndOfFrame();
        }

        // Debug.Log("Target started at position " + targetsStartingProjectedPosition + " and ended at position " + target.transform.position + "\nWe predicted the position " + targetsEndProjectedPosition);

        isIslandRotating = false;

        StopCoroutine(islandRotationNewTarget);
        yield return null;
    }

    // ===============================================
    //      OTHER METHODS
    // ===============================================

    public void Fire()
    {
        

        if (!areRingsResetting)
        {

            var score = CalculateScore();

            if (score > 1200)
            {
                // Increase score
                totalScore += score;
                scoreText.text = totalScore.ToString("D9");

                // Animate it
                scoreAddedTextScript.StartAnimation(score);

                // Save the vector to previous target for Ring One's smooth animation
                vectorToPreviousTarget = target.transform.position - transform.position;

                // Spawn visual effects
                var particles = Instantiate(ExplosionParticles, target.transform.position, Quaternion.LookRotation(vectorToPreviousTarget));

                // Destroy 
                if (target != null)
                {Destroy(target.gameObject);}

                
                // Select new target
                SelectNewTarget();

                // Smooth rotate towards it
                islandRotationNewTarget = StartCoroutine(RotateIslandTowardsNewTarget());


                startRingRotation = true;
            }
            else
            {
                // Debug.Log("The rings are not aligned enough!   " + score);
                currentNotAlignedEnoughTextTimer = 3.5f;
                notAlignedEnoughText.SetActive(true);
            }            
        }
    }

    void SelectNewTarget()
    {
        var shipsDetected = Physics.OverlapSphere(transform.position, 100, enemyShipsLayer);
        if (shipsDetected.Length == 0)
        {
            Debug.LogError("NO SHIPS FOUND");
            target = null;
            return;
        }

        // Chose a random one
        var rnd = Random.Range(0, shipsDetected.Length);

        // Prevent getting the same as before (it should be destroyed but technically can be picked up again because the Destroy is not immediate)
        if (shipsDetected[rnd].transform == target)
        {
            if (rnd == 0)
            {
                rnd ++;
            }
            else
            {
                rnd --;
            }
        }

        target = shipsDetected[rnd].transform;

        targetScript = target.GetComponent<EnemyShipsScript>();
        finalTargetHeight = targetScript.WhatsYourHeightIn(islandRotationTimer);
    }

    int CalculateScore()
    {
        

        float score = 0;

        float temp0 = 0;

        for (int i = 0; i < 4; i++)
        {
            // Rotation difference is a number between 0 and 1, the closer to 0 the better is the score
            temp0 = VerifyRotationDifference(Rings[i].GO);


            // Debug.Log(( 5 / temp0) + " " + VerifyRotationDifference(Rings[i].GO));


            // Something weird happened...
            // Once during testing, The score overflowed to -2147483648 precisely because one ring was EXACTLY ALIGNED
            // so its sin was exactly 0, and there's a division by 0 so it's infinite, and then scores were added on top of it so it overflowed
            // So there's a fix for that event that won't happen ever again
            if (temp0 == 0)
            {
                temp0 = 0.00001f;
            }

            score += 5 / temp0;
        }    

        return (int)(score * 10);
    }


}
