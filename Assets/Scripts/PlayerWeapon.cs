using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    PlayerDirection direction;
    public GameObject bullet;
    PlayerInventory inventory;

    public Transform FireForward;
    public Transform FireUp;

    public float FireSpeed = 10f;

    void Awake(){
        direction = this.GetComponentInParent<PlayerDirection>();
        inventory = this.GetComponentInParent<PlayerInventory>();
    }

    void Update(){
        if(Input.GetKeyDown(KeyCode.X)){
            GameObject bulletInstance = GameObject.Instantiate(bullet);

            if(direction.IsLookingUp()){
                bulletInstance.transform.position = FireUp.position;
                bulletInstance.GetComponent<Rigidbody>().linearVelocity = Vector3.up * FireSpeed;
            } else {
                bulletInstance.transform.position = FireForward.position;
                if (direction.IsFacingRight()) {bulletInstance.GetComponent<Rigidbody>().linearVelocity = Vector3.right * FireSpeed;}
                else {bulletInstance.GetComponent<Rigidbody>().linearVelocity = Vector3.left * FireSpeed;}


            }
            if(!inventory.hasLongBeam()) {Destroy(bulletInstance, 0.35f);}
        }
    }
}
