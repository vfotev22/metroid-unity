using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public int damage = 8;
    public float knockback = 8f;
    public float knockUp = 2f;

    void OnTriggerEnter(Collider other)
    {
        var root = other.transform.root;
        if (!root.CompareTag("Player"))
        {
            return;
        }

        var hp = root.GetComponentInParent<PlayerHealth>();
        if (hp)
        {
            hp.TakeDamage(damage);
        }

        var rb = root.GetComponent<Rigidbody>();
        if (rb)
        {
            Vector3 dir = (root.position - transform.position).normalized;

            Vector3 knockDir = new Vector3(dir.x, 0f, dir.z).normalized * knockback + Vector3.up * knockUp;
            rb.velocity = Vector3.zero;

            rb.AddForce(knockDir, ForceMode.Impulse);
        }
    }
}
