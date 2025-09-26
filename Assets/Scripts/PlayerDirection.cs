using UnityEngine;

public class PlayerDirection : MonoBehaviour
{
    public SpriteRenderer SpriteRenderer;
    public Sprite LookingForwardSprite;
    public Sprite LookingUpSprite;

    bool FacingRight = true;
    bool LookingUp = false;
   
    void Update()
    {
        // looking left and right
        float HorizontalAxis = Input.GetAxis("Horizontal");
        if(FacingRight && HorizontalAxis < 0){
            FacingRight = false;
            this.transform.localScale = new Vector3(-1, 1, 1);
        }
        if(!FacingRight && HorizontalAxis > 0){
            FacingRight = true;
            this.transform.localScale = new Vector3(1, 1, 1);
        }

        // looking up and not looking up
        bool HoldingUp = Input.GetKey(KeyCode.UpArrow);
        if (LookingUp && !HoldingUp){
            LookingUp = false;
            SpriteRenderer.sprite = LookingForwardSprite;
        } else if (!LookingUp && HoldingUp){
            LookingUp = true;
            SpriteRenderer.sprite = LookingUpSprite;
        }
    }

    // Get facing directions
        public bool IsFacingRight(){
            return FacingRight;
        }
        public bool IsLookingUp(){
            return LookingUp;
        }
}
