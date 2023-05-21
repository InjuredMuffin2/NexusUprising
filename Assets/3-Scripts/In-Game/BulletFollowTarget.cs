using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFollowTarget : MonoBehaviour
{
    public float speed = 10f;
    public float rotationSpeed = 360f;
    public float enemyDetectionRadius = 10f;
    public bool useMouseAsTarget = true;
    public bool enemyTakesPriority = true;

    private Rigidbody2D rb;
    private Transform target;
    private Vector3 direction;
    private LayerMask enemyLayer;

    private float bulletLifetime = 2;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // Set the enemyLayer to the "Enemy" layer
        enemyLayer = 1 << LayerMask.NameToLayer("Enemy");

        // Set initial direction based on mouse position
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        direction = (new Vector3(mousePos.x, mousePos.y, 0) - transform.position);
        direction.z = 0;
        direction.Normalize();
        rb.velocity = direction * speed;

        // Set initial rotation to face the direction of the mouse cursor
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }

    private void FixedUpdate()
    {
        rotationSpeed = Random.Range(300f, 400f);
    }
    private void Update()
    {
        bulletLifetime -= Time.deltaTime;

        if (useMouseAsTarget)
        {
            if (enemyTakesPriority)
            {
                FindClosestEnemy();
                if (target == null)
                {
                    FollowMouse();
                }
            }
            else
            {
                FollowMouse();
            }
        }

        if (target != null)
        {
            RotateTowards(target.position);
        }

        if(bulletLifetime <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Enemy") || collision.collider.CompareTag("Surface"))
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") || collision.CompareTag("Surface"))
        {
            Destroy(this.gameObject);
        }
    }

    private void RotateTowards(Vector3 targetPos)
    {
        Vector3 directionToTarget = (targetPos - transform.position).normalized;
        float targetAngle = Mathf.Atan2(directionToTarget.y, directionToTarget.x) * Mathf.Rad2Deg - 90f;
        float angle = Mathf.MoveTowardsAngle(transform.eulerAngles.z, targetAngle, rotationSpeed * Time.deltaTime);
        transform.eulerAngles = new Vector3(0, 0, angle);
        rb.velocity = transform.up * speed;
    }

    private void FindClosestEnemy()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, enemyDetectionRadius, enemyLayer);

        float closestDistance = Mathf.Infinity;
        Transform closestEnemy = null;

        foreach (Collider2D collider in colliders)
        {
            float distance = Vector3.Distance(transform.position, collider.transform.position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestEnemy = collider.transform;
            }
        }

        target = closestEnemy;
    }

    private void FollowMouse()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z));
        mousePos.z = 0;
        RotateTowards(mousePos);
    }
}