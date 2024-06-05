﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    PlayerController playerController;
    public Animator animator;
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        animator = GetComponent<Animator>();
    }
    void Update()
    {      
        animator.SetFloat("inputX",playerController.input.x * playerController.currentSpeedMultiplier);
        animator.SetFloat("inputY", playerController.input.y * playerController.currentSpeedMultiplier);

        animator.SetBool("isAction", playerController.player.isActionMode);
        animator.SetBool("isFree", playerController.player.isFreeMode);

        animator.SetBool("isCrouch",playerController.player.isCrouch);

        animator.SetBool("isAxeInHand", playerController.player.isFullHand);// foreach ile elinde ne olduğuna göre aktif edilecek
    }
}
