using UnityEngine;

public class TestRotationScript : MonoBehaviour
{

    public Ring_Parameters[] Rings;

    float timer;
    int value;

    // ======================== [DEFAULT UNITY METHODS] ========================
    
    void Start()
    {
        timer = 0;
        value = 1;

        Rings[0].RotationUpVector = Rings[0].transform.up;
    }
    
    void Update()
    {
        timer += Time.deltaTime;

        RotateRing(Rings[0].GO, Rings[0], 60 * Time.deltaTime * value);

        if (timer > 8)
        {
            timer = 0;
            value = -value;
        }

    }

    // ======================== [SCRIPT METHODS] ========================

    // Rotates around the Green circle axis, the one that the player will change
    public void RotateRing(GameObject _ring, Ring_Parameters ringScript,  float rotationValue)
    {
        _ring.transform.Rotate(ringScript.RotationUpVector * rotationValue, Space.Self); 
    }

}
