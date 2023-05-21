using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBullet : MonoBehaviour
{
    public float bulletSpeed = 10f;
    public float shootingCooldown = 0.5f;
    public Sprite bulletSprite;

    private float lastShotTime;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && Time.time > lastShotTime + shootingCooldown)
        {
            lastShotTime = Time.time;
            Shoot();
        }
    }

    private void Shoot()
    {
        // Create a new bullet
        GameObject bullet = new GameObject("Bullet");
        bullet.transform.position = transform.position;
        bullet.transform.rotation = transform.rotation;
        bullet.tag = "Projectile";

        // Add SpriteRenderer to the bullet and assign a default sprite
        SpriteRenderer spriteRenderer = bullet.AddComponent<SpriteRenderer>();
        spriteRenderer.sprite = bulletSprite;

        // Add BoxCollider2D to the bullet and set it as a trigger
        BoxCollider2D boxCollider = bullet.AddComponent<BoxCollider2D>();
        boxCollider.size = new Vector2(0.5f, 0.5f);
        boxCollider.isTrigger = true;

        // Add Rigidbody2D to the bullet
        Rigidbody2D rb = bullet.AddComponent<Rigidbody2D>();
        rb.gravityScale = 0;

        // Set initial direction and rotation based on mouse position
        Vector3 direction = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position);
        direction.z = 0;
        direction.Normalize();
        rb.velocity = direction * bulletSpeed;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
        bullet.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

        // Add BulletFollowTarget script to the bullet
        bullet.AddComponent<BulletFollowTarget>();
    }
}