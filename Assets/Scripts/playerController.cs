using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class playerController : MonoBehaviour
{
    const int maxHP = 3;
    public int HP;
    
    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private float jumpForce;

    Rigidbody2D rb2D;

    private bool isGrounded;
    [SerializeField]
    private Transform groundPos;
    [SerializeField]
    private float Radius;
    [SerializeField]
    private LayerMask groundMask;

    public bool isDead;

    [SerializeField]
    private Transform hand;
    [SerializeField]
    private GameObject bomb;
    [SerializeField]
    private float throwForce;

    [SerializeField]
    GameObject gameOverScreen;

    Animator anim;

    bool canTakeDamage;
    float canTakeDamageTime;
    float canTakeDamgeMaxTime = 1;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();

        anim = GetComponent<Animator>();

        HP = maxHP;

        canTakeDamage = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead == false)
        {
            isGrounded = Physics2D.OverlapCircle(groundPos.position, Radius, groundMask);
            if (Input.GetAxisRaw("Vertical") > 0 && isGrounded == true)
            {
                rb2D.velocity = Vector2.up * jumpForce;
            }

            if (GameObject.FindGameObjectWithTag("dead").transform.position.y > transform.position.y)
            {
                isDead = true;
            }

            if(isGrounded == false)
            {
                anim.SetInteger("state", 2);
            }

            Attacking();
        }
        else
        {
            gameOverScreen.SetActive(true);
        }

        if(canTakeDamage == false)
        {
            canTakeDamageTime += Time.deltaTime;
            if(canTakeDamageTime >= canTakeDamgeMaxTime)
            {
                canTakeDamage = true;
                canTakeDamageTime = 0;
            }
        }

        if(HP <= 0)
        {
            isDead = true;
        }
    }

    void FixedUpdate()
    {
        if (isDead == false)
        {
            Movement();
        }
    }

    void Movement()
    {
        float xMove = Input.GetAxisRaw("Horizontal") * moveSpeed * Time.fixedDeltaTime;
        Vector2 move = new Vector2(xMove, rb2D.velocity.y);
        rb2D.velocity = move;

        if(xMove > 0)
        {
            transform.localScale = new Vector2(1, 1);
        }
        if(xMove < 0)
        {
            transform.localScale = new Vector2(-1, 1);
        }
        if (isGrounded == true) {
            if (xMove != 0)
            {
                anim.SetInteger("state", 1);
            }
            else
            {
                anim.SetInteger("state", 0);
            }
        }
    }

    void Attacking()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject _bomb = Instantiate(bomb, hand.position, transform.rotation);
            if (transform.localScale.x > 0)
            {
                _bomb.GetComponent<Rigidbody2D>().velocity = transform.right * throwForce;
            }
            else
            {
                _bomb.GetComponent<Rigidbody2D>().velocity = -transform.right * throwForce;
            }
            Destroy(_bomb, 5);
        }
    }

    void takeDamage()
    {
        if(canTakeDamage == true)
        {
            HP--;
            canTakeDamage = false;
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(groundPos.position, Radius);
    }

    void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.CompareTag("enemy"))
        {
            takeDamage();
        }
        if (obj.CompareTag("Finish"))
        {
            Application.LoadLevel(Application.loadedLevel + 1);
        }

    }
}
