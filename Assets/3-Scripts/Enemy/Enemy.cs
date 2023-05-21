using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public EnemyType enemyType;

    [System.Serializable]
    public class TransformListAttribute : PropertyAttribute { }

    [TransformList]
    public List<Transform> patrolPoints;

    public float moveSpeed;
    public float baseMoveSpeed;
    public float jumpForce;
    public float jumpCooldown = 0.5f;
    public LayerMask groundLayer;

    private Rigidbody2D enemyRB;
    public GameObject patrolPointsContainer;
    private int currentTarget;
    private bool facingRight = true;
    private bool canJump = true;

    public enum EnemyType
    {
        Patrolling = 0,
        Stationary = 1,
    }

    private void Start()
    {
        moveSpeed = baseMoveSpeed;

        enemyRB = GetComponent<Rigidbody2D>();

        if (patrolPoints.Count > 0)
        {
            currentTarget = 0;
        }
    }

    private void Update()
    {
        if (enemyType == EnemyType.Patrolling && patrolPoints.Count > 0)
        {
            Patrol();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("PatrolPoint"))
        {
            return;
        }
        else for (int i = 0; i < patrolPoints.Count; i++)
        {
            if (patrolPoints[i] == collision.transform)
            {
                currentTarget = (i + 1) % patrolPoints.Count;
                break;
            }
        }
    }

    private void Patrol()
    {
        Vector2 direction = patrolPoints[currentTarget].position - transform.position;
        float distanceToTarget = direction.magnitude;

        if (distanceToTarget < 0.1f)
        {
            currentTarget = (currentTarget + 1) % patrolPoints.Count;
            return;
        }
        else
        {
            direction.Normalize();
            CheckForObstacle();
            enemyRB.velocity = new Vector2(direction.x * moveSpeed, enemyRB.velocity.y);

            if (direction.x > 0 && !facingRight)
            {
                Flip();
            }
            else if (direction.x < 0 && facingRight)
            {
                Flip();
            }
        }
    }

    private void Flip()
    {
        facingRight = !facingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }

    private void CheckForObstacle()
    {
        if (canJump)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, facingRight ? Vector2.right : Vector2.left, 1f, groundLayer);

            if (hit.collider != null)
            {
                JumpOverObstacle();
            }
        }
    }

    private void JumpOverObstacle()
    {
        enemyRB.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        StartCoroutine(JumpCooldown());
    }

    private IEnumerator JumpCooldown()
    {
        canJump = false;
        yield return new WaitForSeconds(jumpCooldown);
        canJump = true;
    }

    public void ApplyMoveSpeedMultiplier(float multiplier)
    {
        moveSpeed = baseMoveSpeed * multiplier;
    }
}
