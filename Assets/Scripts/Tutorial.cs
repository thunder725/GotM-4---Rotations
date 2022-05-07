using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{

    GameObject tutorialPanel;
    [SerializeField] GameObject centerTutorialPanel, rightTutorialPanel;
    Text centerPanelText, rightPanelText;
    [TextArea]
    [SerializeField] string[] tutorialTexts;

    // I'm too lazy to create a separate script for buttons or to make a scriptable object or a static thing
    // So I'll attack this script on the buttons to go to the next step, they'll call "NextStepButton"
    // It will call NextStep on the reference only
    // Trash but it works
    public Tutorial referenceForButtons;
    
    int currentStep;

    // ======================== [DEFAULT UNITY METHODS] ========================
    void Awake()
    {
        // Workaround way to only launch this code if this is the real script and not the button's script
        if (referenceForButtons == null)
        {
            tutorialPanel = this.gameObject;
            centerPanelText = centerTutorialPanel.transform.GetChild(0).GetComponent<Text>();
            rightPanelText = rightTutorialPanel.transform.GetChild(0).GetComponent<Text>();

            NextStep(0);
            currentStep = 0;
        }
    }

    // ""Flowchart"" of the tutorial: 
    
    /*
        - 0 - Presentation of the tutorial +   [X] to skip
        - 1 - "Align the rings as best as you can and shoot the ships"
        - 2 - "Click on a ring and rotate it"
        - 3 - "Use ZS ED RF TG to rotate it"
        - 4 - "Do the highest score possible"
        - 5 - End Tutorial
    */


    // ======================== [SCRIPT METHODS] ========================

    public void SkipTutorial()
    {
        tutorialPanel.SetActive(false);
        centerTutorialPanel.SetActive(false);
        rightTutorialPanel.SetActive(false);
    }

    // Show the next step of the tutorial
    void NextStep(int stepIndex)
    {
        switch (stepIndex)
        {
            case 0:
            rightTutorialPanel.SetActive(false);
            centerTutorialPanel.SetActive(true);
            centerPanelText.text = tutorialTexts[0];
            break;
            
            case 1:
            rightTutorialPanel.SetActive(false);
            centerTutorialPanel.SetActive(true);
            centerPanelText.text = tutorialTexts[1];
            break;

            case 2:
            rightTutorialPanel.SetActive(true);
            centerTutorialPanel.SetActive(false);
            rightPanelText.text = tutorialTexts[2];
            break;

            case 3:
            rightTutorialPanel.SetActive(true);
            centerTutorialPanel.SetActive(false);
            rightPanelText.text = tutorialTexts[3];
            break;

            case 4:
            rightTutorialPanel.SetActive(true);
            centerTutorialPanel.SetActive(false);
            rightPanelText.text = tutorialTexts[4];
            break;

            case 5:
            SkipTutorial();
            break;

            default:
                Debug.LogError("Unknown index for the tutorial: " + stepIndex);
            break;
        }
    }

    public void NextStepFromButton()
    {
        // Increase current step by 1, and then call NextStep on the real Tutorial manager and not on this button
        referenceForButtons.currentStep++;
        referenceForButtons.NextStep(referenceForButtons.currentStep);
    }



}
