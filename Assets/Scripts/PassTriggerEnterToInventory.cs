using UnityEngine;

public class PassTriggerEnterToInventory : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    PlayerInventory inventory;

    void Awake(){
        inventory = this.GetComponentInParent<PlayerInventory>();
    }

    void OnTriggerEnter(Collider other){
        inventory.OnTriggerEnter(other);
    }
}
