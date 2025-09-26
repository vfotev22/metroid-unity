using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    public float JumpPower = 12f;
    Rigidbody rb;
    Collider c;

    void Awake()
    {
        rb = this.GetComponentInParent<Rigidbody>();
        c = this.GetComponent<Collider>();
    }
    // Update is called once per frame
    void Update()
    {
        Vector3 NewVelocity = rb.linearVelocity;
        if (Input.GetKeyDown(KeyCode.Z) && IsGrounded()) {NewVelocity.y = JumpPower;}
        rb.linearVelocity = NewVelocity;
    }

    bool IsGrounded(){
        Collider c = this.GetComponentInChildren<Collider>();
        Ray r = new Ray(c.bounds.center, Vector3.down);
        float radius = c.bounds.extents.x - 0.05f;
        float FullDistance = c.bounds.extents.y + 0.05f;

        if (Physics.SphereCast(r, radius, FullDistance))
            return true;
        else
            return false;
    }
}
