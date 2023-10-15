using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Referencias")]
    public EnemyType type = EnemyType.Eva;
    public GameObject bulletPrefab;
    public Transform firePoint;
    float timer = 0;
    [Header("Estadisticas")]
    public float speed = 4f;
    public float timeBtwShoot = 2f;
    public float moveSpeed = 2f;
    float life = 3f;
    public float maxLife = 3f;
    public float bulletSpeed = 5;
    public float damage = 1f;
    public float timeBtwSpawn = 0.5f;
    public Rigidbody2D rb;

    public int health = 1; // Puedes ajustar la cantidad de salud según tus necesidades

     void Start()
    {
       
    }

     void Update()
    {
        Movement();
        Mirror();
        Shoot();
    }
    void Movement()
    {
        if(gameObject != null)
        {
            transform.Translate(speed * Time.deltaTime, 0, 0);
            // bodyAnim.SetFloat("Speed", Mathf.Abs(rb.velocity.x));
        }

    }


    void Mirror()
    {
        if(gameObject != null)
        {
            if (rb.velocity.x < 0)
            {
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }
            else if (rb.velocity.x > 0)
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);

            }
        }
        

    }

    void Shoot()
    {
        if(gameObject != null && firePoint != null)
        {
            if (timer < timeBtwShoot)
            {
                timer += Time.deltaTime;
            }
            else
            {
                timer = 0f;
                GameObject bulletGo = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

            }
        }
       
    }

    public void TakeDamage(float amount)
    {
        life -= amount;
        if (life <= 0f)
        {
            Debug.Log("Un enemigo murio");
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(gameObject != null)
        {
            if (collision.gameObject.CompareTag("Wall_Right"))
            {
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }
            else if (collision.gameObject.CompareTag("Wall_Left"))
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);

            }
        }
        
    }
    public void ReceiveDamage(int damage)
    {
        if (health > 0)
        {
            health -= damage;
            if (health <= 0)
            {
                // El enemigo ha sido derrotado, puedes agregar lógica adicional aquí
                Destroy(gameObject);
            }
        }
    }
}

public enum EnemyType
{
    Eva,
    Mo
}
