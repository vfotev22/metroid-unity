using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class DestoryOnTriggerEnter : MonoBehaviour
{
    public int damage = 5;
    void OnTriggerEnter(Collider other)
    {
        EnemyZoomer enemy = other.GetComponent<EnemyZoomer>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }
        Destroy(this.gameObject);
    }
}
