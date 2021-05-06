using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followTarget : MonoBehaviour
{

    [SerializeField]
    Transform target;

    [SerializeField]
    Vector3 offset;

    [SerializeField]
    float smoothSpeed;

    Vector3 normalPos;
    Vector3 smoothPos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (FindObjectOfType<playerController>().isDead == false)
        {
            normalPos = target.position + offset;
            smoothPos = Vector3.Lerp(transform.position, normalPos, smoothSpeed);
            transform.position = smoothPos;
        }
    }
}
