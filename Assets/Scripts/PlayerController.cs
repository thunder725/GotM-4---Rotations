using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    Ringu ringManager;
    PlayerControllerInputs inputs;

    GameObject selectedRing;

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

        if (ringTwoRotationValue != 0)
        {

        }

        if (ringThreeRotationValue != 0)
        {

        }

        if (ringFourRotationValue != 0)
        {

        }

        if (ringFiveRotationValue != 0)
        {

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
            }
        }
    }
    public Vector2 MousePositionOnScreen()
    {
        return inputs.Default.MousePosition.ReadValue<Vector2>();
    }

    void RotateSelectedRing(InputAction.CallbackContext c)
    {

    }
    void Fire(InputAction.CallbackContext c)
    {
        StartCoroutine(ringManager.NewRingRotations());
    }

}
