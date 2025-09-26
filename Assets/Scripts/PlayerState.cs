using UnityEngine;

public class PlayerState : MonoBehaviour
{
    PlayerInventory inventory;
    public GameObject standing;
    public GameObject morphed;

    bool isStanding = false;

    void Awake(){
        inventory = this.GetComponent<PlayerInventory>();
    }

    void Update()
    {
        if (isStanding && Input.GetKeyDown(KeyCode.DownArrow) && inventory.hasMorphBall())
        {
            standing.SetActive(false);
            morphed.SetActive(true);
            isStanding = false;
        }
        if (!isStanding && Input.GetKeyDown(KeyCode.UpArrow))
        {
            standing.SetActive(true);
            morphed.SetActive(false);
            isStanding = true;
        }
    }
}
