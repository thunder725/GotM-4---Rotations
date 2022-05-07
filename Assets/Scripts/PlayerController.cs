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
        inputs.Default.SkipTutorial.started += SkipTutorial;
        inputs.Default.QuitTheGame.started += QuitTheGame;
    }

    void OnDestroy()
    {
        inputs.Disable();
        inputs.Default.SelectRing.started -= SelectRing;
        inputs.Default.RotateSelectedRing.started -= RotateSelectedRing;
        inputs.Default.Fire.started -= Fire;
        inputs.Default.SkipTutorial.started -= SkipTutorial;
        inputs.Default.QuitTheGame.started += QuitTheGame;
    }

    void Update()
    {
        var ringTwoRotationValue = inputs.Default.RotateRingTwo.ReadValue<float>();
        var ringThreeRotationValue = inputs.Default.RotateRingThree.ReadValue<float>();
        var ringFourRotationValue = inputs.Default.RotateRingFour.ReadValue<float>();
        var ringFiveRotationValue = inputs.Default.RotateRingFive.ReadValue<float>();

        // Debug.Log(ringTwoRotationValue + "  " + ringThreeRotationValue + "  " + ringFourRotationValue + "  " + ringFiveRotationValue);

        // Don't rotate if the rings are doing the setup rotations
        if (!ringManager.areRingsResetting)
        {
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
        if (!ringManager.areRingsResetting)
        {
            if (selectedRing == null)
            {
                return;
            }

            // Use only the sign, because otherwise the speed difference between editor and build is like a factor of 4, even with *Time.deltaTime
            var value = Mathf.Sign(inputs.Default.RotateSelectedRing.ReadValue<float>());

            ringManager.RotateRing(selectedRing, selectedRingScript, selectedRotationSpeed * value * Time.deltaTime);
        }
    }

    void Fire(InputAction.CallbackContext c)
    {
        ringManager.Fire();
    }

    void SkipTutorial(InputAction.CallbackContext c)
    {

        // Only call SkipTutorial in the main script and not the buttons' script
        var _array = FindObjectsOfType<Tutorial>();
        foreach (Tutorial _t in _array)
        {
            if (_t.referenceForButtons == null)
            {
                _t.SkipTutorial();
                return;
            }
        }
    }

    void QuitTheGame(InputAction.CallbackContext c)
    {
        Application.Quit();
        Debug.Log("Quit game lol");
    }

}
