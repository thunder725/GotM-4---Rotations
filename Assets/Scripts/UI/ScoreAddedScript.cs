using UnityEngine;
using UnityEngine.UI;

public class ScoreAddedScript : MonoBehaviour
{

    Text text;  RectTransform rect; Animator animator;
    Vector3 startingPos;

    // ======================== [DEFAULT UNITY METHODS] ========================
    void Awake()
    {
        text = GetComponent<Text>();
        animator = GetComponent<Animator>();
    }

    // ======================== [SCRIPT METHODS] ========================

    public void StartAnimation(int value)
    {
        transform.position = startingPos;

        text.text = value.ToString();

        animator.SetTrigger("Launch");
    }

}
