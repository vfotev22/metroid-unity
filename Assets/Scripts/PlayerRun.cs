using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEditor.Il2Cpp;
using UnityEngine;

public class PlayerRun : MonoBehaviour
{
    Rigidbody rigid;

    public float moveSpeed = 5;
    private bool isKnockback = false;

    void Awake()
    {
        rigid = this.GetComponent<Rigidbody>();
    }

    void Update()
    {
        UnityEngine.Vector3 newVelocity = rigid.velocity;

        newVelocity.x = Input.GetAxis("Horizontal") * moveSpeed;

        rigid.velocity = newVelocity;
    }
}
