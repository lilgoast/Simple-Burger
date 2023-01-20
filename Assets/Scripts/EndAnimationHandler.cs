using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndAnimationHandler : MonoBehaviour
{
    [SerializeField] Camera mainCamera;
    [SerializeField] GameObject obstacles;

    private Animator animator;
    private Animator cameraAnimator;

    void Awake()
    {
        cameraAnimator = mainCamera.GetComponent<Animator>();
        animator = gameObject.GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        if (UIHandler.levelComplete)
        {
            animator.SetTrigger("LevelComplete");

            obstacles.SetActive(false);

            cameraAnimator.Play("CameraAnim");
        }
    }
}
