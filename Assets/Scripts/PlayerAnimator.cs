using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{

    public SpriteRenderer spriteRenderer;
    public PlayerDirection direction;
    public PlayerJump jump;

    public Sprite[] runFrames;
    public Sprite[] runLookUpFrames;
    public Sprite[] runJumpFrames;
    public Sprite jumpSprite;
    public Sprite lookUpSprite;
    public Sprite jumpUpSprite;

    public float frameRate = .05f;

    private int currentFrame;
    private float timer;

    void Update()
    {
        float input = Input.GetAxisRaw("Horizontal");

        if (!jump.IsGrounded())
        {
            if (jump.IsRunJumping() && runJumpFrames.Length > 0)
            {
                timer += Time.deltaTime;
                if (timer >= frameRate)
                {
                    timer = 0f;
                    currentFrame = (currentFrame + 1) % runJumpFrames.Length;
                    spriteRenderer.sprite = runJumpFrames[currentFrame];
                }
            }
            else
            {
                if (direction.IsLookingUp() && jumpUpSprite != null)
                {
                    spriteRenderer.sprite = jumpUpSprite;
                }
                else
                {
                    spriteRenderer.sprite = jumpSprite;
                }
                currentFrame = 0;
                timer = 0f;
            }
            return;
        }


        if (direction.IsLookingUp() && !jump.IsRunJumping() && Mathf.Abs(input) > .01f && runLookUpFrames.Length > 0)
        {
            timer += Time.deltaTime;
            if (timer >= frameRate)
            {
                timer = 0f;
                currentFrame = (currentFrame + 1) % runLookUpFrames.Length;
                spriteRenderer.sprite = runLookUpFrames[currentFrame];
            }
            return;
        }

        if (direction.IsLookingUp() && !jump.lastJumpWasRunJump)
        {
            spriteRenderer.sprite = lookUpSprite;
            return;
        }

        if (Mathf.Abs(input) > .01f)
        {
            timer += Time.deltaTime;
            if (timer >= frameRate)
            {
                timer = 0f;
                currentFrame = (currentFrame + 1) % runFrames.Length;
                spriteRenderer.sprite = runFrames[currentFrame];
            }
        }
        else
        {
            spriteRenderer.sprite = direction.spriteLookingForward;
            currentFrame = 0;
            timer = 0f;
        }
    }
}
