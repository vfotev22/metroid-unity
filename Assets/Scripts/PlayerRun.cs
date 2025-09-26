using UnityEngine;
//using UnityEngine.InputSystem;
using System.Collections;
using System.Collections.Generic;

public class PlayerRun : MonoBehaviour
{
    Rigidbody rb;
    public float MoveSpeed = 5f;
    public float JumpPower = 12f;

    void Awake(){
        rb = this.GetComponent<Rigidbody>();
    }
    void Update(){
        Vector3 NewVelocity = rb.linearVelocity;
        NewVelocity.x = Input.GetAxis("Horizontal") * MoveSpeed;
        rb.linearVelocity = NewVelocity;

    }
}
