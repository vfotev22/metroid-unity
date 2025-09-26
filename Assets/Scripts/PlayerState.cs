using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{

    PlayerInventory playerInventory;

    public GameObject standing;
    public GameObject morphed;
    PlayerJump jump;

    bool isStanding = false;

    void Awake()
    {
        playerInventory = this.GetComponent<PlayerInventory>();
        jump = GetComponentInChildren<PlayerJump>();
    }

    void Update()
    {
        if (isStanding && Input.GetKeyDown(KeyCode.DownArrow) && playerInventory.HasMorphBall() && jump != null && jump.IsGrounded())
        {
            standing.SetActive(false);
            morphed.SetActive(true);
            isStanding = false;
        }

        if (!isStanding && (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.UpArrow)))
        {
            standing.SetActive(true);
            morphed.SetActive(false);
            isStanding = true;
        }
    }
}
