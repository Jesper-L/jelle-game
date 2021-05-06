using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{

    [SerializeField]
    private float moveSpeed;

    private bool isGrounded;
    [SerializeField]
    private Transform groundPos;
    [SerializeField]
    private float Radius;
    [SerializeField]
    private LayerMask groundMask;

    private float rotationY = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);

        isGrounded = Physics2D.OverlapCircle(groundPos.position, Radius, groundMask);
        if(isGrounded == false)
        {
            rotationY += 180;
            transform.rotation = Quaternion.Euler(0, rotationY, 0);
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(groundPos.position, Radius);
    }
}
