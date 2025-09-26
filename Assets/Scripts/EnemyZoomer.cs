using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Scripting.APIUpdating;

public class EnemyZoomer : MonoBehaviour
{

    public float moveSpeed;
    public GameObject[] wayPoints;
    public SpriteRenderer sr;
    public Sprite moveFrame2;
    float frameRate = .05f;
    public int maxHealth = 20;
    public Color hitColor = Color.red;
    public float flashDuration = 0.1f;



    private Color originalColor;
    private int currentHealth;

    private Sprite idleFrame;
    private float animTimer = 0f;
    private bool useAlt = false;

    int nextWaypoint = 0;
    float distToPoint;

    Rigidbody rb;

    void Start()
    {
        if (sr == null) sr = GetComponent<SpriteRenderer>();
        idleFrame = sr.sprite;

        currentHealth = maxHealth;
        originalColor = sr.color;
    }

    void Update()
    {
        Move();
        Animate();
    }

    void Move()
    {
        if (wayPoints == null || wayPoints.Length == 0)
        {
            return;
        }

        Vector3 target = wayPoints[nextWaypoint].transform.position;

        distToPoint = Vector3.Distance(transform.position, target);

        Vector3 nextPos = Vector3.MoveTowards(transform.position, target, moveSpeed * Time.deltaTime);

        if (rb != null)
        {
            rb.MovePosition(nextPos);
        }
        else
        {
            transform.position = nextPos;
        }

        if (distToPoint < .2f)
        {
            TakeTurn();
        }
    }

    void TakeTurn()
    {
        Vector3 currRot = transform.eulerAngles;
        currRot.z += wayPoints[nextWaypoint].transform.eulerAngles.z;
        transform.eulerAngles = currRot;
        ChooseNextWaypoint();
    }

    void ChooseNextWaypoint()
    {
        if (wayPoints == null || wayPoints.Length == 0)
        {
            return;
        }
        nextWaypoint = (nextWaypoint + 1) % wayPoints.Length;
    }

    void Animate()
    {
        if (sr == null || moveFrame2 == null)
        {
            return;
        }

        animTimer += Time.deltaTime;
        if (animTimer >= frameRate)
        {
            animTimer = 0f;
            useAlt = !useAlt;
            sr.sprite = useAlt ? moveFrame2 : idleFrame;
        }
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        StartCoroutine(FlashRed());
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }

    private IEnumerator FlashRed()
    {
        sr.color = hitColor;
        yield return new WaitForSeconds(flashDuration);
        sr.color = originalColor;
    }
}
