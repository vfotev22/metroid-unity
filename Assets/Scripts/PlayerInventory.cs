using UnityEngine;
using TMPro;

public class PlayerInventory : MonoBehaviour
{
    public bool HasMorphBall = false;
    public bool HasMissiles = false;
    public bool HasLongBeam = false;
    public bool GodMode = false;

    public int Health = 30; // starting health and missile stats
    public int Missiles = 0;
    public int IFramesLeft = 0;

    public TMP_Text UIText;

    void Update(){
        if (HasMissiles) {UIText.text = "Health " + Health + "\nMissiles " + Missiles;}
        else {UIText.text = "Health " + Health;}

        if (Health > 99) {Health = 99;}

        if (Input.GetKeyDown(KeyCode.Alpha1)) {ToggleGodMode();}
        
        if (IFramesLeft > 0) {IFramesLeft--;}
    }

    public void OnTriggerEnter(Collider other){
        if (other.tag == "MorphBall"){
            Destroy(other.gameObject);
            HasMorphBall = true;
        }
        if (other.tag == "MissileUnlock"){
            Destroy(other.gameObject);
            HasMissiles = true;
            Missiles = 5;
        }
        if (other.tag == "LongBeamUnlock"){
            Destroy(other.gameObject);
            HasLongBeam = true;
        }

        if (other.tag == "HealthPickup" && Health < 99){
            Destroy(other.gameObject);
            Health += 5;
        }
        if (other.tag == "MissilePickup" && HasMissiles){
            Destroy(other.gameObject);
            Missiles += 5;
        }

        if (other.tag == "Enemy"){
            TakeDamage(8);
            IFramesLeft = 30;
        }
        if (other.tag == "Lava"){
            TakeDamage(1);
            IFramesLeft = 3;
        }
        //if other = missile unlock | longbeam unlock: HasMissiles = true
        //if other = missile pickup: if HasMissiles = false or missiles >= 5 do nothing | if HasMissiles = true missiles += 2 and destroy item
        //if other = health pickup -> if health < 99 destroy item, health += 5 (else do nothing)
    }

    void TakeDamage(int damage) // create tag for lava and enemy | damager tag exists for now
    {
        if (GodMode == false && IFramesLeft == 0) {Health -= damage;}
        // 8 damage on touching an enemy + iframes. 1 damage on touching lava + no iframes.
    }
    void ToggleGodMode()
    {
        GodMode = !GodMode;
    }

    public bool hasMorphBall(){
        return HasMorphBall;
    }
    public bool hasMissiles(){
        return HasMissiles;
    }
    public bool hasLongBeam(){
        return HasLongBeam;
    }

    public int GetHealth(){
        return Health;
    }
    public int GetMissiles(){
        return Missiles;
    }
}
