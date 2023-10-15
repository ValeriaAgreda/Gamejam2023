using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    [Header("estadisticas")]
    public float moveSpeed = 2f;
    public float junmpForce = 5f;
    public bool canJump = true;
    [Header("referencias")]
    public Rigidbody2D rb;
    public Animator animator;
    public int damageAmount = 1; // La cantidad de daño que inflige el jugador
    public float LifePlayer = 3;
    public float life = 3f;
    public float maxLife = 3f;
    // Referencia al enemigo
    public Enemy enemy;


    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Mirror();
        Atack();

    }
    void Movement()
    {
        float inputMovimientoX = Input.GetAxis("Horizontal");
        float inputMovimientoY = Input.GetAxis("Vertical");
        rb.velocity = new Vector2(inputMovimientoX * moveSpeed, inputMovimientoY*moveSpeed);
        if(inputMovimientoX != 0f || inputMovimientoY != 0f)
        {
            animator.SetBool("IsRunning", true);
        }
        else
        {
            animator.SetBool("IsRunning", false);
        }

    }
    void Mirror()
    {
        if( gameObject != null)
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

    void Atack()
    {
        if (Input.GetMouseButton(0))
        {
            
            animator.SetBool("IsAtacking", true);
        }
        else
        {
            animator.SetBool("IsAtacking", false);
        }
    }

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (animator.GetBool("IsAtacking") == true)
        {
            Debug.Log("enemigo detectado");
            enemy.ReceiveDamage(1);
        }
        else
        {
            Debug.Log("Fallo");
        }
    }

    public void TakeDamage(float amount)
    {
        life -= amount;
        if (life <= 0f && LifePlayer > 0)
        {
            Debug.Log("Perdiste 1 vida");
            LifePlayer--;


        }
        else if (LifePlayer == 0)
        {
            Destroy(gameObject);
            Debug.Log("Ya no te quedan vidas");
        }
    }


}
