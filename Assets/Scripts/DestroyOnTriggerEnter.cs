using UnityEngine;

public class DestroyOnTriggerEnter : MonoBehaviour
{
    void OnTriggerEnter(Collider other){
        Destroy(this.gameObject);
    }
}
