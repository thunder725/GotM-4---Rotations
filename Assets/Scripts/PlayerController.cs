using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    Ringu ringManager;
    PlayerControllerInputs inputs;

    GameObject selectedRing;
    Ring_Parameters selectedRingScript;

    public float selectedRotationSpeed;

    [SerializeField] LayerMask RingHitLayer;



    // ====================================
    //         Default Unity Methods
    // ====================================

    void Awake()
    {
        ringManager = FindObjectOfType<Ringu>();

        inputs = new PlayerControllerInputs();
        inputs.Enable();
        inputs.Default.SelectRing.started += SelectRing;
        inputs.Default.RotateSelectedRing.started += RotateSelectedRing;
        inputs.Default.Fire.started += Fire;
    }

    void OnDestroy()
    {
        inputs.Disable();
        inputs.Default.SelectRing.started -= SelectRing;
        inputs.Default.RotateSelectedRing.started -= RotateSelectedRing;
        inputs.Default.Fire.started -= Fire;
    }

    void Update()
    {
        var ringTwoRotationValue = inputs.Default.RotateRingTwo.ReadValue<float>();
        var ringThreeRotationValue = inputs.Default.RotateRingThree.ReadValue<float>();
        var ringFourRotationValue = inputs.Default.RotateRingFour.ReadValue<float>();
        var ringFiveRotationValue = inputs.Default.RotateRingFive.ReadValue<float>();

        // If the buttons are pressed, rotate in the good direction the corresponding ring
        if (ringTwoRotationValue != 0)
        {
            ringManager.RotateRing(ringManager.Rings[0].GO, ringManager.Rings[0], ringManager.Rings[0].RotationSpeed * Time.deltaTime * ringTwoRotationValue);
        }

        if (ringThreeRotationValue != 0)
        {
            ringManager.RotateRing(ringManager.Rings[1].GO, ringManager.Rings[1], ringManager.Rings[1].RotationSpeed * Time.deltaTime * ringThreeRotationValue);
        }

        if (ringFourRotationValue != 0)
        {
            ringManager.RotateRing(ringManager.Rings[2].GO, ringManager.Rings[2], ringManager.Rings[2].RotationSpeed * Time.deltaTime * ringFourRotationValue);
        }

        if (ringFiveRotationValue != 0)
        {
            ringManager.RotateRing(ringManager.Rings[3].GO, ringManager.Rings[3], ringManager.Rings[3].RotationSpeed * Time.deltaTime * ringFiveRotationValue);
        }
    }



    // ====================================
    //    Inputs & Distributors Methods
    // ====================================

    void SelectRing(InputAction.CallbackContext c)
    {
        if (!ringManager.areRingsResetting)
        {
            // Do a raycast that hits the rings
            Ray ray = Camera.main.ScreenPointToRay(MousePositionOnScreen());

            if (Physics.Raycast(ray, out RaycastHit raycastHit, Mathf.Infinity, RingHitLayer))
            {
                // The colliders are in child objects of the Rings, so i'll use the Rigidbody (on the Ring) and not the Colliders (in the child)
                selectedRing = raycastHit.rigidbody.gameObject;
                selectedRingScript = selectedRing.GetComponent<Ring_Parameters>();
            }
        }
    }
    public Vector2 MousePositionOnScreen()
    {
        return inputs.Default.MousePosition.ReadValue<Vector2>();
    }

    void RotateSelectedRing(InputAction.CallbackContext c)
    {
        if (selectedRing == null)
        {
            return;
        }

        var value = inputs.Default.RotateSelectedRing.ReadValue<float>();

        ringManager.RotateRing(selectedRing, selectedRingScript, selectedRotationSpeed * value * Time.deltaTime);
    }

    void Fire(InputAction.CallbackContext c)
    {
        ringManager.Fire();
    }

}
