using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

    // ====================== ROTATING METHODS ======================
    // ringTwo.transform.Rotate(Vector3.right * tempSpeed * Time.deltaTime, Space.Self);
    // ringThree.transform.Rotate(Vector3.right * tempSpeed * Time.deltaTime, Space.Self);
    // ringFour.transform.Rotate(Vector3.right * tempSpeed * Time.deltaTime, Space.Self);
    // ringFive.transform.Rotate(Vector3.right * tempSpeed * Time.deltaTime, Space.Self);

public class Ringu : MonoBehaviour
{
    [SerializeField] Ring_Parameters[] Rings;
    PlayerController playerController;

    // The starting Z rotation of the rings before we do any rotation
    // Afterwards, when checking if the player has done it well, it'll check for the "Zero Rotation" which is not 0 but the start rotation

    void Awake()
    {
        playerController = FindObjectOfType<PlayerController>();
    }

    void Start()
    {
        for (int i = 0; i < 4; i++)
        {
            Rings[i].RingStartingAngle = Rings[i].RingGO.transform.localEulerAngles.z;
        }
    }

    void Update()
    {
        for (int i = 0; i < 4; i++)
        {
            Rings[i].DebugText.text = Rings[i].RingName + ": " + VerifyRotationDifference(Rings[i].RingGO, Rings[i].RingStartingAngle);
        }
        
    }

    // ===============================================
    //      ROTATION METHODS
    // ===============================================

    float VerifyRotationDifference(GameObject ring, float startZRotation)
    {
        float angleDifference = 0;

        // 

        // Calculate the difference of rotation between the wanted Z rotation and the actual Z rotation
        // Since the axes are not aligned with the world, rotating the LOCAL Y axis changes the GLOBAL Z rotation, so only taking one sample works
        // The ring being rotated 180° is the same as if not rotated visually so I tell it to not care
        angleDifference += Mathf.DeltaAngle(startZRotation, ring.transform.localEulerAngles.z);
        

        return angleDifference;
    }

    public void RotateRing(GameObject _ring, float rotationValue)
    {
        _ring.transform.Rotate(Vector3.right * rotationValue, Space.Self); 
    }

}
