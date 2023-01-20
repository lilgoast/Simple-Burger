using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndAnimationHandler : MonoBehaviour
{
    [SerializeField] Camera mainCamera;

    private static Animator animator;
    private static Animator cameraAnimator;

    void Awake()
    {
        cameraAnimator = mainCamera.GetComponent<Animator>();
        animator = gameObject.GetComponent<Animator>();
    }

    public static void StartAnimation()
    {
        if (UIHandler.levelComplete)
        {
            animator.SetTrigger("LevelComplete");

            GameObject.FindGameObjectWithTag("Obstacles").SetActive(false);

            cameraAnimator.Play("CameraAnim");
        }
    }
}
