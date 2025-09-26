using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDirection : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite spriteLookingForward;
    public Sprite spriteLookingUpward;

    bool facingRight = true;
    bool lookingUp = false;

    void Update()
    {
        float HorizontalAxis = Input.GetAxis("Horizontal");
        if (facingRight && HorizontalAxis < 0)
        {
            facingRight = false;
            this.transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (!facingRight && HorizontalAxis > 0)
        {
            facingRight = true;
            this.transform.localScale = new Vector3(1, 1, 1);
        }

        bool holdingUp = Input.GetKey(KeyCode.UpArrow);
        if (lookingUp && !holdingUp)
        {
            lookingUp = false;
            spriteRenderer.sprite = spriteLookingForward;
        }
        else if (!lookingUp && holdingUp)
        {
            lookingUp = true;
            spriteRenderer.sprite = spriteLookingUpward;
        }
    }

    public bool IsFacingRight()
    {
        return facingRight;
    }

    public bool IsLookingUp()
    {
        return lookingUp;
    }
}
