using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 6f;
    public float timeToDestroy = 4f;
    public bool playerBullet = false;
    public float damage = 1f;
    void Start()
    {
        Destroy(gameObject, timeToDestroy);

    }

    void Update()
    {
        transform.Translate(speed * Time.deltaTime, 0, 0);

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!playerBullet && collision.gameObject.CompareTag("Player"))
        {
            Player p = collision.gameObject.GetComponent<Player>();
            p.TakeDamage(damage);
            Destroy(gameObject);
        }
        else if (playerBullet && collision.gameObject.CompareTag("Enemy"))
        {
            Enemy e = collision.gameObject.GetComponent<Enemy>();
            e.TakeDamage(damage);
            Destroy(gameObject);
        }
        else
                if (collision.gameObject.CompareTag("Wall_Right"))
                {
                     Destroy(gameObject);
                }else if (collision.gameObject.CompareTag("Wall_Left"))
        {
            Destroy(gameObject);
        }
    }
}
