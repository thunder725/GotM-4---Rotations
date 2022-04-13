using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    // ====================== ROTATING METHODS ======================
    // ringTwo.transform.Rotate(Vector3.right * tempSpeed * Time.deltaTime, Space.Self);
    // ringThree.transform.Rotate(Vector3.right * tempSpeed * Time.deltaTime, Space.Self);
    // ringFour.transform.Rotate(Vector3.right * tempSpeed * Time.deltaTime, Space.Self);
    // ringFive.transform.Rotate(Vector3.right * tempSpeed * Time.deltaTime, Space.Self);

public class Ringu : MonoBehaviour
{
    [SerializeField] GameObject ringOne, ringTwo, ringThree, ringFour, ringFive;
    [SerializeField] float ringTwoSpeed, ringThreeSpeed, ringFourSpeed, ringFiveSpeed;

    // The starting Z rotation of the rings before we do any rotation
    // Afterwards, when checking if the player has done it well, it'll check for the "Zero Rotation" which is not 0 but the start rotation
    float startRingTwoZRotation, startRingThreeZRotation, startRingFourZRotation, startRingFiveZRotation;

    void Start()
    {
        startRingTwoZRotation = ringTwo.transform.localEulerAngles.z;
        startRingThreeZRotation = ringThree.transform.localEulerAngles.z;
        startRingFourZRotation = ringFour.transform.localEulerAngles.z;
        startRingFiveZRotation = ringFive.transform.localEulerAngles.z;
    }

    void Update()
    {
        
    }
}
