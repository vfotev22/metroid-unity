using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    Rigidbody rigid;
    Collider col;
    public PlayerRun run;

    public float jumpPower = 10.3f;
    public float jumpCutMultiplier = 0.35f;

    private bool wasGrounded;
    public bool lastJumpWasRunJump;

    void Awake()
    {
        rigid = this.GetComponentInParent<Rigidbody>();
        col = this.GetComponent<Collider>();
        run = this.GetComponentInParent<PlayerRun>();
    }

    void Update()
    {
        Vector3 newVelocity = rigid.velocity;

        bool grounded = IsGrounded();
        
        if (Input.GetKeyDown(KeyCode.Z) && IsGrounded())
        {
            newVelocity.y = jumpPower;

            lastJumpWasRunJump = Mathf.Abs(Input.GetAxisRaw("Horizontal")) > .01f;

            if (run != null)
            {
                bool standingStill = Mathf.Abs(Input.GetAxisRaw("Horizontal")) < .01f;
                run.moveSpeed = standingStill ? 4f : 5f;
            }
        }

        if (Input.GetKeyUp(KeyCode.Z) && newVelocity.y > 0f)
        {
            newVelocity.y *= jumpCutMultiplier;
        }

        if (grounded && !wasGrounded && run != null)
            {
                run.moveSpeed = 5f;
                lastJumpWasRunJump = false;
            }

        rigid.velocity = newVelocity;
        wasGrounded = grounded;
    }

    public bool IsRunJumping()
    {
        return !IsGrounded() && lastJumpWasRunJump;
    }

    public bool IsGrounded()
    {
        Collider col = GetComponentInChildren<Collider>();

        Ray ray = new Ray(col.bounds.center, Vector3.down);

        float radius = col.bounds.extents.x - 0.05f;

        float fullDistance = col.bounds.extents.y + 0.05f;

        return Physics.SphereCast(ray, radius, fullDistance);
    }
}
